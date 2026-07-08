using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using LibrarySystem.WinForms.Models.Sales;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmSupplierTransactionDialog : Form
    {
        private readonly List<Supplier> _suppliers;
        private readonly SupplierTransaction _editTransaction;
        private readonly bool _isEditMode;

        public FrmSupplierTransactionDialog(List<Supplier> suppliers, SupplierTransaction transaction = null)
        {
            InitializeComponent();
            _suppliers = suppliers;
            _editTransaction = transaction;
            _isEditMode = transaction != null;
        }

        private void FrmSupplierTransactionDialog_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            cmbSupplier.SelectedIndexChanged += CmbSupplier_SelectedIndexChanged;

            if (_isEditMode)
            {
                lblTitle.Text = "Edit Supplier Transaction";
                PopulateFields();
            }
            else
            {
                txtReference.Text = GenerateReferenceNumber();
                txtReference.ReadOnly = true;
                txtReference.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                _ = LoadInvoiceNumbersAsync();
            }
        }

        private string GenerateReferenceNumber()
        {
            return "REF-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
        }

        private void LoadSuppliers()
        {
            cmbSupplier.Items.Clear();
            foreach (var s in _suppliers)
                cmbSupplier.Items.Add(new ComboItem(s.SupplierName, s.SupplierID));
            if (cmbSupplier.Items.Count > 0)
                cmbSupplier.SelectedIndex = 0;
        }

        private async void CmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isEditMode)
                await LoadInvoiceNumbersAsync();
        }

        private async Task LoadInvoiceNumbersAsync()
        {
            try
            {
                var selectedSupplier = cmbSupplier.SelectedItem as ComboItem;
                if (selectedSupplier == null || selectedSupplier.Value == 0) return;

                var invoices = await ApiHelper.GetAsync<List<Invoice>>($"invoices?InvoiceTypeID=6&CustomerID={selectedSupplier.Value}") ?? new List<Invoice>();

                cmbInvoiceNumber.Items.Clear();
                cmbInvoiceNumber.AutoCompleteCustomSource.Clear();

                foreach (var inv in invoices)
                {
                    if (string.IsNullOrEmpty(inv.InvoiceNumber)) continue;
                    cmbInvoiceNumber.Items.Add(inv.InvoiceNumber);
                    cmbInvoiceNumber.AutoCompleteCustomSource.Add(inv.InvoiceNumber);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading invoices: " + ex.Message);
            }
        }

        private void PopulateFields()
        {
            for (int i = 0; i < cmbSupplier.Items.Count; i++)
            {
                if (((ComboItem)cmbSupplier.Items[i]).Value == _editTransaction.SupplierID)
                {
                    cmbSupplier.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbType.Items.Count; i++)
            {
                if (cmbType.Items[i].ToString() == _editTransaction.TransactionType)
                {
                    cmbType.SelectedIndex = i;
                    break;
                }
            }

            txtAmount.Text = _editTransaction.Amount.ToString("N2");
            dtpDate.Value = _editTransaction.TransactionDate;
            cmbInvoiceNumber.Text = _editTransaction.InvoiceNumber;
            txtReference.Text = _editTransaction.ReferenceNumber;
            txtNotes.Text = _editTransaction.Notes;

            cmbSupplier.Enabled = false;
            cmbType.Enabled = false;
            txtReference.ReadOnly = true;
            txtReference.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                btnSave.Enabled = false;
                Cursor = System.Windows.Forms.Cursors.WaitCursor;

                decimal amount = decimal.Parse(txtAmount.Text.Replace(",", ""));

                if (_isEditMode)
                {
                    var dto = new UpdateSupplierTransactionDTO
                    {
                        TransactionID = _editTransaction.TransactionID,
                        Amount = amount,
                        ReferenceNumber = txtReference.Text.Trim(),
                        Notes = BuildNotes()
                    };

                    var result = await ApiHelper.PutAsync<object>($"SupplierTransactions/{dto.TransactionID}", dto);
                    if (result != null)
                    {
                        MessageHelper.ShowSuccess("Transaction updated successfully.");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageHelper.ShowError("Failed to update transaction.");
                    }
                }
                else
                {
                    var selectedSupplier = cmbSupplier.SelectedItem as ComboItem;

                    var dto = new CreateSupplierTransactionDTO
                    {
                        SupplierID = selectedSupplier?.Value ?? 0,
                        TransactionType = cmbType.SelectedItem?.ToString() ?? "",
                        Amount = amount,
                        ReferenceNumber = txtReference.Text.Trim(),
                        Notes = BuildNotes(),
                        CreatedBy = SessionManager.UserId
                    };

                    var result = await ApiHelper.PostAsync<object>("SupplierTransactions", dto);
                    if (result != null)
                    {
                        MessageHelper.ShowSuccess("Transaction added successfully.");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageHelper.ShowError("Failed to add transaction.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error: " + ex.Message);
            }
            finally
            {
                btnSave.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private string BuildNotes()
        {
            string notes = txtNotes.Text.Trim();
            string invoiceNo = cmbInvoiceNumber.Text.Trim();

            if (!string.IsNullOrEmpty(invoiceNo))
            {
                string invoicePart = "Invoice: " + invoiceNo;
                notes = string.IsNullOrEmpty(notes) ? invoicePart : invoicePart + " | " + notes;
            }

            return notes;
        }

        private bool ValidateInput()
        {
            if (cmbSupplier.SelectedItem == null)
            {
                MessageHelper.ShowWarning("Please select a supplier.");
                cmbSupplier.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageHelper.ShowWarning("Please enter the amount.");
                txtAmount.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAmount.Text.Replace(",", ""), out decimal amount) || amount <= 0)
            {
                MessageHelper.ShowWarning("Please enter a valid amount greater than zero.");
                txtAmount.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private class ComboItem
        {
            public string Display { get; }
            public int Value { get; }
            public ComboItem(string display, int value) { Display = display; Value = value; }
            public override string ToString() => Display;
        }
    }
}