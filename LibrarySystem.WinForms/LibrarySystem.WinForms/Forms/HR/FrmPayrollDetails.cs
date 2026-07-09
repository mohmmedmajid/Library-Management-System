using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.HR;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.HR
{
    public partial class FrmPayrollDetails : Form
    {
        private int _payrollId;
        private string _payrollPeriod;
        private List<PayrollDetail> _details = new List<PayrollDetail>();

        public FrmPayrollDetails(int payrollId, string payrollPeriod)
        {
            InitializeComponent();
            _payrollId = payrollId;
            _payrollPeriod = payrollPeriod;

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(440, 8);
            spinner.Size = new Size(50, 50);
            pnlTop.Controls.Add(spinner);

            searchBox = new SearchBoxControl();
            searchBox.Location = new Point(510, 15);
            searchBox.Size = new Size(250, 35);
            searchBox.OnSearch += SearchBox_OnSearch;
            pnlTop.Controls.Add(searchBox);
        }

        private async void FrmPayrollDetails_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "📋 Payroll Details - " + _payrollPeriod;
            this.Text = "Payroll Details - " + _payrollPeriod;
            await LoadDetails();
        }

        private async System.Threading.Tasks.Task LoadDetails()
        {
            try
            {
                spinner.Start();
                _details = await ApiHelper.GetAsync<List<PayrollDetail>>("payrolldetails/by-payroll/" + _payrollId)
                     ?? new List<PayrollDetail>();
                BindGrid(_details);
                UpdateTotals(_details);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading payroll details: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<PayrollDetail> list)
        {
            dgvDetails.Rows.Clear();
            foreach (var d in list)
            {
                dgvDetails.Rows.Add(
                    d.PayrollDetailID,
                    d.EmployeeCode,
                    d.EmployeeName,
                    d.Department,
                    d.JobTitle,
                    d.BasicSalary.ToString("N2"),
                    d.TotalAdditions.ToString("N2"),
                    d.TotalDeductions.ToString("N2"),
                    d.NetSalary.ToString("N2"),
                    d.Notes
                );

                int row = dgvDetails.Rows.Count - 1;
                if (d.NetSalary > d.BasicSalary)
                    dgvDetails.Rows[row].Cells["colNetSalary"].Style.ForeColor = Color.FromArgb(40, 160, 100);
                else if (d.NetSalary < d.BasicSalary)
                    dgvDetails.Rows[row].Cells["colNetSalary"].Style.ForeColor = Color.FromArgb(200, 50, 50);
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void UpdateTotals(List<PayrollDetail> list)
        {
            decimal totalBasic = 0, totalAdd = 0, totalDed = 0, totalNet = 0;
            foreach (var d in list)
            {
                totalBasic += d.BasicSalary;
                totalAdd += d.TotalAdditions;
                totalDed += d.TotalDeductions;
                totalNet += d.NetSalary;
            }
            lblTotalBasic.Text = "Basic: " + totalBasic.ToString("N2");
            lblTotalAdd.Text = "Additions: " + totalAdd.ToString("N2");
            lblTotalDed.Text = "Deductions: " + totalDed.ToString("N2");
            lblTotalNet.Text = "Net: " + totalNet.ToString("N2");
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_details); UpdateTotals(_details); return; }
            string s = text.ToLower();
            var filtered = new List<PayrollDetail>();
            foreach (var d in _details)
                if (d.EmployeeCode.ToLower().Contains(s) ||
                    d.EmployeeName.ToLower().Contains(s) ||
                    (d.Department != null && d.Department.ToLower().Contains(s)) ||
                    (d.JobTitle != null && d.JobTitle.ToLower().Contains(s)))
                    filtered.Add(d);
            BindGrid(filtered);
            UpdateTotals(filtered);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadDetails();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}