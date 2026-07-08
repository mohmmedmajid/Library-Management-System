namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmBorrowInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpBorrowInfo = new System.Windows.Forms.GroupBox();
            this.lblBorrowNumber = new System.Windows.Forms.Label();
            this.txtBorrowNumber = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblBorrowDate = new System.Windows.Forms.Label();
            this.dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.lblDays = new System.Windows.Forms.Label();
            this.nudDays = new System.Windows.Forms.NumericUpDown();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.grpBookEntry = new System.Windows.Forms.GroupBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.txtSelectedBook = new System.Windows.Forms.TextBox();
            this.btnSelectBook = new System.Windows.Forms.Button();
            this.lblQtyLabel = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblPricePerDay = new System.Windows.Forms.Label();
            this.txtPricePerDay = new System.Windows.Forms.TextBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colDetailProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailPricePerDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDetailDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblTotalDaysLabel = new System.Windows.Forms.Label();
            this.lblTotalDays = new System.Windows.Forms.Label();
            this.lblTotalBooksLabel = new System.Windows.Forms.Label();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.pnlTotalBar = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblDiscountLabel = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblPaidLabel = new System.Windows.Forms.Label();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.lblRemainingLabel = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkThermalPrint = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpBorrowInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            this.grpBookEntry.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.grpSummary.SuspendLayout();
            this.pnlTotalBar.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 55);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(15, 13);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(400, 30);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "📚 Borrow Invoice";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlLeft.Controls.Add(this.grpBorrowInfo);
            this.pnlLeft.Controls.Add(this.grpBookEntry);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 55);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(8);
            this.pnlLeft.Size = new System.Drawing.Size(440, 645);
            this.pnlLeft.TabIndex = 1;
            // 
            // grpBorrowInfo
            // 
            this.grpBorrowInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBorrowInfo.Controls.Add(this.lblBorrowNumber);
            this.grpBorrowInfo.Controls.Add(this.txtBorrowNumber);
            this.grpBorrowInfo.Controls.Add(this.lblCustomer);
            this.grpBorrowInfo.Controls.Add(this.cmbCustomer);
            this.grpBorrowInfo.Controls.Add(this.lblBorrowDate);
            this.grpBorrowInfo.Controls.Add(this.dtpBorrowDate);
            this.grpBorrowInfo.Controls.Add(this.lblDays);
            this.grpBorrowInfo.Controls.Add(this.nudDays);
            this.grpBorrowInfo.Controls.Add(this.lblReturnDate);
            this.grpBorrowInfo.Controls.Add(this.dtpReturnDate);
            this.grpBorrowInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpBorrowInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpBorrowInfo.Location = new System.Drawing.Point(8, 8);
            this.grpBorrowInfo.Name = "grpBorrowInfo";
            this.grpBorrowInfo.Size = new System.Drawing.Size(416, 270);
            this.grpBorrowInfo.TabIndex = 0;
            this.grpBorrowInfo.TabStop = false;
            this.grpBorrowInfo.Text = "  Borrowing Information";
            // 
            // lblBorrowNumber
            // 
            this.lblBorrowNumber.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBorrowNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblBorrowNumber.Location = new System.Drawing.Point(10, 25);
            this.lblBorrowNumber.Name = "lblBorrowNumber";
            this.lblBorrowNumber.Size = new System.Drawing.Size(390, 18);
            this.lblBorrowNumber.TabIndex = 0;
            this.lblBorrowNumber.Text = "Borrowing Number";
            // 
            // txtBorrowNumber
            // 
            this.txtBorrowNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBorrowNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtBorrowNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBorrowNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBorrowNumber.Location = new System.Drawing.Point(10, 45);
            this.txtBorrowNumber.Name = "txtBorrowNumber";
            this.txtBorrowNumber.ReadOnly = true;
            this.txtBorrowNumber.Size = new System.Drawing.Size(390, 25);
            this.txtBorrowNumber.TabIndex = 1;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblCustomer.Location = new System.Drawing.Point(10, 81);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(390, 18);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer *";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCustomer.Location = new System.Drawing.Point(10, 101);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(390, 25);
            this.cmbCustomer.TabIndex = 3;
            // 
            // lblBorrowDate
            // 
            this.lblBorrowDate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBorrowDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblBorrowDate.Location = new System.Drawing.Point(10, 137);
            this.lblBorrowDate.Name = "lblBorrowDate";
            this.lblBorrowDate.Size = new System.Drawing.Size(185, 18);
            this.lblBorrowDate.TabIndex = 4;
            this.lblBorrowDate.Text = "Borrow Date";
            // 
            // dtpBorrowDate
            // 
            this.dtpBorrowDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBorrowDate.Location = new System.Drawing.Point(10, 157);
            this.dtpBorrowDate.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new System.Drawing.Size(185, 25);
            this.dtpBorrowDate.TabIndex = 5;
            this.dtpBorrowDate.ValueChanged += new System.EventHandler(this.dtpBorrowDate_ValueChanged);
            // 
            // lblDays
            // 
            this.lblDays.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblDays.Location = new System.Drawing.Point(205, 137);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(185, 18);
            this.lblDays.TabIndex = 6;
            this.lblDays.Text = "Borrow Days";
            // 
            // nudDays
            // 
            this.nudDays.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudDays.Location = new System.Drawing.Point(205, 157);
            this.nudDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDays.Name = "nudDays";
            this.nudDays.Size = new System.Drawing.Size(185, 25);
            this.nudDays.TabIndex = 7;
            this.nudDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudDays.ValueChanged += new System.EventHandler(this.nudDays_ValueChanged);
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblReturnDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblReturnDate.Location = new System.Drawing.Point(10, 193);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(390, 18);
            this.lblReturnDate.TabIndex = 8;
            this.lblReturnDate.Text = "Expected Return Date";
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Enabled = false;
            this.dtpReturnDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(10, 213);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(390, 25);
            this.dtpReturnDate.TabIndex = 9;
            // 
            // grpBookEntry
            // 
            this.grpBookEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBookEntry.Controls.Add(this.lblBook);
            this.grpBookEntry.Controls.Add(this.txtSelectedBook);
            this.grpBookEntry.Controls.Add(this.btnSelectBook);
            this.grpBookEntry.Controls.Add(this.lblQtyLabel);
            this.grpBookEntry.Controls.Add(this.txtQty);
            this.grpBookEntry.Controls.Add(this.lblPricePerDay);
            this.grpBookEntry.Controls.Add(this.txtPricePerDay);
            this.grpBookEntry.Controls.Add(this.btnAddBook);
            this.grpBookEntry.Controls.Add(this.btnCancelEdit);
            this.grpBookEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpBookEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpBookEntry.Location = new System.Drawing.Point(8, 286);
            this.grpBookEntry.Name = "grpBookEntry";
            this.grpBookEntry.Size = new System.Drawing.Size(416, 195);
            this.grpBookEntry.TabIndex = 1;
            this.grpBookEntry.TabStop = false;
            this.grpBookEntry.Text = "  Add Book";
            // 
            // lblBook
            // 
            this.lblBook.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblBook.Location = new System.Drawing.Point(10, 22);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(390, 18);
            this.lblBook.TabIndex = 0;
            this.lblBook.Text = "Book";
            // 
            // txtSelectedBook
            // 
            this.txtSelectedBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSelectedBook.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSelectedBook.Location = new System.Drawing.Point(10, 42);
            this.txtSelectedBook.Name = "txtSelectedBook";
            this.txtSelectedBook.ReadOnly = true;
            this.txtSelectedBook.Size = new System.Drawing.Size(300, 25);
            this.txtSelectedBook.TabIndex = 1;
            // 
            // btnSelectBook
            // 
            this.btnSelectBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.btnSelectBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectBook.FlatAppearance.BorderSize = 0;
            this.btnSelectBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectBook.ForeColor = System.Drawing.Color.White;
            this.btnSelectBook.Location = new System.Drawing.Point(320, 42);
            this.btnSelectBook.Name = "btnSelectBook";
            this.btnSelectBook.Size = new System.Drawing.Size(80, 25);
            this.btnSelectBook.TabIndex = 2;
            this.btnSelectBook.Text = "🔍 Browse";
            this.btnSelectBook.UseVisualStyleBackColor = false;
            this.btnSelectBook.Click += new System.EventHandler(this.btnSelectBook_Click);
            // 
            // lblQtyLabel
            // 
            this.lblQtyLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblQtyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblQtyLabel.Location = new System.Drawing.Point(10, 80);
            this.lblQtyLabel.Name = "lblQtyLabel";
            this.lblQtyLabel.Size = new System.Drawing.Size(190, 18);
            this.lblQtyLabel.TabIndex = 3;
            this.lblQtyLabel.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQty.Location = new System.Drawing.Point(10, 100);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(190, 25);
            this.txtQty.TabIndex = 4;
            this.txtQty.Text = "1";
            // 
            // lblPricePerDay
            // 
            this.lblPricePerDay.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPricePerDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblPricePerDay.Location = new System.Drawing.Point(210, 80);
            this.lblPricePerDay.Name = "lblPricePerDay";
            this.lblPricePerDay.Size = new System.Drawing.Size(190, 18);
            this.lblPricePerDay.TabIndex = 5;
            this.lblPricePerDay.Text = "Price/Day";
            // 
            // txtPricePerDay
            // 
            this.txtPricePerDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPricePerDay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPricePerDay.Location = new System.Drawing.Point(210, 100);
            this.txtPricePerDay.Name = "txtPricePerDay";
            this.txtPricePerDay.Size = new System.Drawing.Size(190, 25);
            this.txtPricePerDay.TabIndex = 6;
            this.txtPricePerDay.Text = "0.00";
            // 
            // btnAddBook
            // 
            this.btnAddBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(160)))));
            this.btnAddBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBook.FlatAppearance.BorderSize = 0;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.Location = new System.Drawing.Point(10, 140);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(300, 40);
            this.btnAddBook.TabIndex = 7;
            this.btnAddBook.Text = "➕ Add Book";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnCancelEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelEdit.FlatAppearance.BorderSize = 0;
            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelEdit.ForeColor = System.Drawing.Color.White;
            this.btnCancelEdit.Location = new System.Drawing.Point(320, 140);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(80, 40);
            this.btnCancelEdit.TabIndex = 8;
            this.btnCancelEdit.Text = "✖";
            this.btnCancelEdit.UseVisualStyleBackColor = false;
            this.btnCancelEdit.Visible = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlRight.Controls.Add(this.grpDetails);
            this.pnlRight.Controls.Add(this.grpSummary);
            this.pnlRight.Controls.Add(this.pnlFooter);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(440, 55);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(8);
            this.pnlRight.Size = new System.Drawing.Size(660, 645);
            this.pnlRight.TabIndex = 0;
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.dgvDetails);
            this.grpDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpDetails.Location = new System.Drawing.Point(8, 8);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(1160, 280);
            this.grpDetails.TabIndex = 0;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "  Books to Borrow";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDetails.ColumnHeadersHeight = 38;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetailProductID,
            this.colDetailName,
            this.colDetailAuthor,
            this.colDetailQty,
            this.colDetailPricePerDay,
            this.colDetailDays,
            this.colDetailTotal,
            this.colDetailEdit,
            this.colDetailDelete});
            this.dgvDetails.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvDetails.Location = new System.Drawing.Point(8, 22);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.RowTemplate.Height = 34;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1144, 248);
            this.dgvDetails.TabIndex = 0;
            // 
            // colDetailProductID
            // 
            this.colDetailProductID.HeaderText = "ID";
            this.colDetailProductID.Name = "colDetailProductID";
            this.colDetailProductID.Visible = false;
            // 
            // colDetailName
            // 
            this.colDetailName.FillWeight = 26F;
            this.colDetailName.HeaderText = "Book Name";
            this.colDetailName.Name = "colDetailName";
            // 
            // colDetailAuthor
            // 
            this.colDetailAuthor.FillWeight = 16F;
            this.colDetailAuthor.HeaderText = "Author";
            this.colDetailAuthor.Name = "colDetailAuthor";
            // 
            // colDetailQty
            // 
            this.colDetailQty.FillWeight = 8F;
            this.colDetailQty.HeaderText = "Qty";
            this.colDetailQty.Name = "colDetailQty";
            // 
            // colDetailPricePerDay
            // 
            this.colDetailPricePerDay.FillWeight = 13F;
            this.colDetailPricePerDay.HeaderText = "Price/Day";
            this.colDetailPricePerDay.Name = "colDetailPricePerDay";
            // 
            // colDetailDays
            // 
            this.colDetailDays.FillWeight = 9F;
            this.colDetailDays.HeaderText = "Days";
            this.colDetailDays.Name = "colDetailDays";
            // 
            // colDetailTotal
            // 
            this.colDetailTotal.FillWeight = 13F;
            this.colDetailTotal.HeaderText = "Total";
            this.colDetailTotal.Name = "colDetailTotal";
            // 
            // colDetailEdit
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            this.colDetailEdit.DefaultCellStyle = dataGridViewCellStyle11;
            this.colDetailEdit.FillWeight = 7.5F;
            this.colDetailEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDetailEdit.HeaderText = "";
            this.colDetailEdit.Name = "colDetailEdit";
            this.colDetailEdit.Text = "✏";
            this.colDetailEdit.UseColumnTextForButtonValue = true;
            // 
            // colDetailDelete
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.colDetailDelete.DefaultCellStyle = dataGridViewCellStyle12;
            this.colDetailDelete.FillWeight = 7.5F;
            this.colDetailDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDetailDelete.HeaderText = "";
            this.colDetailDelete.Name = "colDetailDelete";
            this.colDetailDelete.Text = "🗑";
            this.colDetailDelete.UseColumnTextForButtonValue = true;
            // 
            // grpSummary
            // 
            this.grpSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSummary.Controls.Add(this.lblTotalDaysLabel);
            this.grpSummary.Controls.Add(this.lblTotalDays);
            this.grpSummary.Controls.Add(this.lblTotalBooksLabel);
            this.grpSummary.Controls.Add(this.lblTotalBooks);
            this.grpSummary.Controls.Add(this.pnlTotalBar);
            this.grpSummary.Controls.Add(this.lblDiscountLabel);
            this.grpSummary.Controls.Add(this.txtDiscount);
            this.grpSummary.Controls.Add(this.lblPaidLabel);
            this.grpSummary.Controls.Add(this.txtPaidAmount);
            this.grpSummary.Controls.Add(this.lblRemainingLabel);
            this.grpSummary.Controls.Add(this.lblRemaining);
            this.grpSummary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpSummary.Location = new System.Drawing.Point(8, 296);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(1160, 175);
            this.grpSummary.TabIndex = 1;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "  Summary";
            // 
            // lblTotalDaysLabel
            // 
            this.lblTotalDaysLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTotalDaysLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalDaysLabel.Location = new System.Drawing.Point(10, 22);
            this.lblTotalDaysLabel.Name = "lblTotalDaysLabel";
            this.lblTotalDaysLabel.Size = new System.Drawing.Size(140, 16);
            this.lblTotalDaysLabel.TabIndex = 0;
            this.lblTotalDaysLabel.Text = "Total Days:";
            // 
            // lblTotalDays
            // 
            this.lblTotalDays.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.lblTotalDays.Location = new System.Drawing.Point(10, 38);
            this.lblTotalDays.Name = "lblTotalDays";
            this.lblTotalDays.Size = new System.Drawing.Size(140, 22);
            this.lblTotalDays.TabIndex = 1;
            this.lblTotalDays.Text = "0 days";
            // 
            // lblTotalBooksLabel
            // 
            this.lblTotalBooksLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTotalBooksLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalBooksLabel.Location = new System.Drawing.Point(160, 22);
            this.lblTotalBooksLabel.Name = "lblTotalBooksLabel";
            this.lblTotalBooksLabel.Size = new System.Drawing.Size(140, 16);
            this.lblTotalBooksLabel.TabIndex = 2;
            this.lblTotalBooksLabel.Text = "Total Books:";
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(160)))));
            this.lblTotalBooks.Location = new System.Drawing.Point(160, 38);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(140, 22);
            this.lblTotalBooks.TabIndex = 3;
            this.lblTotalBooks.Text = "0 books";
            // 
            // pnlTotalBar
            // 
            this.pnlTotalBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTotalBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.pnlTotalBar.Controls.Add(this.lblTotalLabel);
            this.pnlTotalBar.Controls.Add(this.lblTotalAmount);
            this.pnlTotalBar.Location = new System.Drawing.Point(8, 68);
            this.pnlTotalBar.Name = "pnlTotalBar";
            this.pnlTotalBar.Size = new System.Drawing.Size(1144, 36);
            this.pnlTotalBar.TabIndex = 4;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalLabel.Location = new System.Drawing.Point(10, 6);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(120, 26);
            this.lblTotalLabel.TabIndex = 0;
            this.lblTotalLabel.Text = "TOTAL:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(960, 3);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(170, 30);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountLabel
            // 
            this.lblDiscountLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDiscountLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblDiscountLabel.Location = new System.Drawing.Point(10, 116);
            this.lblDiscountLabel.Name = "lblDiscountLabel";
            this.lblDiscountLabel.Size = new System.Drawing.Size(160, 16);
            this.lblDiscountLabel.TabIndex = 5;
            this.lblDiscountLabel.Text = "Discount:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtDiscount.Location = new System.Drawing.Point(10, 134);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(160, 25);
            this.txtDiscount.TabIndex = 6;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // lblPaidLabel
            // 
            this.lblPaidLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPaidLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblPaidLabel.Location = new System.Drawing.Point(200, 116);
            this.lblPaidLabel.Name = "lblPaidLabel";
            this.lblPaidLabel.Size = new System.Drawing.Size(160, 16);
            this.lblPaidLabel.TabIndex = 7;
            this.lblPaidLabel.Text = "Paid Amount:";
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaidAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtPaidAmount.Location = new System.Drawing.Point(200, 134);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(160, 25);
            this.txtPaidAmount.TabIndex = 8;
            this.txtPaidAmount.Text = "0.00";
            this.txtPaidAmount.TextChanged += new System.EventHandler(this.txtPaidAmount_TextChanged);
            // 
            // lblRemainingLabel
            // 
            this.lblRemainingLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRemainingLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblRemainingLabel.Location = new System.Drawing.Point(390, 116);
            this.lblRemainingLabel.Name = "lblRemainingLabel";
            this.lblRemainingLabel.Size = new System.Drawing.Size(160, 16);
            this.lblRemainingLabel.TabIndex = 9;
            this.lblRemainingLabel.Text = "Remaining:";
            // 
            // lblRemaining
            // 
            this.lblRemaining.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRemaining.ForeColor = System.Drawing.Color.Red;
            this.lblRemaining.Location = new System.Drawing.Point(390, 134);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(160, 26);
            this.lblRemaining.TabIndex = 10;
            this.lblRemaining.Text = "0.00";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblNotes);
            this.pnlFooter.Controls.Add(this.txtNotes);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnPrint);
            this.pnlFooter.Controls.Add(this.chkThermalPrint);
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(8, 497);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(644, 140);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblNotes.Location = new System.Drawing.Point(8, 4);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(150, 18);
            this.lblNotes.TabIndex = 0;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNotes.Location = new System.Drawing.Point(11, 25);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(619, 44);
            this.txtNotes.TabIndex = 1;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(160)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(8, 80);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 48);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "💾 Save Borrowing";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(206, 80);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(130, 48);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "🖨 Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkThermalPrint
            // 
            this.chkThermalPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkThermalPrint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.chkThermalPrint.Location = new System.Drawing.Point(344, 96);
            this.chkThermalPrint.Name = "chkThermalPrint";
            this.chkThermalPrint.Size = new System.Drawing.Size(90, 20);
            this.chkThermalPrint.TabIndex = 4;
            this.chkThermalPrint.Text = "Thermal";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(956, 80);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 48);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "🗑 Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmBorrowInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(950, 650);
            this.Name = "FrmBorrowInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Borrow Invoice";
            this.Load += new System.EventHandler(this.FrmBorrowInvoice_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grpBorrowInfo.ResumeLayout(false);
            this.grpBorrowInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            this.grpBookEntry.ResumeLayout(false);
            this.grpBookEntry.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.pnlTotalBar.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpBorrowInfo;
        private System.Windows.Forms.Label lblBorrowNumber;
        private System.Windows.Forms.TextBox txtBorrowNumber;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown nudDays;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.GroupBox grpBookEntry;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.TextBox txtSelectedBook;
        private System.Windows.Forms.Button btnSelectBook;
        private System.Windows.Forms.Label lblQtyLabel;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblPricePerDay;
        private System.Windows.Forms.TextBox txtPricePerDay;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailPricePerDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colDetailEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDetailDelete;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblTotalDaysLabel;
        private System.Windows.Forms.Label lblTotalDays;
        private System.Windows.Forms.Label lblTotalBooksLabel;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Panel pnlTotalBar;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblDiscountLabel;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblPaidLabel;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label lblRemainingLabel;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkThermalPrint;
        private System.Windows.Forms.Button btnClear;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}