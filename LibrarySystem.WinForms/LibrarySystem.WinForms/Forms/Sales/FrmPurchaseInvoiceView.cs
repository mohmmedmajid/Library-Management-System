using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Purchases;
using System;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchases
{
    public partial class FrmPurchaseInvoiceView : Form
    {
        private const decimal TAX_PERCENT = 16m;
        private readonly string _invoiceNumber;
        private PurchaseInvoiceFullDTO _invoice;

        public FrmPurchaseInvoiceView(string invoiceNumber)
        {
            _invoiceNumber = invoiceNumber;
            InitializeComponent();
            this.Load += FrmPurchaseInvoiceView_Load;
        }

        private async void FrmPurchaseInvoiceView_Load(object sender, EventArgs e)
        {
            try
            {
                var invoice = await ApiHelper.GetAsync<PurchaseInvoiceFullDTO>("invoices/by-number/" + Uri.EscapeDataString(_invoiceNumber) + "/full");
                if (invoice == null)
                {
                    MessageHelper.ShowError("Invoice not found.");
                    this.Close();
                    return;
                }

                _invoice = invoice;

                lblInvoiceNumber.Text = "Invoice #: " + invoice.InvoiceNumber;
                lblDate.Text = "Date: " + invoice.InvoiceDate.ToString("yyyy-MM-dd HH:mm");
                lblSupplier.Text = "Supplier: " + (string.IsNullOrEmpty(invoice.SupplierName) ? "-" : invoice.SupplierName);
                lblPaymentType.Text = "Payment Type: " + invoice.PaymentType;
                lblPaymentMethod.Text = "Method: " + invoice.PaymentMethodName;
                lblNotes.Text = "Notes: " + invoice.Notes;

                dgvItems.Rows.Clear();
                if (invoice.Details != null)
                {
                    foreach (var d in invoice.Details)
                    {
                        dgvItems.Rows.Add(
                            d.ProductName,
                            d.Quantity,
                            d.UnitPrice.ToString("F3"),
                            d.DiscountAmount.ToString("F3"),
                            d.TotalPrice.ToString("F3")
                        );
                    }
                }

                lblSubTotal.Text = invoice.SubTotal.ToString("F3");
                lblDiscount.Text = invoice.DiscountAmount.ToString("F3");
                lblTax.Text = invoice.TaxAmount.ToString("F3");
                lblTotal.Text = invoice.TotalAmount.ToString("F3");
                lblPaid.Text = invoice.PaidAmount.ToString("F3");
                lblRemaining.Text = invoice.RemainingAmount.ToString("F3");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading invoice: " + ex.Message);
                this.Close();
            }
        }

        private PrintInvoiceData BuildPrintData()
        {
            var data = new PrintInvoiceData
            {
                InvoiceNumber = _invoice.InvoiceNumber,
                InvoiceDate = _invoice.InvoiceDate,
                CustomerName = string.IsNullOrEmpty(_invoice.SupplierName) ? "-" : _invoice.SupplierName,
                PaymentType = _invoice.PaymentType,
                PaymentMethod = _invoice.PaymentMethodName,
                SalesRepName = "",
                Notes = _invoice.Notes,
                SubTotal = _invoice.SubTotal,
                DiscountAmount = _invoice.DiscountAmount,
                TaxAmount = _invoice.TaxAmount,
                TaxPercent = TAX_PERCENT,
                TotalAmount = _invoice.TotalAmount,
                PaidAmount = _invoice.PaidAmount,
                RemainingAmount = _invoice.RemainingAmount
            };

            if (_invoice.Details != null)
            {
                foreach (var d in _invoice.Details)
                {
                    data.Lines.Add(new PrintInvoiceLine
                    {
                        ProductName = d.ProductName,
                        Quantity = (int)d.Quantity,
                        UnitPrice = d.UnitPrice,
                        DiscountAmount = d.DiscountAmount,
                        Total = d.TotalPrice
                    });
                }
            }

            return data;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_invoice == null)
            {
                MessageHelper.ShowWarning("Invoice not loaded yet.");
                return;
            }

            var data = BuildPrintData();

            if (chkThermalPrint.Checked)
                InvoicePrinter.PrintInvoiceThermal(data, showPreview: true);
            else
                InvoicePrinter.PrintInvoice(data, showPreview: true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}