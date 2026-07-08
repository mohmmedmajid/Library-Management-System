using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.Purchasing;
using LibrarySystem.WinForms.Models.DTOs;
using System;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmExpenseCategoryDialog : Form
    {
        private readonly ExpenseCategory _editCategory;
        private readonly bool _isEditMode;

        public FrmExpenseCategoryDialog(ExpenseCategory category = null)
        {
            InitializeComponent();
            _editCategory = category;
            _isEditMode = category != null;
        }

        private void FrmExpenseCategoryDialog_Load(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                lblTitle.Text = "Edit Expense Category";
                txtName.Text = _editCategory.CategoryName;
                txtNameAr.Text = _editCategory.CategoryNameAr;
                txtDescription.Text = _editCategory.Description;
                chkIsActive.Checked = _editCategory.IsActive;
            }
            else
            {
                lblTitle.Text = "Add Expense Category";
                chkIsActive.Checked = true;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                btnSave.Enabled = false;
                Cursor = Cursors.WaitCursor;

                if (_isEditMode)
                {
                    var dto = new UpdateExpenseCategoryDTO
                    {
                        ExpenseCategoryID = _editCategory.ExpenseCategoryID,
                        CategoryName = txtName.Text.Trim(),
                        CategoryNameAr = txtNameAr.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        IsActive = chkIsActive.Checked
                    };

                    await ApiHelper.PutAsync<object>(
                        $"ExpenseCategories/{dto.ExpenseCategoryID}", dto);

                    MessageHelper.ShowSuccess("Category updated successfully.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    var dto = new CreateExpenseCategoryDTO
                    {
                        CategoryName = txtName.Text.Trim(),
                        CategoryNameAr = txtNameAr.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        CreatedBy = SessionManager.UserId
                    };

                    var result = await ApiHelper.PostAsync<object>("ExpenseCategories", dto);

                    if (result != null)
                    {
                        MessageHelper.ShowSuccess("Category added successfully.");
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageHelper.ShowError("Failed to add category.");
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
                Cursor = Cursors.Default;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageHelper.ShowWarning("Please enter the category name.");
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}