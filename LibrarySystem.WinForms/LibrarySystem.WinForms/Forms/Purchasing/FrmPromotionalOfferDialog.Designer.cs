namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmPromotionalOfferDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;

        private System.Windows.Forms.Label lblOfferName;
        private System.Windows.Forms.TextBox txtOfferName;
        private System.Windows.Forms.Label lblOfferNameAr;
        private System.Windows.Forms.TextBox txtOfferNameAr;
        private System.Windows.Forms.Label lblOfferType;
        private System.Windows.Forms.ComboBox cmbOfferType;
        private System.Windows.Forms.Label lblApplicableOn;
        private System.Windows.Forms.ComboBox cmbApplicableOn;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;

        private System.Windows.Forms.Panel pnlBOGO;
        private System.Windows.Forms.Label lblBuyQuantity;
        private System.Windows.Forms.NumericUpDown numBuyQuantity;
        private System.Windows.Forms.Label lblGetQuantity;
        private System.Windows.Forms.NumericUpDown numGetQuantity;
        private System.Windows.Forms.Label lblBuyProduct;
        private System.Windows.Forms.ComboBox cmbBuyProduct;
        private System.Windows.Forms.Label lblGetProduct;
        private System.Windows.Forms.ComboBox cmbGetProduct;

        private System.Windows.Forms.Panel pnlBundle;
        private System.Windows.Forms.Label lblBundlePrice;
        private System.Windows.Forms.NumericUpDown numBundlePrice;

        private System.Windows.Forms.Panel pnlPercentage;
        private System.Windows.Forms.Label lblDiscountPercent;
        private System.Windows.Forms.NumericUpDown numDiscountPercent;

        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.spinner = new LibrarySystem.WinForms.UserControls.LoadingSpinnerControl();

            this.lblOfferName = new System.Windows.Forms.Label();
            this.txtOfferName = new System.Windows.Forms.TextBox();
            this.lblOfferNameAr = new System.Windows.Forms.Label();
            this.txtOfferNameAr = new System.Windows.Forms.TextBox();
            this.lblOfferType = new System.Windows.Forms.Label();
            this.cmbOfferType = new System.Windows.Forms.ComboBox();
            this.lblApplicableOn = new System.Windows.Forms.Label();
            this.cmbApplicableOn = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();

            this.pnlBOGO = new System.Windows.Forms.Panel();
            this.lblBuyQuantity = new System.Windows.Forms.Label();
            this.numBuyQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblGetQuantity = new System.Windows.Forms.Label();
            this.numGetQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblBuyProduct = new System.Windows.Forms.Label();
            this.cmbBuyProduct = new System.Windows.Forms.ComboBox();
            this.lblGetProduct = new System.Windows.Forms.Label();
            this.cmbGetProduct = new System.Windows.Forms.ComboBox();

            this.pnlBundle = new System.Windows.Forms.Panel();
            this.lblBundlePrice = new System.Windows.Forms.Label();
            this.numBundlePrice = new System.Windows.Forms.NumericUpDown();

            this.pnlPercentage = new System.Windows.Forms.Panel();
            this.lblDiscountPercent = new System.Windows.Forms.Label();
            this.numDiscountPercent = new System.Windows.Forms.NumericUpDown();

            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblPriority = new System.Windows.Forms.Label();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlBOGO.SuspendLayout();
            this.pnlBundle.SuspendLayout();
            this.pnlPercentage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBuyQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGetQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBundlePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 50;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.spinner);

            // lblTitle
            this.lblTitle.Text = "Add Promotional Offer";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // spinner
            this.spinner.Location = new System.Drawing.Point(530, 8);
            this.spinner.Size = new System.Drawing.Size(34, 34);

            // lblOfferName
            this.lblOfferName.AutoSize = true;
            this.lblOfferName.Location = new System.Drawing.Point(12, 65);
            this.lblOfferName.Text = "Offer Name:";

            // txtOfferName
            this.txtOfferName.Location = new System.Drawing.Point(130, 62);
            this.txtOfferName.Size = new System.Drawing.Size(420, 24);

            // lblOfferNameAr
            this.lblOfferNameAr.AutoSize = true;
            this.lblOfferNameAr.Location = new System.Drawing.Point(12, 97);
            this.lblOfferNameAr.Text = "Offer Name (Ar):";

            // txtOfferNameAr
            this.txtOfferNameAr.Location = new System.Drawing.Point(130, 94);
            this.txtOfferNameAr.Size = new System.Drawing.Size(420, 24);

            // lblOfferType
            this.lblOfferType.AutoSize = true;
            this.lblOfferType.Location = new System.Drawing.Point(12, 129);
            this.lblOfferType.Text = "Offer Type:";

            // cmbOfferType
            this.cmbOfferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOfferType.Location = new System.Drawing.Point(130, 126);
            this.cmbOfferType.Size = new System.Drawing.Size(150, 24);
            this.cmbOfferType.SelectedIndexChanged += new System.EventHandler(this.cmbOfferType_SelectedIndexChanged);

            // lblApplicableOn
            this.lblApplicableOn.AutoSize = true;
            this.lblApplicableOn.Location = new System.Drawing.Point(300, 129);
            this.lblApplicableOn.Text = "Applicable On:";

            // cmbApplicableOn
            this.cmbApplicableOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplicableOn.Location = new System.Drawing.Point(410, 126);
            this.cmbApplicableOn.Size = new System.Drawing.Size(140, 24);
            this.cmbApplicableOn.SelectedIndexChanged += new System.EventHandler(this.cmbApplicableOn_SelectedIndexChanged);

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 161);
            this.lblCategory.Text = "Category:";

            // cmbCategory
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(130, 158);
            this.cmbCategory.Size = new System.Drawing.Size(300, 24);

            // pnlBOGO
            this.pnlBOGO.Location = new System.Drawing.Point(0, 193);
            this.pnlBOGO.Size = new System.Drawing.Size(560, 110);
            this.pnlBOGO.Controls.Add(this.lblBuyQuantity);
            this.pnlBOGO.Controls.Add(this.numBuyQuantity);
            this.pnlBOGO.Controls.Add(this.lblGetQuantity);
            this.pnlBOGO.Controls.Add(this.numGetQuantity);
            this.pnlBOGO.Controls.Add(this.lblBuyProduct);
            this.pnlBOGO.Controls.Add(this.cmbBuyProduct);
            this.pnlBOGO.Controls.Add(this.lblGetProduct);
            this.pnlBOGO.Controls.Add(this.cmbGetProduct);

            // lblBuyQuantity
            this.lblBuyQuantity.AutoSize = true;
            this.lblBuyQuantity.Location = new System.Drawing.Point(12, 3);
            this.lblBuyQuantity.Text = "Buy Qty:";

            // numBuyQuantity
            this.numBuyQuantity.Location = new System.Drawing.Point(130, 0);
            this.numBuyQuantity.Size = new System.Drawing.Size(80, 24);
            this.numBuyQuantity.Minimum = 1;
            this.numBuyQuantity.Maximum = 1000;
            this.numBuyQuantity.Value = 1;

            // lblGetQuantity
            this.lblGetQuantity.AutoSize = true;
            this.lblGetQuantity.Location = new System.Drawing.Point(240, 3);
            this.lblGetQuantity.Text = "Get Qty:";

            // numGetQuantity
            this.numGetQuantity.Location = new System.Drawing.Point(330, 0);
            this.numGetQuantity.Size = new System.Drawing.Size(80, 24);
            this.numGetQuantity.Minimum = 1;
            this.numGetQuantity.Maximum = 1000;
            this.numGetQuantity.Value = 1;

            // lblBuyProduct
            this.lblBuyProduct.AutoSize = true;
            this.lblBuyProduct.Location = new System.Drawing.Point(12, 38);
            this.lblBuyProduct.Text = "Buy Product:";

            // cmbBuyProduct
            this.cmbBuyProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuyProduct.Location = new System.Drawing.Point(130, 35);
            this.cmbBuyProduct.Size = new System.Drawing.Size(400, 24);

            // lblGetProduct
            this.lblGetProduct.AutoSize = true;
            this.lblGetProduct.Location = new System.Drawing.Point(12, 73);
            this.lblGetProduct.Text = "Get Product:";

            // cmbGetProduct
            this.cmbGetProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGetProduct.Location = new System.Drawing.Point(130, 70);
            this.cmbGetProduct.Size = new System.Drawing.Size(400, 24);

            // pnlBundle
            this.pnlBundle.Location = new System.Drawing.Point(0, 193);
            this.pnlBundle.Size = new System.Drawing.Size(560, 40);
            this.pnlBundle.Visible = false;
            this.pnlBundle.Controls.Add(this.lblBundlePrice);
            this.pnlBundle.Controls.Add(this.numBundlePrice);

            // lblBundlePrice
            this.lblBundlePrice.AutoSize = true;
            this.lblBundlePrice.Location = new System.Drawing.Point(12, 8);
            this.lblBundlePrice.Text = "Bundle Price:";

            // numBundlePrice
            this.numBundlePrice.Location = new System.Drawing.Point(130, 5);
            this.numBundlePrice.Size = new System.Drawing.Size(120, 24);
            this.numBundlePrice.DecimalPlaces = 2;
            this.numBundlePrice.Maximum = 999999;

            // pnlPercentage
            this.pnlPercentage.Location = new System.Drawing.Point(0, 193);
            this.pnlPercentage.Size = new System.Drawing.Size(560, 40);
            this.pnlPercentage.Visible = false;
            this.pnlPercentage.Controls.Add(this.lblDiscountPercent);
            this.pnlPercentage.Controls.Add(this.numDiscountPercent);

            // lblDiscountPercent
            this.lblDiscountPercent.AutoSize = true;
            this.lblDiscountPercent.Location = new System.Drawing.Point(12, 8);
            this.lblDiscountPercent.Text = "Discount %:";

            // numDiscountPercent
            this.numDiscountPercent.Location = new System.Drawing.Point(130, 5);
            this.numDiscountPercent.Size = new System.Drawing.Size(120, 24);
            this.numDiscountPercent.DecimalPlaces = 2;
            this.numDiscountPercent.Maximum = 100;

            // lblStartDate
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(12, 318);
            this.lblStartDate.Text = "Start Date:";

            // dtpStartDate
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(130, 315);
            this.dtpStartDate.Size = new System.Drawing.Size(150, 24);

            // lblEndDate
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(300, 318);
            this.lblEndDate.Text = "End Date:";

            // dtpEndDate
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(410, 315);
            this.dtpEndDate.Size = new System.Drawing.Size(150, 24);

            // lblPriority
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(12, 350);
            this.lblPriority.Text = "Priority:";

            // numPriority
            this.numPriority.Location = new System.Drawing.Point(130, 347);
            this.numPriority.Size = new System.Drawing.Size(80, 24);
            this.numPriority.Minimum = 0;
            this.numPriority.Maximum = 100;

            // chkIsActive
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(300, 350);
            this.chkIsActive.Text = "Active";
            this.chkIsActive.Visible = false;

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 382);
            this.lblDescription.Text = "Description:";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(130, 379);
            this.txtDescription.Size = new System.Drawing.Size(420, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(350, 460);
            this.btnSave.Size = new System.Drawing.Size(100, 34);
            this.btnSave.Text = "Save";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(460, 460);
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FrmPromotionalOfferDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 510);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.BackColor = System.Drawing.Color.White;
            this.Text = "Promotional Offer";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.Load += new System.EventHandler(this.FrmPromotionalOfferDialog_Load);

            this.Controls.Add(this.lblOfferName);
            this.Controls.Add(this.txtOfferName);
            this.Controls.Add(this.lblOfferNameAr);
            this.Controls.Add(this.txtOfferNameAr);
            this.Controls.Add(this.lblOfferType);
            this.Controls.Add(this.cmbOfferType);
            this.Controls.Add(this.lblApplicableOn);
            this.Controls.Add(this.cmbApplicableOn);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.pnlBOGO);
            this.Controls.Add(this.pnlBundle);
            this.Controls.Add(this.pnlPercentage);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.numPriority);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlTop);

            this.pnlTop.ResumeLayout(false);
            this.pnlBOGO.ResumeLayout(false);
            this.pnlBundle.ResumeLayout(false);
            this.pnlPercentage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBuyQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGetQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBundlePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}