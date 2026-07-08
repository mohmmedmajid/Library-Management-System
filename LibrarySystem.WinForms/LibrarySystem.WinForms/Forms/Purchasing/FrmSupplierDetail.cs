using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using System;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmSupplierDetail : Form
    {
        private readonly int _supplierId;
        private Supplier _supplier;

        public FrmSupplierDetail(int supplierId)
        {
            InitializeComponent();
            _supplierId = supplierId;
        }


        private async void FrmSupplierDetail_Load(object sender, EventArgs e)
        {
            if (_supplierId > 0)
            {
                lblTitle.Text = "✏️  Edit Supplier";
                this.Text = "Edit Supplier";
                await LoadSupplierAsync();
            }
            else
            {
                lblTitle.Text = "➕  Add New Supplier";
                this.Text = "Add New Supplier";
                chkIsActive.Checked = true;
                numCreditLimit.Value = 0;
            }
        }

        private async System.Threading.Tasks.Task LoadSupplierAsync()
        {
            try
            {
                SetLoading(true);
                _supplier = await ApiHelper.GetAsync<Supplier>("Suppliers/" + _supplierId);

                if (_supplier == null)
                {
                    MessageHelper.ShowError("Supplier not found.");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                txtSupplierName.Text = _supplier.SupplierName;
                txtContactPerson.Text = _supplier.ContactPerson;
                txtPhone.Text = _supplier.Phone;
                txtEmail.Text = _supplier.Email;
                txtPaymentTerms.Text = _supplier.PaymentTerms;
                numCreditLimit.Value = _supplier.CreditLimit;
                chkIsActive.Checked = _supplier.IsActive;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Failed to load supplier.\n" + ex.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            finally
            {
                SetLoading(false);
            }
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var dto = new CreateSupplierDTO
            {
                SupplierName = txtSupplierName.Text.Trim(),
                ContactPerson = txtContactPerson.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PaymentTerms = txtPaymentTerms.Text.Trim(),
                CreditLimit = numCreditLimit.Value,
                CreatedBy = SessionManager.UserId
            };

            try
            {
                SetLoading(true);

                if (_supplierId > 0)
                {
                    var updateDto = new
                    {
                        SupplierID = _supplierId,
                        SupplierName = dto.SupplierName,
                        ContactPerson = dto.ContactPerson,
                        Phone = dto.Phone,
                        Email = dto.Email,
                        PaymentTerms = dto.PaymentTerms,
                        CreditLimit = dto.CreditLimit,
                        IsActive = chkIsActive.Checked
                    };
                    await ApiHelper.PutAsync<Supplier>("Suppliers/" + _supplierId, updateDto);
                    MessageHelper.ShowSuccess("Supplier updated successfully.");
                }
                else
                {
                    await ApiHelper.PostAsync<Supplier>("Suppliers", dto);
                    MessageHelper.ShowSuccess("Supplier added successfully.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Failed to save supplier.\n" + ex.Message);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private bool ValidateForm()
        {
            if (ValidationHelper.IsEmpty(txtSupplierName.Text))
            {
                MessageHelper.ShowWarning("Supplier name is required.");
                txtSupplierName.Focus();
                return false;
            }

            if (txtSupplierName.Text.Trim().Length < 2)
            {
                MessageHelper.ShowWarning("Supplier name must be at least 2 characters.");
                txtSupplierName.Focus();
                return false;
            }

            if (ValidationHelper.IsEmpty(txtPhone.Text))
            {
                MessageHelper.ShowWarning("Phone number is required.");
                txtPhone.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidPhone(txtPhone.Text))
            {
                MessageHelper.ShowWarning("Please enter a valid phone number.");
                txtPhone.Focus();
                return false;
            }

            if (!ValidationHelper.IsEmpty(txtEmail.Text) && !ValidationHelper.IsValidEmail(txtEmail.Text))
            {
                MessageHelper.ShowWarning("Please enter a valid email address.");
                txtEmail.Focus();
                return false;
            }

            return true;
        }


        private void SetLoading(bool loading)
        {
            this.Cursor = loading ? Cursors.WaitCursor : Cursors.Default;
            btnSave.Enabled = !loading;
            btnCancel.Enabled = !loading;
        }
    }
}