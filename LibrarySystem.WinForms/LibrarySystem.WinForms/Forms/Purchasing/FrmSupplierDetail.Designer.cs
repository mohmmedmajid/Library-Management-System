namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmSupplierDetail
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
            this.pnlBody = new System.Windows.Forms.Panel();

            this.lblSupplierName = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();

            this.lblContactPerson = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();

            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();

            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.lblPaymentTerms = new System.Windows.Forms.Label();
            this.txtPaymentTerms = new System.Windows.Forms.TextBox();

            this.lblCreditLimit = new System.Windows.Forms.Label();
            this.numCreditLimit = new System.Windows.Forms.NumericUpDown();

            this.chkIsActive = new System.Windows.Forms.CheckBox();

            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCreditLimit)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "➕  Add New Supplier";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // ── pnlBody ──
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(25, 20, 25, 10);
            this.pnlBody.Controls.Add(this.chkIsActive);
            this.pnlBody.Controls.Add(this.numCreditLimit);
            this.pnlBody.Controls.Add(this.lblCreditLimit);
            this.pnlBody.Controls.Add(this.txtPaymentTerms);
            this.pnlBody.Controls.Add(this.lblPaymentTerms);
            this.pnlBody.Controls.Add(this.txtEmail);
            this.pnlBody.Controls.Add(this.lblEmail);
            this.pnlBody.Controls.Add(this.txtPhone);
            this.pnlBody.Controls.Add(this.lblPhone);
            this.pnlBody.Controls.Add(this.txtContactPerson);
            this.pnlBody.Controls.Add(this.lblContactPerson);
            this.pnlBody.Controls.Add(this.txtSupplierName);
            this.pnlBody.Controls.Add(this.lblSupplierName);

            // Row 1 - Supplier Name (y = 20)
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.lblSupplierName.Location = new System.Drawing.Point(25, 25);
            this.lblSupplierName.Text = "Supplier Name *";

            this.txtSupplierName.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtSupplierName.Location = new System.Drawing.Point(160, 20);
            this.txtSupplierName.Size = new System.Drawing.Size(330, 28);

            // Row 2 - Contact Person (y = 62)
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblContactPerson.Location = new System.Drawing.Point(25, 67);
            this.lblContactPerson.Text = "Contact Person";

            this.txtContactPerson.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtContactPerson.Location = new System.Drawing.Point(160, 62);
            this.txtContactPerson.Size = new System.Drawing.Size(330, 28);

            // Row 3 - Phone (y = 104)
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.lblPhone.Location = new System.Drawing.Point(25, 109);
            this.lblPhone.Text = "Phone *";

            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtPhone.Location = new System.Drawing.Point(160, 104);
            this.txtPhone.Size = new System.Drawing.Size(330, 28);

            // Row 4 - Email (y = 146)
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblEmail.Location = new System.Drawing.Point(25, 151);
            this.lblEmail.Text = "Email";

            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtEmail.Location = new System.Drawing.Point(160, 146);
            this.txtEmail.Size = new System.Drawing.Size(330, 28);

            // Row 5 - Payment Terms (y = 188)
            this.lblPaymentTerms.AutoSize = true;
            this.lblPaymentTerms.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblPaymentTerms.Location = new System.Drawing.Point(25, 193);
            this.lblPaymentTerms.Text = "Payment Terms";

            this.txtPaymentTerms.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtPaymentTerms.Location = new System.Drawing.Point(160, 188);
            this.txtPaymentTerms.Size = new System.Drawing.Size(330, 28);

            // Row 6 - Credit Limit (y = 230)
            this.lblCreditLimit.AutoSize = true;
            this.lblCreditLimit.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblCreditLimit.Location = new System.Drawing.Point(25, 235);
            this.lblCreditLimit.Text = "Credit Limit";

            this.numCreditLimit.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.numCreditLimit.Location = new System.Drawing.Point(160, 230);
            this.numCreditLimit.Size = new System.Drawing.Size(150, 28);
            this.numCreditLimit.Minimum = 0;
            this.numCreditLimit.Maximum = 1000000;
            this.numCreditLimit.DecimalPlaces = 2;
            this.numCreditLimit.ThousandsSeparator = true;

            // Row 7 - Is Active (y = 272)
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.chkIsActive.Location = new System.Drawing.Point(160, 275);
            this.chkIsActive.Text = "Active";
            this.chkIsActive.Checked = true;

            // ── pnlButtons ──
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 60;
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(295, 13);
            this.btnSave.Size = new System.Drawing.Size(100, 34);
            this.btnSave.Text = "💾  Save";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(405, 13);
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.Text = "✖  Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ── FrmSupplierDetail ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 415);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSupplierDetail";
            this.Text = "Add New Supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmSupplierDetail_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCreditLimit)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;

        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.TextBox txtSupplierName;

        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.TextBox txtContactPerson;

        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Label lblPaymentTerms;
        private System.Windows.Forms.TextBox txtPaymentTerms;

        private System.Windows.Forms.Label lblCreditLimit;
        private System.Windows.Forms.NumericUpDown numCreditLimit;

        private System.Windows.Forms.CheckBox chkIsActive;

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}