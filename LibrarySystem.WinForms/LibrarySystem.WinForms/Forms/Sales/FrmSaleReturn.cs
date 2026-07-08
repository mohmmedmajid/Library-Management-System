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
    public partial class FrmSaleReturn : Form
    {
        private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();
        private InvoiceSearchResult _selectedInvoice = null;
        private List<ReturnableInvoiceDetail> _returnableDetails = new List<ReturnableInvoiceDetail>();

        public FrmSaleReturn()
        {
            InitializeComponent();
        }

        private async void FrmSaleReturn_Load(object sender, EventArgs e)
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
                {
                    await SelectInvoice(results[0]);
                }
                else
                {
                    ShowInvoicePicker(results);
                }
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
                {
                    await SelectInvoice(results[0]);
                }
                else
                {
                    ShowInvoicePicker(results);
                }
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

                dgvItems.Rows.Clear();
                foreach (var d in _returnableDetails)
                {
                    dgvItems.Rows.Add(
                        d.InvoiceDetailID,
                        d.ProductName,
                        d.Quantity,
                        d.AlreadyReturnedQuantity,
                        d.ReturnableQuantity,
                        d.UnitPrice.ToString("F3"),
                        0
                    );
                }

                if (_returnableDetails.Count == 0)
                    MessageHelper.ShowWarning("No returnable items found for this invoice.");
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading returnable details: " + ex.Message); }
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvItems.Columns[e.ColumnIndex].Name != "colReturnQty") return;

            var row = dgvItems.Rows[e.RowIndex];

            int returnableQty = 0;
            int.TryParse(row.Cells["colReturnableQty"].Value?.ToString(), out returnableQty);

            int returnQty = 0;
            int.TryParse(row.Cells["colReturnQty"].Value?.ToString(), out returnQty);

            if (returnQty < 0)
            {
                row.Cells["colReturnQty"].Value = 0;
                return;
            }

            if (returnQty > returnableQty)
            {
                MessageHelper.ShowWarning("Return quantity exceeds returnable quantity (" + returnableQty + ").");
                row.Cells["colReturnQty"].Value = returnableQty;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedInvoice == null)
            {
                MessageHelper.ShowWarning("Please search and select an invoice first.");
                return;
            }

            var details = new List<SaleReturnDetailInputDTO>();
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                int returnQty = 0;
                int.TryParse(row.Cells["colReturnQty"].Value?.ToString(), out returnQty);
                if (returnQty <= 0) continue;

                int invoiceDetailId = 0;
                int.TryParse(row.Cells["colInvoiceDetailID"].Value?.ToString(), out invoiceDetailId);

                details.Add(new SaleReturnDetailInputDTO
                {
                    InvoiceDetailID = invoiceDetailId,
                    ReturnedQuantity = returnQty
                });
            }

            if (details.Count == 0)
            {
                MessageHelper.ShowWarning("Please enter a return quantity for at least one item.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbRefundMethod.Text))
            {
                MessageHelper.ShowWarning("Please select a refund method.");
                return;
            }

            PaymentMethod pm = cmbPaymentMethod.SelectedItem as PaymentMethod;
            if (pm == null)
            {
                MessageHelper.ShowWarning("Please select a payment method.");
                return;
            }

            try
            {
                btnSave.Enabled = false;
                btnSave.Text = "Saving...";

                var dto = new CreateSaleReturnDTO
                {
                    OriginalInvoiceID = _selectedInvoice.InvoiceID,
                    CustomerID = _selectedInvoice.CustomerID ?? 0,
                    RefundMethod = cmbRefundMethod.Text,
                    PaymentMethodID = pm.PaymentMethodID,
                    Notes = txtNotes.Text.Trim(),
                    CreatedBy = SessionManager.UserId,
                    Details = details
                };

                var result = await ApiHelper.PostAsync<SaleReturn>("salereturns", dto);

                if (result != null)
                {
                    MessageHelper.ShowSuccess("Sale return saved successfully!\nReturn #: " + result.SaleReturnNumber);
                    ClearForm();
                }
                else
                {
                    MessageHelper.ShowError("Failed to save sale return.");
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Save error: " + ex.Message); }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "💾 Save Return";
            }
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
            dgvItems.Rows.Clear();
            lblSelectedInvoice.Text = "No invoice selected";
            txtInvoiceNumber.Clear();
            txtBarcode.Clear();
            txtCustomerName.Clear();
            txtNotes.Clear();
            cmbRefundMethod.SelectedIndex = -1;
            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}