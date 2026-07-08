using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmSupplierTransactions : Form
    {
        private List<SupplierTransaction> _allTransactions = new List<SupplierTransaction>();
        private List<Supplier> _suppliers = new List<Supplier>();
        private int _selectedTransactionId = 0;
        private int _filterSupplierId = 0;

        private const string SearchPlaceholder = "Search by supplier, invoice number, reference...";
        private bool _isPlaceholderActive = false;

        public FrmSupplierTransactions(int supplierId = 0)
        {
            InitializeComponent();
            _filterSupplierId = supplierId;
        }

        private async void FrmSupplierTransactions_Load(object sender, EventArgs e)
        {
            SetupForm();
            await LoadSuppliersAsync();
            await LoadTransactionsAsync();
        }

        private void SetupForm()
        {
            SetupFilters();
            SetupSearchPlaceholder();

            if (_filterSupplierId > 0)
                cmbFilterSupplier.Enabled = false;
        }

        private void SetupFilters()
        {
            cmbTransactionType.Items.Clear();
            cmbTransactionType.Items.Add(new ComboItem("All", ""));
            cmbTransactionType.Items.Add(new ComboItem("Purchase", "Purchase"));
            cmbTransactionType.Items.Add(new ComboItem("Payment", "Payment"));
            cmbTransactionType.Items.Add(new ComboItem("Return", "Return"));
            cmbTransactionType.SelectedIndex = 0;

            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
        }

        private void SetupSearchPlaceholder()
        {
            ShowPlaceholder();
        }

        private void ShowPlaceholder()
        {
            _isPlaceholderActive = true;
            txtSearch.Text = SearchPlaceholder;
            txtSearch.ForeColor = Color.Gray;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (_isPlaceholderActive)
            {
                _isPlaceholderActive = false;
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                ShowPlaceholder();
        }

        private async Task LoadSuppliersAsync()
        {
            try
            {
                _suppliers = await ApiHelper.GetAsync<List<Supplier>>("Suppliers?isActive=true") ?? new List<Supplier>();

                cmbFilterSupplier.Items.Clear();
                cmbFilterSupplier.Items.Add(new ComboItem("All Suppliers", 0));
                foreach (var s in _suppliers)
                    cmbFilterSupplier.Items.Add(new ComboItem(s.SupplierName, s.SupplierID));

                if (_filterSupplierId > 0)
                {
                    for (int i = 0; i < cmbFilterSupplier.Items.Count; i++)
                    {
                        if (((ComboItem)cmbFilterSupplier.Items[i]).Value == _filterSupplierId)
                        {
                            cmbFilterSupplier.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cmbFilterSupplier.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading suppliers: " + ex.Message);
            }
        }

        private async Task LoadTransactionsAsync()
        {
            try
            {
                ShowLoading(true);

                var selectedSupplier = cmbFilterSupplier.SelectedItem as ComboItem;
                int supplierId = _filterSupplierId > 0 ? _filterSupplierId : (selectedSupplier?.Value ?? 0);
                string type = (cmbTransactionType.SelectedItem as ComboItem)?.Text2 ?? "";
                string start = dtpStartDate.Value.ToString("yyyy-MM-dd");
                string end = dtpEndDate.Value.ToString("yyyy-MM-dd");

                string url;
                if (supplierId > 0)
                    url = $"SupplierTransactions/supplier/{supplierId}?startDate={start}&endDate={end}";
                else
                    url = $"SupplierTransactions?transactionType={type}&startDate={start}&endDate={end}";

                _allTransactions = await ApiHelper.GetAsync<List<SupplierTransaction>>(url) ?? new List<SupplierTransaction>();

                if (supplierId == 0 && !string.IsNullOrEmpty(type))
                    _allTransactions = _allTransactions.Where(t => t.TransactionType == type).ToList();

                ApplySearchFilter();
                UpdateSummary();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading transactions: " + ex.Message);
            }
            finally
            {
                ShowLoading(false);
            }
        }

        private void ApplySearchFilter()
        {
            string search = _isPlaceholderActive ? "" : txtSearch.Text.Trim().ToLower();

            var filtered = string.IsNullOrEmpty(search)
                ? _allTransactions
                : _allTransactions.Where(t =>
                    t.SupplierName.ToLower().Contains(search) ||
                    (t.InvoiceNumber ?? "").ToLower().Contains(search) ||
                    (t.ReferenceNumber ?? "").ToLower().Contains(search) ||
                    (t.Notes ?? "").ToLower().Contains(search)).ToList();

            dgvTransactions.DataSource = null;
            dgvTransactions.DataSource = filtered;
            lblCount.Text = $"Total: {filtered.Count} transactions";
        }

        private void UpdateSummary()
        {
            decimal totalPurchases = _allTransactions.Where(t => t.TransactionType == "Purchase").Sum(t => t.Amount);
            decimal totalPayments = _allTransactions.Where(t => t.TransactionType == "Payment").Sum(t => t.Amount);
            decimal totalReturns = _allTransactions.Where(t => t.TransactionType == "Return").Sum(t => t.Amount);
            decimal balance = totalPurchases - totalPayments - totalReturns;

            lblTotalPurchases.Text = $"Total Purchases: {totalPurchases:N2}";
            lblTotalPayments.Text = $"Total Payments: {totalPayments:N2}";
            lblBalance.Text = $"Balance: {balance:N2}";
            lblBalance.ForeColor = balance > 0 ? Color.DarkRed : Color.DarkGreen;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmSupplierTransactionDialog(_suppliers))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    _ = LoadTransactionsAsync();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedTransactionId == 0) { MessageHelper.ShowWarning("Please select a transaction first."); return; }
            var tr = _allTransactions.FirstOrDefault(t => t.TransactionID == _selectedTransactionId);
            if (tr == null) return;

            using (var frm = new FrmSupplierTransactionDialog(_suppliers, tr))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    _ = LoadTransactionsAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedTransactionId == 0) { MessageHelper.ShowWarning("Please select a transaction first."); return; }
            if (!MessageHelper.ShowConfirm("Are you sure you want to delete this transaction?")) return;

            try
            {
                bool ok = await ApiHelper.DeleteAsync($"SupplierTransactions/{_selectedTransactionId}");
                if (ok) { MessageHelper.ShowSuccess("Transaction deleted successfully."); await LoadTransactionsAsync(); }
                else { MessageHelper.ShowError("Failed to delete transaction."); }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void dgvTransactions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow?.DataBoundItem is SupplierTransaction tr)
            {
                _selectedTransactionId = tr.TransactionID;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                _selectedTransactionId = 0;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplySearchFilter();

        private async void btnSearch_Click(object sender, EventArgs e) => await LoadTransactionsAsync();

        private async void btnRefresh_Click(object sender, EventArgs e) => await LoadTransactionsAsync();

        private void ShowLoading(bool show)
        {
            Cursor = show ? Cursors.WaitCursor : Cursors.Default;
            btnSearch.Enabled = !show;
        }

        private class ComboItem
        {
            public string Display { get; }
            public int Value { get; }
            public string Text2 { get; }
            public ComboItem(string display, int value) { Display = display; Value = value; Text2 = ""; }
            public ComboItem(string display, string text2) { Display = display; Value = 0; Text2 = text2; }
            public override string ToString() => Display;
        }
    }
}