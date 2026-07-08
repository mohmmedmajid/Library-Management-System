using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.HR;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Reports
{
    public partial class FrmHRReports : Form
    {
        private List<Employee> _employees = new List<Employee>();
        private List<Payroll> _payrolls = new List<Payroll>();
        private List<EmployeeAdvance> _advances = new List<EmployeeAdvance>();
        private List<Bonus> _bonuses = new List<Bonus>();

        public FrmHRReports()
        {
            InitializeComponent();
            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(40, 40);
            pnlTop.Controls.Add(spinner);
        }

        private async void FrmHRReports_Load(object sender, EventArgs e)
        {
            SetupColumnsForEmployees();
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[] { "All", "Active", "Inactive", "Terminated" });
            cmbStatus.SelectedIndex = 0;
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
            await LoadDepartmentsAsync();

            cmbReportType.SelectedIndexChanged -= CmbReportType_SelectedIndexChanged;
            cmbReportType.SelectedIndex = 0;
            cmbReportType.SelectedIndexChanged += CmbReportType_SelectedIndexChanged;

            await LoadReportAsync();
        }

        private async Task LoadDepartmentsAsync()
        {
            try
            {
                var departments = await ApiHelper.GetAsync<List<Department>>("Departments?isActive=true");
                cmbDepartment.Items.Clear();
                cmbDepartment.Items.Add("All Departments");
                foreach (var d in departments)
                    cmbDepartment.Items.Add(d.DepartmentName);
                cmbDepartment.SelectedIndex = 0;
            }
            catch { }
        }

        private async Task LoadReportAsync()
        {
            try
            {
                spinner.Start();
                lblStatus.Text = "Loading...";

                string reportType = cmbReportType.SelectedItem?.ToString() ?? "Employees";

                switch (reportType)
                {
                    case "Employees":
                        await LoadEmployeesAsync();
                        break;
                    case "Payroll":
                        await LoadPayrollAsync();
                        break;
                    case "Advances":
                        await LoadAdvancesAsync();
                        break;
                    case "Bonuses":
                        await LoadBonusesAsync();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Failed to load report: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                lblStatus.Text = "";
            }
        }

        private async Task LoadEmployeesAsync()
        {
            string url = "Employees?isActive=true";
            if (cmbStatus.SelectedItem?.ToString() == "Active") url = "Employees?isActive=true&status=Active";
            else if (cmbStatus.SelectedItem?.ToString() == "Inactive") url = "Employees?isActive=false";
            else if (cmbStatus.SelectedItem?.ToString() != "All") url = $"Employees?status={cmbStatus.SelectedItem}";

            _employees = await ApiHelper.GetAsync<List<Employee>>(url);

            var filtered = FilterEmployees(_employees);
            BindEmployeeGrid(filtered);
            UpdateEmployeeSummary(filtered);
        }

        private async Task LoadPayrollAsync()
        {
            string url = $"Payrolls?payrollYear={dtpFrom.Value.Year}";
            if (cmbStatus.SelectedItem?.ToString() != "All")
                url += $"&status={cmbStatus.SelectedItem}";
            _payrolls = await ApiHelper.GetAsync<List<Payroll>>(url);

            var filtered = _payrolls;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var q = txtSearch.Text.ToLower();
                filtered = filtered.Where(p =>
                    p.PayrollNumber.ToLower().Contains(q) ||
                    p.Status.ToLower().Contains(q)
                ).ToList();
            }
            BindPayrollGrid(filtered);
            UpdatePayrollSummary(filtered);
        }

        private async Task LoadAdvancesAsync()
        {
            string url = $"EmployeeAdvances?startDate={dtpFrom.Value:yyyy-MM-dd}&endDate={dtpTo.Value:yyyy-MM-dd}";
            if (cmbStatus.SelectedItem?.ToString() != "All")
                url += $"&status={cmbStatus.SelectedItem}";
            _advances = await ApiHelper.GetAsync<List<EmployeeAdvance>>(url);

            var filtered = _advances;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var q = txtSearch.Text.ToLower();
                filtered = filtered.Where(a =>
                    a.EmployeeName.ToLower().Contains(q) ||
                    a.AdvanceNumber.ToLower().Contains(q)
                ).ToList();
            }
            BindAdvanceGrid(filtered);
            UpdateAdvanceSummary(filtered);
        }

        private async Task LoadBonusesAsync()
        {
            string url = $"Bonuses?startDate={dtpFrom.Value:yyyy-MM-dd}&endDate={dtpTo.Value:yyyy-MM-dd}";
            _bonuses = await ApiHelper.GetAsync<List<Bonus>>(url);

            var filtered = _bonuses;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var q = txtSearch.Text.ToLower();
                filtered = filtered.Where(b =>
                    b.EmployeeName.ToLower().Contains(q) ||
                    b.BonusNumber.ToLower().Contains(q) ||
                    b.BonusType.ToLower().Contains(q)
                ).ToList();
            }
            BindBonusGrid(filtered);
            UpdateBonusSummary(filtered);
        }

        private List<Employee> FilterEmployees(List<Employee> data)
        {
            var filtered = data;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var q = txtSearch.Text.ToLower();
                filtered = filtered.Where(e =>
                    e.FullName.ToLower().Contains(q) ||
                    e.EmployeeCode.ToLower().Contains(q) ||
                    e.Phone.ToLower().Contains(q)
                ).ToList();
            }
            if (cmbDepartment.SelectedIndex > 0)
            {
                string dept = cmbDepartment.SelectedItem.ToString();
                filtered = filtered.Where(e => e.DepartmentName == dept).ToList();
            }
            return filtered;
        }

        private void BindEmployeeGrid(List<Employee> data)
        {
            dgvReport.Rows.Clear();
            foreach (var e in data)
            {
                dgvReport.Rows.Add(
                    e.EmployeeID,
                    e.EmployeeCode,
                    e.FullName,
                    e.DepartmentName,
                    e.JobTitle,
                    e.Phone,
                    e.BasicSalary.ToString("N2"),
                    e.HireDate.HasValue ? e.HireDate.Value.ToString("yyyy-MM-dd") : "",
                    e.YearsOfService,
                    e.IsActive ? "Active" : "Inactive",
                    ""
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void BindPayrollGrid(List<Payroll> data)
        {
            dgvReport.Rows.Clear();
            foreach (var p in data)
            {
                dgvReport.Rows.Add(
                    p.PayrollID,
                    p.PayrollNumber,
                    $"{p.PayrollMonth}/{p.PayrollYear}",
                    p.TotalEmployees,
                    p.TotalBasicSalary.ToString("N2"),
                    p.TotalAdditions.ToString("N2"),
                    p.TotalDeductions.ToString("N2"),
                    p.TotalNetSalary.ToString("N2"),
                    p.Status,
                    p.CreatedDate.ToString("yyyy-MM-dd"),
                    p.CreatedByName
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void BindAdvanceGrid(List<EmployeeAdvance> data)
        {
            dgvReport.Rows.Clear();
            foreach (var a in data)
            {
                dgvReport.Rows.Add(
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
                    a.ApprovedByName
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void BindBonusGrid(List<Bonus> data)
        {
            dgvReport.Rows.Clear();
            foreach (var b in data)
            {
                dgvReport.Rows.Add(
                    b.BonusID,
                    b.BonusNumber,
                    b.EmployeeName,
                    b.BonusDate.ToString("yyyy-MM-dd"),
                    b.BonusType,
                    b.Amount.ToString("N2"),
                    b.Reason,
                    b.IsPaid ? "Paid" : "Pending",
                    b.ApprovedByName,
                    "", ""
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void UpdateEmployeeSummary(List<Employee> data)
        {
            int activeCount = data.Count(e => e.IsActive);
            int inactiveCount = data.Count(e => !e.IsActive);
            decimal totalSalary = data.Sum(e => e.BasicSalary);
            int deptCount = data.Select(e => e.DepartmentName).Distinct().Count();

            lblStat1.Text = data.Count.ToString();
            lblStat2.Text = activeCount.ToString();
            lblStat3.Text = inactiveCount.ToString();
            lblStat4.Text = totalSalary.ToString("N2");
            lblStat5.Text = deptCount.ToString();
            lblStat6.Text = data.Count > 0 ? (totalSalary / data.Count).ToString("N2") : "0.00";

            lblStat1Lbl.Text = "Total Employees";
            lblStat2Lbl.Text = "Active";
            lblStat3Lbl.Text = "Inactive";
            lblStat4Lbl.Text = "Total Salaries";
            lblStat5Lbl.Text = "Departments";
            lblStat6Lbl.Text = "Avg Salary";
        }

        private void UpdatePayrollSummary(List<Payroll> data)
        {
            decimal totalNet = data.Sum(p => p.TotalNetSalary);
            decimal totalAdditions = data.Sum(p => p.TotalAdditions);
            decimal totalDeductions = data.Sum(p => p.TotalDeductions);
            int paidCount = data.Count(p => p.Status == "Paid");

            lblStat1.Text = data.Count.ToString();
            lblStat2.Text = totalNet.ToString("N2");
            lblStat3.Text = totalAdditions.ToString("N2");
            lblStat4.Text = totalDeductions.ToString("N2");
            lblStat5.Text = paidCount.ToString();
            lblStat6.Text = (data.Count - paidCount).ToString();

            lblStat1Lbl.Text = "Total Payrolls";
            lblStat2Lbl.Text = "Total Net";
            lblStat3Lbl.Text = "Total Additions";
            lblStat4Lbl.Text = "Total Deductions";
            lblStat5Lbl.Text = "Paid";
            lblStat6Lbl.Text = "Pending";
        }

        private void UpdateAdvanceSummary(List<EmployeeAdvance> data)
        {
            decimal totalAmount = data.Sum(a => a.Amount);
            decimal totalPaid = data.Sum(a => a.PaidAmount);
            decimal totalRemaining = data.Sum(a => a.RemainingAmount);
            int activeCount = data.Count(a => a.Status == "Active");

            lblStat1.Text = data.Count.ToString();
            lblStat2.Text = totalAmount.ToString("N2");
            lblStat3.Text = totalPaid.ToString("N2");
            lblStat4.Text = totalRemaining.ToString("N2");
            lblStat5.Text = activeCount.ToString();
            lblStat6.Text = (data.Count - activeCount).ToString();

            lblStat1Lbl.Text = "Total Advances";
            lblStat2Lbl.Text = "Total Amount";
            lblStat3Lbl.Text = "Total Paid";
            lblStat4Lbl.Text = "Remaining";
            lblStat5Lbl.Text = "Active";
            lblStat6Lbl.Text = "Completed";
        }

        private void UpdateBonusSummary(List<Bonus> data)
        {
            decimal totalAmount = data.Sum(b => b.Amount);
            int paidCount = data.Count(b => b.IsPaid);
            decimal paidAmount = data.Where(b => b.IsPaid).Sum(b => b.Amount);
            decimal pendingAmount = data.Where(b => !b.IsPaid).Sum(b => b.Amount);

            lblStat1.Text = data.Count.ToString();
            lblStat2.Text = totalAmount.ToString("N2");
            lblStat3.Text = paidCount.ToString();
            lblStat4.Text = paidAmount.ToString("N2");
            lblStat5.Text = (data.Count - paidCount).ToString();
            lblStat6.Text = pendingAmount.ToString("N2");

            lblStat1Lbl.Text = "Total Bonuses";
            lblStat2Lbl.Text = "Total Amount";
            lblStat3Lbl.Text = "Paid Count";
            lblStat4Lbl.Text = "Paid Amount";
            lblStat5Lbl.Text = "Pending Count";
            lblStat6Lbl.Text = "Pending Amount";
        }

        private void SetupColumnsForEmployees()
        {
            dgvReport.Columns.Clear();
            dgvReport.Columns.AddRange(new DataGridViewColumn[]
            {
                CreateCol("colID", "ID", false, 0f),
                CreateCol("colCode", "Code", true, 8f),
                CreateCol("colName", "Full Name", true, 16f),
                CreateCol("colDept", "Department", true, 14f),
                CreateCol("colJob", "Job Title", true, 13f),
                CreateCol("colPhone", "Phone", true, 10f),
                CreateCol("colSalary", "Basic Salary", true, 10f),
                CreateCol("colHire", "Hire Date", true, 10f),
                CreateCol("colYears", "Years", true, 6f),
                CreateCol("colStatus", "Status", true, 7f),
                CreateCol("col10", "", false, 0f)
            });
        }

        private void SetupColumnsForPayroll()
        {
            dgvReport.Columns.Clear();
            dgvReport.Columns.AddRange(new DataGridViewColumn[]
            {
                CreateCol("colID", "ID", false, 0f),
                CreateCol("colNumber", "Payroll No", true, 12f),
                CreateCol("colPeriod", "Period", true, 9f),
                CreateCol("colEmployees", "Employees", true, 9f),
                CreateCol("colBasic", "Basic Salary", true, 11f),
                CreateCol("colAdditions", "Additions", true, 10f),
                CreateCol("colDeductions", "Deductions", true, 10f),
                CreateCol("colNet", "Net Salary", true, 10f),
                CreateCol("colStatus", "Status", true, 8f),
                CreateCol("colDate", "Date", true, 10f),
                CreateCol("colCreatedBy", "Created By", true, 11f)
            });
        }

        private void SetupColumnsForAdvances()
        {
            dgvReport.Columns.Clear();
            dgvReport.Columns.AddRange(new DataGridViewColumn[]
            {
                CreateCol("colID", "ID", false, 0f),
                CreateCol("colNumber", "Advance No", true, 11f),
                CreateCol("colEmployee", "Employee", true, 15f),
                CreateCol("colDate", "Date", true, 9f),
                CreateCol("colAmount", "Amount", true, 9f),
                CreateCol("colInstallments", "Installments", true, 9f),
                CreateCol("colMonthly", "Monthly", true, 9f),
                CreateCol("colPaid", "Paid", true, 9f),
                CreateCol("colRemaining", "Remaining", true, 9f),
                CreateCol("colStatus", "Status", true, 8f),
                CreateCol("colApproved", "Approved By", true, 12f)
            });
        }

        private void SetupColumnsForBonuses()
        {
            dgvReport.Columns.Clear();
            dgvReport.Columns.AddRange(new DataGridViewColumn[]
            {
                CreateCol("colID", "ID", false, 0f),
                CreateCol("colNumber", "Bonus No", true, 11f),
                CreateCol("colEmployee", "Employee", true, 15f),
                CreateCol("colDate", "Date", true, 9f),
                CreateCol("colType", "Type", true, 10f),
                CreateCol("colAmount", "Amount", true, 9f),
                CreateCol("colReason", "Reason", true, 16f),
                CreateCol("colStatus", "Status", true, 8f),
                CreateCol("colApproved", "Approved By", true, 12f),
                CreateCol("col9", "", false, 0f),
                CreateCol("col10", "", false, 0f)
            });
        }

        private DataGridViewTextBoxColumn CreateCol(string name, string header, bool visible, float fill)
        {
            var col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.HeaderText = header;
            col.Visible = visible;
            if (fill > 0) col.FillWeight = fill;
            return col;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private async void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem?.ToString() ?? "Employees";

            cmbStatus.Items.Clear();
            switch (reportType)
            {
                case "Employees":
                    cmbStatus.Items.AddRange(new object[] { "All", "Active", "Inactive", "Terminated" });
                    SetupColumnsForEmployees();
                    lblDeptLbl.Visible = true;
                    cmbDepartment.Visible = true;
                    break;
                case "Payroll":
                    cmbStatus.Items.AddRange(new object[] { "All", "Draft", "Approved", "Posted", "Paid" });
                    SetupColumnsForPayroll();
                    lblDeptLbl.Visible = false;
                    cmbDepartment.Visible = false;
                    break;
                case "Advances":
                    cmbStatus.Items.AddRange(new object[] { "All", "Active", "Completed", "Cancelled" });
                    SetupColumnsForAdvances();
                    lblDeptLbl.Visible = false;
                    cmbDepartment.Visible = false;
                    break;
                case "Bonuses":
                    cmbStatus.Items.AddRange(new object[] { "All", "Paid", "Pending" });
                    SetupColumnsForBonuses();
                    lblDeptLbl.Visible = false;
                    cmbDepartment.Visible = false;
                    break;
            }
            cmbStatus.SelectedIndex = 0;
            await LoadReportAsync();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = new System.Text.StringBuilder();
                var headers = new List<string>();
                foreach (DataGridViewColumn col in dgvReport.Columns)
                    if (col.Visible) headers.Add(col.HeaderText);
                sb.AppendLine(string.Join(",", headers));

                for (int i = 0; i < dgvReport.Rows.Count; i++)
                {
                    var row = dgvReport.Rows[i];
                    var vals = new List<string>();
                    foreach (DataGridViewColumn col in dgvReport.Columns)
                        if (col.Visible) vals.Add(row.Cells[col.Name].Value?.ToString() ?? "");
                    sb.AppendLine(string.Join(",", vals));
                }

                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "CSV files (*.csv)|*.csv";
                    dlg.FileName = $"HRReport_{DateTime.Now:yyyyMMdd}";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(dlg.FileName, sb.ToString(), System.Text.Encoding.UTF8);
                        MessageHelper.ShowSuccess("Exported successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Export failed: " + ex.Message);
            }
        }

        private async void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private void DgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            var statusCol = dgvReport.Columns["colStatus"];
            if (statusCol != null && e.ColumnIndex == statusCol.Index)
            {
                string val = e.Value.ToString();
                switch (val)
                {
                    case "Active":
                    case "Paid":
                    case "Approved":
                    case "Posted":
                        e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                        e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                        break;
                    case "Inactive":
                    case "Terminated":
                    case "Cancelled":
                        e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                        e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                        break;
                    case "Draft":
                    case "Pending":
                    case "Completed":
                        e.CellStyle.ForeColor = Color.FromArgb(180, 120, 0);
                        e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                        break;
                }
            }
        }
    }
}