namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmSupplierTransactionDialog
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
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.cmbInvoiceNumber = new System.Windows.Forms.ComboBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
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
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "Add Supplier Transaction";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // pnlContent
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30, 20, 30, 10);
            this.pnlContent.Controls.Add(this.txtNotes);
            this.pnlContent.Controls.Add(this.lblNotes);
            this.pnlContent.Controls.Add(this.txtReference);
            this.pnlContent.Controls.Add(this.lblReference);
            this.pnlContent.Controls.Add(this.cmbInvoiceNumber);
            this.pnlContent.Controls.Add(this.lblInvoiceNumber);
            this.pnlContent.Controls.Add(this.dtpDate);
            this.pnlContent.Controls.Add(this.lblDate);
            this.pnlContent.Controls.Add(this.txtAmount);
            this.pnlContent.Controls.Add(this.lblAmount);
            this.pnlContent.Controls.Add(this.cmbType);
            this.pnlContent.Controls.Add(this.lblType);
            this.pnlContent.Controls.Add(this.cmbSupplier);
            this.pnlContent.Controls.Add(this.lblSupplier);

            // Row 1 - Supplier
            this.lblSupplier.Text = "Supplier:";
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSupplier.Location = new System.Drawing.Point(30, 25);
            this.lblSupplier.Size = new System.Drawing.Size(120, 22);

            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.cmbSupplier.Location = new System.Drawing.Point(30, 49);
            this.cmbSupplier.Size = new System.Drawing.Size(330, 28);

            // Row 1 - Type
            this.lblType.Text = "Transaction Type:";
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblType.Location = new System.Drawing.Point(375, 25);
            this.lblType.Size = new System.Drawing.Size(140, 22);

            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.cmbType.Location = new System.Drawing.Point(375, 49);
            this.cmbType.Size = new System.Drawing.Size(215, 28);
            this.cmbType.Items.AddRange(new object[] { "Purchase", "Payment", "Return" });
            this.cmbType.SelectedIndex = 0;

            // Row 2 - Amount
            this.lblAmount.Text = "Amount:";
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(30, 95);
            this.lblAmount.Size = new System.Drawing.Size(120, 22);

            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtAmount.Location = new System.Drawing.Point(30, 119);
            this.txtAmount.Size = new System.Drawing.Size(250, 28);
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // Row 2 - Date
            this.lblDate.Text = "Transaction Date:";
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(295, 95);
            this.lblDate.Size = new System.Drawing.Size(140, 22);

            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(295, 119);
            this.dtpDate.Size = new System.Drawing.Size(295, 28);

            // Row 3 - Invoice Number
            this.lblInvoiceNumber.Text = "Invoice Number:";
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblInvoiceNumber.Location = new System.Drawing.Point(30, 165);
            this.lblInvoiceNumber.Size = new System.Drawing.Size(140, 22);

            this.cmbInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.cmbInvoiceNumber.Location = new System.Drawing.Point(30, 189);
            this.cmbInvoiceNumber.Size = new System.Drawing.Size(250, 28);
            this.cmbInvoiceNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;

            // Row 3 - Reference
            this.lblReference.Text = "Reference Number:";
            this.lblReference.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblReference.Location = new System.Drawing.Point(295, 165);
            this.lblReference.Size = new System.Drawing.Size(150, 22);

            this.txtReference.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtReference.Location = new System.Drawing.Point(295, 189);
            this.txtReference.Size = new System.Drawing.Size(295, 28);

            // Row 4 - Notes
            this.lblNotes.Text = "Notes:";
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblNotes.Location = new System.Drawing.Point(30, 235);
            this.lblNotes.Size = new System.Drawing.Size(120, 22);

            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtNotes.Location = new System.Drawing.Point(30, 259);
            this.txtNotes.Size = new System.Drawing.Size(560, 65);
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 55;
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(370, 10);
            this.btnSave.Size = new System.Drawing.Size(120, 34);
            this.btnSave.Text = "Save";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(500, 10);
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 500);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSupplierTransactionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Supplier Transaction";
            this.Load += new System.EventHandler(this.FrmSupplierTransactionDialog_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.ComboBox cmbInvoiceNumber;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}