namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmCouponDialog
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblCouponCode = new System.Windows.Forms.Label();
            this.txtCouponCode = new System.Windows.Forms.TextBox();
            this.lblCouponName = new System.Windows.Forms.Label();
            this.txtCouponName = new System.Windows.Forms.TextBox();
            this.lblCouponNameAr = new System.Windows.Forms.Label();
            this.txtCouponNameAr = new System.Windows.Forms.TextBox();
            this.lblDiscountType = new System.Windows.Forms.Label();
            this.cmbDiscountType = new System.Windows.Forms.ComboBox();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.numDiscountValue = new System.Windows.Forms.NumericUpDown();
            this.lblValueUnit = new System.Windows.Forms.Label();
            this.lblMinPurchase = new System.Windows.Forms.Label();
            this.numMinPurchase = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDiscount = new System.Windows.Forms.Label();
            this.numMaxDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblApplicableOn = new System.Windows.Forms.Label();
            this.cmbApplicableOn = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblUsageLimit = new System.Windows.Forms.Label();
            this.numUsageLimit = new System.Windows.Forms.NumericUpDown();
            this.lblUsageLimitPerCustomer = new System.Windows.Forms.Label();
            this.numUsageLimitPerCustomer = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkIsPublic = new System.Windows.Forms.CheckBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();

            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitPerCustomer)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "Coupon Details";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 60;
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(260, 12);
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.Text = "💾  Save";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(400, 12);
            this.btnCancel.Size = new System.Drawing.Size(110, 36);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // pnlBody
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.AutoScroll = true;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlBody.Controls.Add(this.lblCouponCode);
            this.pnlBody.Controls.Add(this.txtCouponCode);
            this.pnlBody.Controls.Add(this.lblCouponName);
            this.pnlBody.Controls.Add(this.txtCouponName);
            this.pnlBody.Controls.Add(this.lblCouponNameAr);
            this.pnlBody.Controls.Add(this.txtCouponNameAr);
            this.pnlBody.Controls.Add(this.lblDiscountType);
            this.pnlBody.Controls.Add(this.cmbDiscountType);
            this.pnlBody.Controls.Add(this.lblDiscountValue);
            this.pnlBody.Controls.Add(this.numDiscountValue);
            this.pnlBody.Controls.Add(this.lblValueUnit);
            this.pnlBody.Controls.Add(this.lblMinPurchase);
            this.pnlBody.Controls.Add(this.numMinPurchase);
            this.pnlBody.Controls.Add(this.lblMaxDiscount);
            this.pnlBody.Controls.Add(this.numMaxDiscount);
            this.pnlBody.Controls.Add(this.lblApplicableOn);
            this.pnlBody.Controls.Add(this.cmbApplicableOn);
            this.pnlBody.Controls.Add(this.lblStartDate);
            this.pnlBody.Controls.Add(this.dtpStartDate);
            this.pnlBody.Controls.Add(this.lblEndDate);
            this.pnlBody.Controls.Add(this.dtpEndDate);
            this.pnlBody.Controls.Add(this.lblUsageLimit);
            this.pnlBody.Controls.Add(this.numUsageLimit);
            this.pnlBody.Controls.Add(this.lblUsageLimitPerCustomer);
            this.pnlBody.Controls.Add(this.numUsageLimitPerCustomer);
            this.pnlBody.Controls.Add(this.lblDescription);
            this.pnlBody.Controls.Add(this.txtDescription);
            this.pnlBody.Controls.Add(this.chkIsPublic);
            this.pnlBody.Controls.Add(this.chkIsActive);

            // lblCouponCode
            this.lblCouponCode.Text = "Coupon Code:";
            this.lblCouponCode.Location = new System.Drawing.Point(20, 20);
            this.lblCouponCode.Size = new System.Drawing.Size(170, 20);
            this.lblCouponCode.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCouponCode.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // txtCouponCode
            this.txtCouponCode.Location = new System.Drawing.Point(200, 14);
            this.txtCouponCode.Size = new System.Drawing.Size(270, 28);
            this.txtCouponCode.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtCouponCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCouponCode.MaxLength = 30;

            // lblCouponName
            this.lblCouponName.Text = "Coupon Name (EN):";
            this.lblCouponName.Location = new System.Drawing.Point(20, 60);
            this.lblCouponName.Size = new System.Drawing.Size(170, 20);
            this.lblCouponName.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCouponName.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // txtCouponName
            this.txtCouponName.Location = new System.Drawing.Point(200, 54);
            this.txtCouponName.Size = new System.Drawing.Size(270, 28);
            this.txtCouponName.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtCouponName.MaxLength = 100;

            // lblCouponNameAr
            this.lblCouponNameAr.Text = "Coupon Name (AR):";
            this.lblCouponNameAr.Location = new System.Drawing.Point(20, 100);
            this.lblCouponNameAr.Size = new System.Drawing.Size(170, 20);
            this.lblCouponNameAr.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCouponNameAr.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // txtCouponNameAr
            this.txtCouponNameAr.Location = new System.Drawing.Point(200, 94);
            this.txtCouponNameAr.Size = new System.Drawing.Size(270, 28);
            this.txtCouponNameAr.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtCouponNameAr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCouponNameAr.MaxLength = 100;

            // lblDiscountType
            this.lblDiscountType.Text = "Discount Type:";
            this.lblDiscountType.Location = new System.Drawing.Point(20, 140);
            this.lblDiscountType.Size = new System.Drawing.Size(170, 20);
            this.lblDiscountType.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDiscountType.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // cmbDiscountType
            this.cmbDiscountType.Location = new System.Drawing.Point(200, 134);
            this.cmbDiscountType.Size = new System.Drawing.Size(270, 28);
            this.cmbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscountType.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbDiscountType.SelectedIndexChanged += new System.EventHandler(this.cmbDiscountType_SelectedIndexChanged);

            // lblDiscountValue
            this.lblDiscountValue.Text = "Discount Value:";
            this.lblDiscountValue.Location = new System.Drawing.Point(20, 180);
            this.lblDiscountValue.Size = new System.Drawing.Size(170, 20);
            this.lblDiscountValue.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDiscountValue.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // numDiscountValue
            this.numDiscountValue.Location = new System.Drawing.Point(200, 174);
            this.numDiscountValue.Size = new System.Drawing.Size(225, 28);
            this.numDiscountValue.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.numDiscountValue.Minimum = 0;
            this.numDiscountValue.Maximum = 100;
            this.numDiscountValue.DecimalPlaces = 2;
            this.numDiscountValue.ThousandsSeparator = true;

            // lblValueUnit
            this.lblValueUnit.Text = "%";
            this.lblValueUnit.Location = new System.Drawing.Point(430, 180);
            this.lblValueUnit.Size = new System.Drawing.Size(40, 20);
            this.lblValueUnit.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblValueUnit.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);

            // lblMinPurchase
            this.lblMinPurchase.Text = "Min Purchase Amount:";
            this.lblMinPurchase.Location = new System.Drawing.Point(20, 220);
            this.lblMinPurchase.Size = new System.Drawing.Size(170, 20);
            this.lblMinPurchase.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblMinPurchase.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // numMinPurchase
            this.numMinPurchase.Location = new System.Drawing.Point(200, 214);
            this.numMinPurchase.Size = new System.Drawing.Size(270, 28);
            this.numMinPurchase.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.numMinPurchase.Minimum = 0;
            this.numMinPurchase.Maximum = 9999999;
            this.numMinPurchase.DecimalPlaces = 2;
            this.numMinPurchase.ThousandsSeparator = true;

            // lblMaxDiscount
            this.lblMaxDiscount.Text = "Max Discount Amount:";
            this.lblMaxDiscount.Location = new System.Drawing.Point(20, 260);
            this.lblMaxDiscount.Size = new System.Drawing.Size(170, 20);
            this.lblMaxDiscount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblMaxDiscount.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // numMaxDiscount
            this.numMaxDiscount.Location = new System.Drawing.Point(200, 254);
            this.numMaxDiscount.Size = new System.Drawing.Size(270, 28);
            this.numMaxDiscount.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.numMaxDiscount.Minimum = 0;
            this.numMaxDiscount.Maximum = 9999999;
            this.numMaxDiscount.DecimalPlaces = 2;
            this.numMaxDiscount.ThousandsSeparator = true;

            // lblApplicableOn
            this.lblApplicableOn.Text = "Applicable On:";
            this.lblApplicableOn.Location = new System.Drawing.Point(20, 300);
            this.lblApplicableOn.Size = new System.Drawing.Size(170, 20);
            this.lblApplicableOn.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblApplicableOn.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // cmbApplicableOn
            this.cmbApplicableOn.Location = new System.Drawing.Point(200, 294);
            this.cmbApplicableOn.Size = new System.Drawing.Size(270, 28);
            this.cmbApplicableOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplicableOn.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbApplicableOn.Enabled = !_isEditPlaceholder;

            // lblStartDate
            this.lblStartDate.Text = "Start Date:";
            this.lblStartDate.Location = new System.Drawing.Point(20, 340);
            this.lblStartDate.Size = new System.Drawing.Size(170, 20);
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // dtpStartDate
            this.dtpStartDate.Location = new System.Drawing.Point(200, 334);
            this.dtpStartDate.Size = new System.Drawing.Size(270, 28);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpStartDate.Value = System.DateTime.Today;

            // lblEndDate
            this.lblEndDate.Text = "End Date:";
            this.lblEndDate.Location = new System.Drawing.Point(20, 380);
            this.lblEndDate.Size = new System.Drawing.Size(170, 20);
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // dtpEndDate
            this.dtpEndDate.Location = new System.Drawing.Point(200, 374);
            this.dtpEndDate.Size = new System.Drawing.Size(270, 28);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpEndDate.Value = System.DateTime.Today.AddMonths(1);

            // lblUsageLimit
            this.lblUsageLimit.Text = "Usage Limit:";
            this.lblUsageLimit.Location = new System.Drawing.Point(20, 420);
            this.lblUsageLimit.Size = new System.Drawing.Size(170, 20);
            this.lblUsageLimit.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblUsageLimit.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // numUsageLimit
            this.numUsageLimit.Location = new System.Drawing.Point(200, 414);
            this.numUsageLimit.Size = new System.Drawing.Size(270, 28);
            this.numUsageLimit.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.numUsageLimit.Minimum = 0;
            this.numUsageLimit.Maximum = 9999999;

            // lblUsageLimitPerCustomer
            this.lblUsageLimitPerCustomer.Text = "Limit Per Customer:";
            this.lblUsageLimitPerCustomer.Location = new System.Drawing.Point(20, 460);
            this.lblUsageLimitPerCustomer.Size = new System.Drawing.Size(170, 20);
            this.lblUsageLimitPerCustomer.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblUsageLimitPerCustomer.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // numUsageLimitPerCustomer
            this.numUsageLimitPerCustomer.Location = new System.Drawing.Point(200, 454);
            this.numUsageLimitPerCustomer.Size = new System.Drawing.Size(270, 28);
            this.numUsageLimitPerCustomer.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.numUsageLimitPerCustomer.Minimum = 1;
            this.numUsageLimitPerCustomer.Maximum = 9999;
            this.numUsageLimitPerCustomer.Value = 1;

            // lblDescription
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new System.Drawing.Point(20, 500);
            this.lblDescription.Size = new System.Drawing.Size(170, 20);
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(200, 494);
            this.txtDescription.Size = new System.Drawing.Size(270, 28);
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtDescription.MaxLength = 250;

            // chkIsPublic
            this.chkIsPublic.Text = "Public Coupon";
            this.chkIsPublic.Location = new System.Drawing.Point(200, 534);
            this.chkIsPublic.AutoSize = true;
            this.chkIsPublic.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.chkIsPublic.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.chkIsPublic.Checked = true;

            // chkIsActive
            this.chkIsActive.Text = "Active";
            this.chkIsActive.Location = new System.Drawing.Point(350, 534);
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.chkIsActive.Checked = true;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 640);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.BackColor = System.Drawing.Color.White;
            this.Text = "Coupon Details";

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);

            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitPerCustomer)).EndInit();
            this.ResumeLayout(false);
        }

        private bool _isEditPlaceholder = false;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblCouponCode;
        private System.Windows.Forms.TextBox txtCouponCode;
        private System.Windows.Forms.Label lblCouponName;
        private System.Windows.Forms.TextBox txtCouponName;
        private System.Windows.Forms.Label lblCouponNameAr;
        private System.Windows.Forms.TextBox txtCouponNameAr;
        private System.Windows.Forms.Label lblDiscountType;
        private System.Windows.Forms.ComboBox cmbDiscountType;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.NumericUpDown numDiscountValue;
        private System.Windows.Forms.Label lblValueUnit;
        private System.Windows.Forms.Label lblMinPurchase;
        private System.Windows.Forms.NumericUpDown numMinPurchase;
        private System.Windows.Forms.Label lblMaxDiscount;
        private System.Windows.Forms.NumericUpDown numMaxDiscount;
        private System.Windows.Forms.Label lblApplicableOn;
        private System.Windows.Forms.ComboBox cmbApplicableOn;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblUsageLimit;
        private System.Windows.Forms.NumericUpDown numUsageLimit;
        private System.Windows.Forms.Label lblUsageLimitPerCustomer;
        private System.Windows.Forms.NumericUpDown numUsageLimitPerCustomer;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkIsPublic;
        private System.Windows.Forms.CheckBox chkIsActive;
    }
}