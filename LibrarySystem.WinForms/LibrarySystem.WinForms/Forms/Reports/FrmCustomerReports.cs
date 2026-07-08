using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Reports
{
    public partial class FrmCustomerReports : Form
    {
        private List<Customer> _customers = new List<Customer>();

        public FrmCustomerReports()
        {
            InitializeComponent();
            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(40, 40);
            pnlTop.Controls.Add(spinner);
        }

        private async void FrmCustomerReports_Load(object sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private async Task LoadReportAsync()
        {
            try
            {
                spinner.Start();
                lblStatus.Text = "Loading...";

                bool? isActive = cmbStatus.SelectedItem?.ToString() == "Active" ? true
                                : cmbStatus.SelectedItem?.ToString() == "Inactive" ? false
                                : (bool?)null;

                string url = isActive.HasValue ? $"Customers?isActive={isActive.Value}" : "Customers";
                _customers = await ApiHelper.GetAsync<List<Customer>>(url);

                var filtered = _customers;

                if (cmbDebtFilter.SelectedIndex == 1)
                    filtered = filtered.Where(c => c.TotalDebt > 0).ToList();
                else if (cmbDebtFilter.SelectedIndex == 2)
                    filtered = filtered.Where(c => c.TotalDebt <= 0).ToList();

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    var q = txtSearch.Text.ToLower();
                    filtered = filtered.Where(c =>
                        (c.CustomerName != null && c.CustomerName.ToLower().Contains(q)) ||
                        (c.Phone != null && c.Phone.ToLower().Contains(q))
                    ).ToList();
                }

                BindGrid(filtered);
                UpdateSummary(filtered);
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

        private void BindGrid(List<Customer> data)
        {
            dgvReport.Rows.Clear();
            foreach (var c in data)
            {
                dgvReport.Rows.Add(
                    c.CustomerID,
                    c.CustomerName,
                    c.Phone,
                    c.Email,
                    c.TotalPurchases.ToString("N2"),
                    c.TotalBorrowings,
                    c.TotalDebt.ToString("N2"),
                    c.TotalLateFees.ToString("N2"),
                    c.IsActive ? "Active" : "Inactive",
                    c.CreatedDate.ToString("yyyy-MM-dd")
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void UpdateSummary(List<Customer> data)
        {
            decimal totalPurchases = data.Sum(c => c.TotalPurchases);
            int totalBorrowings = data.Sum(c => c.TotalBorrowings);
            decimal totalDebt = data.Sum(c => c.TotalDebt);
            decimal totalLateFees = data.Sum(c => c.TotalLateFees);
            int withDebtCount = data.Count(c => c.TotalDebt > 0);
            int activeCount = data.Count(c => c.IsActive);

            lblTotalCustomers.Text = data.Count.ToString();
            lblTotalPurchases.Text = totalPurchases.ToString("N2");
            lblTotalBorrowings.Text = totalBorrowings.ToString("N0");
            lblTotalDebt.Text = totalDebt.ToString("N2");
            lblTotalLateFees.Text = totalLateFees.ToString("N2");
            lblWithDebt.Text = withDebtCount.ToString();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = new System.Text.StringBuilder();
                sb.AppendLine("Customer,Phone,Email,Total Purchases,Total Borrowings,Total Debt,Late Fees,Status,Created Date");
                for (int i = 0; i < dgvReport.Rows.Count; i++)
                {
                    var row = dgvReport.Rows[i];
                    sb.AppendLine($"{row.Cells["colCustomerName"].Value},{row.Cells["colPhone"].Value}," +
                                  $"{row.Cells["colEmail"].Value},{row.Cells["colTotalPurchases"].Value}," +
                                  $"{row.Cells["colTotalBorrowings"].Value},{row.Cells["colTotalDebt"].Value}," +
                                  $"{row.Cells["colLateFees"].Value},{row.Cells["colStatus"].Value}," +
                                  $"{row.Cells["colCreatedDate"].Value}");
                }

                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "CSV files (*.csv)|*.csv";
                    dlg.FileName = $"CustomerReport_{DateTime.Now:yyyyMMdd}";
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

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                BindGrid(_customers);
                UpdateSummary(_customers);
                return;
            }
            var q = txtSearch.Text.ToLower();
            var filtered = _customers.Where(c =>
                (c.CustomerName != null && c.CustomerName.ToLower().Contains(q)) ||
                (c.Phone != null && c.Phone.ToLower().Contains(q))
            ).ToList();
            BindGrid(filtered);
            UpdateSummary(filtered);
        }

        private void DgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = dgvReport.Columns["colStatus"];
            if (col != null && e.ColumnIndex == col.Index && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Active")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }

            var debtCol = dgvReport.Columns["colTotalDebt"];
            if (debtCol != null && e.ColumnIndex == debtCol.Index && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal debt) && debt > 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }
        }
    }
}