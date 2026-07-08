namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmSaleReturn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colInvoiceDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlreadyReturned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturnableQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelectedInvoice = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.btnSearchByNumber = new System.Windows.Forms.Button();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnSearchByBarcode = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnSearchByCustomer = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpRefund = new System.Windows.Forms.GroupBox();
            this.lblRefundMethod = new System.Windows.Forms.Label();
            this.cmbRefundMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpRefund.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 58);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "↩ Sale Return";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlBody.Controls.Add(this.grpItems);
            this.pnlBody.Controls.Add(this.grpSearch);
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 58);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBody.Size = new System.Drawing.Size(1100, 532);
            this.pnlBody.TabIndex = 1;
            // 
            // grpItems
            // 
            this.grpItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Controls.Add(this.lblSelectedInvoice);
            this.grpItems.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.grpItems.Location = new System.Drawing.Point(348, 118);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(744, 406);
            this.grpItems.TabIndex = 2;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Returnable Items";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeight = 38;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceDetailID,
            this.colProductName,
            this.colOriginalQty,
            this.colAlreadyReturned,
            this.colReturnableQty,
            this.colUnitPrice,
            this.colReturnQty});
            this.dgvItems.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvItems.Location = new System.Drawing.Point(10, 50);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 32;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(724, 346);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEndEdit);
            // 
            // colInvoiceDetailID
            // 
            this.colInvoiceDetailID.HeaderText = "ID";
            this.colInvoiceDetailID.Name = "colInvoiceDetailID";
            this.colInvoiceDetailID.ReadOnly = true;
            this.colInvoiceDetailID.Visible = false;
            // 
            // colProductName
            // 
            this.colProductName.FillWeight = 30F;
            this.colProductName.HeaderText = "Product";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colOriginalQty
            // 
            this.colOriginalQty.FillWeight = 12F;
            this.colOriginalQty.HeaderText = "Original Qty";
            this.colOriginalQty.Name = "colOriginalQty";
            this.colOriginalQty.ReadOnly = true;
            // 
            // colAlreadyReturned
            // 
            this.colAlreadyReturned.FillWeight = 14F;
            this.colAlreadyReturned.HeaderText = "Already Returned";
            this.colAlreadyReturned.Name = "colAlreadyReturned";
            this.colAlreadyReturned.ReadOnly = true;
            // 
            // colReturnableQty
            // 
            this.colReturnableQty.FillWeight = 14F;
            this.colReturnableQty.HeaderText = "Returnable";
            this.colReturnableQty.Name = "colReturnableQty";
            this.colReturnableQty.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.FillWeight = 14F;
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colReturnQty
            // 
            this.colReturnQty.FillWeight = 16F;
            this.colReturnQty.HeaderText = "Return Qty";
            this.colReturnQty.Name = "colReturnQty";
            // 
            // lblSelectedInvoice
            // 
            this.lblSelectedInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSelectedInvoice.ForeColor = System.Drawing.Color.Gray;
            this.lblSelectedInvoice.Location = new System.Drawing.Point(10, 24);
            this.lblSelectedInvoice.Name = "lblSelectedInvoice";
            this.lblSelectedInvoice.Size = new System.Drawing.Size(724, 22);
            this.lblSelectedInvoice.TabIndex = 0;
            this.lblSelectedInvoice.Text = "No invoice selected";
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearch.Controls.Add(this.lblInvoiceNumber);
            this.grpSearch.Controls.Add(this.txtInvoiceNumber);
            this.grpSearch.Controls.Add(this.btnSearchByNumber);
            this.grpSearch.Controls.Add(this.lblBarcode);
            this.grpSearch.Controls.Add(this.txtBarcode);
            this.grpSearch.Controls.Add(this.btnSearchByBarcode);
            this.grpSearch.Controls.Add(this.lblCustomerName);
            this.grpSearch.Controls.Add(this.txtCustomerName);
            this.grpSearch.Controls.Add(this.btnSearchByCustomer);
            this.grpSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.grpSearch.Location = new System.Drawing.Point(348, 8);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(744, 104);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Find Original Invoice";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInvoiceNumber.Location = new System.Drawing.Point(10, 24);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(120, 20);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "By Invoice Number:";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtInvoiceNumber.Location = new System.Drawing.Point(140, 22);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(160, 24);
            this.txtInvoiceNumber.TabIndex = 1;
            // 
            // btnSearchByNumber
            // 
            this.btnSearchByNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnSearchByNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchByNumber.FlatAppearance.BorderSize = 0;
            this.btnSearchByNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchByNumber.ForeColor = System.Drawing.Color.White;
            this.btnSearchByNumber.Location = new System.Drawing.Point(306, 20);
            this.btnSearchByNumber.Name = "btnSearchByNumber";
            this.btnSearchByNumber.Size = new System.Drawing.Size(30, 28);
            this.btnSearchByNumber.TabIndex = 2;
            this.btnSearchByNumber.Text = "🔍";
            this.btnSearchByNumber.UseVisualStyleBackColor = false;
            this.btnSearchByNumber.Click += new System.EventHandler(this.btnSearchByNumber_Click);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBarcode.Location = new System.Drawing.Point(10, 58);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(120, 20);
            this.lblBarcode.TabIndex = 3;
            this.lblBarcode.Text = "By Product Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBarcode.Location = new System.Drawing.Point(140, 56);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(160, 24);
            this.txtBarcode.TabIndex = 4;
            // 
            // btnSearchByBarcode
            // 
            this.btnSearchByBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnSearchByBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchByBarcode.FlatAppearance.BorderSize = 0;
            this.btnSearchByBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchByBarcode.ForeColor = System.Drawing.Color.White;
            this.btnSearchByBarcode.Location = new System.Drawing.Point(306, 54);
            this.btnSearchByBarcode.Name = "btnSearchByBarcode";
            this.btnSearchByBarcode.Size = new System.Drawing.Size(30, 28);
            this.btnSearchByBarcode.TabIndex = 5;
            this.btnSearchByBarcode.Text = "🔍";
            this.btnSearchByBarcode.UseVisualStyleBackColor = false;
            this.btnSearchByBarcode.Click += new System.EventHandler(this.btnSearchByBarcode_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerName.Location = new System.Drawing.Point(360, 24);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(120, 20);
            this.lblCustomerName.TabIndex = 6;
            this.lblCustomerName.Text = "By Customer Name:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCustomerName.Location = new System.Drawing.Point(480, 22);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(190, 24);
            this.txtCustomerName.TabIndex = 7;
            // 
            // btnSearchByCustomer
            // 
            this.btnSearchByCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnSearchByCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchByCustomer.FlatAppearance.BorderSize = 0;
            this.btnSearchByCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchByCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSearchByCustomer.Location = new System.Drawing.Point(676, 20);
            this.btnSearchByCustomer.Name = "btnSearchByCustomer";
            this.btnSearchByCustomer.Size = new System.Drawing.Size(30, 28);
            this.btnSearchByCustomer.TabIndex = 8;
            this.btnSearchByCustomer.Text = "🔍";
            this.btnSearchByCustomer.UseVisualStyleBackColor = false;
            this.btnSearchByCustomer.Click += new System.EventHandler(this.btnSearchByCustomer_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpRefund);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(8, 8);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(340, 516);
            this.pnlLeft.TabIndex = 0;
            // 
            // grpRefund
            // 
            this.grpRefund.Controls.Add(this.lblRefundMethod);
            this.grpRefund.Controls.Add(this.cmbRefundMethod);
            this.grpRefund.Controls.Add(this.lblPaymentMethod);
            this.grpRefund.Controls.Add(this.cmbPaymentMethod);
            this.grpRefund.Controls.Add(this.lblNotes);
            this.grpRefund.Controls.Add(this.txtNotes);
            this.grpRefund.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpRefund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.grpRefund.Location = new System.Drawing.Point(8, 8);
            this.grpRefund.Name = "grpRefund";
            this.grpRefund.Size = new System.Drawing.Size(324, 300);
            this.grpRefund.TabIndex = 0;
            this.grpRefund.TabStop = false;
            this.grpRefund.Text = "Refund Details";
            // 
            // lblRefundMethod
            // 
            this.lblRefundMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRefundMethod.Location = new System.Drawing.Point(10, 24);
            this.lblRefundMethod.Name = "lblRefundMethod";
            this.lblRefundMethod.Size = new System.Drawing.Size(120, 20);
            this.lblRefundMethod.TabIndex = 0;
            this.lblRefundMethod.Text = "Refund Method:";
            // 
            // cmbRefundMethod
            // 
            this.cmbRefundMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRefundMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbRefundMethod.Items.AddRange(new object[] {
            "Cash",
            "StoreCredit"});
            this.cmbRefundMethod.Location = new System.Drawing.Point(10, 44);
            this.cmbRefundMethod.Name = "cmbRefundMethod";
            this.cmbRefundMethod.Size = new System.Drawing.Size(300, 25);
            this.cmbRefundMethod.TabIndex = 1;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentMethod.Location = new System.Drawing.Point(10, 84);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(120, 20);
            this.lblPaymentMethod.TabIndex = 2;
            this.lblPaymentMethod.Text = "Payment Method:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPaymentMethod.Location = new System.Drawing.Point(10, 104);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(300, 25);
            this.cmbPaymentMethod.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNotes.Location = new System.Drawing.Point(10, 144);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(60, 20);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNotes.Location = new System.Drawing.Point(10, 164);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(300, 100);
            this.txtNotes.TabIndex = 5;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 590);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1100, 60);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(770, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Save Return";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(0)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(910, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 40);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "🗑 Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1006, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✖ Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmSaleReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "FrmSaleReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sale Return";
            this.Load += new System.EventHandler(this.FrmSaleReturn_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.grpRefund.ResumeLayout(false);
            this.grpRefund.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Button btnSearchByNumber;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnSearchByBarcode;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnSearchByCustomer;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlreadyReturned;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturnableQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturnQty;
        private System.Windows.Forms.Label lblSelectedInvoice;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpRefund;
        private System.Windows.Forms.Label lblRefundMethod;
        private System.Windows.Forms.ComboBox cmbRefundMethod;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
    }
}