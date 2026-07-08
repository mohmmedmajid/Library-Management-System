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
    public partial class FrmSalesReports : Form
    {
        private List<Invoice> _invoices = new List<Invoice>();
        private List<SalesRepresentative> _salesReps = new List<SalesRepresentative>();

        public FrmSalesReports()
        {
            InitializeComponent();
            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(40, 40);
            pnlTop.Controls.Add(spinner);
        }

        private async void FrmSalesReports_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
            await LoadSalesRepsAsync();
            await LoadReportAsync();
        }

        private async Task LoadSalesRepsAsync()
        {
            try
            {
                _salesReps = await ApiHelper.GetAsync<List<SalesRepresentative>>("SalesRepresentatives");
                cmbSalesRep.Items.Clear();
                cmbSalesRep.Items.Add("All Reps");
                foreach (var r in _salesReps)
                    cmbSalesRep.Items.Add(r.RepName);
                cmbSalesRep.SelectedIndex = 0;
            }
            catch { }
        }

        private async Task LoadReportAsync()
        {
            try
            {
                spinner.Start();
                lblStatus.Text = "Loading...";

                string status = cmbStatus.SelectedItem?.ToString() == "All" ? "" : cmbStatus.SelectedItem?.ToString() ?? "";
                string url = $"Invoices?StartDate={dtpFrom.Value:yyyy-MM-dd}&EndDate={dtpTo.Value:yyyy-MM-dd}&Status={status}";
                _invoices = await ApiHelper.GetAsync<List<Invoice>>(url);

                if (cmbSalesRep.SelectedIndex > 0)
                {
                    var repName = cmbSalesRep.SelectedItem.ToString();
                    var rep = _salesReps.FirstOrDefault(r => r.RepName == repName);
                    if (rep != null)
                        _invoices = _invoices.Where(i => i.SalesRepID == rep.SalesRepID).ToList();
                }

                BindGrid(_invoices);
                UpdateSummary(_invoices);
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

        private void BindGrid(List<Invoice> data)
        {
            dgvReport.Rows.Clear();
            foreach (var inv in data)
            {
                dgvReport.Rows.Add(
                    inv.InvoiceID,
                    inv.InvoiceNumber,
                    inv.InvoiceDate.ToString("yyyy-MM-dd"),
                    inv.CustomerName,
                    inv.TypeName,
                    inv.MethodName,
                    inv.SubTotal.ToString("N2"),
                    inv.DiscountAmount.ToString("N2"),
                    inv.TaxAmount.ToString("N2"),
                    inv.TotalAmount.ToString("N2"),
                    inv.PaidAmount.ToString("N2"),
                    inv.RemainingAmount.ToString("N2"),
                    inv.Status,
                    inv.CreatedByName
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void UpdateSummary(List<Invoice> data)
        {
            decimal totalSales = data.Sum(i => i.TotalAmount);
            decimal totalPaid = data.Sum(i => i.PaidAmount);
            decimal totalRemaining = data.Sum(i => i.RemainingAmount);
            decimal totalDiscount = data.Sum(i => i.DiscountAmount);
            decimal totalTax = data.Sum(i => i.TaxAmount);
            int completed = data.Count(i => i.Status == "Completed");
            int cancelled = data.Count(i => i.Status == "Cancelled");

            lblTotalSales.Text = totalSales.ToString("N2");
            lblTotalPaid.Text = totalPaid.ToString("N2");
            lblTotalRemaining.Text = totalRemaining.ToString("N2");
            lblTotalDiscount.Text = totalDiscount.ToString("N2");
            lblTotalTax.Text = totalTax.ToString("N2");
            lblCompleted.Text = completed.ToString();
            lblCancelled.Text = cancelled.ToString();
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
                sb.AppendLine("Invoice No,Date,Customer,Type,Method,SubTotal,Discount,Tax,Total,Paid,Remaining,Status,Created By");
                foreach (var inv in _invoices)
                {
                    sb.AppendLine($"{inv.InvoiceNumber},{inv.InvoiceDate:yyyy-MM-dd},{inv.CustomerName},{inv.TypeName},{inv.MethodName}," +
                                  $"{inv.SubTotal:N2},{inv.DiscountAmount:N2},{inv.TaxAmount:N2},{inv.TotalAmount:N2}," +
                                  $"{inv.PaidAmount:N2},{inv.RemainingAmount:N2},{inv.Status},{inv.CreatedByName}");
                }

                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "CSV files (*.csv)|*.csv";
                    dlg.FileName = $"SalesReport_{DateTime.Now:yyyyMMdd}";
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
                BindGrid(_invoices);
                return;
            }
            var q = txtSearch.Text.ToLower();
            var filtered = _invoices.Where(i =>
                (i.InvoiceNumber != null && i.InvoiceNumber.ToLower().Contains(q)) ||
                (i.CustomerName != null && i.CustomerName.ToLower().Contains(q))
            ).ToList();
            BindGrid(filtered);
        }

        private void DgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = dgvReport.Columns["colStatus"];
            if (col != null && e.ColumnIndex == col.Index && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Completed")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else if (status == "Cancelled")
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