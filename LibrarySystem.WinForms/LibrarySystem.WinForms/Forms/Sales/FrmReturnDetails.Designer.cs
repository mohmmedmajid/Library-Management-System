namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmReturnDetails
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle hdrStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblBorrowNumLbl = new System.Windows.Forms.Label();
            this.lblBorrowNumber = new System.Windows.Forms.Label();
            this.lblCustLbl = new System.Windows.Forms.Label();
            this.lblCustomerVal = new System.Windows.Forms.Label();
            this.lblBorrowDtLbl = new System.Windows.Forms.Label();
            this.lblBorrowDateVal = new System.Windows.Forms.Label();
            this.lblExpDtLbl = new System.Windows.Forms.Label();
            this.lblExpectedDateVal = new System.Windows.Forms.Label();
            this.lblReturnDtLbl = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblOrigAmtLbl = new System.Windows.Forms.Label();
            this.lblOriginalAmountVal = new System.Windows.Forms.Label();
            this.lblLateDaysLbl = new System.Windows.Forms.Label();
            this.lblLateDaysVal = new System.Windows.Forms.Label();
            this.lblLateFeeLbl = new System.Windows.Forms.Label();
            this.lblLateFeeVal = new System.Windows.Forms.Label();

            this.pnlOnTime = new System.Windows.Forms.Panel();
            this.lblOnTimeIcon = new System.Windows.Forms.Label();
            this.lblOnTimeMsg = new System.Windows.Forms.Label();

            this.pnlLate = new System.Windows.Forms.Panel();
            this.lblLateIcon = new System.Windows.Forms.Label();
            this.lblLateTitle = new System.Windows.Forms.Label();
            this.lblLateFeeAmount = new System.Windows.Forms.Label();

            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBook = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemainingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPricePerDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlPay = new System.Windows.Forms.Panel();
            this.lblPayAmountLbl = new System.Windows.Forms.Label();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.btnPayFull = new System.Windows.Forms.Button();
            this.lblRemainingLbl = new System.Windows.Forms.Label();
            this.lblRemainingVal = new System.Windows.Forms.Label();

            this.lblNotesLbl = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.chkThermalPrint = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlOnTime.SuspendLayout();
            this.pnlLate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.pnlPay.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(520, 50);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnClose);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Size = new System.Drawing.Size(300, 26);
            this.lblTitle.Text = "↩ Return Book";

            this.btnClose.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(480, 8);
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // pnlInfo
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(8, 58);
            this.pnlInfo.Size = new System.Drawing.Size(504, 165);
            this.pnlInfo.Controls.Add(this.lblBorrowNumLbl);
            this.pnlInfo.Controls.Add(this.lblBorrowNumber);
            this.pnlInfo.Controls.Add(this.lblCustLbl);
            this.pnlInfo.Controls.Add(this.lblCustomerVal);
            this.pnlInfo.Controls.Add(this.lblBorrowDtLbl);
            this.pnlInfo.Controls.Add(this.lblBorrowDateVal);
            this.pnlInfo.Controls.Add(this.lblExpDtLbl);
            this.pnlInfo.Controls.Add(this.lblExpectedDateVal);
            this.pnlInfo.Controls.Add(this.lblReturnDtLbl);
            this.pnlInfo.Controls.Add(this.dtpReturnDate);
            this.pnlInfo.Controls.Add(this.lblOrigAmtLbl);
            this.pnlInfo.Controls.Add(this.lblOriginalAmountVal);
            this.pnlInfo.Controls.Add(this.lblLateDaysLbl);
            this.pnlInfo.Controls.Add(this.lblLateDaysVal);
            this.pnlInfo.Controls.Add(this.lblLateFeeLbl);
            this.pnlInfo.Controls.Add(this.lblLateFeeVal);

            this.lblBorrowNumLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblBorrowNumLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblBorrowNumLbl.Location = new System.Drawing.Point(10, 8);
            this.lblBorrowNumLbl.Size = new System.Drawing.Size(150, 18);
            this.lblBorrowNumLbl.Text = "Borrow #";

            this.lblBorrowNumber.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblBorrowNumber.Location = new System.Drawing.Point(10, 26);
            this.lblBorrowNumber.Size = new System.Drawing.Size(150, 22);
            this.lblBorrowNumber.Text = "-";

            this.lblCustLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblCustLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblCustLbl.Location = new System.Drawing.Point(170, 8);
            this.lblCustLbl.Size = new System.Drawing.Size(200, 18);
            this.lblCustLbl.Text = "Customer";

            this.lblCustomerVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblCustomerVal.Location = new System.Drawing.Point(170, 26);
            this.lblCustomerVal.Size = new System.Drawing.Size(240, 22);
            this.lblCustomerVal.Text = "-";

            this.lblBorrowDtLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblBorrowDtLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblBorrowDtLbl.Location = new System.Drawing.Point(10, 54);
            this.lblBorrowDtLbl.Size = new System.Drawing.Size(150, 18);
            this.lblBorrowDtLbl.Text = "Borrow Date";

            this.lblBorrowDateVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblBorrowDateVal.Location = new System.Drawing.Point(10, 72);
            this.lblBorrowDateVal.Size = new System.Drawing.Size(150, 22);
            this.lblBorrowDateVal.Text = "-";

            this.lblExpDtLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblExpDtLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblExpDtLbl.Location = new System.Drawing.Point(170, 54);
            this.lblExpDtLbl.Size = new System.Drawing.Size(150, 18);
            this.lblExpDtLbl.Text = "Due Date";

            this.lblExpectedDateVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblExpectedDateVal.Location = new System.Drawing.Point(170, 72);
            this.lblExpectedDateVal.Size = new System.Drawing.Size(150, 22);
            this.lblExpectedDateVal.Text = "-";

            this.lblReturnDtLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblReturnDtLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblReturnDtLbl.Location = new System.Drawing.Point(330, 54);
            this.lblReturnDtLbl.Size = new System.Drawing.Size(150, 18);
            this.lblReturnDtLbl.Text = "Return Date";

            this.dtpReturnDate.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(330, 72);
            this.dtpReturnDate.Size = new System.Drawing.Size(160, 24);
            this.dtpReturnDate.ValueChanged += new System.EventHandler(this.dtpReturnDate_ValueChanged);

            this.lblOrigAmtLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblOrigAmtLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblOrigAmtLbl.Location = new System.Drawing.Point(10, 100);
            this.lblOrigAmtLbl.Size = new System.Drawing.Size(150, 18);
            this.lblOrigAmtLbl.Text = "Original Amount";

            this.lblOriginalAmountVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblOriginalAmountVal.Location = new System.Drawing.Point(10, 118);
            this.lblOriginalAmountVal.Size = new System.Drawing.Size(150, 22);
            this.lblOriginalAmountVal.Text = "-";

            this.lblLateDaysLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLateDaysLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblLateDaysLbl.Location = new System.Drawing.Point(170, 100);
            this.lblLateDaysLbl.Size = new System.Drawing.Size(150, 18);
            this.lblLateDaysLbl.Text = "Late Days";

            this.lblLateDaysVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblLateDaysVal.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblLateDaysVal.Location = new System.Drawing.Point(170, 118);
            this.lblLateDaysVal.Size = new System.Drawing.Size(150, 22);
            this.lblLateDaysVal.Text = "-";

            this.lblLateFeeLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLateFeeLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblLateFeeLbl.Location = new System.Drawing.Point(330, 100);
            this.lblLateFeeLbl.Size = new System.Drawing.Size(150, 18);
            this.lblLateFeeLbl.Text = "Late Fee";

            this.lblLateFeeVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblLateFeeVal.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblLateFeeVal.Location = new System.Drawing.Point(330, 118);
            this.lblLateFeeVal.Size = new System.Drawing.Size(150, 22);
            this.lblLateFeeVal.Text = "-";

            // pnlOnTime
            this.pnlOnTime.BackColor = System.Drawing.Color.FromArgb(236, 252, 240);
            this.pnlOnTime.Location = new System.Drawing.Point(8, 226);
            this.pnlOnTime.Size = new System.Drawing.Size(504, 44);
            this.pnlOnTime.Visible = false;
            this.pnlOnTime.Controls.Add(this.lblOnTimeIcon);
            this.pnlOnTime.Controls.Add(this.lblOnTimeMsg);

            this.lblOnTimeIcon.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblOnTimeIcon.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblOnTimeIcon.Location = new System.Drawing.Point(10, 6);
            this.lblOnTimeIcon.Size = new System.Drawing.Size(30, 30);
            this.lblOnTimeIcon.Text = "✓";

            this.lblOnTimeMsg.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.lblOnTimeMsg.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblOnTimeMsg.Location = new System.Drawing.Point(46, 12);
            this.lblOnTimeMsg.Size = new System.Drawing.Size(400, 22);
            this.lblOnTimeMsg.Text = "No late fee — on time or early return.";

            // pnlLate
            this.pnlLate.BackColor = System.Drawing.Color.FromArgb(255, 238, 238);
            this.pnlLate.Location = new System.Drawing.Point(8, 226);
            this.pnlLate.Size = new System.Drawing.Size(504, 44);
            this.pnlLate.Visible = false;
            this.pnlLate.Controls.Add(this.lblLateIcon);
            this.pnlLate.Controls.Add(this.lblLateTitle);
            this.pnlLate.Controls.Add(this.lblLateFeeAmount);

            this.lblLateIcon.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblLateIcon.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblLateIcon.Location = new System.Drawing.Point(10, 6);
            this.lblLateIcon.Size = new System.Drawing.Size(30, 30);
            this.lblLateIcon.Text = "!";

            this.lblLateTitle.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.lblLateTitle.ForeColor = System.Drawing.Color.FromArgb(190, 40, 40);
            this.lblLateTitle.Location = new System.Drawing.Point(46, 4);
            this.lblLateTitle.Size = new System.Drawing.Size(120, 18);
            this.lblLateTitle.Text = "LATE RETURN";

            this.lblLateFeeAmount.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.lblLateFeeAmount.ForeColor = System.Drawing.Color.FromArgb(170, 30, 30);
            this.lblLateFeeAmount.Location = new System.Drawing.Point(46, 22);
            this.lblLateFeeAmount.Size = new System.Drawing.Size(440, 18);
            this.lblLateFeeAmount.Text = "Fee: -";

            // lblDetailsTitle
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblDetailsTitle.Location = new System.Drawing.Point(10, 276);
            this.lblDetailsTitle.Size = new System.Drawing.Size(200, 20);
            this.lblDetailsTitle.Text = "Borrowed Books";

            // dgvDetails
            altStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvDetails.AlternatingRowsDefaultCellStyle = altStyle;
            hdrStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            hdrStyle.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            hdrStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = hdrStyle;
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetails.ColumnHeadersHeight = 32;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect, this.colDetailID, this.colProductID, this.colBook,
            this.colRemainingQty, this.colReturnQty, this.colPricePerDay, this.colDays, this.colTotal});
            this.dgvDetails.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dgvDetails.Location = new System.Drawing.Point(10, 298);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = false;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.RowTemplate.Height = 28;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(502, 140);
            this.dgvDetails.TabIndex = 0;

            this.colSelect.HeaderText = "";
            this.colSelect.Name = "colSelect";
            this.colSelect.FillWeight = 8f;

            this.colDetailID.HeaderText = "ID";
            this.colDetailID.Name = "colDetailID";
            this.colDetailID.Visible = false;

            this.colProductID.HeaderText = "PID";
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = false;

            this.colBook.FillWeight = 30f; this.colBook.HeaderText = "Book"; this.colBook.Name = "colBook"; this.colBook.ReadOnly = true;
            this.colRemainingQty.FillWeight = 12f; this.colRemainingQty.HeaderText = "Remaining"; this.colRemainingQty.Name = "colRemainingQty"; this.colRemainingQty.ReadOnly = true;
            this.colReturnQty.FillWeight = 12f; this.colReturnQty.HeaderText = "Return Qty"; this.colReturnQty.Name = "colReturnQty"; this.colReturnQty.ReadOnly = false;
            this.colPricePerDay.FillWeight = 15f; this.colPricePerDay.HeaderText = "Price/Day"; this.colPricePerDay.Name = "colPricePerDay"; this.colPricePerDay.ReadOnly = true;
            this.colDays.FillWeight = 10f; this.colDays.HeaderText = "Days"; this.colDays.Name = "colDays"; this.colDays.ReadOnly = true;
            this.colTotal.FillWeight = 13f; this.colTotal.HeaderText = "Total"; this.colTotal.Name = "colTotal"; this.colTotal.ReadOnly = true;

            // pnlPay
            this.pnlPay.BackColor = System.Drawing.Color.FromArgb(240, 246, 255);
            this.pnlPay.Location = new System.Drawing.Point(8, 446);
            this.pnlPay.Size = new System.Drawing.Size(504, 60);
            this.pnlPay.Controls.Add(this.lblPayAmountLbl);
            this.pnlPay.Controls.Add(this.txtPaidAmount);
            this.pnlPay.Controls.Add(this.btnPayFull);
            this.pnlPay.Controls.Add(this.lblRemainingLbl);
            this.pnlPay.Controls.Add(this.lblRemainingVal);

            this.lblPayAmountLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.lblPayAmountLbl.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblPayAmountLbl.Location = new System.Drawing.Point(10, 8);
            this.lblPayAmountLbl.Size = new System.Drawing.Size(120, 20);
            this.lblPayAmountLbl.Text = "Fee Paid Now:";

            this.txtPaidAmount.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.txtPaidAmount.Location = new System.Drawing.Point(10, 30);
            this.txtPaidAmount.Size = new System.Drawing.Size(110, 24);
            this.txtPaidAmount.Text = "0.00";
            this.txtPaidAmount.TextChanged += new System.EventHandler(this.txtPaidAmount_TextChanged);

            this.btnPayFull.BackColor = System.Drawing.Color.FromArgb(200, 220, 245);
            this.btnPayFull.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayFull.FlatAppearance.BorderSize = 0;
            this.btnPayFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayFull.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.btnPayFull.ForeColor = System.Drawing.Color.FromArgb(20, 70, 130);
            this.btnPayFull.Location = new System.Drawing.Point(130, 30);
            this.btnPayFull.Size = new System.Drawing.Size(90, 24);
            this.btnPayFull.Text = "Full Amount";
            this.btnPayFull.UseVisualStyleBackColor = false;
            this.btnPayFull.Click += new System.EventHandler(this.btnPayFull_Click);

            this.lblRemainingLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblRemainingLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblRemainingLbl.Location = new System.Drawing.Point(360, 8);
            this.lblRemainingLbl.Size = new System.Drawing.Size(120, 20);
            this.lblRemainingLbl.Text = "Remaining Fee:";

            this.lblRemainingVal.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblRemainingVal.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblRemainingVal.Location = new System.Drawing.Point(360, 28);
            this.lblRemainingVal.Size = new System.Drawing.Size(130, 26);
            this.lblRemainingVal.Text = "0.00";

            // Notes
            this.lblNotesLbl.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblNotesLbl.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblNotesLbl.Location = new System.Drawing.Point(8, 512);
            this.lblNotesLbl.Size = new System.Drawing.Size(120, 20);
            this.lblNotesLbl.Text = "Notes:";

            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtNotes.Location = new System.Drawing.Point(8, 534);
            this.txtNotes.Multiline = true;
            this.txtNotes.Size = new System.Drawing.Size(360, 46);

            this.chkThermalPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkThermalPrint.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.chkThermalPrint.Location = new System.Drawing.Point(378, 548);
            this.chkThermalPrint.Size = new System.Drawing.Size(90, 20);
            this.chkThermalPrint.Text = "Thermal";

            // btnConfirm
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(22, 110, 200);
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(8, 590);
            this.btnConfirm.Size = new System.Drawing.Size(504, 46);
            this.btnConfirm.Text = "✔  Confirm Return";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // FrmReturnDetails
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(520, 644);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlOnTime);
            this.Controls.Add(this.pnlLate);
            this.Controls.Add(this.lblDetailsTitle);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.pnlPay);
            this.Controls.Add(this.lblNotesLbl);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.chkThermalPrint);
            this.Controls.Add(this.btnConfirm);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReturnDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Return Book";
            this.Load += new System.EventHandler(this.FrmReturnDetails_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlOnTime.ResumeLayout(false);
            this.pnlLate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.pnlPay.ResumeLayout(false);
            this.pnlPay.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblBorrowNumLbl, lblBorrowNumber;
        private System.Windows.Forms.Label lblCustLbl, lblCustomerVal;
        private System.Windows.Forms.Label lblBorrowDtLbl, lblBorrowDateVal;
        private System.Windows.Forms.Label lblExpDtLbl, lblExpectedDateVal;
        private System.Windows.Forms.Label lblReturnDtLbl;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lblOrigAmtLbl, lblOriginalAmountVal;
        private System.Windows.Forms.Label lblLateDaysLbl, lblLateDaysVal;
        private System.Windows.Forms.Label lblLateFeeLbl, lblLateFeeVal;

        private System.Windows.Forms.Panel pnlOnTime;
        private System.Windows.Forms.Label lblOnTimeIcon, lblOnTimeMsg;

        private System.Windows.Forms.Panel pnlLate;
        private System.Windows.Forms.Label lblLateIcon, lblLateTitle, lblLateFeeAmount;

        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailID, colProductID, colBook,
            colRemainingQty, colReturnQty, colPricePerDay, colDays, colTotal;

        private System.Windows.Forms.Panel pnlPay;
        private System.Windows.Forms.Label lblPayAmountLbl;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Button btnPayFull;
        private System.Windows.Forms.Label lblRemainingLbl, lblRemainingVal;

        private System.Windows.Forms.Label lblNotesLbl;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox chkThermalPrint;
        private System.Windows.Forms.Button btnConfirm;

        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}