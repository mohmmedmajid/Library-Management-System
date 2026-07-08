using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmCustomerTransactions : Form
    {
        private readonly int _customerID;
        private readonly string _customerName;
        private List<CustomerTransaction> _transactions = new List<CustomerTransaction>();

        public FrmCustomerTransactions(int customerID, string customerName)
        {
            InitializeComponent();
            _customerID = customerID;
            _customerName = customerName;

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(50, 50);
            pnlFilter.Controls.Add(spinner);

            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
        }

        private void DgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int typeCol = dgvTransactions.Columns["colTransactionType"].Index;
            int amountCol = dgvTransactions.Columns["colAmount"].Index;

            if (e.ColumnIndex == typeCol)
            {
                string type = e.Value?.ToString() ?? "";
                switch (type)
                {
                    case "Sale":
                        e.CellStyle.ForeColor = Color.FromArgb(30, 100, 180);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                    case "Borrowing":
                        e.CellStyle.ForeColor = Color.FromArgb(100, 60, 160);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                    case "Return":
                        e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                    case "LateFee":
                        e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                    case "Payment":
                        e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                    case "Refund":
                        e.CellStyle.ForeColor = Color.FromArgb(200, 100, 0);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                }
            }
            else if (e.ColumnIndex == amountCol)
            {
                string type = dgvTransactions.Rows[e.RowIndex].Cells["colTransactionType"].Value?.ToString() ?? "";
                if (type == "Return" || type == "Refund")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(200, 100, 0);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
                else if (type == "Payment")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
            }
        }

        private async void FrmCustomerTransactions_Load(object sender, EventArgs e)
        {
            lblCustomerName.Text = "👤 " + _customerName;
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            await LoadTransactions();
            await LoadCustomerSummary();
        }

        private async System.Threading.Tasks.Task LoadCustomerSummary()
        {
            try
            {
                decimal totalPurchases = 0, totalDebt = 0, totalLateFees = 0;
                int totalBorrow = 0;

                foreach (var t in _transactions)
                {
                    switch (t.TransactionType)
                    {
                        case "Sale":
                            totalPurchases += t.Amount;
                            break;
                        case "Borrowing":
                            totalBorrow++;
                            break;
                        case "LateFee":
                            totalLateFees += t.Amount;
                            break;
                    }
                }

                var customer = await ApiHelper.GetAsync<Customer>("customers/" + _customerID);
                if (customer != null)
                {
                    totalDebt = customer.TotalDebt;
                }

                lblTotalPurchases.Text = totalPurchases.ToString("F2");
                lblTotalBorrow.Text = totalBorrow.ToString();
                lblTotalDebt.Text = totalDebt.ToString("F2");
                lblTotalLateFees.Text = totalLateFees.ToString("F2");

                lblTotalDebt.ForeColor = totalDebt > 0
                    ? Color.FromArgb(200, 50, 50)
                    : Color.FromArgb(40, 160, 100);
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadTransactions()
        {
            try
            {
                spinner.Start();
                string endpoint = $"customertransactions/by-customer?CustomerID={_customerID}&StartDate={dtpFrom.Value:yyyy-MM-dd}&EndDate={dtpTo.Value:yyyy-MM-dd}";
                _transactions = await ApiHelper.GetAsync<List<CustomerTransaction>>(endpoint)
                                ?? new List<CustomerTransaction>();
                BindGrid(_transactions);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading transactions: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<CustomerTransaction> list)
        {
            dgvTransactions.Rows.Clear();
            foreach (var t in list)
            {
                dgvTransactions.Rows.Add(
                    t.TransactionID,
                    t.TransactionDate.ToString("yyyy-MM-dd HH:mm"),
                    t.TransactionType,
                    t.InvoiceNumber ?? "",
                    t.Amount.ToString("F2"),
                    t.Notes ?? "",
                    t.CreatedByName ?? ""
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            { MessageHelper.ShowWarning("Start date must be before end date."); return; }
            await LoadTransactions();
            await LoadCustomerSummary();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            await LoadTransactions();
            await LoadCustomerSummary();
        }
    }
}