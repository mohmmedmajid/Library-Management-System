using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using System;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmCouponDialog : Form
    {
        private readonly Coupon _coupon;
        private readonly bool _isEdit;

        public FrmCouponDialog(Coupon coupon = null)
        {
            _coupon = coupon;
            _isEdit = coupon != null;
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
            txtCouponCode.Text = _coupon.CouponCode;
            txtCouponName.Text = _coupon.CouponName;
            txtCouponNameAr.Text = _coupon.CouponNameAr;
            cmbDiscountType.SelectedItem = _coupon.DiscountType;
            numDiscountValue.Maximum = _coupon.DiscountType == "Percentage" ? 100 : 9999999;
            numDiscountValue.Value = Math.Max(0, _coupon.DiscountValue);
            lblValueUnit.Text = _coupon.DiscountType == "Percentage" ? "%" : "JD";
            numMinPurchase.Value = Math.Max(0, _coupon.MinimumPurchaseAmount);
            cmbApplicableOn.SelectedItem = _coupon.ApplicableOn;
            if (_coupon.StartDate != DateTime.MinValue) dtpStartDate.Value = _coupon.StartDate;
            if (_coupon.EndDate != DateTime.MinValue) dtpEndDate.Value = _coupon.EndDate;
            chkIsPublic.Checked = _coupon.IsPublic;
            chkIsActive.Checked = _coupon.IsActive;
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
                bool success;
                if (_isEdit)
                {
                    var dto = new UpdateCouponDTO
                    {
                        CouponID = _coupon.CouponID,
                        CouponCode = txtCouponCode.Text.Trim(),
                        CouponName = txtCouponName.Text.Trim(),
                        CouponNameAr = txtCouponNameAr.Text.Trim(),
                        DiscountType = cmbDiscountType.SelectedItem != null ? cmbDiscountType.SelectedItem.ToString() : "",
                        DiscountValue = numDiscountValue.Value,
                        MinimumPurchaseAmount = numMinPurchase.Value,
                        MaximumDiscountAmount = numMaxDiscount.Value,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        UsageLimit = (int)numUsageLimit.Value,
                        UsageLimitPerCustomer = (int)numUsageLimitPerCustomer.Value,
                        IsPublic = chkIsPublic.Checked,
                        Description = txtDescription.Text.Trim(),
                        IsActive = chkIsActive.Checked
                    };
                    var updateResponse = await ApiHelper.PutAsync<SaveCouponResponse>($"Coupons/{_coupon.CouponID}", dto);
                    success = true;
                }
                else
                {
                    var dto = new CreateCouponDTO
                    {
                        CouponCode = txtCouponCode.Text.Trim(),
                        CouponName = txtCouponName.Text.Trim(),
                        CouponNameAr = txtCouponNameAr.Text.Trim(),
                        DiscountType = cmbDiscountType.SelectedItem != null ? cmbDiscountType.SelectedItem.ToString() : "",
                        DiscountValue = numDiscountValue.Value,
                        MinimumPurchaseAmount = numMinPurchase.Value,
                        MaximumDiscountAmount = numMaxDiscount.Value,
                        ApplicableOn = cmbApplicableOn.SelectedItem != null ? cmbApplicableOn.SelectedItem.ToString() : "All",
                        CategoryID = 0,
                        ProductID = 0,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        UsageLimit = (int)numUsageLimit.Value,
                        UsageLimitPerCustomer = (int)numUsageLimitPerCustomer.Value,
                        IsPublic = chkIsPublic.Checked,
                        Description = txtDescription.Text.Trim(),
                        CreatedBy = SessionManager.UserId
                    };
                    var createResponse = await ApiHelper.PostAsync<SaveCouponResponse>("Coupons", dto);
                    success = createResponse != null && createResponse.CouponId > 0;
                }

                if (success)
                {
                    MessageHelper.ShowSuccess(_isEdit ? "Coupon updated successfully." : "Coupon added successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageHelper.ShowError("Operation failed.");
                    btnSave.Enabled = true;
                    btnSave.Text = _isEdit ? "💾  Update" : "💾  Save";
                }
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
            if (string.IsNullOrWhiteSpace(txtCouponCode.Text))
            {
                MessageHelper.ShowWarning("Please enter the coupon code.");
                txtCouponCode.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCouponName.Text))
            {
                MessageHelper.ShowWarning("Please enter the coupon name.");
                txtCouponName.Focus();
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