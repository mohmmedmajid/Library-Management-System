// FrmJournalEntryDetails.cs
using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Accounting
{
    public partial class FrmJournalEntryDetails : Form
    {
        private int _openWithEntryId = 0;
        private JournalEntry _currentEntry = null;
        private List<JournalEntryDetail> _currentDetails = new List<JournalEntryDetail>();

        public FrmJournalEntryDetails()
        {
            InitializeComponent();
        }

        public FrmJournalEntryDetails(int journalEntryId) : this()
        {
            _openWithEntryId = journalEntryId;
        }

        private async void FrmJournalEntryDetails_Load(object sender, EventArgs e)
        {
            lblDateValue.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm");
            dtpEndDate.Value = DateTime.Today;

            if (_openWithEntryId > 0)
            {
                txtEntryId.Text = _openWithEntryId.ToString();
                await LoadByEntryId(_openWithEntryId);
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtEntryId.Text.Trim(), out id) || id <= 0)
            {
                MessageHelper.ShowWarning("Please enter a valid Entry ID.");
                return;
            }
            await LoadByEntryId(id);
        }

        private async Task LoadByEntryId(int entryId)
        {
            try
            {
                btnLoad.Enabled = false;
                btnLoad.Text = "...";

                var entry = await ApiHelper.GetAsync<JournalEntry>("journalentries/" + entryId);
                if (entry == null)
                {
                    MessageHelper.ShowWarning("Journal entry not found.");
                    ClearEntryInfo();
                    _currentEntry = null;
                    _currentDetails = new List<JournalEntryDetail>();
                    return;
                }

                var details = await ApiHelper.GetAsync<List<JournalEntryDetail>>(
                    "journalentrydetails/by-journal-entry/" + entryId);

                _currentEntry = entry;
                _currentDetails = details ?? new List<JournalEntryDetail>();

                PopulateEntryInfo(entry);
                PopulateGrid(_currentDetails);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Load error: " + ex.Message);
            }
            finally
            {
                btnLoad.Enabled = true;
                btnLoad.Text = "Load";
            }
        }

        private async void btnSearchByDate_Click(object sender, EventArgs e)
        {
            int accountId;
            if (!int.TryParse(txtAccountId.Text.Trim(), out accountId) || accountId <= 0)
            {
                MessageHelper.ShowWarning("Please enter a valid Account ID.");
                return;
            }

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageHelper.ShowWarning("Start date cannot be after end date.");
                return;
            }

            try
            {
                btnSearchByDate.Enabled = false;
                btnSearchByDate.Text = "...";

                string start = dtpStartDate.Value.ToString("yyyy-MM-dd");
                string end = dtpEndDate.Value.ToString("yyyy-MM-dd");

                var details = await ApiHelper.GetAsync<List<JournalEntryDetail>>(
                    string.Format("journalentrydetails/by-account?AccountID={0}&StartDate={1}&EndDate={2}", accountId, start, end));

                ClearEntryInfo();
                _currentEntry = null;
                _currentDetails = details ?? new List<JournalEntryDetail>();
                PopulateGrid(_currentDetails);

                lblEntryNumberValue.Text = string.Format("Account #{0}  |  {1}  →  {2}", accountId, start, end);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Search error: " + ex.Message);
            }
            finally
            {
                btnSearchByDate.Enabled = true;
                btnSearchByDate.Text = "Search by Date";
            }
        }

        private void PopulateEntryInfo(JournalEntry entry)
        {
            lblEntryNumberValue.Text = "Entry #: " + entry.JournalEntryNumber;
            lblInfoEntryNumVal.Text = entry.JournalEntryNumber;
            lblInfoDateVal.Text = entry.EntryDate.ToString("yyyy-MM-dd");
            lblInfoTypeVal.Text = entry.EntryType;
            lblInfoDescVal.Text = entry.Description;
            lblInfoDebitVal.Text = entry.TotalDebit.ToString("F3");
            lblInfoCreditVal.Text = entry.TotalCredit.ToString("F3");

            lblInfoStatusVal.Text = entry.Status;
            switch (entry.Status)
            {
                case "Posted":
                    lblInfoStatusVal.ForeColor = Color.FromArgb(40, 140, 80);
                    break;
                case "Reversed":
                    lblInfoStatusVal.ForeColor = Color.FromArgb(100, 110, 130);
                    break;
                default:
                    lblInfoStatusVal.ForeColor = Color.FromArgb(150, 90, 0);
                    break;
            }
        }

        private void ClearEntryInfo()
        {
            lblEntryNumberValue.Text = "";
            lblInfoEntryNumVal.Text = "-";
            lblInfoDateVal.Text = "-";
            lblInfoTypeVal.Text = "-";
            lblInfoStatusVal.Text = "-";
            lblInfoStatusVal.ForeColor = Color.Gray;
            lblInfoDescVal.Text = "-";
            lblInfoDebitVal.Text = "0.000";
            lblInfoCreditVal.Text = "0.000";
        }

        private void PopulateGrid(List<JournalEntryDetail> details)
        {
            dgvDetails.Rows.Clear();

            decimal totalDebit = 0;
            decimal totalCredit = 0;

            foreach (var d in details)
            {
                string debitStr = d.IsDebit ? d.Amount.ToString("F3") : "0.000";
                string creditStr = d.IsDebit ? "0.000" : d.Amount.ToString("F3");

                if (d.IsDebit) totalDebit += d.Amount;
                else totalCredit += d.Amount;

                int rowIdx = dgvDetails.Rows.Add(
                    d.LineNumber,
                    d.AccountCode,
                    d.AccountName,
                    debitStr,
                    creditStr,
                    d.Description
                );

                if (d.IsDebit)
                    dgvDetails.Rows[rowIdx].Cells["colDebit"].Style.ForeColor = Color.FromArgb(30, 100, 180);
                else
                    dgvDetails.Rows[rowIdx].Cells["colCredit"].Style.ForeColor = Color.FromArgb(40, 140, 80);
            }

            UpdateFooterTotals(totalDebit, totalCredit);
        }

        private void UpdateFooterTotals(decimal totalDebit, decimal totalCredit)
        {
            decimal diff = Math.Abs(totalDebit - totalCredit);

            lblTotalDebitVal.Text = totalDebit.ToString("F3");
            lblTotalCreditVal.Text = totalCredit.ToString("F3");

            if (diff == 0 && (totalDebit > 0 || totalCredit > 0))
            {
                lblBalanceVal.Text = "0.000  [Balanced]";
                lblBalanceVal.ForeColor = Color.FromArgb(40, 140, 80);
            }
            else
            {
                lblBalanceVal.Text = diff.ToString("F3");
                lblBalanceVal.ForeColor = Color.FromArgb(200, 50, 50);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_currentEntry == null)
            {
                MessageHelper.ShowWarning("Please load a single journal entry first (by Entry ID) before printing.");
                return;
            }

            JournalEntryPrinter.Print(_currentEntry, _currentDetails, showPreview: true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PnlFooter_Resize(object sender, EventArgs e)
        {
            btnClose.Location = new Point(pnlFooter.ClientSize.Width - btnClose.Width - 12, 9);
            btnPrint.Location = new Point(btnClose.Left - btnPrint.Width - 10, 9);
        }
    }
}