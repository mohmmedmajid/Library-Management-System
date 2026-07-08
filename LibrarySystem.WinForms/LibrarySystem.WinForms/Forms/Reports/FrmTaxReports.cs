using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Advanced;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Reports
{
    public partial class FrmTaxReports : Form
    {
        private List<TaxDeclaration> _declarations = new List<TaxDeclaration>();
        private List<InvoiceTax> _invoiceTaxes = new List<InvoiceTax>();
        private List<TaxType> _taxTypes = new List<TaxType>();

        public FrmTaxReports()
        {
            InitializeComponent();
            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(40, 40);
            pnlTop.Controls.Add(spinner);
        }

        private async void FrmTaxReports_Load(object sender, EventArgs e)
        {
            SetupColumnsForDeclarations();
            cmbReportType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            dtpFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpTo.Value = DateTime.Now;
            await LoadTaxTypesAsync();
            await LoadReportAsync();
        }

        private async Task LoadTaxTypesAsync()
        {
            try
            {
                _taxTypes = await ApiHelper.GetAsync<List<TaxType>>("TaxTypes?isActive=true");
                cmbTaxType.Items.Clear();
                cmbTaxType.Items.Add("All Tax Types");
                foreach (var t in _taxTypes)
                    cmbTaxType.Items.Add(t.TaxName);
                cmbTaxType.SelectedIndex = 0;
            }
            catch { }
        }

        private async Task LoadReportAsync()
        {
            try
            {
                spinner.Start();
                lblStatus.Text = "Loading...";

                string reportType = cmbReportType.SelectedItem?.ToString() ?? "Declarations";

                if (reportType == "Invoice Taxes")
                    await LoadInvoiceTaxesAsync();
                else
                    await LoadDeclarationsAsync();
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

        private async Task LoadDeclarationsAsync()
        {
            string url = $"TaxDeclarations?fiscalYear={dtpFrom.Value.Year}";

            int taxTypeId = GetSelectedTaxTypeId();
            if (taxTypeId > 0) url += $"&taxTypeId={taxTypeId}";

            string status = cmbStatus.SelectedItem?.ToString();
            if (status != "All") url += $"&status={status}";

            _declarations = await ApiHelper.GetAsync<List<TaxDeclaration>>(url);

            var filtered = _declarations;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var q = txtSearch.Text.ToLower();
                filtered = filtered.Where(d =>
                    d.DeclarationNumber.ToLower().Contains(q) ||
                    d.TaxName.ToLower().Contains(q) ||
                    d.TaxCode.ToLower().Contains(q)
                ).ToList();
            }
            BindDeclarationGrid(filtered);
            UpdateDeclarationSummary(filtered);
        }

        private async Task LoadInvoiceTaxesAsync()
        {
            string url = $"InvoiceTaxes?startDate={dtpFrom.Value:yyyy-MM-dd}&endDate={dtpTo.Value:yyyy-MM-dd}";

            int taxTypeId = GetSelectedTaxTypeId();
            if (taxTypeId > 0) url += $"&taxTypeId={taxTypeId}";

            _invoiceTaxes = await ApiHelper.GetAsync<List<InvoiceTax>>(url);

            var filtered = _invoiceTaxes;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var q = txtSearch.Text.ToLower();
                filtered = filtered.Where(t =>
                    t.InvoiceNumber.ToLower().Contains(q) ||
                    t.TaxName.ToLower().Contains(q) ||
                    t.TaxCode.ToLower().Contains(q)
                ).ToList();
            }
            BindInvoiceTaxGrid(filtered);
            UpdateInvoiceTaxSummary(filtered);
        }

        private int GetSelectedTaxTypeId()
        {
            if (cmbTaxType.SelectedIndex <= 0) return 0;
            string name = cmbTaxType.SelectedItem.ToString();
            var found = _taxTypes.FirstOrDefault(t => t.TaxName == name);
            return found?.TaxTypeID ?? 0;
        }

        private void BindDeclarationGrid(List<TaxDeclaration> data)
        {
            dgvReport.Rows.Clear();
            foreach (var d in data)
            {
                dgvReport.Rows.Add(
                    d.DeclarationID,
                    d.DeclarationNumber,
                    d.TaxName,
                    d.TaxCode,
                    d.DeclarationType,
                    $"{d.FiscalMonth}/{d.FiscalYear}",
                    d.PeriodStartDate.ToString("yyyy-MM-dd"),
                    d.PeriodEndDate.ToString("yyyy-MM-dd"),
                    d.TotalSalesTax.ToString("N2"),
                    d.TotalPurchaseTax.ToString("N2"),
                    d.NetTaxDue.ToString("N2"),
                    d.PaidAmount.ToString("N2"),
                    d.RemainingAmount.ToString("N2"),
                    d.Status,
                    d.CreatedByName
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void BindInvoiceTaxGrid(List<InvoiceTax> data)
        {
            dgvReport.Rows.Clear();
            foreach (var t in data)
            {
                dgvReport.Rows.Add(
                    t.InvoiceTaxID,
                    t.InvoiceNumber,
                    t.TaxName,
                    t.TaxCode,
                    t.TaxCategory,
                    t.TaxableAmount.ToString("N2"),
                    t.TaxRate.ToString("N2") + "%",
                    t.TaxAmount.ToString("N2"),
                    t.CreatedDate.ToString("yyyy-MM-dd"),
                    "", "", "", "", "", ""
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void UpdateDeclarationSummary(List<TaxDeclaration> data)
        {
            decimal totalSalesTax = data.Sum(d => d.TotalSalesTax);
            decimal totalPurchaseTax = data.Sum(d => d.TotalPurchaseTax);
            decimal totalNetDue = data.Sum(d => d.NetTaxDue);
            decimal totalPaid = data.Sum(d => d.PaidAmount);
            decimal totalRemaining = data.Sum(d => d.RemainingAmount);
            int paidCount = data.Count(d => d.Status == "Paid");

            lblStat1.Text = totalSalesTax.ToString("N2");
            lblStat2.Text = totalPurchaseTax.ToString("N2");
            lblStat3.Text = totalNetDue.ToString("N2");
            lblStat4.Text = totalPaid.ToString("N2");
            lblStat5.Text = totalRemaining.ToString("N2");
            lblStat6.Text = paidCount.ToString();

            lblStat1Lbl.Text = "Sales Tax";
            lblStat2Lbl.Text = "Purchase Tax";
            lblStat3Lbl.Text = "Net Due";
            lblStat4Lbl.Text = "Paid";
            lblStat5Lbl.Text = "Remaining";
            lblStat6Lbl.Text = "Paid Declarations";
        }

        private void UpdateInvoiceTaxSummary(List<InvoiceTax> data)
        {
            decimal totalTaxable = data.Sum(t => t.TaxableAmount);
            decimal totalTax = data.Sum(t => t.TaxAmount);
            int invoiceCount = data.Select(t => t.InvoiceID).Distinct().Count();
            int taxTypeCount = data.Select(t => t.TaxTypeID).Distinct().Count();

            lblStat1.Text = data.Count.ToString();
            lblStat2.Text = totalTaxable.ToString("N2");
            lblStat3.Text = totalTax.ToString("N2");
            lblStat4.Text = invoiceCount.ToString();
            lblStat5.Text = taxTypeCount.ToString();
            lblStat6.Text = totalTaxable > 0 ? ((totalTax / totalTaxable) * 100).ToString("N2") + "%" : "0%";

            lblStat1Lbl.Text = "Total Records";
            lblStat2Lbl.Text = "Taxable Amount";
            lblStat3Lbl.Text = "Total Tax";
            lblStat4Lbl.Text = "Invoices Count";
            lblStat5Lbl.Text = "Tax Types";
            lblStat6Lbl.Text = "Effective Rate";
        }

        private void SetupColumnsForDeclarations()
        {
            dgvReport.Columns.Clear();
            dgvReport.Columns.AddRange(new DataGridViewColumn[]
            {
                CreateCol("colID", "ID", false, 0f),
                CreateCol("colNumber", "Declaration No", true, 12f),
                CreateCol("colTaxName", "Tax Name", true, 12f),
                CreateCol("colTaxCode", "Tax Code", true, 8f),
                CreateCol("colType", "Type", true, 8f),
                CreateCol("colPeriod", "Period", true, 7f),
                CreateCol("colStart", "Start Date", true, 9f),
                CreateCol("colEnd", "End Date", true, 9f),
                CreateCol("colSalesTax", "Sales Tax", true, 8f),
                CreateCol("colPurchaseTax", "Purchase Tax", true, 9f),
                CreateCol("colNetDue", "Net Due", true, 8f),
                CreateCol("colPaid", "Paid", true, 7f),
                CreateCol("colRemaining", "Remaining", true, 7f),
                CreateCol("colStatus", "Status", true, 6f),
                CreateCol("colCreatedBy", "Created By", true, 10f)
            });
        }

        private void SetupColumnsForInvoiceTaxes()
        {
            dgvReport.Columns.Clear();
            dgvReport.Columns.AddRange(new DataGridViewColumn[]
            {
                CreateCol("colID", "ID", false, 0f),
                CreateCol("colInvoice", "Invoice No", true, 14f),
                CreateCol("colTaxName", "Tax Name", true, 14f),
                CreateCol("colTaxCode", "Tax Code", true, 10f),
                CreateCol("colCategory", "Category", true, 12f),
                CreateCol("colTaxable", "Taxable Amount", true, 13f),
                CreateCol("colRate", "Tax Rate", true, 9f),
                CreateCol("colTaxAmount", "Tax Amount", true, 12f),
                CreateCol("colDate", "Date", true, 10f),
                CreateCol("col9", "", false, 0f),
                CreateCol("col10", "", false, 0f),
                CreateCol("col11", "", false, 0f),
                CreateCol("col12", "", false, 0f),
                CreateCol("col13", "", false, 0f),
                CreateCol("col14", "", false, 0f)
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
            string reportType = cmbReportType.SelectedItem?.ToString() ?? "Declarations";

            cmbStatus.Items.Clear();
            if (reportType == "Declarations")
            {
                cmbStatus.Items.AddRange(new object[] { "All", "Draft", "Submitted", "Paid" });
                SetupColumnsForDeclarations();
            }
            else
            {
                cmbStatus.Items.AddRange(new object[] { "All" });
                SetupColumnsForInvoiceTaxes();
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
                    dlg.FileName = $"TaxReport_{DateTime.Now:yyyyMMdd}";
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
                    case "Paid":
                        e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                        e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                        break;
                    case "Submitted":
                        e.CellStyle.ForeColor = Color.FromArgb(30, 100, 180);
                        e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                        break;
                    case "Draft":
                        e.CellStyle.ForeColor = Color.FromArgb(180, 120, 0);
                        e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                        break;
                }
            }
        }
    }
}