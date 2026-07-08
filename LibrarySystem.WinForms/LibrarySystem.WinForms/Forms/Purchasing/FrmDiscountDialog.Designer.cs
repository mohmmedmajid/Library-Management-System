namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmDiscountDialog
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
            this.lblDiscountName = new System.Windows.Forms.Label();
            this.txtDiscountName = new System.Windows.Forms.TextBox();
            this.lblDiscountNameAr = new System.Windows.Forms.Label();
            this.txtDiscountNameAr = new System.Windows.Forms.TextBox();
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
            this.chkIsActive = new System.Windows.Forms.CheckBox();

            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimit)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "Discount Details";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 55;
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 10);
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.Text = "Save";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(390, 10);
            this.btnCancel.Size = new System.Drawing.Size(110, 36);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // lblDiscountName
            this.lblDiscountName.Text = "Discount Name (EN):";
            this.lblDiscountName.Location = new System.Drawing.Point(20, 76);
            this.lblDiscountName.Size = new System.Drawing.Size(170, 20);
            this.lblDiscountName.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDiscountName.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // txtDiscountName
            this.txtDiscountName.Location = new System.Drawing.Point(200, 70);
            this.txtDiscountName.Size = new System.Drawing.Size(270, 28);
            this.txtDiscountName.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // lblDiscountNameAr
            this.lblDiscountNameAr.Text = "Discount Name (AR):";
            this.lblDiscountNameAr.Location = new System.Drawing.Point(20, 116);
            this.lblDiscountNameAr.Size = new System.Drawing.Size(170, 20);
            this.lblDiscountNameAr.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDiscountNameAr.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // txtDiscountNameAr
            this.txtDiscountNameAr.Location = new System.Drawing.Point(200, 110);
            this.txtDiscountNameAr.Size = new System.Drawing.Size(270, 28);
            this.txtDiscountNameAr.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // lblDiscountType
            this.lblDiscountType.Text = "Discount Type:";
            this.lblDiscountType.Location = new System.Drawing.Point(20, 156);
            this.lblDiscountType.Size = new System.Drawing.Size(170, 20);
            this.lblDiscountType.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDiscountType.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // cmbDiscountType
            this.cmbDiscountType.Location = new System.Drawing.Point(200, 150);
            this.cmbDiscountType.Size = new System.Drawing.Size(270, 28);
            this.cmbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscountType.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbDiscountType.SelectedIndexChanged += new System.EventHandler(this.cmbDiscountType_SelectedIndexChanged);

            // lblDiscountValue
            this.lblDiscountValue.Text = "Discount Value:";
            this.lblDiscountValue.Location = new System.Drawing.Point(20, 196);
            this.lblDiscountValue.Size = new System.Drawing.Size(170, 20);
            this.lblDiscountValue.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDiscountValue.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // numDiscountValue
            this.numDiscountValue.Location = new System.Drawing.Point(200, 190);
            this.numDiscountValue.Size = new System.Drawing.Size(225, 28);
            this.numDiscountValue.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.numDiscountValue.Minimum = 0;
            this.numDiscountValue.Maximum = 100;
            this.numDiscountValue.DecimalPlaces = 2;
            this.numDiscountValue.ThousandsSeparator = true;

            // lblValueUnit
            this.lblValueUnit.Text = "%";
            this.lblValueUnit.Location = new System.Drawing.Point(430, 196);
            this.lblValueUnit.Size = new System.Drawing.Size(40, 20);
            this.lblValueUnit.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblValueUnit.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);

            // lblMinPurchase
            this.lblMinPurchase.Text = "Min Purchase Amount:";
            this.lblMinPurchase.Location = new System.Drawing.Point(20, 236);
            this.lblMinPurchase.Size = new System.Drawing.Size(170, 20);
            this.lblMinPurchase.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblMinPurchase.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // numMinPurchase
            this.numMinPurchase.Location = new System.Drawing.Point(200, 230);
            this.numMinPurchase.Size = new System.Drawing.Size(270, 28);
            this.numMinPurchase.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.numMinPurchase.Minimum = 0;
            this.numMinPurchase.Maximum = 9999999;
            this.numMinPurchase.DecimalPlaces = 2;
            this.numMinPurchase.ThousandsSeparator = true;

            // lblMaxDiscount
            this.lblMaxDiscount.Text = "Max Discount Amount:";
            this.lblMaxDiscount.Location = new System.Drawing.Point(20, 276);
            this.lblMaxDiscount.Size = new System.Drawing.Size(170, 20);
            this.lblMaxDiscount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblMaxDiscount.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // numMaxDiscount
            this.numMaxDiscount.Location = new System.Drawing.Point(200, 270);
            this.numMaxDiscount.Size = new System.Drawing.Size(270, 28);
            this.numMaxDiscount.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.numMaxDiscount.Minimum = 0;
            this.numMaxDiscount.Maximum = 9999999;
            this.numMaxDiscount.DecimalPlaces = 2;
            this.numMaxDiscount.ThousandsSeparator = true;

            // lblApplicableOn
            this.lblApplicableOn.Text = "Applicable On:";
            this.lblApplicableOn.Location = new System.Drawing.Point(20, 316);
            this.lblApplicableOn.Size = new System.Drawing.Size(170, 20);
            this.lblApplicableOn.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblApplicableOn.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // cmbApplicableOn
            this.cmbApplicableOn.Location = new System.Drawing.Point(200, 310);
            this.cmbApplicableOn.Size = new System.Drawing.Size(270, 28);
            this.cmbApplicableOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplicableOn.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // lblStartDate
            this.lblStartDate.Text = "Start Date:";
            this.lblStartDate.Location = new System.Drawing.Point(20, 356);
            this.lblStartDate.Size = new System.Drawing.Size(170, 20);
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // dtpStartDate
            this.dtpStartDate.Location = new System.Drawing.Point(200, 350);
            this.dtpStartDate.Size = new System.Drawing.Size(270, 28);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpStartDate.Value = System.DateTime.Today;

            // lblEndDate
            this.lblEndDate.Text = "End Date:";
            this.lblEndDate.Location = new System.Drawing.Point(20, 396);
            this.lblEndDate.Size = new System.Drawing.Size(170, 20);
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // dtpEndDate
            this.dtpEndDate.Location = new System.Drawing.Point(200, 390);
            this.dtpEndDate.Size = new System.Drawing.Size(270, 28);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpEndDate.Value = System.DateTime.Today.AddMonths(1);

            // lblUsageLimit
            this.lblUsageLimit.Text = "Usage Limit:";
            this.lblUsageLimit.Location = new System.Drawing.Point(20, 436);
            this.lblUsageLimit.Size = new System.Drawing.Size(170, 20);
            this.lblUsageLimit.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblUsageLimit.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            // numUsageLimit
            this.numUsageLimit.Location = new System.Drawing.Point(200, 430);
            this.numUsageLimit.Size = new System.Drawing.Size(270, 28);
            this.numUsageLimit.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.numUsageLimit.Minimum = 0;
            this.numUsageLimit.Maximum = 9999999;
            this.numUsageLimit.DecimalPlaces = 0;
            this.numUsageLimit.ThousandsSeparator = true;

            // chkIsActive
            this.chkIsActive.Text = "Active";
            this.chkIsActive.Location = new System.Drawing.Point(200, 470);
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.chkIsActive.Checked = true;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 580);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.BackColor = System.Drawing.Color.White;
            this.Text = "Discount Details";

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.lblDiscountName);
            this.Controls.Add(this.txtDiscountName);
            this.Controls.Add(this.lblDiscountNameAr);
            this.Controls.Add(this.txtDiscountNameAr);
            this.Controls.Add(this.lblDiscountType);
            this.Controls.Add(this.cmbDiscountType);
            this.Controls.Add(this.lblDiscountValue);
            this.Controls.Add(this.numDiscountValue);
            this.Controls.Add(this.lblValueUnit);
            this.Controls.Add(this.lblMinPurchase);
            this.Controls.Add(this.numMinPurchase);
            this.Controls.Add(this.lblMaxDiscount);
            this.Controls.Add(this.numMaxDiscount);
            this.Controls.Add(this.lblApplicableOn);
            this.Controls.Add(this.cmbApplicableOn);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblUsageLimit);
            this.Controls.Add(this.numUsageLimit);
            this.Controls.Add(this.chkIsActive);

            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDiscountName;
        private System.Windows.Forms.TextBox txtDiscountName;
        private System.Windows.Forms.Label lblDiscountNameAr;
        private System.Windows.Forms.TextBox txtDiscountNameAr;
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
        private System.Windows.Forms.CheckBox chkIsActive;
    }
}