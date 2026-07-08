namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmLateFeeDetails
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
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblBorrowNumLbl = new System.Windows.Forms.Label();
            this.lblBorrowNumber = new System.Windows.Forms.Label();
            this.lblCustLbl = new System.Windows.Forms.Label();
            this.lblCustomerVal = new System.Windows.Forms.Label();
            this.lblLateDaysLbl = new System.Windows.Forms.Label();
            this.lblLateDaysVal = new System.Windows.Forms.Label();
            this.lblFeePerDayLbl = new System.Windows.Forms.Label();
            this.lblFeePerDayVal = new System.Windows.Forms.Label();
            this.lblTotalFeeLbl = new System.Windows.Forms.Label();
            this.lblTotalFeeVal = new System.Windows.Forms.Label();
            this.lblPaidLbl = new System.Windows.Forms.Label();
            this.lblPaidVal = new System.Windows.Forms.Label();
            this.lblRemainingLbl = new System.Windows.Forms.Label();
            this.lblRemainingVal = new System.Windows.Forms.Label();
            this.lblStatusLbl = new System.Windows.Forms.Label();
            this.lblStatusVal = new System.Windows.Forms.Label();

            this.pnlPay = new System.Windows.Forms.Panel();
            this.lblPayIcon = new System.Windows.Forms.Label();
            this.lblPayTitle = new System.Windows.Forms.Label();
            this.lblPayAmountLbl = new System.Windows.Forms.Label();
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.btnPayFull = new System.Windows.Forms.Button();

            this.lblNotesLbl = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnWaive = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlPay.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(500, 50);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnClose);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Size = new System.Drawing.Size(300, 26);
            this.lblTitle.Text = "Late Fee Details";

            this.btnClose.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(460, 8);
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // pnlInfo
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(8, 58);
            this.pnlInfo.Size = new System.Drawing.Size(484, 190);
            this.pnlInfo.Controls.Add(this.lblBorrowNumLbl);
            this.pnlInfo.Controls.Add(this.lblBorrowNumber);
            this.pnlInfo.Controls.Add(this.lblCustLbl);
            this.pnlInfo.Controls.Add(this.lblCustomerVal);
            this.pnlInfo.Controls.Add(this.lblLateDaysLbl);
            this.pnlInfo.Controls.Add(this.lblLateDaysVal);
            this.pnlInfo.Controls.Add(this.lblFeePerDayLbl);
            this.pnlInfo.Controls.Add(this.lblFeePerDayVal);
            this.pnlInfo.Controls.Add(this.lblTotalFeeLbl);
            this.pnlInfo.Controls.Add(this.lblTotalFeeVal);
            this.pnlInfo.Controls.Add(this.lblPaidLbl);
            this.pnlInfo.Controls.Add(this.lblPaidVal);
            this.pnlInfo.Controls.Add(this.lblRemainingLbl);
            this.pnlInfo.Controls.Add(this.lblRemainingVal);
            this.pnlInfo.Controls.Add(this.lblStatusLbl);
            this.pnlInfo.Controls.Add(this.lblStatusVal);

            this.lblBorrowNumLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblBorrowNumLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblBorrowNumLbl.Location = new System.Drawing.Point(10, 10);
            this.lblBorrowNumLbl.Size = new System.Drawing.Size(110, 18);
            this.lblBorrowNumLbl.Text = "Borrow #";

            this.lblBorrowNumber.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblBorrowNumber.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblBorrowNumber.Location = new System.Drawing.Point(10, 28);
            this.lblBorrowNumber.Size = new System.Drawing.Size(130, 22);
            this.lblBorrowNumber.Text = "-";

            this.lblCustLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblCustLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblCustLbl.Location = new System.Drawing.Point(155, 10);
            this.lblCustLbl.Size = new System.Drawing.Size(110, 18);
            this.lblCustLbl.Text = "Customer";

            this.lblCustomerVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblCustomerVal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblCustomerVal.Location = new System.Drawing.Point(155, 28);
            this.lblCustomerVal.Size = new System.Drawing.Size(220, 22);
            this.lblCustomerVal.Text = "-";

            this.lblLateDaysLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLateDaysLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblLateDaysLbl.Location = new System.Drawing.Point(10, 58);
            this.lblLateDaysLbl.Size = new System.Drawing.Size(110, 18);
            this.lblLateDaysLbl.Text = "Late Days";

            this.lblLateDaysVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblLateDaysVal.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblLateDaysVal.Location = new System.Drawing.Point(10, 76);
            this.lblLateDaysVal.Size = new System.Drawing.Size(130, 22);
            this.lblLateDaysVal.Text = "-";

            this.lblFeePerDayLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblFeePerDayLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblFeePerDayLbl.Location = new System.Drawing.Point(155, 58);
            this.lblFeePerDayLbl.Size = new System.Drawing.Size(110, 18);
            this.lblFeePerDayLbl.Text = "Fee / Day";

            this.lblFeePerDayVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblFeePerDayVal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblFeePerDayVal.Location = new System.Drawing.Point(155, 76);
            this.lblFeePerDayVal.Size = new System.Drawing.Size(130, 22);
            this.lblFeePerDayVal.Text = "-";

            this.lblTotalFeeLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalFeeLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalFeeLbl.Location = new System.Drawing.Point(10, 104);
            this.lblTotalFeeLbl.Size = new System.Drawing.Size(110, 18);
            this.lblTotalFeeLbl.Text = "Total Fee";

            this.lblTotalFeeVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblTotalFeeVal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTotalFeeVal.Location = new System.Drawing.Point(10, 122);
            this.lblTotalFeeVal.Size = new System.Drawing.Size(130, 22);
            this.lblTotalFeeVal.Text = "-";

            this.lblPaidLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblPaidLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblPaidLbl.Location = new System.Drawing.Point(155, 104);
            this.lblPaidLbl.Size = new System.Drawing.Size(110, 18);
            this.lblPaidLbl.Text = "Paid";

            this.lblPaidVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblPaidVal.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblPaidVal.Location = new System.Drawing.Point(155, 122);
            this.lblPaidVal.Size = new System.Drawing.Size(130, 22);
            this.lblPaidVal.Text = "-";

            this.lblRemainingLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblRemainingLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblRemainingLbl.Location = new System.Drawing.Point(10, 150);
            this.lblRemainingLbl.Size = new System.Drawing.Size(110, 18);
            this.lblRemainingLbl.Text = "Remaining";

            this.lblRemainingVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblRemainingVal.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblRemainingVal.Location = new System.Drawing.Point(10, 168);
            this.lblRemainingVal.Size = new System.Drawing.Size(130, 22);
            this.lblRemainingVal.Text = "-";

            this.lblStatusLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblStatusLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStatusLbl.Location = new System.Drawing.Point(155, 150);
            this.lblStatusLbl.Size = new System.Drawing.Size(110, 18);
            this.lblStatusLbl.Text = "Status";

            this.lblStatusVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblStatusVal.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblStatusVal.Location = new System.Drawing.Point(155, 168);
            this.lblStatusVal.Size = new System.Drawing.Size(130, 22);
            this.lblStatusVal.Text = "-";

            // pnlPay
            this.pnlPay.BackColor = System.Drawing.Color.FromArgb(240, 246, 255);
            this.pnlPay.Location = new System.Drawing.Point(8, 256);
            this.pnlPay.Size = new System.Drawing.Size(484, 88);
            this.pnlPay.Visible = false;
            this.pnlPay.Controls.Add(this.lblPayIcon);
            this.pnlPay.Controls.Add(this.lblPayTitle);
            this.pnlPay.Controls.Add(this.lblPayAmountLbl);
            this.pnlPay.Controls.Add(this.txtPayAmount);
            this.pnlPay.Controls.Add(this.btnPayFull);

            this.lblPayIcon.Font = new System.Drawing.Font("Segoe UI", 16f);
            this.lblPayIcon.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblPayIcon.Location = new System.Drawing.Point(8, 8);
            this.lblPayIcon.Size = new System.Drawing.Size(36, 36);
            this.lblPayIcon.Text = "$";

            this.lblPayTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblPayTitle.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblPayTitle.Location = new System.Drawing.Point(48, 8);
            this.lblPayTitle.Size = new System.Drawing.Size(200, 20);
            this.lblPayTitle.Text = "COLLECT PAYMENT";

            this.lblPayAmountLbl.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblPayAmountLbl.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblPayAmountLbl.Location = new System.Drawing.Point(48, 36);
            this.lblPayAmountLbl.Size = new System.Drawing.Size(80, 22);
            this.lblPayAmountLbl.Text = "Amount:";

            this.txtPayAmount.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.txtPayAmount.Location = new System.Drawing.Point(135, 33);
            this.txtPayAmount.Size = new System.Drawing.Size(120, 26);

            this.btnPayFull.BackColor = System.Drawing.Color.FromArgb(200, 220, 245);
            this.btnPayFull.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayFull.FlatAppearance.BorderSize = 0;
            this.btnPayFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayFull.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.btnPayFull.ForeColor = System.Drawing.Color.FromArgb(20, 70, 130);
            this.btnPayFull.Location = new System.Drawing.Point(265, 33);
            this.btnPayFull.Size = new System.Drawing.Size(100, 26);
            this.btnPayFull.Text = "Full Amount";
            this.btnPayFull.UseVisualStyleBackColor = false;
            this.btnPayFull.Click += new System.EventHandler(this.btnPayFull_Click);

            // Notes
            this.lblNotesLbl.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblNotesLbl.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblNotesLbl.Location = new System.Drawing.Point(8, 356);
            this.lblNotesLbl.Size = new System.Drawing.Size(60, 22);
            this.lblNotesLbl.Text = "Notes:";

            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtNotes.Location = new System.Drawing.Point(8, 378);
            this.txtNotes.Multiline = true;
            this.txtNotes.Size = new System.Drawing.Size(484, 60);

            // Action buttons
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.Enabled = false;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(8, 448);
            this.btnPay.Size = new System.Drawing.Size(484, 44);
            this.btnPay.Text = "Record Payment";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);

            this.btnWaive.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnWaive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWaive.Enabled = false;
            this.btnWaive.FlatAppearance.BorderSize = 0;
            this.btnWaive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaive.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.btnWaive.ForeColor = System.Drawing.Color.White;
            this.btnWaive.Location = new System.Drawing.Point(8, 500);
            this.btnWaive.Size = new System.Drawing.Size(484, 44);
            this.btnWaive.Text = "Waive Fee";
            this.btnWaive.UseVisualStyleBackColor = false;
            this.btnWaive.Click += new System.EventHandler(this.btnWaive_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(500, 556);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlPay);
            this.Controls.Add(this.lblNotesLbl);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnWaive);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLateFeeDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Late Fee Details";
            this.Load += new System.EventHandler(this.FrmLateFeeDetails_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlPay.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblBorrowNumLbl, lblBorrowNumber;
        private System.Windows.Forms.Label lblCustLbl, lblCustomerVal;
        private System.Windows.Forms.Label lblLateDaysLbl, lblLateDaysVal;
        private System.Windows.Forms.Label lblFeePerDayLbl, lblFeePerDayVal;
        private System.Windows.Forms.Label lblTotalFeeLbl, lblTotalFeeVal;
        private System.Windows.Forms.Label lblPaidLbl, lblPaidVal;
        private System.Windows.Forms.Label lblRemainingLbl, lblRemainingVal;
        private System.Windows.Forms.Label lblStatusLbl, lblStatusVal;

        private System.Windows.Forms.Panel pnlPay;
        private System.Windows.Forms.Label lblPayIcon, lblPayTitle, lblPayAmountLbl;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.Button btnPayFull;

        private System.Windows.Forms.Label lblNotesLbl;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnWaive;
    }
}