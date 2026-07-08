using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Sales;
using System;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmSaleInvoiceView : Form
    {
        private const decimal TAX_PERCENT = 16m;
        private readonly string _invoiceNumber;
        private SaleInvoiceFullDTO _invoice;

        public FrmSaleInvoiceView(string invoiceNumber)
        {
            _invoiceNumber = invoiceNumber;
            InitializeComponent();
            this.Load += FrmSaleInvoiceView_Load;
        }

        private async void FrmSaleInvoiceView_Load(object sender, EventArgs e)
        {
            try
            {
                var invoice = await ApiHelper.GetAsync<SaleInvoiceFullDTO>("invoices/by-number/" + Uri.EscapeDataString(_invoiceNumber) + "/full");
                if (invoice == null)
                {
                    MessageHelper.ShowError("Invoice not found.");
                    this.Close();
                    return;
                }

                _invoice = invoice;

                lblInvoiceNumber.Text = "Invoice #: " + invoice.InvoiceNumber;
                lblDate.Text = "Date: " + invoice.InvoiceDate.ToString("yyyy-MM-dd HH:mm");
                lblCustomer.Text = "Customer: " + (string.IsNullOrEmpty(invoice.CustomerName) ? "Walk-in Customer" : invoice.CustomerName);
                lblPaymentType.Text = "Payment Type: " + invoice.PaymentType;
                lblPaymentMethod.Text = "Method: " + invoice.PaymentMethodName;
                lblSalesRep.Text = "Sales Rep: " + (string.IsNullOrEmpty(invoice.SalesRepName) ? "-" : invoice.SalesRepName);
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
                CustomerName = string.IsNullOrEmpty(_invoice.CustomerName) ? "Walk-in Customer" : _invoice.CustomerName,
                PaymentType = _invoice.PaymentType,
                PaymentMethod = _invoice.PaymentMethodName,
                SalesRepName = _invoice.SalesRepName,
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
                        Quantity = d.Quantity,
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