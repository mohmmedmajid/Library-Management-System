namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmPurchaseInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpProducts = new System.Windows.Forms.GroupBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnBarcodeSearch = new System.Windows.Forms.Button();
            this.lblQty = new System.Windows.Forms.Label();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnBrowseProducts = new System.Windows.Forms.Button();
            this.lblSearchProduct = new System.Windows.Forms.Label();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountPct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpSupplier = new System.Windows.Forms.GroupBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.btnNewSupplier = new System.Windows.Forms.Button();
            this.lblSupplierDebt = new System.Windows.Forms.Label();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrintLast = new System.Windows.Forms.Button();
            this.chkThermalPrint = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpTotals = new System.Windows.Forms.GroupBox();
            this.lblSubTotalLabel = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblDiscountLabel = new System.Windows.Forms.Label();
            this.txtInvoiceDiscount = new System.Windows.Forms.TextBox();
            this.lblTaxLabel = new System.Windows.Forms.Label();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPaidLabel = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.lblRemainingLabel = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.grpSupplier.SuspendLayout();
            this.grpPayment.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterButtons.SuspendLayout();
            this.grpTotals.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblInvoiceNumber);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Controls.Add(this.lblDateValue);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 58);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🧾 Purchase Invoice";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.lblInvoiceNumber.Location = new System.Drawing.Point(290, 16);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(280, 26);
            this.lblInvoiceNumber.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(210)))));
            this.lblDate.Location = new System.Drawing.Point(1740, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 20);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date:";
            // 
            // lblDateValue
            // 
            this.lblDateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateValue.ForeColor = System.Drawing.Color.White;
            this.lblDateValue.Location = new System.Drawing.Point(1782, 20);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(200, 20);
            this.lblDateValue.TabIndex = 3;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlBody.Controls.Add(this.pnlRight);
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 58);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1100, 544);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlRight.Controls.Add(this.grpProducts);
            this.pnlRight.Controls.Add(this.dgvItems);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(340, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(4, 8, 8, 8);
            this.pnlRight.Size = new System.Drawing.Size(760, 544);
            this.pnlRight.TabIndex = 0;
            // 
            // grpProducts
            // 
            this.grpProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProducts.Controls.Add(this.lblBarcode);
            this.grpProducts.Controls.Add(this.txtBarcode);
            this.grpProducts.Controls.Add(this.btnBarcodeSearch);
            this.grpProducts.Controls.Add(this.lblQty);
            this.grpProducts.Controls.Add(this.nudQty);
            this.grpProducts.Controls.Add(this.lblDiscount);
            this.grpProducts.Controls.Add(this.txtDiscount);
            this.grpProducts.Controls.Add(this.btnAddItem);
            this.grpProducts.Controls.Add(this.btnBrowseProducts);
            this.grpProducts.Controls.Add(this.lblSearchProduct);
            this.grpProducts.Controls.Add(this.txtSearchProduct);
            this.grpProducts.Controls.Add(this.btnSearchProduct);
            this.grpProducts.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.grpProducts.Location = new System.Drawing.Point(4, 8);
            this.grpProducts.Name = "grpProducts";
            this.grpProducts.Size = new System.Drawing.Size(760, 60);
            this.grpProducts.TabIndex = 0;
            this.grpProducts.TabStop = false;
            this.grpProducts.Text = "Add Product";
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBarcode.Location = new System.Drawing.Point(8, 26);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(55, 20);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBarcode.Location = new System.Drawing.Point(66, 23);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(105, 24);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // btnBarcodeSearch
            // 
            this.btnBarcodeSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnBarcodeSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBarcodeSearch.FlatAppearance.BorderSize = 0;
            this.btnBarcodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarcodeSearch.ForeColor = System.Drawing.Color.White;
            this.btnBarcodeSearch.Location = new System.Drawing.Point(173, 23);
            this.btnBarcodeSearch.Name = "btnBarcodeSearch";
            this.btnBarcodeSearch.Size = new System.Drawing.Size(26, 26);
            this.btnBarcodeSearch.TabIndex = 2;
            this.btnBarcodeSearch.Text = "🔍";
            this.btnBarcodeSearch.UseVisualStyleBackColor = false;
            this.btnBarcodeSearch.Click += new System.EventHandler(this.btnBarcodeSearch_Click);
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQty.Location = new System.Drawing.Point(512, 26);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(32, 20);
            this.lblQty.TabIndex = 3;
            this.lblQty.Text = "Qty:";
            // 
            // nudQty
            // 
            this.nudQty.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudQty.Location = new System.Drawing.Point(546, 23);
            this.nudQty.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(65, 24);
            this.nudQty.TabIndex = 4;
            this.nudQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDiscount
            // 
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscount.Location = new System.Drawing.Point(619, 26);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(46, 20);
            this.lblDiscount.TabIndex = 5;
            this.lblDiscount.Text = "Disc%:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiscount.Location = new System.Drawing.Point(667, 23);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(55, 24);
            this.txtDiscount.TabIndex = 6;
            this.txtDiscount.Text = "0";
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(730, 21);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(40, 30);
            this.btnAddItem.TabIndex = 7;
            this.btnAddItem.Text = "+";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnBrowseProducts
            // 
            this.btnBrowseProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(110)))));
            this.btnBrowseProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseProducts.FlatAppearance.BorderSize = 0;
            this.btnBrowseProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseProducts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseProducts.ForeColor = System.Drawing.Color.White;
            this.btnBrowseProducts.Location = new System.Drawing.Point(465, 21);
            this.btnBrowseProducts.Name = "btnBrowseProducts";
            this.btnBrowseProducts.Size = new System.Drawing.Size(40, 30);
            this.btnBrowseProducts.TabIndex = 8;
            this.btnBrowseProducts.Text = "📋";
            this.btnBrowseProducts.UseVisualStyleBackColor = false;
            this.btnBrowseProducts.Click += new System.EventHandler(this.btnBrowseProducts_Click);
            // 
            // lblSearchProduct
            // 
            this.lblSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearchProduct.Location = new System.Drawing.Point(207, 26);
            this.lblSearchProduct.Name = "lblSearchProduct";
            this.lblSearchProduct.Size = new System.Drawing.Size(55, 20);
            this.lblSearchProduct.TabIndex = 9;
            this.lblSearchProduct.Text = "Product:";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearchProduct.Location = new System.Drawing.Point(265, 23);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(160, 24);
            this.txtSearchProduct.TabIndex = 10;
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchProduct.FlatAppearance.BorderSize = 0;
            this.btnSearchProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProduct.ForeColor = System.Drawing.Color.White;
            this.btnSearchProduct.Location = new System.Drawing.Point(429, 23);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(30, 26);
            this.btnSearchProduct.TabIndex = 11;
            this.btnSearchProduct.Text = "🔍";
            this.btnSearchProduct.UseVisualStyleBackColor = false;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.ColumnHeadersHeight = 42;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colProductName,
            this.colBarcode,
            this.colQty,
            this.colCostPrice,
            this.colDiscountPct,
            this.colDiscountAmt,
            this.colTotal,
            this.colEdit,
            this.colDelete});
            this.dgvItems.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvItems.Location = new System.Drawing.Point(4, 76);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 36;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(760, 594);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellClick);
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvItems_CellEndEdit);
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = false;
            // 
            // colProductName
            // 
            this.colProductName.FillWeight = 26F;
            this.colProductName.HeaderText = "Product";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colBarcode
            // 
            this.colBarcode.FillWeight = 12F;
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.FillWeight = 7F;
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            // 
            // colCostPrice
            // 
            this.colCostPrice.FillWeight = 11F;
            this.colCostPrice.HeaderText = "Cost Price";
            this.colCostPrice.Name = "colCostPrice";
            // 
            // colDiscountPct
            // 
            this.colDiscountPct.FillWeight = 8F;
            this.colDiscountPct.HeaderText = "Disc %";
            this.colDiscountPct.Name = "colDiscountPct";
            // 
            // colDiscountAmt
            // 
            this.colDiscountAmt.FillWeight = 10F;
            this.colDiscountAmt.HeaderText = "Disc Amt";
            this.colDiscountAmt.Name = "colDiscountAmt";
            this.colDiscountAmt.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.FillWeight = 11F;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.FillWeight = 6F;
            this.colEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.Text = "✎";
            this.colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            this.colDelete.FillWeight = 6F;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "🗑";
            this.colDelete.UseColumnTextForButtonValue = true;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlLeft.Controls.Add(this.grpSupplier);
            this.pnlLeft.Controls.Add(this.grpPayment);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(8, 8, 4, 8);
            this.pnlLeft.Size = new System.Drawing.Size(340, 544);
            this.pnlLeft.TabIndex = 1;
            // 
            // grpSupplier
            // 
            this.grpSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSupplier.Controls.Add(this.lblSupplier);
            this.grpSupplier.Controls.Add(this.cmbSupplier);
            this.grpSupplier.Controls.Add(this.btnNewSupplier);
            this.grpSupplier.Controls.Add(this.lblSupplierDebt);
            this.grpSupplier.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.grpSupplier.Location = new System.Drawing.Point(8, 8);
            this.grpSupplier.Name = "grpSupplier";
            this.grpSupplier.Size = new System.Drawing.Size(324, 120);
            this.grpSupplier.TabIndex = 0;
            this.grpSupplier.TabStop = false;
            this.grpSupplier.Text = "Supplier";
            // 
            // lblSupplier
            // 
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSupplier.Location = new System.Drawing.Point(10, 24);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(130, 20);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Select Supplier: *";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSupplier.Location = new System.Drawing.Point(10, 44);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(226, 25);
            this.cmbSupplier.TabIndex = 1;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(100)))));
            this.btnNewSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewSupplier.FlatAppearance.BorderSize = 0;
            this.btnNewSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSupplier.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnNewSupplier.ForeColor = System.Drawing.Color.White;
            this.btnNewSupplier.Location = new System.Drawing.Point(245, 44);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(68, 26);
            this.btnNewSupplier.TabIndex = 2;
            this.btnNewSupplier.Text = "+ New";
            this.btnNewSupplier.UseVisualStyleBackColor = false;
            this.btnNewSupplier.Click += new System.EventHandler(this.btnNewSupplier_Click);
            // 
            // lblSupplierDebt
            // 
            this.lblSupplierDebt.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSupplierDebt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSupplierDebt.Location = new System.Drawing.Point(10, 78);
            this.lblSupplierDebt.Name = "lblSupplierDebt";
            this.lblSupplierDebt.Size = new System.Drawing.Size(300, 20);
            this.lblSupplierDebt.TabIndex = 3;
            // 
            // grpPayment
            // 
            this.grpPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPayment.Controls.Add(this.lblPaymentType);
            this.grpPayment.Controls.Add(this.cmbPaymentType);
            this.grpPayment.Controls.Add(this.lblPaymentMethod);
            this.grpPayment.Controls.Add(this.cmbPaymentMethod);
            this.grpPayment.Controls.Add(this.lblNotes);
            this.grpPayment.Controls.Add(this.txtNotes);
            this.grpPayment.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.grpPayment.Location = new System.Drawing.Point(8, 136);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(324, 250);
            this.grpPayment.TabIndex = 1;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Payment & Info";
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentType.Location = new System.Drawing.Point(10, 24);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(120, 20);
            this.lblPaymentType.TabIndex = 0;
            this.lblPaymentType.Text = "Payment Type:";
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPaymentType.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.cmbPaymentType.Location = new System.Drawing.Point(10, 44);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(300, 25);
            this.cmbPaymentType.TabIndex = 1;
            this.cmbPaymentType.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentType_SelectedIndexChanged);
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
            this.cmbPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNotes.Location = new System.Drawing.Point(10, 164);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(300, 70);
            this.txtNotes.TabIndex = 5;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.pnlFooterButtons);
            this.pnlFooter.Controls.Add(this.grpTotals);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 602);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1100, 78);
            this.pnlFooter.TabIndex = 1;
            // 
            // pnlFooterButtons
            // 
            this.pnlFooterButtons.BackColor = System.Drawing.Color.White;
            this.pnlFooterButtons.Controls.Add(this.btnSave);
            this.pnlFooterButtons.Controls.Add(this.btnPrintLast);
            this.pnlFooterButtons.Controls.Add(this.chkThermalPrint);
            this.pnlFooterButtons.Controls.Add(this.btnClear);
            this.pnlFooterButtons.Controls.Add(this.btnClose);
            this.pnlFooterButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFooterButtons.Location = new System.Drawing.Point(680, 0);
            this.pnlFooterButtons.Name = "pnlFooterButtons";
            this.pnlFooterButtons.Size = new System.Drawing.Size(420, 78);
            this.pnlFooterButtons.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(10, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrintLast
            // 
            this.btnPrintLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(140)))), ((int)(((byte)(60)))));
            this.btnPrintLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintLast.FlatAppearance.BorderSize = 0;
            this.btnPrintLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintLast.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintLast.ForeColor = System.Drawing.Color.White;
            this.btnPrintLast.Location = new System.Drawing.Point(120, 19);
            this.btnPrintLast.Name = "btnPrintLast";
            this.btnPrintLast.Size = new System.Drawing.Size(95, 40);
            this.btnPrintLast.TabIndex = 1;
            this.btnPrintLast.Text = "🖨 Print";
            this.btnPrintLast.UseVisualStyleBackColor = false;
            this.btnPrintLast.Click += new System.EventHandler(this.btnPrintLast_Click);
            // 
            // chkThermalPrint
            // 
            this.chkThermalPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkThermalPrint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.chkThermalPrint.Location = new System.Drawing.Point(10, 0);
            this.chkThermalPrint.Name = "chkThermalPrint";
            this.chkThermalPrint.Size = new System.Drawing.Size(90, 18);
            this.chkThermalPrint.TabIndex = 2;
            this.chkThermalPrint.Text = "Thermal";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(0)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(225, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 3;
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
            this.btnClose.Location = new System.Drawing.Point(335, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "✖ Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpTotals
            // 
            this.grpTotals.Controls.Add(this.lblSubTotalLabel);
            this.grpTotals.Controls.Add(this.lblSubTotal);
            this.grpTotals.Controls.Add(this.lblDiscountLabel);
            this.grpTotals.Controls.Add(this.txtInvoiceDiscount);
            this.grpTotals.Controls.Add(this.lblTaxLabel);
            this.grpTotals.Controls.Add(this.lblTaxValue);
            this.grpTotals.Controls.Add(this.lblTotalLabel);
            this.grpTotals.Controls.Add(this.lblTotal);
            this.grpTotals.Controls.Add(this.lblPaidLabel);
            this.grpTotals.Controls.Add(this.txtPaid);
            this.grpTotals.Controls.Add(this.lblRemainingLabel);
            this.grpTotals.Controls.Add(this.lblRemaining);
            this.grpTotals.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTotals.Location = new System.Drawing.Point(8, 4);
            this.grpTotals.Name = "grpTotals";
            this.grpTotals.Size = new System.Drawing.Size(700, 68);
            this.grpTotals.TabIndex = 1;
            this.grpTotals.TabStop = false;
            this.grpTotals.Text = "Totals";
            // 
            // lblSubTotalLabel
            // 
            this.lblSubTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubTotalLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTotalLabel.Location = new System.Drawing.Point(10, 16);
            this.lblSubTotalLabel.Name = "lblSubTotalLabel";
            this.lblSubTotalLabel.Size = new System.Drawing.Size(70, 16);
            this.lblSubTotalLabel.TabIndex = 0;
            this.lblSubTotalLabel.Text = "SubTotal:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblSubTotal.Location = new System.Drawing.Point(10, 34);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(105, 26);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "0.000";
            // 
            // lblDiscountLabel
            // 
            this.lblDiscountLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDiscountLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblDiscountLabel.Location = new System.Drawing.Point(125, 16);
            this.lblDiscountLabel.Name = "lblDiscountLabel";
            this.lblDiscountLabel.Size = new System.Drawing.Size(80, 16);
            this.lblDiscountLabel.TabIndex = 2;
            this.lblDiscountLabel.Text = "Disc:";
            // 
            // txtInvoiceDiscount
            // 
            this.txtInvoiceDiscount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtInvoiceDiscount.Location = new System.Drawing.Point(125, 34);
            this.txtInvoiceDiscount.Name = "txtInvoiceDiscount";
            this.txtInvoiceDiscount.Size = new System.Drawing.Size(85, 27);
            this.txtInvoiceDiscount.TabIndex = 3;
            this.txtInvoiceDiscount.Text = "0";
            this.txtInvoiceDiscount.TextChanged += new System.EventHandler(this.txtInvoiceDiscount_TextChanged);
            // 
            // lblTaxLabel
            // 
            this.lblTaxLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTaxLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTaxLabel.Location = new System.Drawing.Point(230, 16);
            this.lblTaxLabel.Name = "lblTaxLabel";
            this.lblTaxLabel.Size = new System.Drawing.Size(80, 16);
            this.lblTaxLabel.TabIndex = 4;
            this.lblTaxLabel.Text = "Tax (16%):";
            // 
            // lblTaxValue
            // 
            this.lblTaxValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTaxValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(90)))), ((int)(((byte)(0)))));
            this.lblTaxValue.Location = new System.Drawing.Point(230, 34);
            this.lblTaxValue.Name = "lblTaxValue";
            this.lblTaxValue.Size = new System.Drawing.Size(105, 26);
            this.lblTaxValue.TabIndex = 5;
            this.lblTaxValue.Text = "0.000";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalLabel.Location = new System.Drawing.Point(350, 16);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(50, 16);
            this.lblTotalLabel.TabIndex = 6;
            this.lblTotalLabel.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.lblTotal.Location = new System.Drawing.Point(350, 32);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 30);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "0.000";
            // 
            // lblPaidLabel
            // 
            this.lblPaidLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPaidLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblPaidLabel.Location = new System.Drawing.Point(485, 16);
            this.lblPaidLabel.Name = "lblPaidLabel";
            this.lblPaidLabel.Size = new System.Drawing.Size(50, 16);
            this.lblPaidLabel.TabIndex = 8;
            this.lblPaidLabel.Text = "Paid:";
            // 
            // txtPaid
            // 
            this.txtPaid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtPaid.Location = new System.Drawing.Point(485, 34);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(100, 27);
            this.txtPaid.TabIndex = 9;
            this.txtPaid.Text = "0";
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // lblRemainingLabel
            // 
            this.lblRemainingLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRemainingLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblRemainingLabel.Location = new System.Drawing.Point(600, 16);
            this.lblRemainingLabel.Name = "lblRemainingLabel";
            this.lblRemainingLabel.Size = new System.Drawing.Size(100, 16);
            this.lblRemainingLabel.TabIndex = 10;
            this.lblRemainingLabel.Text = "Remaining:";
            // 
            // lblRemaining
            // 
            this.lblRemaining.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRemaining.Location = new System.Drawing.Point(600, 32);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(100, 28);
            this.lblRemaining.TabIndex = 11;
            this.lblRemaining.Text = "0.000";
            // 
            // FrmPurchaseInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FrmPurchaseInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase Invoice";
            this.Load += new System.EventHandler(this.FrmPurchaseInvoice_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.grpProducts.ResumeLayout(false);
            this.grpProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.grpSupplier.ResumeLayout(false);
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterButtons.ResumeLayout(false);
            this.grpTotals.ResumeLayout(false);
            this.grpTotals.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.Label lblSupplierDebt;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpProducts;
        private System.Windows.Forms.Label lblSearchProduct;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.Button btnBrowseProducts;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnBarcodeSearch;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountPct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterButtons;
        private System.Windows.Forms.GroupBox grpTotals;
        private System.Windows.Forms.Label lblSubTotalLabel;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblDiscountLabel;
        private System.Windows.Forms.TextBox txtInvoiceDiscount;
        private System.Windows.Forms.Label lblTaxLabel;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPaidLabel;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label lblRemainingLabel;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrintLast;
        private System.Windows.Forms.CheckBox chkThermalPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
    }
}