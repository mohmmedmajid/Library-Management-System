namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmExchangeInvoice
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.grpExchange = new System.Windows.Forms.GroupBox();
            this.lblDifferenceCase = new System.Windows.Forms.Label();
            this.lblDifferenceValueLabel = new System.Windows.Forms.Label();
            this.lblDifference = new System.Windows.Forms.Label();
            this.lblNewProduct = new System.Windows.Forms.Label();
            this.txtSearchNewProduct = new System.Windows.Forms.TextBox();
            this.btnSearchNewProduct = new System.Windows.Forms.Button();
            this.lblNewUnitPrice = new System.Windows.Forms.Label();
            this.lblNewQty = new System.Windows.Forms.Label();
            this.nudNewQty = new System.Windows.Forms.NumericUpDown();
            this.lblOldProduct = new System.Windows.Forms.Label();
            this.cmbOldProduct = new System.Windows.Forms.ComboBox();
            this.lblOldUnitPrice = new System.Windows.Forms.Label();
            this.lblOldQty = new System.Windows.Forms.Label();
            this.nudOldQty = new System.Windows.Forms.NumericUpDown();
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
            this.lblSelectedInvoice = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrintLast = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkThermalPrint = new System.Windows.Forms.CheckBox();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.grpExchange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOldQty)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpPayment.SuspendLayout();
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
            this.lblTitle.Text = "🔄 Exchange Invoice";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlBody.Controls.Add(this.grpExchange);
            this.pnlBody.Controls.Add(this.grpSearch);
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 58);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBody.Size = new System.Drawing.Size(1100, 532);
            this.pnlBody.TabIndex = 1;
            // 
            // grpExchange
            // 
            this.grpExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExchange.Controls.Add(this.lblDifferenceCase);
            this.grpExchange.Controls.Add(this.lblDifferenceValueLabel);
            this.grpExchange.Controls.Add(this.lblDifference);
            this.grpExchange.Controls.Add(this.lblNewProduct);
            this.grpExchange.Controls.Add(this.txtSearchNewProduct);
            this.grpExchange.Controls.Add(this.btnSearchNewProduct);
            this.grpExchange.Controls.Add(this.lblNewUnitPrice);
            this.grpExchange.Controls.Add(this.lblNewQty);
            this.grpExchange.Controls.Add(this.nudNewQty);
            this.grpExchange.Controls.Add(this.lblOldProduct);
            this.grpExchange.Controls.Add(this.cmbOldProduct);
            this.grpExchange.Controls.Add(this.lblOldUnitPrice);
            this.grpExchange.Controls.Add(this.lblOldQty);
            this.grpExchange.Controls.Add(this.nudOldQty);
            this.grpExchange.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpExchange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.grpExchange.Location = new System.Drawing.Point(348, 118);
            this.grpExchange.Name = "grpExchange";
            this.grpExchange.Size = new System.Drawing.Size(744, 406);
            this.grpExchange.TabIndex = 2;
            this.grpExchange.TabStop = false;
            this.grpExchange.Text = "Exchange Details";
            // 
            // lblDifferenceCase
            // 
            this.lblDifferenceCase.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDifferenceCase.Location = new System.Drawing.Point(14, 300);
            this.lblDifferenceCase.Name = "lblDifferenceCase";
            this.lblDifferenceCase.Size = new System.Drawing.Size(700, 30);
            this.lblDifferenceCase.TabIndex = 13;
            // 
            // lblDifferenceValueLabel
            // 
            this.lblDifferenceValueLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDifferenceValueLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblDifferenceValueLabel.Location = new System.Drawing.Point(14, 250);
            this.lblDifferenceValueLabel.Name = "lblDifferenceValueLabel";
            this.lblDifferenceValueLabel.Size = new System.Drawing.Size(150, 24);
            this.lblDifferenceValueLabel.TabIndex = 11;
            this.lblDifferenceValueLabel.Text = "Price Difference:";
            // 
            // lblDifference
            // 
            this.lblDifference.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDifference.Location = new System.Drawing.Point(14, 270);
            this.lblDifference.Name = "lblDifference";
            this.lblDifference.Size = new System.Drawing.Size(300, 36);
            this.lblDifference.TabIndex = 12;
            this.lblDifference.Text = "0.000";
            // 
            // lblNewProduct
            // 
            this.lblNewProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewProduct.Location = new System.Drawing.Point(14, 150);
            this.lblNewProduct.Name = "lblNewProduct";
            this.lblNewProduct.Size = new System.Drawing.Size(150, 20);
            this.lblNewProduct.TabIndex = 7;
            this.lblNewProduct.Text = "New Product:";
            // 
            // txtSearchNewProduct
            // 
            this.txtSearchNewProduct.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearchNewProduct.Location = new System.Drawing.Point(14, 170);
            this.txtSearchNewProduct.Name = "txtSearchNewProduct";
            this.txtSearchNewProduct.Size = new System.Drawing.Size(400, 24);
            this.txtSearchNewProduct.TabIndex = 8;
            // 
            // btnSearchNewProduct
            // 
            this.btnSearchNewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnSearchNewProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchNewProduct.FlatAppearance.BorderSize = 0;
            this.btnSearchNewProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchNewProduct.ForeColor = System.Drawing.Color.White;
            this.btnSearchNewProduct.Location = new System.Drawing.Point(420, 168);
            this.btnSearchNewProduct.Name = "btnSearchNewProduct";
            this.btnSearchNewProduct.Size = new System.Drawing.Size(30, 28);
            this.btnSearchNewProduct.TabIndex = 9;
            this.btnSearchNewProduct.Text = "🔍";
            this.btnSearchNewProduct.UseVisualStyleBackColor = false;
            this.btnSearchNewProduct.Click += new System.EventHandler(this.btnSearchNewProduct_Click);
            // 
            // lblNewUnitPrice
            // 
            this.lblNewUnitPrice.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblNewUnitPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblNewUnitPrice.Location = new System.Drawing.Point(14, 202);
            this.lblNewUnitPrice.Name = "lblNewUnitPrice";
            this.lblNewUnitPrice.Size = new System.Drawing.Size(400, 20);
            this.lblNewUnitPrice.TabIndex = 10;
            // 
            // lblNewQty
            // 
            this.lblNewQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewQty.Location = new System.Drawing.Point(460, 150);
            this.lblNewQty.Name = "lblNewQty";
            this.lblNewQty.Size = new System.Drawing.Size(80, 20);
            this.lblNewQty.TabIndex = 100;
            this.lblNewQty.Text = "New Qty:";
            // 
            // nudNewQty
            // 
            this.nudNewQty.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudNewQty.Location = new System.Drawing.Point(460, 170);
            this.nudNewQty.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudNewQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNewQty.Name = "nudNewQty";
            this.nudNewQty.Size = new System.Drawing.Size(90, 24);
            this.nudNewQty.TabIndex = 101;
            this.nudNewQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNewQty.ValueChanged += new System.EventHandler(this.nudNewQty_ValueChanged);
            // 
            // lblOldProduct
            // 
            this.lblOldProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOldProduct.Location = new System.Drawing.Point(14, 24);
            this.lblOldProduct.Name = "lblOldProduct";
            this.lblOldProduct.Size = new System.Drawing.Size(200, 20);
            this.lblOldProduct.TabIndex = 0;
            this.lblOldProduct.Text = "Product to Exchange (Old):";
            // 
            // cmbOldProduct
            // 
            this.cmbOldProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOldProduct.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbOldProduct.Location = new System.Drawing.Point(14, 44);
            this.cmbOldProduct.Name = "cmbOldProduct";
            this.cmbOldProduct.Size = new System.Drawing.Size(436, 25);
            this.cmbOldProduct.TabIndex = 1;
            this.cmbOldProduct.SelectedIndexChanged += new System.EventHandler(this.cmbOldProduct_SelectedIndexChanged);
            // 
            // lblOldUnitPrice
            // 
            this.lblOldUnitPrice.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblOldUnitPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblOldUnitPrice.Location = new System.Drawing.Point(14, 76);
            this.lblOldUnitPrice.Name = "lblOldUnitPrice";
            this.lblOldUnitPrice.Size = new System.Drawing.Size(400, 20);
            this.lblOldUnitPrice.TabIndex = 2;
            // 
            // lblOldQty
            // 
            this.lblOldQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOldQty.Location = new System.Drawing.Point(460, 24);
            this.lblOldQty.Name = "lblOldQty";
            this.lblOldQty.Size = new System.Drawing.Size(80, 20);
            this.lblOldQty.TabIndex = 3;
            this.lblOldQty.Text = "Old Qty:";
            // 
            // nudOldQty
            // 
            this.nudOldQty.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudOldQty.Location = new System.Drawing.Point(460, 44);
            this.nudOldQty.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudOldQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOldQty.Name = "nudOldQty";
            this.nudOldQty.Size = new System.Drawing.Size(90, 24);
            this.nudOldQty.TabIndex = 4;
            this.nudOldQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOldQty.ValueChanged += new System.EventHandler(this.nudOldQty_ValueChanged);
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
            this.grpSearch.Controls.Add(this.lblSelectedInvoice);
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
            // lblSelectedInvoice
            // 
            this.lblSelectedInvoice.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSelectedInvoice.ForeColor = System.Drawing.Color.Gray;
            this.lblSelectedInvoice.Location = new System.Drawing.Point(10, 82);
            this.lblSelectedInvoice.Name = "lblSelectedInvoice";
            this.lblSelectedInvoice.Size = new System.Drawing.Size(724, 20);
            this.lblSelectedInvoice.TabIndex = 9;
            this.lblSelectedInvoice.Text = "No invoice selected";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpPayment);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(8, 8);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(340, 516);
            this.pnlLeft.TabIndex = 0;
            // 
            // grpPayment
            // 
            this.grpPayment.Controls.Add(this.lblPaymentMethod);
            this.grpPayment.Controls.Add(this.cmbPaymentMethod);
            this.grpPayment.Controls.Add(this.lblNotes);
            this.grpPayment.Controls.Add(this.txtNotes);
            this.grpPayment.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.grpPayment.Location = new System.Drawing.Point(8, 8);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(324, 260);
            this.grpPayment.TabIndex = 0;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Payment & Notes";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentMethod.Location = new System.Drawing.Point(10, 24);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(120, 20);
            this.lblPaymentMethod.TabIndex = 0;
            this.lblPaymentMethod.Text = "Payment Method:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPaymentMethod.Location = new System.Drawing.Point(10, 44);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(300, 25);
            this.cmbPaymentMethod.TabIndex = 1;
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNotes.Location = new System.Drawing.Point(10, 84);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(60, 20);
            this.lblNotes.TabIndex = 2;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNotes.Location = new System.Drawing.Point(10, 104);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(300, 140);
            this.txtNotes.TabIndex = 3;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnPrintLast);
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Controls.Add(this.chkThermalPrint);
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
            this.btnSave.Location = new System.Drawing.Point(600, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Save Exchange";
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
            this.btnPrintLast.Location = new System.Drawing.Point(750, 15);
            this.btnPrintLast.Name = "btnPrintLast";
            this.btnPrintLast.Size = new System.Drawing.Size(100, 40);
            this.btnPrintLast.TabIndex = 1;
            this.btnPrintLast.Text = "🖨 Print";
            this.btnPrintLast.UseVisualStyleBackColor = false;
            this.btnPrintLast.Click += new System.EventHandler(this.btnPrintLast_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(0)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(860, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 40);
            this.btnClear.TabIndex = 2;
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
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "✖ Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkThermalPrint
            // 
            this.chkThermalPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkThermalPrint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.chkThermalPrint.Location = new System.Drawing.Point(750, -1);
            this.chkThermalPrint.Name = "chkThermalPrint";
            this.chkThermalPrint.Size = new System.Drawing.Size(100, 18);
            this.chkThermalPrint.TabIndex = 4;
            this.chkThermalPrint.Text = "Thermal";
            // 
            // FrmExchangeInvoice
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
            this.Name = "FrmExchangeInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exchange Invoice";
            this.Load += new System.EventHandler(this.FrmExchangeInvoice_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.grpExchange.ResumeLayout(false);
            this.grpExchange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOldQty)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
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
        private System.Windows.Forms.Label lblSelectedInvoice;
        private System.Windows.Forms.GroupBox grpExchange;
        private System.Windows.Forms.Label lblOldProduct;
        private System.Windows.Forms.ComboBox cmbOldProduct;
        private System.Windows.Forms.Label lblOldUnitPrice;
        private System.Windows.Forms.Label lblOldQty;
        private System.Windows.Forms.NumericUpDown nudOldQty;
        private System.Windows.Forms.Label lblNewProduct;
        private System.Windows.Forms.TextBox txtSearchNewProduct;
        private System.Windows.Forms.Button btnSearchNewProduct;
        private System.Windows.Forms.Label lblNewUnitPrice;
        private System.Windows.Forms.Label lblNewQty;
        private System.Windows.Forms.NumericUpDown nudNewQty;
        private System.Windows.Forms.Label lblDifferenceValueLabel;
        private System.Windows.Forms.Label lblDifference;
        private System.Windows.Forms.Label lblDifferenceCase;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrintLast;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkThermalPrint;
    }
}