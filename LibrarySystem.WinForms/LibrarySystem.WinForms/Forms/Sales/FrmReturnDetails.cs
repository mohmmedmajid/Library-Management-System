using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Sales;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmReturnDetails : Form
    {
        private readonly BorrowingTransaction _borrowing;
        private List<BorrowingDetail> _details = new List<BorrowingDetail>();

        private decimal _dailyRate = 0; 
        private string _returnStatus = "OnTime"; 

      
        private decimal _totalLateFee = 0;
        private decimal _totalRefund = 0;
        private int _maxLateDays = 0;
        private int _maxEarlyDays = 0;

        public bool Changed { get; private set; } = false;

        public FrmReturnDetails(BorrowingTransaction borrowing)
        {
            InitializeComponent();
            _borrowing = borrowing;

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(460, 8);
            spinner.Size = new Size(36, 36);
            pnlHeader.Controls.Add(spinner);

            dgvDetails.CellContentClick += DgvDetails_CellContentClick;
            dgvDetails.CellEndEdit += DgvDetails_CellEndEdit;
        }

        private async void FrmReturnDetails_Load(object sender, EventArgs e)
        {
            lblBorrowNumber.Text = _borrowing.BorrowingNumber;
            lblCustomerVal.Text = _borrowing.CustomerName;
            lblBorrowDateVal.Text = _borrowing.BorrowingDate.ToString("yyyy-MM-dd");
            lblExpectedDateVal.Text = _borrowing.ExpectedReturnDate.ToString("yyyy-MM-dd");
            lblOriginalAmountVal.Text = _borrowing.TotalAmount.ToString("F2");

            dtpReturnDate.Value = DateTime.Today;

            try
            {
                spinner.Start();
                _details = await ApiHelper.GetAsync<List<BorrowingDetail>>(
                    $"borrowingdetails/by-borrowing/{_borrowing.BorrowingID}") ?? new List<BorrowingDetail>();

                BindDetailsGrid();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading details: " + ex.Message); }
            finally { spinner.Stop(); }

            CalculateReturn();
        }

       
        private void BindDetailsGrid()
        {
            dgvDetails.Rows.Clear();
            foreach (var d in _details)
            {
                if (d.RemainingQuantity <= 0)
                    continue; 

                int rowIndex = dgvDetails.Rows.Add(
                    false,                           
                    d.BorrowingDetailID,               
                    d.ProductID,                        
                    d.ProductName,                       
                    d.RemainingQuantity,                
                    d.RemainingQuantity,                
                    d.PricePerDay.ToString("F2"),        
                    d.TotalDays,                        
                    d.TotalPrice.ToString("F2"));         
            }

            if (dgvDetails.Rows.Count == 0)
            {
                MessageHelper.ShowInfo("All books in this borrowing have already been returned.");
            }
        }

        private void DgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int selectCol = dgvDetails.Columns["colSelect"].Index;
            if (e.ColumnIndex == selectCol)
            {
                dgvDetails.EndEdit();
                CalculateReturn();
            }
        }

        private void DgvDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int qtyCol = dgvDetails.Columns["colReturnQty"].Index;
            int remainingCol = dgvDetails.Columns["colRemainingQty"].Index;

            if (e.ColumnIndex == qtyCol)
            {
                var row = dgvDetails.Rows[e.RowIndex];
                int remaining = Convert.ToInt32(row.Cells[remainingCol].Value);

                if (!int.TryParse(row.Cells[qtyCol].Value?.ToString(), out int qty) || qty <= 0)
                {
                    row.Cells[qtyCol].Value = remaining;
                }
                else if (qty > remaining)
                {
                    MessageHelper.ShowWarning($"Cannot return more than {remaining} for this book.");
                    row.Cells[qtyCol].Value = remaining;
                }
            }

            CalculateReturn();
        }

        // إرجاع قائمة الكتب المحددة فقط عبر checkbox
        private List<(BorrowingDetail Detail, int ReturnQty)> GetSelectedLines()
        {
            var result = new List<(BorrowingDetail, int)>();
            int selectCol = dgvDetails.Columns["colSelect"].Index;
            int idCol = dgvDetails.Columns["colDetailID"].Index;
            int qtyCol = dgvDetails.Columns["colReturnQty"].Index;

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells[selectCol].Value ?? false);
                if (!isChecked) continue;

                int detailId = Convert.ToInt32(row.Cells[idCol].Value);
                var detail = _details.Find(d => d.BorrowingDetailID == detailId);
                if (detail == null) continue;

                int.TryParse(row.Cells[qtyCol].Value?.ToString(), out int qty);
                if (qty <= 0) qty = detail.RemainingQuantity;

                result.Add((detail, qty));
            }

            return result;
        }

        private void CalculateReturn()
        {
            DateTime returnDate = dtpReturnDate.Value.Date;
            DateTime expectedDate = _borrowing.ExpectedReturnDate.Date;

            var selected = GetSelectedLines();

            _totalLateFee = 0;
            _totalRefund = 0;
            _maxLateDays = 0;
            _maxEarlyDays = 0;

            if (returnDate > expectedDate)
            {
                _returnStatus = "Late";
                _maxLateDays = (returnDate - expectedDate).Days;

                foreach (var (detail, qty) in selected)
                {
                    decimal lineDailyRate = detail.PricePerDay * qty;
                    _totalLateFee += _maxLateDays * lineDailyRate;
                }
            }
            else if (returnDate < expectedDate)
            {
                _returnStatus = "Early";
                _maxEarlyDays = (expectedDate - returnDate).Days;

                foreach (var (detail, qty) in selected)
                {
                    decimal lineDailyRate = detail.PricePerDay * qty;
                    _totalRefund += _maxEarlyDays * lineDailyRate;
                }
            }
            else
            {
                _returnStatus = "OnTime";
            }

            lblLateDaysVal.Text = _maxLateDays.ToString();
            lblLateFeeVal.Text = _totalLateFee.ToString("F2");

            if (selected.Count == 0)
            {
                pnlLate.Visible = false;
                pnlOnTime.Visible = true;
                lblOnTimeIcon.Text = "ℹ";
                lblOnTimeIcon.ForeColor = Color.Gray;
                lblOnTimeMsg.ForeColor = Color.Gray;
                lblOnTimeMsg.Text = "Select at least one book to return.";
                txtPaidAmount.Text = "0.00";
                txtPaidAmount.Enabled = false;
            }
            else if (_returnStatus == "Late")
            {
                pnlLate.Visible = true;
                pnlOnTime.Visible = false;
                lblLateFeeAmount.Text = $"{_totalLateFee:F2} JD  ({_maxLateDays} days x selected books)";
                txtPaidAmount.Text = _totalLateFee.ToString("F2");
                txtPaidAmount.Enabled = true;
            }
            else if (_returnStatus == "Early")
            {
                pnlLate.Visible = false;
                pnlOnTime.Visible = true;
                lblOnTimeMsg.Text = $"Early return — refund of {_totalRefund:F2} JD ({_maxEarlyDays} days)";
                lblOnTimeIcon.Text = "↩";
                lblOnTimeIcon.ForeColor = Color.FromArgb(30, 100, 180);
                lblOnTimeMsg.ForeColor = Color.FromArgb(30, 100, 180);
                txtPaidAmount.Text = "0.00";
                txtPaidAmount.Enabled = false;
            }
            else
            {
                pnlLate.Visible = false;
                pnlOnTime.Visible = true;
                lblOnTimeMsg.Text = "On time — no late fee, no refund.";
                lblOnTimeIcon.Text = "✓";
                lblOnTimeIcon.ForeColor = Color.FromArgb(40, 160, 100);
                lblOnTimeMsg.ForeColor = Color.FromArgb(40, 160, 100);
                txtPaidAmount.Text = "0.00";
                txtPaidAmount.Enabled = false;
            }

            UpdateRemaining();
        }

        private void UpdateRemaining()
        {
            decimal.TryParse(txtPaidAmount.Text, out decimal paid);
            decimal remaining = _totalLateFee - paid;
            lblRemainingVal.Text = remaining.ToString("F2");
            lblRemainingVal.ForeColor = remaining > 0 ? Color.Red : Color.FromArgb(40, 160, 100);
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e) => CalculateReturn();

        private void txtPaidAmount_TextChanged(object sender, EventArgs e) => UpdateRemaining();

        private void btnPayFull_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text = _totalLateFee.ToString("F2");
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedLines();
            if (selected.Count == 0)
            {
                MessageHelper.ShowWarning("Please select at least one book to return.");
                return;
            }

            if (!decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount) || paidAmount < 0)
            { MessageHelper.ShowWarning("Please enter a valid paid amount."); return; }

            if (paidAmount > _totalLateFee)
            { MessageHelper.ShowWarning("Paid amount cannot exceed the late fee."); return; }

            string booksList = string.Join(", ", selected.Select(s => $"{s.Detail.ProductName} (x{s.ReturnQty})"));

            string msg;
            if (_returnStatus == "Late")
                msg = $"Confirm returning:\n{booksList}\n\nAFTER due date — Late fee: {_totalLateFee:F2} JD\nPaid now: {paidAmount:F2} JD";
            else if (_returnStatus == "Early")
                msg = $"Confirm returning:\n{booksList}\n\nBEFORE due date — Refund: {_totalRefund:F2} JD";
            else
                msg = $"Confirm returning:\n{booksList}\n\nON TIME — no late fee, no refund.";

            if (!MessageHelper.ShowConfirm(msg)) return;

            try
            {
                btnConfirm.Enabled = false;

                DateTime returnDate = dtpReturnDate.Value.Date;

                var dto = new CreateReturnWithDetailsDTO
                {
                    BorrowingID = _borrowing.BorrowingID,
                    ReturnDate = returnDate,
                    Notes = txtNotes.Text.Trim(),
                    CreatedBy = SessionManager.UserId,
                    Details = selected.Select(s => new ReturnDetailItemDTO
                    {
                        BorrowingDetailID = s.Detail.BorrowingDetailID,
                        ProductID = s.Detail.ProductID,
                        ReturnQuantity = s.ReturnQty,
                        LateDays = _returnStatus == "Late" ? _maxLateDays : 0,
                        LateFeeAmount = _returnStatus == "Late" ? (_maxLateDays * s.Detail.PricePerDay * s.ReturnQty) : 0,
                        RefundAmount = _returnStatus == "Early" ? (_maxEarlyDays * s.Detail.PricePerDay * s.ReturnQty) : 0
                    }).ToList()
                };

                await ApiHelper.PostAsync<object>("returntransactions/with-details", dto);

                var printData = BuildPrintData(paidAmount, selected);

                if (MessageHelper.ShowConfirm("Return processed successfully!\n\nDo you want to print the return invoice?"))
                {
                    if (chkThermalPrint.Checked)
                        InvoicePrinter.PrintInvoiceThermal(printData, showPreview: true);
                    else
                        InvoicePrinter.PrintInvoice(printData, showPreview: true);
                }

                Changed = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error processing return: " + ex.Message);
                btnConfirm.Enabled = true;
            }
        }

        private PrintInvoiceData BuildPrintData(decimal paidAmount, List<(BorrowingDetail Detail, int ReturnQty)> selected)
        {
            decimal remaining = _totalLateFee - paidAmount;

            string statusNote;
            if (_returnStatus == "Late")
                statusNote = $"Returned AFTER the due date — Late fee: {_totalLateFee:F2} JD ({_maxLateDays} days)";
            else if (_returnStatus == "Early")
                statusNote = $"Returned BEFORE the due date — Refunded: {_totalRefund:F2} JD ({_maxEarlyDays} days)";
            else
                statusNote = "Returned ON the due date — No late fee, no refund";

            string notes = string.IsNullOrWhiteSpace(txtNotes.Text)
                ? statusNote
                : statusNote + " | " + txtNotes.Text.Trim();

            var data = new PrintInvoiceData
            {
                InvoiceNumber = "RTN-" + _borrowing.BorrowingNumber,
                InvoiceDate = DateTime.Now,
                CustomerName = _borrowing.CustomerName,
                PaymentType = "Return",
                PaymentMethod = "-",
                SalesRepName = "",
                CashierName = SessionManager.UserId.ToString(),
                Notes = notes,
                SubTotal = _totalLateFee,
                DiscountAmount = 0,
                TaxAmount = 0,
                TaxPercent = 0,
                TotalAmount = _totalLateFee,
                PaidAmount = paidAmount,
                RemainingAmount = remaining,
                TotalDays = _borrowing.TotalDays,
                ReturnDate = dtpReturnDate.Value.Date
            };

            // فقط الكتب المرجعة فعلياً في هذه العملية
            foreach (var (detail, qty) in selected)
            {
                data.Lines.Add(new PrintInvoiceLine
                {
                    ProductName = detail.ProductName,
                    Quantity = qty,
                    UnitPrice = detail.PricePerDay,
                    DiscountAmount = 0,
                    Total = detail.PricePerDay * qty * detail.TotalDays
                });
            }

            if (_totalLateFee > 0)
            {
                data.Lines.Add(new PrintInvoiceLine
                {
                    ProductName = $"Late Fee ({_maxLateDays} days)",
                    Quantity = 1,
                    UnitPrice = _totalLateFee,
                    DiscountAmount = 0,
                    Total = _totalLateFee
                });
            }

            if (_totalRefund > 0)
            {
                data.Lines.Add(new PrintInvoiceLine
                {
                    ProductName = $"Early Return Refund ({_maxEarlyDays} days)",
                    Quantity = 1,
                    UnitPrice = -_totalRefund,
                    DiscountAmount = 0,
                    Total = -_totalRefund
                });
            }

            return data;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}