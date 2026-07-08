namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmExpenseDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.lblReceipt = new System.Windows.Forms.Label();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "Add Expense";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblTitle.Name = "lblTitle";

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 55;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(420, 10);
            this.btnSave.Size = new System.Drawing.Size(100, 34);
            this.btnSave.Text = "Save";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(530, 10);
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // pnlContent
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30, 20, 30, 10);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Controls.Add(this.txtDescription);
            this.pnlContent.Controls.Add(this.lblDescription);
            this.pnlContent.Controls.Add(this.cmbStatus);
            this.pnlContent.Controls.Add(this.lblStatus);
            this.pnlContent.Controls.Add(this.txtReceipt);
            this.pnlContent.Controls.Add(this.lblReceipt);
            this.pnlContent.Controls.Add(this.txtReference);
            this.pnlContent.Controls.Add(this.lblReference);
            this.pnlContent.Controls.Add(this.txtSupplier);
            this.pnlContent.Controls.Add(this.lblSupplier);
            this.pnlContent.Controls.Add(this.cmbPaymentMethod);
            this.pnlContent.Controls.Add(this.lblPaymentMethod);
            this.pnlContent.Controls.Add(this.txtAmount);
            this.pnlContent.Controls.Add(this.lblAmount);
            this.pnlContent.Controls.Add(this.dtpDate);
            this.pnlContent.Controls.Add(this.lblDate);
            this.pnlContent.Controls.Add(this.cmbCategory);
            this.pnlContent.Controls.Add(this.lblCategory);

            // Row 1 - Category + Date
            this.lblCategory.Text = "Category:";
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(30, 25);
            this.lblCategory.Size = new System.Drawing.Size(100, 22);
            this.lblCategory.Name = "lblCategory";

            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.cmbCategory.Location = new System.Drawing.Point(30, 50);
            this.cmbCategory.Size = new System.Drawing.Size(260, 28);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.TabIndex = 0;

            this.lblDate.Text = "Expense Date:";
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(310, 25);
            this.lblDate.Size = new System.Drawing.Size(110, 22);
            this.lblDate.Name = "lblDate";

            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(310, 50);
            this.dtpDate.Size = new System.Drawing.Size(260, 28);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.TabIndex = 1;

            // Row 2 - Amount + PaymentMethod
            this.lblAmount.Text = "Amount:";
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(30, 95);
            this.lblAmount.Size = new System.Drawing.Size(100, 22);
            this.lblAmount.Name = "lblAmount";

            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtAmount.Location = new System.Drawing.Point(30, 120);
            this.txtAmount.Size = new System.Drawing.Size(260, 28);
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.TabIndex = 2;

            this.lblPaymentMethod.Text = "Payment Method:";
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblPaymentMethod.Location = new System.Drawing.Point(310, 95);
            this.lblPaymentMethod.Size = new System.Drawing.Size(130, 22);
            this.lblPaymentMethod.Name = "lblPaymentMethod";

            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.cmbPaymentMethod.Location = new System.Drawing.Point(310, 120);
            this.cmbPaymentMethod.Size = new System.Drawing.Size(260, 28);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.TabIndex = 3;

            // Row 3 - Supplier + Status
            this.lblSupplier.Text = "Supplier Name:";
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSupplier.Location = new System.Drawing.Point(30, 165);
            this.lblSupplier.Size = new System.Drawing.Size(120, 22);
            this.lblSupplier.Name = "lblSupplier";

            this.txtSupplier.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtSupplier.Location = new System.Drawing.Point(30, 190);
            this.txtSupplier.Size = new System.Drawing.Size(260, 28);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.TabIndex = 4;

            this.lblStatus.Text = "Status:";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(310, 165);
            this.lblStatus.Size = new System.Drawing.Size(80, 22);
            this.lblStatus.Name = "lblStatus";

            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.cmbStatus.Location = new System.Drawing.Point(310, 190);
            this.cmbStatus.Size = new System.Drawing.Size(260, 28);
            this.cmbStatus.Items.AddRange(new object[] { "Paid", "Pending" });
            this.cmbStatus.SelectedIndex = 0;
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.TabIndex = 5;

            // Row 4 - Reference + Receipt
            this.lblReference.Text = "Reference No.:";
            this.lblReference.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblReference.Location = new System.Drawing.Point(30, 235);
            this.lblReference.Size = new System.Drawing.Size(120, 22);
            this.lblReference.Name = "lblReference";

            this.txtReference.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtReference.Location = new System.Drawing.Point(30, 260);
            this.txtReference.Size = new System.Drawing.Size(250, 28);
            this.txtReference.Name = "txtReference";
            this.txtReference.TabIndex = 6;

            this.lblReceipt.Text = "Receipt No.:";
            this.lblReceipt.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblReceipt.Location = new System.Drawing.Point(310, 235);
            this.lblReceipt.Size = new System.Drawing.Size(110, 22);
            this.lblReceipt.Name = "lblReceipt";

            this.txtReceipt.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtReceipt.Location = new System.Drawing.Point(310, 260);
            this.txtReceipt.Size = new System.Drawing.Size(250, 28);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.TabIndex = 7;

            // Row 5 - Description
            this.lblDescription.Text = "Description:";
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(30, 305);
            this.lblDescription.Size = new System.Drawing.Size(120, 22);
            this.lblDescription.Name = "lblDescription";

            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtDescription.Location = new System.Drawing.Point(30, 330);
            this.txtDescription.Size = new System.Drawing.Size(120, 80);
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top
                                        | System.Windows.Forms.AnchorStyles.Left
                                        | System.Windows.Forms.AnchorStyles.Right;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.TabIndex = 8;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 540);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExpenseDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expense";
            this.Load += new System.EventHandler(this.FrmExpenseDialog_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label lblReceipt;
        private System.Windows.Forms.TextBox txtReceipt;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}