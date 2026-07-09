using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.HR;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.HR
{
    public partial class FrmPayroll : Form
    {
        private List<Payroll> _payrolls = new List<Payroll>();

        public FrmPayroll()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(440, 8);
            spinner.Size = new Size(50, 50);
            pnlTop.Controls.Add(spinner);

            dgvPayroll.CellFormatting += DgvPayroll_CellFormatting;
        }

        private void DgvPayroll_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPayroll.Columns["colApprove"] != null && e.ColumnIndex == dgvPayroll.Columns["colApprove"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(40, 160, 100);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 130, 80);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (dgvPayroll.Columns["colPost"] != null && e.ColumnIndex == dgvPayroll.Columns["colPost"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(20, 80, 160);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (dgvPayroll.Columns["colDetails"] != null && e.ColumnIndex == dgvPayroll.Columns["colDetails"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(120, 80, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(100, 60, 160);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (dgvPayroll.Columns["colDelete"] != null && e.ColumnIndex == dgvPayroll.Columns["colDelete"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(170, 30, 30);
                e.CellStyle.SelectionForeColor = Color.White;
            }

            // Status color
            if (dgvPayroll.Columns["colStatus"] != null && e.ColumnIndex == dgvPayroll.Columns["colStatus"].Index && e.RowIndex >= 0)
            {
                string val = e.Value?.ToString() ?? "";
                if (val.Contains("Draft")) { e.CellStyle.ForeColor = Color.FromArgb(150, 100, 0); e.CellStyle.BackColor = Color.FromArgb(255, 243, 200); }
                else if (val.Contains("Approved")) { e.CellStyle.ForeColor = Color.FromArgb(40, 130, 60); e.CellStyle.BackColor = Color.FromArgb(220, 245, 225); }
                else if (val.Contains("Posted")) { e.CellStyle.ForeColor = Color.FromArgb(30, 80, 160); e.CellStyle.BackColor = Color.FromArgb(215, 230, 255); }
                else if (val.Contains("Paid")) { e.CellStyle.ForeColor = Color.FromArgb(100, 60, 160); e.CellStyle.BackColor = Color.FromArgb(235, 225, 255); }
            }
        }

        private async void FrmPayroll_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvPayroll.Columns["colApprove"].Visible = SessionManager.IsAdmin;
            dgvPayroll.Columns["colPost"].Visible = SessionManager.IsAdmin;
            dgvPayroll.Columns["colDelete"].Visible = SessionManager.IsAdmin;

            int year = DateTime.Now.Year;
            for (int y = year; y >= year - 5; y--)
                cmbFilterYear.Items.Add(y.ToString());
            cmbFilterYear.Items.Insert(0, "All Years");
            cmbFilterYear.SelectedIndex = 0;

            await LoadPayrolls();
        }

        private async System.Threading.Tasks.Task LoadPayrolls()
        {
            try
            {
                spinner.Start();
                _payrolls = await ApiHelper.GetAsync<List<Payroll>>("payrolls") ?? new List<Payroll>();
                BindGrid(_payrolls);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading payrolls: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<Payroll> list)
        {
            dgvPayroll.Rows.Clear();
            foreach (var p in list)
            {
                string monthName = new System.Globalization.DateTimeFormatInfo().GetMonthName(p.PayrollMonth);
                dgvPayroll.Rows.Add(
                    p.PayrollID,
                    p.PayrollNumber,
                    monthName + " " + p.PayrollYear,
                    p.PayrollDate.ToString("yyyy-MM-dd"),
                    p.TotalEmployees,
                    p.TotalBasicSalary.ToString("N2"),
                    p.TotalAdditions.ToString("N2"),
                    p.TotalDeductions.ToString("N2"),
                    p.TotalNetSalary.ToString("N2"),
                    p.Status,
                    "📋 Details",
                    "✔ Approve",
                    "📌 Post",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvPayroll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvPayroll.Rows[e.RowIndex].Cells["colID"].Value);
            var payroll = _payrolls.Find(x => x.PayrollID == id);
            if (payroll == null) return;

            if (e.ColumnIndex == dgvPayroll.Columns["colDetails"].Index)
                OpenDetails(payroll);
            else if (e.ColumnIndex == dgvPayroll.Columns["colApprove"].Index && SessionManager.IsAdmin)
                ApprovePayroll(payroll);
            else if (e.ColumnIndex == dgvPayroll.Columns["colPost"].Index && SessionManager.IsAdmin)
                PostPayroll(payroll);
            else if (e.ColumnIndex == dgvPayroll.Columns["colDelete"].Index && SessionManager.IsAdmin)
                DeletePayroll(payroll);
        }

        private void OpenDetails(Payroll payroll)
        {
            var frm = new FrmPayrollDetails(payroll.PayrollID,
                new System.Globalization.DateTimeFormatInfo().GetMonthName(payroll.PayrollMonth) + " " + payroll.PayrollYear);
            frm.ShowDialog(this);
        }

        private async void ApprovePayroll(Payroll payroll)
        {
            if (payroll.Status != "Draft")
            { MessageHelper.ShowWarning("Only Draft payrolls can be approved."); return; }
            if (!MessageHelper.ShowConfirm($"Approve payroll \"{payroll.PayrollNumber}\"?")) return;
            try
            {
                spinner.Start();
                var dto = new ApprovePayrollDTO { PayrollID = payroll.PayrollID, ApprovedBy = SessionManager.UserId };
                await ApiHelper.PostAsync<object>("payrolls/" + payroll.PayrollID + "/approve", dto);
                MessageHelper.ShowSuccess("Payroll approved successfully.");
                await LoadPayrolls();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private async void PostPayroll(Payroll payroll)
        {
            if (payroll.Status != "Approved")
            { MessageHelper.ShowWarning("Only Approved payrolls can be posted."); return; }
            if (!MessageHelper.ShowConfirm($"Post payroll \"{payroll.PayrollNumber}\"?")) return;
            try
            {
                spinner.Start();
                var dto = new PostPayrollDTO { PayrollID = payroll.PayrollID, PostedBy = SessionManager.UserId };
                await ApiHelper.PostAsync<object>("payrolls/" + payroll.PayrollID + "/post", dto);
                MessageHelper.ShowSuccess("Payroll posted successfully.");
                await LoadPayrolls();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private async void DeletePayroll(Payroll payroll)
        {
            if (payroll.Status != "Draft")
            { MessageHelper.ShowWarning("Only Draft payrolls can be deleted."); return; }
            if (!MessageHelper.ShowConfirm($"Delete payroll \"{payroll.PayrollNumber}\"?\nThis action cannot be undone.")) return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("payrolls/" + payroll.PayrollID);
                MessageHelper.ShowSuccess("Payroll deleted successfully.");
                await LoadPayrolls();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void OpenCreateDialog()
        {
            var dlg = new Form
            {
                Text = "➕ Create Payroll",
                Size = new Size(380, 280),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHead = new Panel { Location = new Point(0, 0), Size = new Size(380, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHead.Controls.Add(new Label { Text = "➕ Create New Payroll", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(350, 28) });
            dlg.Controls.Add(pnlHead);

            int y = 70; int fx = 20; int fw = 330;

            dlg.Controls.Add(new Label { Text = "Payroll Month *", Location = new Point(fx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 25;
            var cmbMonth = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            var dtfi = new System.Globalization.DateTimeFormatInfo();
            for (int m = 1; m <= 12; m++)
                cmbMonth.Items.Add(new ComboItem(m, dtfi.GetMonthName(m)));
            cmbMonth.DisplayMember = "Display"; cmbMonth.ValueMember = "Id";
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            dlg.Controls.Add(cmbMonth); y += 45;

            dlg.Controls.Add(new Label { Text = "Payroll Year *", Location = new Point(fx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 25;
            var cmbYear = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            for (int yr = DateTime.Now.Year; yr >= DateTime.Now.Year - 3; yr--)
                cmbYear.Items.Add(yr);
            cmbYear.SelectedIndex = 0;
            dlg.Controls.Add(cmbYear); y += 50;

            var btnSave = new Button { Text = "💾 Create", Location = new Point(fx, y), Size = new Size(155, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 170, y), Size = new Size(155, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Creating...";
                    var dto = new CreatePayrollDTO
                    {
                        PayrollMonth = (cmbMonth.SelectedItem as ComboItem).Id,
                        PayrollYear = (int)cmbYear.SelectedItem,
                        CreatedBy = SessionManager.UserId
                    };
                    if (await ApiHelper.PostAsync<Payroll>("payrolls", dto) != null)
                    { MessageHelper.ShowSuccess("Payroll created successfully!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Create"; }
            };

            dlg.Height = y + 110;
            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadPayrolls();
        }

        private void ApplyFilters()
        {
            string status = cmbFilterStatus.SelectedItem?.ToString() ?? "All";
            string year = cmbFilterYear.SelectedItem?.ToString() ?? "All Years";

            var filtered = new List<Payroll>();
            foreach (var p in _payrolls)
            {
                bool matchStatus = status == "All" || p.Status == status;
                bool matchYear = year == "All Years" || p.PayrollYear.ToString() == year;
                if (matchStatus && matchYear)
                    filtered.Add(p);
            }
            BindGrid(filtered);
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();
        private void cmbFilterYear_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();
        private void btnNew_Click(object sender, EventArgs e) => OpenCreateDialog();
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterYear.SelectedIndex = 0;
            await LoadPayrolls();
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