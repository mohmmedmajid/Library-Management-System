using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using System;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmDiscountDialog : Form
    {
        private readonly Discount _discount;
        private readonly bool _isEdit;

        public FrmDiscountDialog(Discount discount = null)
        {
            _discount = discount;
            _isEdit = discount != null;
            InitializeComponent();
            SetupComboBoxes();
            if (_isEdit) PopulateFields();
        }

        private void SetupComboBoxes()
        {
            cmbDiscountType.Items.Clear();
            cmbDiscountType.Items.AddRange(new object[] { "Percentage", "FixedAmount" });
            cmbDiscountType.SelectedIndex = 0;

            cmbApplicableOn.Items.Clear();
            cmbApplicableOn.Items.AddRange(new object[] { "All", "Category", "Product" });
            cmbApplicableOn.SelectedIndex = 0;
        }

        private void PopulateFields()
        {
            txtDiscountName.Text = _discount.DiscountName;
            txtDiscountNameAr.Text = _discount.DiscountNameAr;
            cmbDiscountType.SelectedItem = _discount.DiscountType;
            numDiscountValue.Maximum = _discount.DiscountType == "Percentage" ? 100 : 9999999;
            numDiscountValue.Value = Math.Max(0, _discount.DiscountValue);
            lblValueUnit.Text = _discount.DiscountType == "Percentage" ? "%" : "JD";
            numMinPurchase.Value = Math.Max(0, _discount.MinimumPurchaseAmount);
            numMaxDiscount.Value = Math.Max(0, _discount.MaximumDiscountAmount ?? 0);
            cmbApplicableOn.SelectedItem = _discount.ApplicableOn;
            if (_discount.StartDate != DateTime.MinValue) dtpStartDate.Value = _discount.StartDate;
            if (_discount.EndDate != DateTime.MinValue) dtpEndDate.Value = _discount.EndDate;
            chkIsActive.Checked = _discount.IsActive;
        }

        private void cmbDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isPct = cmbDiscountType.SelectedItem != null && cmbDiscountType.SelectedItem.ToString() == "Percentage";
            numDiscountValue.Maximum = isPct ? 100 : 9999999;
            lblValueUnit.Text = isPct ? "%" : "JD";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            btnSave.Enabled = false;
            btnSave.Text = "Saving...";

            try
            {
                if (_isEdit)
                {
                    var dto = new UpdateDiscountDTO
                    {
                        DiscountID = _discount.DiscountID,
                        DiscountName = txtDiscountName.Text.Trim(),
                        DiscountNameAr = txtDiscountNameAr.Text.Trim(),
                        DiscountType = cmbDiscountType.SelectedItem != null ? cmbDiscountType.SelectedItem.ToString() : "",
                        DiscountValue = numDiscountValue.Value,
                        MinimumPurchaseAmount = numMinPurchase.Value,
                        MaximumDiscountAmount = numMaxDiscount.Value,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        UsageLimit = (int)numUsageLimit.Value,
                        IsActive = chkIsActive.Checked
                    };

                    await ApiHelper.PutAsync<object>($"Discounts/{dto.DiscountID}", dto);
                }
                else
                {
                    var dto = new CreateDiscountDTO
                    {
                        DiscountName = txtDiscountName.Text.Trim(),
                        DiscountNameAr = txtDiscountNameAr.Text.Trim(),
                        DiscountType = cmbDiscountType.SelectedItem != null ? cmbDiscountType.SelectedItem.ToString() : "",
                        DiscountValue = numDiscountValue.Value,
                        MinimumPurchaseAmount = numMinPurchase.Value,
                        MaximumDiscountAmount = numMaxDiscount.Value,
                        ApplicableOn = cmbApplicableOn.SelectedItem != null ? cmbApplicableOn.SelectedItem.ToString() : "All",
                        CategoryID = null,
                        ProductID = null,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        UsageLimit = (int)numUsageLimit.Value,
                        CreatedBy = SessionManager.UserId
                    };

                    await ApiHelper.PostAsync<object>("Discounts", dto);
                }

                MessageHelper.ShowSuccess(_isEdit ? "Discount updated successfully." : "Discount added successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error: " + ex.Message);
                btnSave.Enabled = true;
                btnSave.Text = _isEdit ? "💾  Update" : "💾  Save";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDiscountName.Text))
            {
                MessageHelper.ShowWarning("Please enter the discount name.");
                txtDiscountName.Focus();
                return false;
            }
            if (numDiscountValue.Value <= 0)
            {
                MessageHelper.ShowWarning("Please enter a discount value greater than 0.");
                numDiscountValue.Focus();
                return false;
            }
            if (cmbDiscountType.SelectedItem != null && cmbDiscountType.SelectedItem.ToString() == "Percentage" && numDiscountValue.Value > 100)
            {
                MessageHelper.ShowWarning("Percentage cannot exceed 100%.");
                numDiscountValue.Focus();
                return false;
            }
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageHelper.ShowWarning("End date must be after start date.");
                dtpEndDate.Focus();
                return false;
            }
            return true;
        }
    }
}