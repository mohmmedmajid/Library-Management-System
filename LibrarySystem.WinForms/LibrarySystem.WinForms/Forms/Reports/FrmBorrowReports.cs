using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Sales;
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
    public partial class FrmBorrowReports : Form
    {
        private List<BorrowingTransaction> _borrowings = new List<BorrowingTransaction>();

        public FrmBorrowReports()
        {
            InitializeComponent();
            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(40, 40);
            pnlTop.Controls.Add(spinner);
        }

        private async void FrmBorrowReports_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
            await LoadReportAsync();
        }

        private async Task LoadReportAsync()
        {
            try
            {
                spinner.Start();
                lblStatus.Text = "Loading...";

                if (cmbStatus.SelectedItem?.ToString() == "Active")
                {
                    _borrowings = await ApiHelper.GetAsync<List<BorrowingTransaction>>("BorrowingTransactions/active");
                }
                else if (cmbStatus.SelectedItem?.ToString() == "Late")
                {
                    _borrowings = await ApiHelper.GetAsync<List<BorrowingTransaction>>("BorrowingTransactions/late");
                }
                else
                {
                    string status = cmbStatus.SelectedItem?.ToString() == "All" ? "" : cmbStatus.SelectedItem?.ToString() ?? "";
                    string url = $"BorrowingTransactions?StartDate={dtpFrom.Value:yyyy-MM-dd}&EndDate={dtpTo.Value:yyyy-MM-dd}&Status={status}";
                    _borrowings = await ApiHelper.GetAsync<List<BorrowingTransaction>>(url);
                }

                var filtered = _borrowings;

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    var q = txtSearch.Text.ToLower();
                    filtered = filtered.Where(b =>
                        (b.BorrowingNumber != null && b.BorrowingNumber.ToLower().Contains(q)) ||
                        (b.CustomerName != null && b.CustomerName.ToLower().Contains(q))
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

        private void BindGrid(List<BorrowingTransaction> data)
        {
            dgvReport.Rows.Clear();
            foreach (var b in data)
            {
                int remainingDays = (b.ExpectedReturnDate - DateTime.Now).Days;
                bool isLate = b.Status == "Borrowed" && DateTime.Now > b.ExpectedReturnDate;

                dgvReport.Rows.Add(
                    b.BorrowingID,
                    b.BorrowingNumber,
                    b.BorrowingDate.ToString("yyyy-MM-dd"),
                    b.CustomerName,
                    b.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                    b.TotalDays,
                    b.TotalAmount.ToString("N2"),
                    b.PaidAmount.ToString("N2"),
                    (b.TotalAmount - b.PaidAmount).ToString("N2"),
                    isLate ? "Late" : b.Status,
                    b.CreatedByName
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void UpdateSummary(List<BorrowingTransaction> data)
        {
            decimal totalAmount = data.Sum(b => b.TotalAmount);
            decimal totalPaid = data.Sum(b => b.PaidAmount);
            decimal totalRemaining = totalAmount - totalPaid;
            int borrowedCount = data.Count(b => b.Status == "Borrowed");
            int returnedCount = data.Count(b => b.Status == "Returned");
            int lateCount = data.Count(b => b.Status == "Borrowed" && DateTime.Now > b.ExpectedReturnDate);

            lblTotalAmount.Text = totalAmount.ToString("N2");
            lblTotalPaid.Text = totalPaid.ToString("N2");
            lblTotalRemaining.Text = totalRemaining.ToString("N2");
            lblBorrowed.Text = borrowedCount.ToString();
            lblReturned.Text = returnedCount.ToString();
            lblLate.Text = lateCount.ToString();
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
                sb.AppendLine("Borrowing No,Date,Customer,Expected Return,Days,Total,Paid,Remaining,Status,Created By");
                for (int i = 0; i < dgvReport.Rows.Count; i++)
                {
                    var row = dgvReport.Rows[i];
                    sb.AppendLine($"{row.Cells["colBorrowingNo"].Value},{row.Cells["colDate"].Value}," +
                                  $"{row.Cells["colCustomer"].Value},{row.Cells["colExpectedReturn"].Value}," +
                                  $"{row.Cells["colDays"].Value},{row.Cells["colTotal"].Value}," +
                                  $"{row.Cells["colPaid"].Value},{row.Cells["colRemaining"].Value}," +
                                  $"{row.Cells["colStatus"].Value},{row.Cells["colCreatedBy"].Value}");
                }

                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "CSV files (*.csv)|*.csv";
                    dlg.FileName = $"BorrowReport_{DateTime.Now:yyyyMMdd}";
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
                BindGrid(_borrowings);
                UpdateSummary(_borrowings);
                return;
            }
            var q = txtSearch.Text.ToLower();
            var filtered = _borrowings.Where(b =>
                (b.BorrowingNumber != null && b.BorrowingNumber.ToLower().Contains(q)) ||
                (b.CustomerName != null && b.CustomerName.ToLower().Contains(q))
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
                if (status == "Returned")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else if (status == "Late")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(180, 120, 0);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }
        }
    }
}