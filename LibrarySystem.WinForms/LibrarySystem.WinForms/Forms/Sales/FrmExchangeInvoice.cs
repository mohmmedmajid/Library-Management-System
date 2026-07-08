using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Sales;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmExchangeInvoice : Form
    {
        private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();
        private InvoiceSearchResult _selectedInvoice = null;
        private List<ReturnableInvoiceDetail> _returnableDetails = new List<ReturnableInvoiceDetail>();
        private ReturnableInvoiceDetail _selectedOldDetail = null;
        private Product _selectedNewProduct = null;

        private PrintInvoiceData _lastExchangeForPrint = null;

        public FrmExchangeInvoice()
        {
            InitializeComponent();
        }

        private async void FrmExchangeInvoice_Load(object sender, EventArgs e)
        {
            await LoadPaymentMethods();
        }

        private async Task LoadPaymentMethods()
        {
            try
            {
                var list = await ApiHelper.GetAsync<List<PaymentMethod>>("paymentmethods");
                _paymentMethods = list ?? new List<PaymentMethod>();
                cmbPaymentMethod.DataSource = _paymentMethods;
                cmbPaymentMethod.DisplayMember = "MethodName";
                cmbPaymentMethod.ValueMember = "PaymentMethodID";
            }
            catch { }
        }

        private async void btnSearchByNumber_Click(object sender, EventArgs e)
        {
            string number = txtInvoiceNumber.Text.Trim();
            if (string.IsNullOrEmpty(number))
            {
                MessageHelper.ShowWarning("Please enter an invoice number.");
                return;
            }

            try
            {
                var dto = new SearchInvoiceByNumberDTO { InvoiceNumber = number };
                var result = await ApiHelper.PostAsync<InvoiceSearchResult>("salereturns/search-by-number", dto);
                if (result == null)
                {
                    MessageHelper.ShowWarning("Invoice not found.");
                    return;
                }
                await SelectInvoice(result);
            }
            catch (Exception ex) { MessageHelper.ShowError("Search error: " + ex.Message); }
        }

        private async void btnSearchByBarcode_Click(object sender, EventArgs e)
        {
            string barcode = txtBarcode.Text.Trim();
            if (string.IsNullOrEmpty(barcode))
            {
                MessageHelper.ShowWarning("Please enter a barcode.");
                return;
            }

            try
            {
                var dto = new SearchInvoiceByBarcodeDTO { Barcode = barcode };
                var results = await ApiHelper.PostAsync<List<InvoiceSearchResult>>("salereturns/search-by-barcode", dto);
                if (results == null || results.Count == 0)
                {
                    MessageHelper.ShowWarning("No invoices found for this barcode.");
                    return;
                }

                if (results.Count == 1)
                    await SelectInvoice(results[0]);
                else
                    ShowInvoicePicker(results);
            }
            catch (Exception ex) { MessageHelper.ShowError("Search error: " + ex.Message); }
        }

        private async void btnSearchByCustomer_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim();
            if (string.IsNullOrEmpty(customerName))
            {
                MessageHelper.ShowWarning("Please enter a customer name.");
                return;
            }

            try
            {
                var dto = new SearchInvoiceByCustomerNameDTO { CustomerName = customerName };
                var results = await ApiHelper.PostAsync<List<InvoiceSearchResult>>("salereturns/search-by-customer-name", dto);
                if (results == null || results.Count == 0)
                {
                    MessageHelper.ShowWarning("No invoices found for this customer.");
                    return;
                }

                if (results.Count == 1)
                    await SelectInvoice(results[0]);
                else
                    ShowInvoicePicker(results);
            }
            catch (Exception ex) { MessageHelper.ShowError("Search error: " + ex.Message); }
        }

        private void ShowInvoicePicker(List<InvoiceSearchResult> invoices)
        {
            Form dlg = new Form
            {
                Text = "Select Invoice",
                Size = new Size(600, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            ListBox lb = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10f)
            };

            foreach (var inv in invoices)
                lb.Items.Add(inv.InvoiceNumber + "  |  " + inv.InvoiceDate.ToString("yyyy-MM-dd") + "  |  " + (inv.CustomerName ?? "-") + "  |  Total: " + inv.TotalAmount.ToString("F3"));

            Button btn = new Button
            {
                Text = "Select",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.FromArgb(30, 100, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            List<InvoiceSearchResult> captured = invoices;
            btn.Click += async delegate
            {
                if (lb.SelectedIndex >= 0)
                {
                    var selected = captured[lb.SelectedIndex];
                    dlg.Close();
                    await SelectInvoice(selected);
                }
            };

            dlg.Controls.Add(lb);
            dlg.Controls.Add(btn);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private async Task SelectInvoice(InvoiceSearchResult invoice)
        {
            _selectedInvoice = invoice;
            lblSelectedInvoice.Text = "Invoice: " + invoice.InvoiceNumber + "  |  Date: " + invoice.InvoiceDate.ToString("yyyy-MM-dd") + "  |  Customer: " + (invoice.CustomerName ?? "-");

            await LoadReturnableDetails(invoice.InvoiceID);
        }

        private async Task LoadReturnableDetails(int invoiceId)
        {
            try
            {
                var dto = new GetReturnableDetailsDTO { InvoiceID = invoiceId };
                var results = await ApiHelper.PostAsync<List<ReturnableInvoiceDetail>>("salereturns/returnable-details", dto);
                _returnableDetails = results ?? new List<ReturnableInvoiceDetail>();

                cmbOldProduct.DataSource = null;
                cmbOldProduct.DisplayMember = "ProductName";
                cmbOldProduct.ValueMember = "InvoiceDetailID";
                cmbOldProduct.DataSource = _returnableDetails;

                if (_returnableDetails.Count == 0)
                    MessageHelper.ShowWarning("No exchangeable items found for this invoice.");
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading items: " + ex.Message); }
        }

        private void cmbOldProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedOldDetail = cmbOldProduct.SelectedItem as ReturnableInvoiceDetail;
            if (_selectedOldDetail != null)
            {
                nudOldQty.Maximum = _selectedOldDetail.ReturnableQuantity > 0 ? _selectedOldDetail.ReturnableQuantity : 1;
                nudOldQty.Value = 1;
                lblOldUnitPrice.Text = "Unit Price: " + _selectedOldDetail.UnitPrice.ToString("F3") + "  |  Max Qty: " + _selectedOldDetail.ReturnableQuantity;
            }
            else
            {
                lblOldUnitPrice.Text = "";
            }
            RecalcDifference();
        }

        private async void btnSearchNewProduct_Click(object sender, EventArgs e)
        {
            string term = txtSearchNewProduct.Text.Trim();
            if (string.IsNullOrEmpty(term)) return;

            try
            {
                var dto = new SearchProductDTO { SearchTerm = term };
                var results = await ApiHelper.PostAsync<List<Product>>("products/search", dto);
                if (results == null || results.Count == 0)
                {
                    MessageHelper.ShowWarning("No products found.");
                    return;
                }

                if (results.Count == 1)
                {
                    _selectedNewProduct = results[0];
                    txtSearchNewProduct.Text = _selectedNewProduct.ProductName;
                    lblNewUnitPrice.Text = "Unit Price: " + _selectedNewProduct.UnitPrice.ToString("F3") + "  |  Available: " + _selectedNewProduct.AvailableQuantity;
                    RecalcDifference();
                }
                else
                {
                    ShowProductPicker(results);
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Search error: " + ex.Message); }
        }

        private void ShowProductPicker(List<Product> products)
        {
            Form dlg = new Form
            {
                Text = "Select Product",
                Size = new Size(450, 380),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            ListBox lb = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10f)
            };

            foreach (var p in products)
                lb.Items.Add(p.ProductName + "  |  " + p.Barcode + "  |  Price: " + p.UnitPrice.ToString("F3") + "  |  Stock: " + p.AvailableQuantity);

            Button btn = new Button
            {
                Text = "Select",
                Dock = DockStyle.Bottom,
                Height = 38,
                BackColor = Color.FromArgb(30, 100, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            List<Product> captured = products;
            btn.Click += delegate
            {
                if (lb.SelectedIndex >= 0)
                {
                    _selectedNewProduct = captured[lb.SelectedIndex];
                    txtSearchNewProduct.Text = _selectedNewProduct.ProductName;
                    lblNewUnitPrice.Text = "Unit Price: " + _selectedNewProduct.UnitPrice.ToString("F3") + "  |  Available: " + _selectedNewProduct.AvailableQuantity;
                    dlg.Close();
                    RecalcDifference();
                }
            };

            dlg.Controls.Add(lb);
            dlg.Controls.Add(btn);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void nudOldQty_ValueChanged(object sender, EventArgs e)
        {
            RecalcDifference();
        }

        private void nudNewQty_ValueChanged(object sender, EventArgs e)
        {
            RecalcDifference();
        }

        private void RecalcDifference()
        {
            if (_selectedOldDetail == null || _selectedNewProduct == null)
            {
                lblDifference.Text = "0.000";
                lblDifferenceCase.Text = "";
                return;
            }

            decimal oldTotal = _selectedOldDetail.UnitPrice * (int)nudOldQty.Value;
            decimal newTotal = _selectedNewProduct.UnitPrice * (int)nudNewQty.Value;
            decimal difference = newTotal - oldTotal;

            lblDifference.Text = Math.Abs(difference).ToString("F3");

            if (difference > 0)
            {
                lblDifferenceCase.Text = "Customer pays more";
                lblDifferenceCase.ForeColor = Color.FromArgb(200, 50, 50);
                lblDifference.ForeColor = Color.FromArgb(200, 50, 50);
            }
            else if (difference < 0)
            {
                lblDifferenceCase.Text = "Customer receives refund";
                lblDifferenceCase.ForeColor = Color.FromArgb(40, 160, 100);
                lblDifference.ForeColor = Color.FromArgb(40, 160, 100);
            }
            else
            {
                lblDifferenceCase.Text = "No difference (equal exchange)";
                lblDifferenceCase.ForeColor = Color.Gray;
                lblDifference.ForeColor = Color.FromArgb(22, 32, 50);
            }
        }

        private PrintInvoiceData BuildPrintData(string exchangeNumber, int oldQty, int newQty, decimal difference)
        {
            var data = new PrintInvoiceData
            {
                InvoiceNumber = exchangeNumber,
                InvoiceDate = DateTime.Now,
                CustomerName = _selectedInvoice != null && !string.IsNullOrEmpty(_selectedInvoice.CustomerName) ? _selectedInvoice.CustomerName : "Walk-in Customer",
                PaymentType = "Exchange",
                PaymentMethod = (cmbPaymentMethod.SelectedItem as PaymentMethod)?.MethodName ?? "",
                SalesRepName = "",
                Notes = txtNotes.Text.Trim(),
                SubTotal = 0,
                DiscountAmount = 0,
                TaxAmount = 0,
                TaxPercent = 0,
                TotalAmount = Math.Abs(difference),
                PaidAmount = difference > 0 ? difference : 0,
                RemainingAmount = 0
            };

            data.Lines.Add(new PrintInvoiceLine
            {
                ProductName = "(Return) " + _selectedOldDetail.ProductName,
                Quantity = oldQty,
                UnitPrice = _selectedOldDetail.UnitPrice,
                DiscountAmount = 0,
                Total = -(_selectedOldDetail.UnitPrice * oldQty)
            });

            data.Lines.Add(new PrintInvoiceLine
            {
                ProductName = "(New) " + _selectedNewProduct.ProductName,
                Quantity = newQty,
                UnitPrice = _selectedNewProduct.UnitPrice,
                DiscountAmount = 0,
                Total = _selectedNewProduct.UnitPrice * newQty
            });

            return data;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedInvoice == null)
            {
                MessageHelper.ShowWarning("Please search and select an invoice first.");
                return;
            }

            if (_selectedOldDetail == null)
            {
                MessageHelper.ShowWarning("Please select the product to exchange.");
                return;
            }

            if (_selectedNewProduct == null)
            {
                MessageHelper.ShowWarning("Please search and select the new product.");
                return;
            }

            PaymentMethod pm = cmbPaymentMethod.SelectedItem as PaymentMethod;
            if (pm == null)
            {
                MessageHelper.ShowWarning("Please select a payment method.");
                return;
            }

            int oldQty = (int)nudOldQty.Value;
            int newQty = (int)nudNewQty.Value;

            if (oldQty <= 0 || newQty <= 0)
            {
                MessageHelper.ShowWarning("Quantities must be greater than zero.");
                return;
            }

            if (oldQty > _selectedOldDetail.ReturnableQuantity)
            {
                MessageHelper.ShowWarning("Exchange quantity exceeds returnable quantity.");
                return;
            }

            if (newQty > _selectedNewProduct.AvailableQuantity)
            {
                MessageHelper.ShowWarning("Not enough stock for the new product.");
                return;
            }

            try
            {
                btnSave.Enabled = false;
                btnSave.Text = "Saving...";

                var dto = new CreateExchangeDTO
                {
                    OriginalInvoiceID = _selectedInvoice.InvoiceID,
                    OriginalInvoiceDetailID = _selectedOldDetail.InvoiceDetailID,
                    CustomerID = _selectedInvoice.CustomerID ?? 0,
                    OldProductID = _selectedOldDetail.ProductID,
                    OldQuantity = oldQty,
                    NewProductID = _selectedNewProduct.ProductID,
                    NewQuantity = newQty,
                    PaymentMethodID = pm.PaymentMethodID,
                    Notes = txtNotes.Text.Trim(),
                    CreatedBy = SessionManager.UserId
                };

                decimal oldTotal = _selectedOldDetail.UnitPrice * oldQty;
                decimal newTotal = _selectedNewProduct.UnitPrice * newQty;
                decimal difference = newTotal - oldTotal;

                var result = await ApiHelper.PostAsync<ExchangeTransaction>("exchange", dto);

                if (result != null)
                {
                    _lastExchangeForPrint = BuildPrintData(result.ExchangeNumber, oldQty, newQty, difference);

                    if (MessageHelper.ShowConfirm("Exchange saved successfully!\nExchange #: " + result.ExchangeNumber + "\n\nDo you want to print it now?"))
                    {
                        if (chkThermalPrint.Checked)
                            InvoicePrinter.PrintInvoiceThermal(_lastExchangeForPrint, showPreview: true);
                        else
                            InvoicePrinter.PrintInvoice(_lastExchangeForPrint, showPreview: true);
                    }

                    ClearForm();
                }
                else
                {
                    MessageHelper.ShowError("Failed to save exchange.");
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Save error: " + ex.Message); }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "💾 Save Exchange";
            }
        }

        private void btnPrintLast_Click(object sender, EventArgs e)
        {
            if (_lastExchangeForPrint == null)
            {
                MessageHelper.ShowWarning("No saved exchange to print yet. Save an exchange first.");
                return;
            }

            if (chkThermalPrint.Checked)
                InvoicePrinter.PrintInvoiceThermal(_lastExchangeForPrint, showPreview: true);
            else
                InvoicePrinter.PrintInvoice(_lastExchangeForPrint, showPreview: true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ShowConfirm("Clear the current form?"))
                ClearForm();
        }

        private void ClearForm()
        {
            _selectedInvoice = null;
            _returnableDetails.Clear();
            _selectedOldDetail = null;
            _selectedNewProduct = null;

            lblSelectedInvoice.Text = "No invoice selected";
            txtInvoiceNumber.Clear();
            txtBarcode.Clear();
            txtCustomerName.Clear();
            txtSearchNewProduct.Clear();
            txtNotes.Clear();
            lblOldUnitPrice.Text = "";
            lblNewUnitPrice.Text = "";
            lblDifference.Text = "0.000";
            lblDifferenceCase.Text = "";

            cmbOldProduct.DataSource = null;
            nudOldQty.Value = 1;
            nudNewQty.Value = 1;

            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}