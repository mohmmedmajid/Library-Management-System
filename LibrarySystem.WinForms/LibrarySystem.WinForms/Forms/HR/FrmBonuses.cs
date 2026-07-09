using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.HR;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.HR
{
    public partial class FrmBonuses : Form
    {
        private List<Bonus> _bonuses = new List<Bonus>();
        private List<Employee> _employees = new List<Employee>();

        public FrmBonuses()
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

            dgvBonuses.CellFormatting += DgvBonuses_CellFormatting;
            dgvBonuses.CellClick += DgvBonuses_CellClick;
        }

        private void DgvBonuses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvBonuses.Columns["colEdit"] != null && e.ColumnIndex == dgvBonuses.Columns["colEdit"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (dgvBonuses.Columns["colDelete"] != null && e.ColumnIndex == dgvBonuses.Columns["colDelete"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private async void FrmBonuses_Load(object sender, EventArgs e)
        {
            await LoadEmployeesAsync();
            await LoadBonusesAsync();
        }

        private async Task LoadEmployeesAsync()
        {
            try
            {
                _employees = await ApiHelper.GetAsync<List<Employee>>("Employees") ?? new List<Employee>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Failed to load employees: " + ex.Message);
            }
        }

        private async Task LoadBonusesAsync()
        {
            try
            {
                spinner.Start();
                _bonuses = await ApiHelper.GetAsync<List<Bonus>>("Bonuses") ?? new List<Bonus>();
                BindGrid(_bonuses);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Failed to load bonuses: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<Bonus> data)
        {
            dgvBonuses.Rows.Clear();
            foreach (var b in data)
            {
                dgvBonuses.Rows.Add(
                    b.BonusID,
                    b.BonusNumber,
                    b.EmployeeCode,
                    b.EmployeeName,
                    b.BonusDate.ToString("yyyy-MM-dd"),
                    b.BonusType,
                    b.Amount.ToString("N2"),
                    b.Reason,
                    b.IsPaid ? "✓ Paid" : "✗ Unpaid",
                    b.ApprovedByName,
                    b.Notes,
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + data.Count;
        }

        private void DgvBonuses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvBonuses.Rows[e.RowIndex].Cells["colID"].Value);
            var bonus = _bonuses.Find(b => b.BonusID == id);
            if (bonus == null) return;

            if (dgvBonuses.Columns["colEdit"] != null && e.ColumnIndex == dgvBonuses.Columns["colEdit"].Index)
                OpenEditDialog(bonus);
            else if (dgvBonuses.Columns["colDelete"] != null && e.ColumnIndex == dgvBonuses.Columns["colDelete"].Index)
                DeleteBonus(bonus);
        }

        private void OpenEditDialog(Bonus bonus = null)
        {
            bool isNew = bonus == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Bonus" : "✏️ Edit Bonus",
                Size = new Size(460, 560),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHead = new Panel { Location = new Point(0, 0), Size = new Size(460, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHead.Controls.Add(new Label { Text = isNew ? "➕ Add Bonus" : "✏️ Edit Bonus", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(420, 28) });
            dlg.Controls.Add(pnlHead);

            int y = 70; int lx = 20; int fx = 20; int fw = 410;

            dlg.Controls.Add(new Label { Text = "Employee *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbEmployee = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbEmployee.Items.Add(new ComboItem(0, "-- Select --"));
            foreach (var emp in _employees)
                cmbEmployee.Items.Add(new ComboItem(emp.EmployeeID, emp.FullName));
            cmbEmployee.DisplayMember = "Display";
            cmbEmployee.ValueMember = "Id";
            cmbEmployee.SelectedIndex = 0;
            if (!isNew)
                foreach (ComboItem ci in cmbEmployee.Items)
                    if (ci.Id == bonus.EmployeeID) { cmbEmployee.SelectedItem = ci; break; }
            dlg.Controls.Add(cmbEmployee); y += 45;

            dlg.Controls.Add(new Label { Text = "Date *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var dtpDate = new DateTimePicker { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), Format = DateTimePickerFormat.Short };
            dtpDate.Value = isNew ? DateTime.Now : bonus.BonusDate;
            dlg.Controls.Add(dtpDate); y += 45;

            dlg.Controls.Add(new Label { Text = "Bonus Type *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbType = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbType.Items.AddRange(new object[] { "Performance", "Monthly", "Annual", "Special" });
            cmbType.Text = isNew ? "" : bonus.BonusType;
            dlg.Controls.Add(cmbType); y += 45;

            dlg.Controls.Add(new Label { Text = "Amount *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtAmount = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : bonus.Amount.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtAmount); y += 45;

            dlg.Controls.Add(new Label { Text = "Reason *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtReason = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 50), Text = isNew ? "" : bonus.Reason, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtReason); y += 65;

            dlg.Controls.Add(new Label { Text = "Notes", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtNotes = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 50), Text = isNew ? "" : bonus.Notes, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtNotes); y += 65;

            var chkPaid = new CheckBox { Text = "✓ Paid", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = !isNew && bonus.IsPaid, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkPaid); y += 42;

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(195, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 210, y), Size = new Size(195, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                int empId = (cmbEmployee.SelectedItem as ComboItem)?.Id ?? 0;
                if (empId == 0) { MessageHelper.ShowWarning("Please select an employee."); return; }
                if (string.IsNullOrWhiteSpace(cmbType.Text)) { MessageHelper.ShowWarning("Please select a bonus type."); return; }
                if (!ValidationHelper.IsValidPrice(txtAmount.Text)) { MessageHelper.ShowWarning("Invalid amount."); return; }
                if (string.IsNullOrWhiteSpace(txtReason.Text)) { MessageHelper.ShowWarning("Please enter a reason."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";

                    if (isNew)
                    {
                        var dto = new CreateBonusDTO
                        {
                            EmployeeID = empId,
                            BonusDate = dtpDate.Value,
                            BonusType = cmbType.Text,
                            Amount = decimal.Parse(txtAmount.Text),
                            Reason = txtReason.Text.Trim(),
                            ApprovedBy = SessionManager.UserId,
                            Notes = txtNotes.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<Bonus>("Bonuses", dto) != null)
                        { MessageHelper.ShowSuccess("Bonus added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateBonusDTO
                        {
                            BonusID = bonus.BonusID,
                            BonusDate = dtpDate.Value,
                            BonusType = cmbType.Text,
                            Amount = decimal.Parse(txtAmount.Text),
                            Reason = txtReason.Text.Trim(),
                            Notes = txtNotes.Text.Trim(),
                            IsPaid = chkPaid.Checked
                        };
                        if (await ApiHelper.PutAsync<Bonus>("Bonuses/" + bonus.BonusID, dto) != null)
                        { MessageHelper.ShowSuccess("Bonus updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            dlg.Height = y + 110;
            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadBonusesAsync();
        }

        private async void DeleteBonus(Bonus bonus)
        {
            if (!MessageHelper.ShowConfirm($"Delete bonus for \"{bonus.EmployeeName}\"?"))
                return;
            try
            {
                spinner.Start();
                var result = await ApiHelper.DeleteAsync("Bonuses/" + bonus.BonusID);
                if (result) { MessageHelper.ShowSuccess("Deleted successfully"); await LoadBonusesAsync(); }
                else MessageHelper.ShowError("Delete failed");
            }
            catch (Exception ex) { MessageHelper.ShowError("Delete failed: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText)) { BindGrid(_bonuses); return; }
            var filtered = _bonuses.Where(b =>
                (b.EmployeeName != null && b.EmployeeName.ToLower().Contains(searchText.ToLower())) ||
                (b.BonusNumber != null && b.BonusNumber.ToLower().Contains(searchText.ToLower())) ||
                (b.EmployeeCode != null && b.EmployeeCode.ToLower().Contains(searchText.ToLower()))
            ).ToList();
            BindGrid(filtered);
        }

        private void BtnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadBonusesAsync();
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