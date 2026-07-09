using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Accounting;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Accounting
{
    public partial class FrmTrialBalance : Form
    {
        private List<AccountBalance> _balances = new List<AccountBalance>();

        public FrmTrialBalance()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(16, 12);
            spinner.Size = new Size(40, 40);
            pnlFooter.Controls.Add(spinner);

            dgvTrialBalance.CellFormatting += DgvTrialBalance_CellFormatting;
        }

        private void DgvTrialBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvTrialBalance.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvTrialBalance.Columns["colDebitTotal"].Index)
            {
                decimal val = 0;
                decimal.TryParse(row.Cells["colDebitTotal"].Value?.ToString(), out val);
                if (val > 0)
                    e.CellStyle.ForeColor = Color.FromArgb(30, 100, 180);
            }
            else if (e.ColumnIndex == dgvTrialBalance.Columns["colCreditTotal"].Index)
            {
                decimal val = 0;
                decimal.TryParse(row.Cells["colCreditTotal"].Value?.ToString(), out val);
                if (val > 0)
                    e.CellStyle.ForeColor = Color.FromArgb(40, 140, 80);
            }
            else if (e.ColumnIndex == dgvTrialBalance.Columns["colClosingBalance"].Index)
            {
                decimal val = 0;
                decimal.TryParse(row.Cells["colClosingBalance"].Value?.ToString(), out val);
                if (val < 0)
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                else if (val > 0)
                    e.CellStyle.ForeColor = Color.FromArgb(22, 32, 50);
            }
        }

        private void FrmTrialBalance_Load(object sender, EventArgs e)
        {
            nudYear.Value = DateTime.Now.Year;
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                btnGenerate.Enabled = false;
                btnGenerate.Text = "Loading...";
                spinner.Start();

                int year = (int)nudYear.Value;
                int month = cmbMonth.SelectedIndex + 1;

                string endpoint = string.Format(
                    "accountbalances/by-period?FiscalYear={0}&FiscalMonth={1}",
                    year, month);

                _balances = await ApiHelper.GetAsync<List<AccountBalance>>(endpoint)
                            ?? new List<AccountBalance>();

                BindGrid(_balances);
                UpdateTotals();

                lblPeriodValue.Text = string.Format("{0} / {1}", cmbMonth.SelectedItem, year);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading trial balance: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                btnGenerate.Enabled = true;
                btnGenerate.Text = "Generate";
            }
        }

        private void BindGrid(List<AccountBalance> list)
        {
            dgvTrialBalance.Rows.Clear();

            foreach (var b in list)
            {
                dgvTrialBalance.Rows.Add(
                    b.AccountCode,
                    b.AccountName,
                    b.AccountType,
                    b.OpeningBalance.ToString("F3"),
                    b.DebitTotal.ToString("F3"),
                    b.CreditTotal.ToString("F3"),
                    b.ClosingBalance.ToString("F3")
                );
            }

            lblCount.Text = "Accounts: " + list.Count;
        }

        private void UpdateTotals()
        {
            decimal totalDebit = 0;
            decimal totalCredit = 0;
            decimal totalOpening = 0;
            decimal totalClosing = 0;

            foreach (var b in _balances)
            {
                totalOpening += b.OpeningBalance;
                totalDebit += b.DebitTotal;
                totalCredit += b.CreditTotal;
                totalClosing += b.ClosingBalance;
            }

            lblTotalOpeningVal.Text = totalOpening.ToString("F3");
            lblTotalDebitVal.Text = totalDebit.ToString("F3");
            lblTotalCreditVal.Text = totalCredit.ToString("F3");
            lblTotalClosingVal.Text = totalClosing.ToString("F3");

            decimal diff = Math.Abs(totalDebit - totalCredit);
            if (diff == 0 && _balances.Count > 0)
            {
                lblBalanceVal.Text = "0.000  ✓ Balanced";
                lblBalanceVal.ForeColor = Color.FromArgb(40, 140, 80);
            }
            else
            {
                lblBalanceVal.Text = diff.ToString("F3") + "  ✗ Unbalanced";
                lblBalanceVal.ForeColor = Color.FromArgb(200, 50, 50);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string s = txtSearch.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(s)) { BindGrid(_balances); UpdateTotals(); return; }

            var filtered = new List<AccountBalance>();
            foreach (var b in _balances)
                if (b.AccountCode.ToLower().Contains(s) ||
                    b.AccountName.ToLower().Contains(s) ||
                   (b.AccountType != null && b.AccountType.ToLower().Contains(s)))
                    filtered.Add(b);

            BindGrid(filtered);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}   