using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.HR;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.HR
{
    public partial class FrmEmployeeAdvances : Form
    {
        private List<EmployeeAdvance> _advances = new List<EmployeeAdvance>();
        private List<Employee> _employees = new List<Employee>();

        public FrmEmployeeAdvances()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(440, 8);
            spinner.Size = new Size(50, 50);
            pnlTop.Controls.Add(spinner);

            searchBox = new SearchBoxControl();
            searchBox.Location = new Point(510, 15);
            searchBox.Size = new Size(250, 35);
            searchBox.OnSearch += SearchBox_OnSearch;
            pnlTop.Controls.Add(searchBox);

            dgvAdvances.CellFormatting += DgvAdvances_CellFormatting;
        }

        private void DgvAdvances_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvAdvances.Columns["colEdit"] != null && e.ColumnIndex == dgvAdvances.Columns["colEdit"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (dgvAdvances.Columns["colDelete"] != null && e.ColumnIndex == dgvAdvances.Columns["colDelete"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.SelectionForeColor = Color.White;
            }

            if (dgvAdvances.Columns["colStatus"] != null && e.ColumnIndex == dgvAdvances.Columns["colStatus"].Index && e.RowIndex >= 0)
            {
                string val = e.Value?.ToString() ?? "";
                if (val == "Active") { e.CellStyle.ForeColor = Color.FromArgb(40, 130, 60); e.CellStyle.BackColor = Color.FromArgb(220, 245, 225); }
                else if (val == "Completed") { e.CellStyle.ForeColor = Color.FromArgb(30, 80, 160); e.CellStyle.BackColor = Color.FromArgb(215, 230, 255); }
                else if (val == "Cancelled") { e.CellStyle.ForeColor = Color.FromArgb(160, 50, 50); e.CellStyle.BackColor = Color.FromArgb(245, 220, 220); }
            }

            if (dgvAdvances.Columns["colRemaining"] != null && e.ColumnIndex == dgvAdvances.Columns["colRemaining"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvAdvances.Rows[e.RowIndex].Cells["colID"].Value);
                var adv = _advances.Find(x => x.AdvanceID == id);
                if (adv != null && adv.RemainingAmount > 0)
                    e.CellStyle.ForeColor = Color.FromArgb(200, 80, 50);
            }
        }

        private async void FrmEmployeeAdvances_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvAdvances.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvAdvances.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadEmployees();
            await LoadAdvances();
        }

        private async System.Threading.Tasks.Task LoadEmployees()
        {
            try
            {
                _employees = await ApiHelper.GetAsync<List<Employee>>("employees") ?? new List<Employee>();
                cmbFilterEmployee.Items.Clear();
                cmbFilterEmployee.Items.Add(new ComboItem(0, "All Employees"));
                foreach (var emp in _employees)
                    cmbFilterEmployee.Items.Add(new ComboItem(emp.EmployeeID, emp.FullName));
                cmbFilterEmployee.SelectedIndex = 0;
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadAdvances()
        {
            try
            {
                spinner.Start();
                _advances = await ApiHelper.GetAsync<List<EmployeeAdvance>>("employeeadvances")
                            ?? new List<EmployeeAdvance>();
                BindGrid(_advances);
                UpdateSummary(_advances);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading advances: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<EmployeeAdvance> list)
        {
            dgvAdvances.Rows.Clear();
            foreach (var a in list)
            {
                dgvAdvances.Rows.Add(
                    a.AdvanceID,
                    a.AdvanceNumber,
                    a.EmployeeName,
                    a.AdvanceDate.ToString("yyyy-MM-dd"),
                    a.Amount.ToString("N2"),
                    a.InstallmentMonths,
                    a.MonthlyDeduction.ToString("N2"),
                    a.PaidAmount.ToString("N2"),
                    a.RemainingAmount.ToString("N2"),
                    a.Status,
                    a.ApprovedByName,
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void UpdateSummary(List<EmployeeAdvance> list)
        {
            decimal totalAmount = 0, totalPaid = 0, totalRemaining = 0;
            foreach (var a in list)
            {
                totalAmount += a.Amount;
                totalPaid += a.PaidAmount;
                totalRemaining += a.RemainingAmount;
            }
            lblTotalAmount.Text = "Total: " + totalAmount.ToString("N2");
            lblTotalPaid.Text = "Paid: " + totalPaid.ToString("N2");
            lblTotalRemaining.Text = "Remaining: " + totalRemaining.ToString("N2");
        }

        private void dgvAdvances_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvAdvances.Rows[e.RowIndex].Cells["colID"].Value);
            var adv = _advances.Find(x => x.AdvanceID == id);
            if (adv == null) return;

            if (e.ColumnIndex == dgvAdvances.Columns["colEdit"].Index)
                OpenEditDialog(adv);
            else if (e.ColumnIndex == dgvAdvances.Columns["colDelete"].Index)
                DeleteAdvance(adv);
        }

        private void OpenEditDialog(EmployeeAdvance adv = null)
        {
            bool isNew = adv == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Advance" : "✏️ Edit Advance",
                Size = new Size(480, 580),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHead = new Panel { Location = new Point(0, 0), Size = new Size(480, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHead.Controls.Add(new Label { Text = isNew ? "➕ Add Employee Advance" : "✏️ Edit Employee Advance", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(450, 28) });
            dlg.Controls.Add(pnlHead);

            int y = 70; int lx = 20; int fx = 20; int fw = 430;

            Action<string> addLabel = (txt) =>
            {
                dlg.Controls.Add(new Label { Text = txt, Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                y += 25;
            };

            // Employee
            addLabel("Employee *");
            var cmbEmp = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbEmp.Items.Add(new ComboItem(0, "-- Select Employee --"));
            foreach (var emp in _employees)
                cmbEmp.Items.Add(new ComboItem(emp.EmployeeID, emp.FullName + " (" + emp.EmployeeCode + ")"));
            cmbEmp.DisplayMember = "Display"; cmbEmp.ValueMember = "Id";
            cmbEmp.SelectedIndex = 0;
            if (!isNew)
                foreach (ComboItem ci in cmbEmp.Items)
                    if (ci.Id == adv.EmployeeID) { cmbEmp.SelectedItem = ci; break; }
            dlg.Controls.Add(cmbEmp); y += 45;

            // Date
            addLabel("Advance Date *");
            var dtpDate = new DateTimePicker { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), Format = DateTimePickerFormat.Short };
            dtpDate.Value = isNew ? DateTime.Now : adv.AdvanceDate;
            dlg.Controls.Add(dtpDate); y += 45;

            // Amount
            addLabel("Amount *");
            var txtAmount = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : adv.Amount.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtAmount); y += 45;

            // Installment Months
            addLabel("Installment Months *");
            var txtMonths = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "1" : adv.InstallmentMonths.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtMonths); y += 45;

            // Reason
            addLabel("Reason");
            var txtReason = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 50), Text = isNew ? "" : adv.Reason, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtReason); y += 65;

            // Notes
            addLabel("Notes");
            var txtNotes = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 50), Text = isNew ? "" : adv.Notes, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtNotes); y += 65;

            // Buttons
            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(205, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 220, y), Size = new Size(205, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if ((cmbEmp.SelectedItem as ComboItem)?.Id == 0) { MessageHelper.ShowWarning("Please select an employee."); return; }
                if (string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out _)) { MessageHelper.ShowWarning("Please enter a valid amount."); return; }
                if (string.IsNullOrWhiteSpace(txtMonths.Text) || !int.TryParse(txtMonths.Text, out _)) { MessageHelper.ShowWarning("Please enter valid installment months."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    int empId = (cmbEmp.SelectedItem as ComboItem).Id;

                    if (isNew)
                    {
                        var dto = new CreateEmployeeAdvanceDTO
                        {
                            EmployeeID = empId,
                            AdvanceDate = dtpDate.Value,
                            Amount = decimal.Parse(txtAmount.Text),
                            InstallmentMonths = int.Parse(txtMonths.Text),
                            Reason = txtReason.Text.Trim(),
                            Notes = txtNotes.Text.Trim(),
                            ApprovedBy = SessionManager.UserId,
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<EmployeeAdvance>("employeeadvances", dto) != null)
                        { MessageHelper.ShowSuccess("Advance added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateEmployeeAdvanceDTO
                        {
                            AdvanceID = adv.AdvanceID,
                            Amount = decimal.Parse(txtAmount.Text),
                            InstallmentMonths = int.Parse(txtMonths.Text),
                            Reason = txtReason.Text.Trim(),
                            Notes = txtNotes.Text.Trim()
                        };
                        if (await ApiHelper.PutAsync<EmployeeAdvance>("employeeadvances/" + adv.AdvanceID, dto) != null)
                        { MessageHelper.ShowSuccess("Advance updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            dlg.Height = y + 110;
            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadAdvances();
        }

        private async void DeleteAdvance(EmployeeAdvance adv)
        {
            if (adv.Status != "Active") { MessageHelper.ShowWarning("Only Active advances can be deleted."); return; }
            if (!MessageHelper.ShowConfirm($"Delete advance \"{adv.AdvanceNumber}\"?\nThis action cannot be undone.")) return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("employeeadvances/" + adv.AdvanceID);
                MessageHelper.ShowSuccess("Advance deleted successfully.");
                await LoadAdvances();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text) => ApplyFilters();
        private void cmbFilterEmployee_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();
        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();

        private void ApplyFilters()
        {
            string search = searchBox.SearchText.ToLower();
            int empId = (cmbFilterEmployee.SelectedItem as ComboItem)?.Id ?? 0;
            string status = cmbFilterStatus.SelectedItem?.ToString() ?? "All";

            var filtered = new List<EmployeeAdvance>();
            foreach (var a in _advances)
            {
                bool matchSearch = string.IsNullOrEmpty(search) ||
                    a.AdvanceNumber.ToLower().Contains(search) ||
                    a.EmployeeName.ToLower().Contains(search) ||
                    (a.EmployeeCode != null && a.EmployeeCode.ToLower().Contains(search));
                bool matchEmp = empId == 0 || a.EmployeeID == empId;
                bool matchStatus = status == "All" || a.Status == status;

                if (matchSearch && matchEmp && matchStatus)
                    filtered.Add(a);
            }
            BindGrid(filtered);
            UpdateSummary(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            cmbFilterEmployee.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndex = 0;
            await LoadAdvances();
        }

        private class ComboItem
        {
            public int Id { get; }
            public string Display { get; }
            public ComboItem(int id, string display) { Id = id; Display = display; }
            public override string ToString() => Display;
        }
    }
}