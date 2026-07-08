using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Purchasing;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Reports
{
    public partial class FrmSupplierReports : Form
    {
        private List<Supplier> _suppliers = new List<Supplier>();
        private List<SupplierTransaction> _transactions = new List<SupplierTransaction>();

        public FrmSupplierReports()
        {
            InitializeComponent();
            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(40, 40);
            pnlTop.Controls.Add(spinner);
        }

        private async void FrmSupplierReports_Load(object sender, EventArgs e)
        {
            SetupColumnsForSuppliers();
            cmbReportType.SelectedIndex = 0;
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

                string reportType = cmbReportType.SelectedItem?.ToString() ?? "Suppliers";

                if (reportType == "Transactions")
                {
                    string url = $"SupplierTransactions?startDate={dtpFrom.Value:yyyy-MM-dd}&endDate={dtpTo.Value:yyyy-MM-dd}";
                    if (cmbTransactionType.SelectedItem?.ToString() != "All")
                        url += $"&transactionType={cmbTransactionType.SelectedItem}";
                    _transactions = await ApiHelper.GetAsync<List<SupplierTransaction>>(url);

                    var filtered = _transactions;
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        var q = txtSearch.Text.ToLower();
                        filtered = filtered.Where(t =>
                            (t.SupplierName != null && t.SupplierName.ToLower().Contains(q)) ||
                            (t.ReferenceNumber != null && t.ReferenceNumber.ToLower().Contains(q))
                        ).ToList();
                    }
                    BindTransactionGrid(filtered);
                    UpdateTransactionSummary(filtered);
                }
                else
                {
                    bool? isActive = null;
                    if (cmbStatus.SelectedItem?.ToString() == "Active") isActive = true;
                    else if (cmbStatus.SelectedItem?.ToString() == "Inactive") isActive = false;

                    string url = isActive.HasValue
                        ? $"Suppliers?isActive={isActive.Value}"
                        : "Suppliers";
                    _suppliers = await ApiHelper.GetAsync<List<Supplier>>(url);

                    var filtered = _suppliers;
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        var q = txtSearch.Text.ToLower();
                        filtered = filtered.Where(s =>
                            (s.SupplierName != null && s.SupplierName.ToLower().Contains(q)) ||
                            (s.ContactPerson != null && s.ContactPerson.ToLower().Contains(q)) ||
                            (s.Phone != null && s.Phone.ToLower().Contains(q))
                        ).ToList();
                    }
                    BindSupplierGrid(filtered);
                    UpdateSupplierSummary(filtered);
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

        private void BindSupplierGrid(List<Supplier> data)
        {
            dgvReport.Rows.Clear();
            foreach (var s in data)
            {
                dgvReport.Rows.Add(
                    s.SupplierID,
                    s.SupplierName,
                    s.ContactPerson,
                    s.Phone,
                    s.Email,
                    s.TotalPurchases.ToString("N2"),
                    s.TotalDebt.ToString("N2"),
                    s.CreditLimit.ToString("N2"),
                    s.PaymentTerms,
                    s.IsActive ? "Active" : "Inactive",
                    s.CreatedDate.ToString("yyyy-MM-dd")
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void BindTransactionGrid(List<SupplierTransaction> data)
        {
            dgvReport.Rows.Clear();
            foreach (var t in data)
            {
                dgvReport.Rows.Add(
                    t.TransactionID,
                    t.SupplierName,
                    t.TransactionType,
                    t.InvoiceNumber,
                    t.Amount.ToString("N2"),
                    t.TransactionDate.ToString("yyyy-MM-dd"),
                    t.ReferenceNumber,
                    t.Notes,
                    "", "", ""
                );
            }
            lblCount.Text = $"Records: {data.Count}";
        }

        private void UpdateSupplierSummary(List<Supplier> data)
        {
            decimal totalPurchases = data.Sum(s => s.TotalPurchases);
            decimal totalDebt = data.Sum(s => s.TotalDebt);
            decimal totalCreditLimit = data.Sum(s => s.CreditLimit);
            int activeCount = data.Count(s => s.IsActive);
            int inactiveCount = data.Count(s => !s.IsActive);
            int withDebtCount = data.Count(s => s.TotalDebt > 0);

            lblStat1.Text = totalPurchases.ToString("N2");
            lblStat2.Text = totalDebt.ToString("N2");
            lblStat3.Text = totalCreditLimit.ToString("N2");
            lblStat4.Text = activeCount.ToString();
            lblStat5.Text = inactiveCount.ToString();
            lblStat6.Text = withDebtCount.ToString();
        }

        private void UpdateTransactionSummary(List<SupplierTransaction> data)
        {
            decimal totalAmount = data.Sum(t => t.Amount);
            int purchaseCount = data.Count(t => t.TransactionType == "Purchase");
            int paymentCount = data.Count(t => t.TransactionType == "Payment");
            decimal purchaseTotal = data.Where(t => t.TransactionType == "Purchase").Sum(t => t.Amount);
            decimal paymentTotal = data.Where(t => t.TransactionType == "Payment").Sum(t => t.Amount);

            lblStat1.Text = totalAmount.ToString("N2");
            lblStat2.Text = purchaseTotal.ToString("N2");
            lblStat3.Text = paymentTotal.ToString("N2");
            lblStat4.Text = purchaseCount.ToString();
            lblStat5.Text = paymentCount.ToString();
            lblStat6.Text = data.Count.ToString();
        }

        private void SetupColumnsForSuppliers()
        {
            dgvReport.Columns.Clear();
            dgvReport.Columns.AddRange(new DataGridViewColumn[]
            {
                CreateCol("colID", "ID", false, 0f),
                CreateCol("colName", "Supplier Name", true, 16f),
                CreateCol("colContact", "Contact Person", true, 13f),
                CreateCol("colPhone", "Phone", true, 11f),
                CreateCol("colEmail", "Email", true, 14f),
                CreateCol("colPurchases", "Total Purchases", true, 12f),
                CreateCol("colDebt", "Total Debt", true, 10f),
                CreateCol("colCreditLimit", "Credit Limit", true, 10f),
                CreateCol("colPaymentTerms", "Payment Terms", true, 11f),
                CreateCol("colStatus", "Status", true, 7f),
                CreateCol("colCreatedDate", "Created Date", true, 10f)
            });

            lblStat1Lbl.Text = "Total Purchases";
            lblStat2Lbl.Text = "Total Debt";
            lblStat3Lbl.Text = "Credit Limit";
            lblStat4Lbl.Text = "Active";
            lblStat5Lbl.Text = "Inactive";
            lblStat6Lbl.Text = "With Debt";
        }

        private void SetupColumnsForTransactions()
        {
            dgvReport.Columns.Clear();
            dgvReport.Columns.AddRange(new DataGridViewColumn[]
            {
                CreateCol("colID", "ID", false, 0f),
                CreateCol("colSupplier", "Supplier", true, 18f),
                CreateCol("colType", "Type", true, 10f),
                CreateCol("colInvoice", "Invoice No", true, 12f),
                CreateCol("colAmount", "Amount", true, 11f),
                CreateCol("colDate", "Date", true, 10f),
                CreateCol("colRef", "Reference", true, 12f),
                CreateCol("colNotes", "Notes", true, 15f),
                CreateCol("colStatus", "Status", false, 0f),
                CreateCol("col9", "", false, 0f),
                CreateCol("col10", "", false, 0f)
            });

            lblStat1Lbl.Text = "Total Amount";
            lblStat2Lbl.Text = "Purchases Total";
            lblStat3Lbl.Text = "Payments Total";
            lblStat4Lbl.Text = "Purchases Count";
            lblStat5Lbl.Text = "Payments Count";
            lblStat6Lbl.Text = "Total Records";
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

        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem?.ToString() ?? "Suppliers";
            bool isTransactions = reportType == "Transactions";

            pnlTransactionFilter.Visible = isTransactions;
            pnlStatusFilter.Visible = !isTransactions;

            if (isTransactions)
                SetupColumnsForTransactions();
            else
                SetupColumnsForSuppliers();
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
                    dlg.FileName = $"SupplierReport_{DateTime.Now:yyyyMMdd}";
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
            string reportType = cmbReportType.SelectedItem?.ToString() ?? "Suppliers";
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                if (reportType == "Transactions") { BindTransactionGrid(_transactions); UpdateTransactionSummary(_transactions); }
                else { BindSupplierGrid(_suppliers); UpdateSupplierSummary(_suppliers); }
                return;
            }
            var q = txtSearch.Text.ToLower();
            if (reportType == "Transactions")
            {
                var filtered = _transactions.Where(t =>
                    (t.SupplierName != null && t.SupplierName.ToLower().Contains(q)) ||
                    (t.ReferenceNumber != null && t.ReferenceNumber.ToLower().Contains(q))
                ).ToList();
                BindTransactionGrid(filtered);
                UpdateTransactionSummary(filtered);
            }
            else
            {
                var filtered = _suppliers.Where(s =>
                    (s.SupplierName != null && s.SupplierName.ToLower().Contains(q)) ||
                    (s.ContactPerson != null && s.ContactPerson.ToLower().Contains(q)) ||
                    (s.Phone != null && s.Phone.ToLower().Contains(q))
                ).ToList();
                BindSupplierGrid(filtered);
                UpdateSupplierSummary(filtered);
            }
        }

        private void DgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            var statusCol = dgvReport.Columns["colStatus"];
            if (statusCol != null && e.ColumnIndex == statusCol.Index)
            {
                string val = e.Value.ToString();
                if (val == "Active")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else if (val == "Inactive")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }

            var typeCol = dgvReport.Columns["colType"];
            if (typeCol != null && e.ColumnIndex == typeCol.Index)
            {
                string type = e.Value.ToString();
                if (type == "Payment")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else if (type == "Purchase")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(180, 120, 0);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }
        }
    }
}