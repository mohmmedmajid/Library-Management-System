using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Sales;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmLateFeeDetails : Form
    {
        private readonly LateFee _fee;
        public bool Changed { get; private set; } = false;

        public FrmLateFeeDetails(LateFee fee)
        {
            InitializeComponent();
            _fee = fee;
        }

        private void FrmLateFeeDetails_Load(object sender, EventArgs e)
        {
            ShowDetails(_fee);
        }

        private void ShowDetails(LateFee f)
        {
            lblBorrowNumber.Text = f.BorrowingNumber;
            lblCustomerVal.Text = f.CustomerName;
            lblLateDaysVal.Text = f.LateDays.ToString();
            lblFeePerDayVal.Text = f.FeePerDay.ToString("F2");
            lblTotalFeeVal.Text = f.TotalFee.ToString("F2");
            lblPaidVal.Text = f.PaidAmount.ToString("F2");
            lblRemainingVal.Text = f.RemainingAmount.ToString("F2");
            lblStatusVal.Text = f.Status;

            switch (f.Status)
            {
                case "Pending":
                    lblStatusVal.ForeColor = Color.FromArgb(200, 50, 50);
                    break;
                case "Paid":
                    lblStatusVal.ForeColor = Color.FromArgb(40, 160, 100);
                    break;
                case "Waived":
                    lblStatusVal.ForeColor = Color.FromArgb(120, 120, 120);
                    break;
                default:
                    lblStatusVal.ForeColor = Color.FromArgb(30, 100, 180);
                    break;
            }

            bool isPending = f.Status == "Pending" && f.RemainingAmount > 0;
            pnlPay.Visible = isPending;
            btnPay.Enabled = isPending;
            btnWaive.Enabled = isPending;

            txtPayAmount.Text = f.RemainingAmount.ToString("F2");
            txtNotes.Text = "";
        }

        private void btnPayFull_Click(object sender, EventArgs e)
        {
            txtPayAmount.Text = _fee.RemainingAmount.ToString("F2");
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsValidPrice(txtPayAmount.Text))
            { MessageHelper.ShowWarning("Please enter a valid payment amount."); return; }

            decimal amount = decimal.Parse(txtPayAmount.Text);
            if (amount <= 0)
            { MessageHelper.ShowWarning("Payment amount must be greater than zero."); return; }

            if (amount > _fee.RemainingAmount)
            { MessageHelper.ShowWarning("Payment amount cannot exceed the remaining balance."); return; }

            if (!MessageHelper.ShowConfirm($"Confirm payment of {amount:F2} JD?")) return;

            try
            {
                btnPay.Enabled = false;
                btnWaive.Enabled = false;

                var dto = new UpdateLateFeePaymentDTO
                {
                    LateFeeID = _fee.LateFeeID,
                    PaymentAmount = amount
                };

                await ApiHelper.PostAsync<object>(
                    $"latefees/{_fee.LateFeeID}/payment", dto);

                MessageHelper.ShowSuccess("Payment recorded successfully!");
                Changed = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error recording payment: " + ex.Message);
                btnPay.Enabled = true;
                btnWaive.Enabled = true;
            }
        }

        private async void btnWaive_Click(object sender, EventArgs e)
        {
            if (!MessageHelper.ShowConfirm(
                $"Are you sure you want to waive this fee of {_fee.RemainingAmount:F2} JD?"))
                return;

            try
            {
                btnPay.Enabled = false;
                btnWaive.Enabled = false;

                var dto = new WaiveLateFeeDTO
                {
                    LateFeeID = _fee.LateFeeID,
                    Notes = txtNotes.Text.Trim()
                };

                await ApiHelper.PostAsync<object>(
                    $"latefees/{_fee.LateFeeID}/waive", dto);

                MessageHelper.ShowSuccess("Late fee waived.");
                Changed = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error waiving fee: " + ex.Message);
                btnPay.Enabled = true;
                btnWaive.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}