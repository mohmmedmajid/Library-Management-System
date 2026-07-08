using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmExpenseDialog : Form
    {
        private readonly Expense _editExpense;
        private readonly bool _isEditMode;
        private List<ExpenseCategory> _categories = new List<ExpenseCategory>();
        private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();

        public FrmExpenseDialog(Expense expense = null)
        {
            InitializeComponent();
            _editExpense = expense;
            _isEditMode = expense != null;
        }

        private async void FrmExpenseDialog_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadPaymentMethodsAsync();

            if (_isEditMode)
            {
                lblTitle.Text = "Edit Expense";
                PopulateFields();
            }
        }

        private async System.Threading.Tasks.Task LoadCategoriesAsync()
        {
            try
            {
                _categories = await ApiHelper.GetAsync<List<ExpenseCategory>>("ExpenseCategories?isActive=true")
                              ?? new List<ExpenseCategory>();
                cmbCategory.Items.Clear();
                foreach (var c in _categories)
                    cmbCategory.Items.Add(new ComboItem(c.CategoryName, c.ExpenseCategoryID));
                if (cmbCategory.Items.Count > 0)
                    cmbCategory.SelectedIndex = 0;
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadPaymentMethodsAsync()
        {
            try
            {
                _paymentMethods = await ApiHelper.GetAsync<List<PaymentMethod>>("PaymentMethods?isActive=true")
                                  ?? new List<PaymentMethod>();
                cmbPaymentMethod.Items.Clear();
                foreach (var p in _paymentMethods)
                    cmbPaymentMethod.Items.Add(new ComboItem(p.MethodName, p.PaymentMethodID));
                if (cmbPaymentMethod.Items.Count > 0)
                    cmbPaymentMethod.SelectedIndex = 0;
            }
            catch { }
        }

        private void PopulateFields()
        {
            for (int i = 0; i < cmbCategory.Items.Count; i++)
            {
                if (((ComboItem)cmbCategory.Items[i]).Value == _editExpense.ExpenseCategoryID)
                { cmbCategory.SelectedIndex = i; break; }
            }

            for (int i = 0; i < cmbPaymentMethod.Items.Count; i++)
            {
                if (((ComboItem)cmbPaymentMethod.Items[i]).Value == _editExpense.PaymentMethodID)
                { cmbPaymentMethod.SelectedIndex = i; break; }
            }

            dtpDate.Value = _editExpense.ExpenseDate;
            txtAmount.Text = _editExpense.Amount.ToString("N2");
            txtSupplier.Text = _editExpense.SupplierName;
            txtReference.Text = _editExpense.ReferenceNumber;
            txtReceipt.Text = _editExpense.ReceiptNumber;
            txtDescription.Text = _editExpense.Description;

            for (int i = 0; i < cmbStatus.Items.Count; i++)
            {
                if (cmbStatus.Items[i].ToString() == _editExpense.Status)
                { cmbStatus.SelectedIndex = i; break; }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                btnSave.Enabled = false;
                Cursor = System.Windows.Forms.Cursors.WaitCursor;

                decimal amount = decimal.Parse(txtAmount.Text.Replace(",", ""));
                var selectedCategory = cmbCategory.SelectedItem as ComboItem;
                var selectedPaymentMethod = cmbPaymentMethod.SelectedItem as ComboItem;

                if (_isEditMode)
                {
                    var dto = new UpdateExpenseDTO
                    {
                        ExpenseID = _editExpense.ExpenseID,
                        ExpenseCategoryID = selectedCategory?.Value ?? 0,
                        ExpenseDate = dtpDate.Value,
                        Amount = amount,
                        PaymentMethodID = selectedPaymentMethod?.Value ?? 0,
                        ReferenceNumber = txtReference.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        SupplierID = null,
                        ReceiptNumber = txtReceipt.Text.Trim(),
                        Status = cmbStatus.SelectedItem?.ToString() ?? "Paid"
                    };

                    await ApiHelper.PutAsync<object>($"Expenses/{dto.ExpenseID}", dto);
                    MessageHelper.ShowSuccess("Expense updated successfully.");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    var dto = new CreateExpenseDTO
                    {
                        ExpenseCategoryID = selectedCategory?.Value ?? 0,
                        ExpenseDate = dtpDate.Value,
                        Amount = amount,
                        PaymentMethodID = selectedPaymentMethod?.Value ?? 0,
                        ReferenceNumber = txtReference.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        ReceiptNumber = txtReceipt.Text.Trim(),
                        Status = cmbStatus.SelectedItem?.ToString() ?? "Paid",
                        CreatedBy = SessionManager.UserId
                    };

                    var result = await ApiHelper.PostAsync<object>("Expenses", dto);
                    if (result != null)
                    {
                        MessageHelper.ShowSuccess("Expense added successfully.");
                        DialogResult = DialogResult.OK;
                    }
                    else MessageHelper.ShowError("Failed to add expense.");
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

        private bool ValidateInput()
        {
            if (cmbCategory.SelectedItem == null)
            {
                MessageHelper.ShowWarning("Please select a category.");
                cmbCategory.Focus();
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

            if (cmbPaymentMethod.SelectedItem == null)
            {
                MessageHelper.ShowWarning("Please select a payment method.");
                cmbPaymentMethod.Focus();
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