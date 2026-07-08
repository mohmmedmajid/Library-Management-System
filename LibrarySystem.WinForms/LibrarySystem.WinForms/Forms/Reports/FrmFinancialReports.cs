using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Accounting;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Reports
{
    public partial class FrmFinancialReports : Form
    {
        private List<JournalEntry> _entries = new List<JournalEntry>();
        private List<AccountBalance> _balances = new List<AccountBalance>();
        private List<ChartOfAccount> _accounts = new List<ChartOfAccount>();

        public FrmFinancialReports()
        {
            InitializeComponent();
            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(40, 40);
            pnlTop.Controls.Add(spinner);
        }

        private async void FrmFinancialReports_Load(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = 0;
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
            SetupColumnsForReportType(cmbReportType.SelectedIndex);
            await LoadAccountsAsync();
            await LoadReportAsync();
        }

        private async Task LoadAccountsAsync()
        {
            try
            {
                _accounts = await ApiHelper.GetAsync<List<ChartOfAccount>>("ChartOfAccounts");
                cmbAccount.Items.Clear();
                cmbAccount.Items.Add("All Accounts");
                foreach (var a in _accounts)
                    cmbAccount.Items.Add(a.AccountCode + " - " + a.AccountName);
                cmbAccount.SelectedIndex = 0;
            }
            catch { }
        }

        private async Task LoadReportAsync()
        {
            try
            {
                spinner.Start();
                lblStatus.Text = "Loading...";

                int reportType = cmbReportType.SelectedIndex;
                if (reportType == 0)
                    await LoadJournalEntriesReport();
                else if (reportType == 1)
                    await LoadTrialBalanceReport();
                else if (reportType == 2)
                    await LoadAccountBalancesReport();
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

        private async Task LoadJournalEntriesReport()
        {
            _entries = await ApiHelper.GetAsync<List<JournalEntry>>("JournalEntries");

            List<JournalEntry> filtered = _entries.Where(e =>
                e.EntryDate >= dtpFrom.Value.Date &&
                e.EntryDate <= dtpTo.Value.Date
            ).ToList();

            if (cmbStatus.SelectedIndex > 0)
            {
                string status = cmbStatus.SelectedItem.ToString();
                filtered = filtered.Where(e => e.Status == status).ToList();
            }

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var q = txtSearch.Text.ToLower();
                filtered = filtered.Where(e =>
                    (e.JournalEntryNumber != null && e.JournalEntryNumber.ToLower().Contains(q)) ||
                    (e.Description != null && e.Description.ToLower().Contains(q)) ||
                    (e.CostCenterName != null && e.CostCenterName.ToLower().Contains(q))
                ).ToList();
            }

            BindJournalGrid(filtered);
            UpdateJournalSummary(filtered);
        }

        private async Task LoadTrialBalanceReport()
        {
            int year = dtpFrom.Value.Year;
            int month = dtpFrom.Value.Month;
            _balances = await ApiHelper.GetAsync<List<AccountBalance>>(
                "AccountBalances/by-period?FiscalYear=" + year + "&FiscalMonth=" + month);
            BindTrialBalanceGrid(_balances);
            UpdateBalanceSummary(_balances);
        }

        private async Task LoadAccountBalancesReport()
        {
            _balances = await ApiHelper.GetAsync<List<AccountBalance>>(
                "AccountBalances/by-period?FiscalYear=" + dtpFrom.Value.Year + "&FiscalMonth=" + dtpFrom.Value.Month);

            List<AccountBalance> filtered = _balances;

            if (cmbAccount.SelectedIndex > 0)
            {
                string selected = cmbAccount.SelectedItem.ToString();
                string code = selected.Split('-')[0].Trim();
                filtered = filtered.Where(b => b.AccountCode == code).ToList();
            }

            BindBalanceGrid(filtered);
            UpdateBalanceSummary(filtered);
        }

        private void BindJournalGrid(List<JournalEntry> data)
        {
            dgvReport.Rows.Clear();
            foreach (var e in data)
            {
                dgvReport.Rows.Add(
                    e.JournalEntryID,
                    e.JournalEntryNumber,
                    e.EntryDate.ToString("yyyy-MM-dd"),
                    e.EntryType,
                    e.CostCenterName,
                    e.Description,
                    e.TotalDebit.ToString("N2"),
                    e.TotalCredit.ToString("N2"),
                    e.IsBalanced ? "Balanced" : "Unbalanced",
                    e.Status,
                    e.CreatedByName
                );
            }
            lblCount.Text = "Records: " + data.Count;
        }

        private void BindTrialBalanceGrid(List<AccountBalance> data)
        {
            dgvReport.Rows.Clear();
            foreach (var b in data)
            {
                dgvReport.Rows.Add(
                    b.BalanceID,
                    b.AccountCode,
                    b.AccountName,
                    b.AccountType,
                    b.OpeningBalance.ToString("N2"),
                    b.DebitTotal.ToString("N2"),
                    b.CreditTotal.ToString("N2"),
                    b.ClosingBalance.ToString("N2"),
                    b.FiscalYear,
                    b.FiscalMonth
                );
            }
            lblCount.Text = "Records: " + data.Count;
        }

        private void BindBalanceGrid(List<AccountBalance> data)
        {
            BindTrialBalanceGrid(data);
        }

        private void UpdateJournalSummary(List<JournalEntry> data)
        {
            decimal totalDebit = data.Sum(e => e.TotalDebit);
            decimal totalCredit = data.Sum(e => e.TotalCredit);
            int balanced = data.Count(e => e.IsBalanced);
            int posted = data.Count(e => e.Status == "Posted");
            int draft = data.Count(e => e.Status == "Draft");

            lblLbl1.Text = "Total Entries";
            lblLbl2.Text = "Total Debit";
            lblLbl3.Text = "Total Credit";
            lblLbl4.Text = "Balanced";
            lblLbl5.Text = "Posted";
            lblLbl6.Text = "Draft";

            lblVal1.Text = data.Count.ToString();
            lblVal2.Text = totalDebit.ToString("N2");
            lblVal3.Text = totalCredit.ToString("N2");
            lblVal4.Text = balanced.ToString();
            lblVal5.Text = posted.ToString();
            lblVal6.Text = draft.ToString();
        }

        private void UpdateBalanceSummary(List<AccountBalance> data)
        {
            decimal totalDebit = data.Sum(b => b.DebitTotal);
            decimal totalCredit = data.Sum(b => b.CreditTotal);
            decimal totalOpening = data.Sum(b => b.OpeningBalance);
            decimal totalClosing = data.Sum(b => b.ClosingBalance);

            lblLbl1.Text = "Total Accounts";
            lblLbl2.Text = "Opening Balance";
            lblLbl3.Text = "Total Debit";
            lblLbl4.Text = "Total Credit";
            lblLbl5.Text = "Closing Balance";
            lblLbl6.Text = "Net Change";

            lblVal1.Text = data.Count.ToString();
            lblVal2.Text = totalOpening.ToString("N2");
            lblVal3.Text = totalDebit.ToString("N2");
            lblVal4.Text = totalCredit.ToString("N2");
            lblVal5.Text = totalClosing.ToString("N2");
            lblVal6.Text = (totalDebit - totalCredit).ToString("N2");
        }

        private void SetupColumnsForReportType(int reportType)
        {
            dgvReport.Columns.Clear();

            if (reportType == 0)
            {
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colID", HeaderText = "ID", Visible = false });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNumber", HeaderText = "Entry No", FillWeight = 12f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Date", FillWeight = 10f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Type", FillWeight = 10f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCostCenter", HeaderText = "Cost Center", FillWeight = 12f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDesc", HeaderText = "Description", FillWeight = 18f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDebit", HeaderText = "Debit", FillWeight = 10f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCredit", HeaderText = "Credit", FillWeight = 10f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBalanced", HeaderText = "Balanced", FillWeight = 10f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Status", FillWeight = 8f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCreatedBy", HeaderText = "Created By", FillWeight = 10f });
            }
            else
            {
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colID", HeaderText = "ID", Visible = false });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCode", HeaderText = "Account Code", FillWeight = 12f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "Account Name", FillWeight = 20f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Type", FillWeight = 12f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOpening", HeaderText = "Opening", FillWeight = 12f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDebit", HeaderText = "Debit", FillWeight = 12f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCredit", HeaderText = "Credit", FillWeight = 12f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colClosing", HeaderText = "Closing", FillWeight = 12f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colYear", HeaderText = "Year", FillWeight = 6f });
                dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMonth", HeaderText = "Month", FillWeight = 6f });
            }
        }

        private async void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupColumnsForReportType(cmbReportType.SelectedIndex);
            bool isJournal = cmbReportType.SelectedIndex == 0;
            pnlJournalFilters.Visible = isJournal;
            pnlBalanceFilters.Visible = !isJournal;
            await LoadReportAsync();
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
                var headers = new List<string>();
                foreach (DataGridViewColumn col in dgvReport.Columns)
                {
                    if (col.Visible)
                        headers.Add(col.HeaderText);
                }
                sb.AppendLine(string.Join(",", headers));

                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    var vals = new List<string>();
                    foreach (DataGridViewColumn col in dgvReport.Columns)
                    {
                        if (col.Visible)
                            vals.Add((row.Cells[col.Index].Value ?? "").ToString().Replace(",", ";"));
                    }
                    sb.AppendLine(string.Join(",", vals));
                }

                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "CSV files (*.csv)|*.csv";
                    dlg.FileName = "FinancialReport_" + DateTime.Now.ToString("yyyyMMdd");
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
            if (e.RowIndex < 0) return;

            var colStatus = dgvReport.Columns["colStatus"];
            if (colStatus != null && e.ColumnIndex == colStatus.Index && e.Value != null)
            {
                string val = e.Value.ToString();
                if (val == "Posted")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else if (val == "Draft")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(180, 120, 0);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else if (val == "Reversed")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }

            var colBalanced = dgvReport.Columns["colBalanced"];
            if (colBalanced != null && e.ColumnIndex == colBalanced.Index && e.Value != null)
            {
                string val = e.Value.ToString();
                e.CellStyle.ForeColor = val == "Balanced"
                    ? Color.FromArgb(40, 160, 100)
                    : Color.FromArgb(200, 50, 50);
                e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
        }
    }
}