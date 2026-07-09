using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Accounting;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Accounting
{
    public partial class FrmAccountBalances : Form
    {
        private List<ChartOfAccount> _accounts = new List<ChartOfAccount>();
        private List<AccountBalance> _balances = new List<AccountBalance>();

        public FrmAccountBalances()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(810, 14);
            spinner.Size = new Size(36, 36);
            pnlTop.Controls.Add(spinner);
        }

        private async void FrmAccountBalances_Load(object sender, EventArgs e)
        {
            FillYearMonth();
            await LoadAccounts();
            await LoadBalances();
        }

        private void FillYearMonth()
        {
            cmbYear.Items.Add("All");
            int currentYear = DateTime.Now.Year;
            for (int y = currentYear - 5; y <= currentYear + 1; y++)
                cmbYear.Items.Add(y.ToString());
            cmbYear.SelectedItem = currentYear.ToString();

            cmbMonth.Items.Add("All");
            for (int m = 1; m <= 12; m++)
                cmbMonth.Items.Add(m.ToString());
            cmbMonth.SelectedIndex = 0;
        }

        private async System.Threading.Tasks.Task LoadAccounts()
        {
            try
            {
                _accounts = await ApiHelper.GetAsync<List<ChartOfAccount>>("chartofaccounts")
                            ?? new List<ChartOfAccount>();

                cmbAccount.Items.Clear();
                cmbAccount.Items.Add(new ChartOfAccount { AccountID = 0, AccountName = "All Accounts" });
                foreach (var a in _accounts)
                    cmbAccount.Items.Add(a);
                cmbAccount.DisplayMember = "AccountName";
                cmbAccount.ValueMember = "AccountID";
                cmbAccount.SelectedIndex = 0;
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadBalances()
        {
            try
            {
                spinner.Start();

                int accountId = cmbAccount.SelectedIndex > 0
                    ? ((ChartOfAccount)cmbAccount.SelectedItem).AccountID : 0;

                int year = (cmbYear.SelectedItem?.ToString() == "All" || cmbYear.SelectedItem == null)
                    ? DateTime.Now.Year
                    : Convert.ToInt32(cmbYear.SelectedItem);

                bool allMonths = (cmbMonth.SelectedItem?.ToString() == "All" || cmbMonth.SelectedIndex == 0);
                int month = allMonths ? DateTime.Now.Month : Convert.ToInt32(cmbMonth.SelectedItem);

                if (accountId > 0)
                {
                    string url = $"accountbalances/balance?AccountID={accountId}&FiscalYear={year}&FiscalMonth={month}";
                    var balance = await ApiHelper.GetAsync<AccountBalance>(url);
                    _balances = balance != null
                        ? new List<AccountBalance> { balance }
                        : new List<AccountBalance>();
                }
                else if (allMonths)
                {
                    _balances = new List<AccountBalance>();
                    for (int m = 1; m <= 12; m++)
                    {
                        string url = $"accountbalances/by-period?FiscalYear={year}&FiscalMonth={m}";
                        var result = await ApiHelper.GetAsync<List<AccountBalance>>(url);
                        if (result != null)
                            _balances.AddRange(result);
                    }
                }
                else
                {
                    string url = $"accountbalances/by-period?FiscalYear={year}&FiscalMonth={month}";
                    _balances = await ApiHelper.GetAsync<List<AccountBalance>>(url)
                                ?? new List<AccountBalance>();
                }

                BindGrid(_balances);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading balances: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<AccountBalance> list)
        {
            if (dgvBalances.Columns.Count == 0)
            {
                dgvBalances.Columns.AddRange(new DataGridViewColumn[] {
            new DataGridViewTextBoxColumn { Name = "colID", HeaderText = "ID", Visible = false },
            new DataGridViewTextBoxColumn { Name = "colAccountCode", HeaderText = "Code", FillWeight = 8F },
            new DataGridViewTextBoxColumn { Name = "colAccountName", HeaderText = "Account Name", FillWeight = 18F },
            new DataGridViewTextBoxColumn { Name = "colAccountNameAr", HeaderText = "Arabic Name", FillWeight = 14F },
            new DataGridViewTextBoxColumn { Name = "colAccountType", HeaderText = "Type", FillWeight = 10F },
            new DataGridViewTextBoxColumn { Name = "colFiscalYear", HeaderText = "Year", FillWeight = 7F },
            new DataGridViewTextBoxColumn { Name = "colFiscalMonth", HeaderText = "Month", FillWeight = 7F },
            new DataGridViewTextBoxColumn { Name = "colOpeningBalance", HeaderText = "Opening", FillWeight = 11F },
            new DataGridViewTextBoxColumn { Name = "colDebitTotal", HeaderText = "Debit Total", FillWeight = 11F },
            new DataGridViewTextBoxColumn { Name = "colCreditTotal", HeaderText = "Credit Total", FillWeight = 11F },
            new DataGridViewTextBoxColumn { Name = "colClosingBalance", HeaderText = "Closing", FillWeight = 11F }
        });
            }

            dgvBalances.Rows.Clear();
            foreach (var b in list)
            {
                dgvBalances.Rows.Add(
                    b.BalanceID,
                    b.AccountCode,
                    b.AccountName,
                    b.AccountNameAr,
                    b.AccountType,
                    b.FiscalYear,
                    b.FiscalMonth,
                    b.OpeningBalance.ToString("N2"),
                    b.DebitTotal.ToString("N2"),
                    b.CreditTotal.ToString("N2"),
                    b.ClosingBalance.ToString("N2")
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadBalances();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbAccount.SelectedIndex = 0;
            cmbYear.SelectedItem = DateTime.Now.Year.ToString();
            cmbMonth.SelectedIndex = 0;
            await LoadBalances();
        }
    }
}