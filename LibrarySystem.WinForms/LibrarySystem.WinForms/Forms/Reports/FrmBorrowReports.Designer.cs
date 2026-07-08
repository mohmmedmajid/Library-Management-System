namespace LibrarySystem.WinForms.Forms.Reports
{
    partial class FrmBorrowReports
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();

            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblSearchFilter = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();

            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSumTitle = new System.Windows.Forms.Label();

            this.lblTotalAmountLbl = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalPaidLbl = new System.Windows.Forms.Label();
            this.lblTotalPaid = new System.Windows.Forms.Label();
            this.lblTotalRemainingLbl = new System.Windows.Forms.Label();
            this.lblTotalRemaining = new System.Windows.Forms.Label();
            this.lblBorrowedLbl = new System.Windows.Forms.Label();
            this.lblBorrowed = new System.Windows.Forms.Label();
            this.lblReturnedLbl = new System.Windows.Forms.Label();
            this.lblReturned = new System.Windows.Forms.Label();
            this.lblLateLbl = new System.Windows.Forms.Label();
            this.lblLate = new System.Windows.Forms.Label();

            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBorrowingNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpectedReturn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1020, 55);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblStatus);
            this.pnlTop.Controls.Add(this.lblCount);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 30);
            this.lblTitle.Text = "Borrow Reports";

            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblStatus.Location = new System.Drawing.Point(310, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 22);
            this.lblStatus.Text = "";

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblCount.Location = new System.Drawing.Point(900, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(110, 22);
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCount.Text = "Records: 0";

            // pnlFilters
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Size = new System.Drawing.Size(1020, 60);
            this.pnlFilters.AutoScroll = true;
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Controls.Add(this.lblFrom);
            this.pnlFilters.Controls.Add(this.dtpFrom);
            this.pnlFilters.Controls.Add(this.lblTo);
            this.pnlFilters.Controls.Add(this.dtpTo);
            this.pnlFilters.Controls.Add(this.lblStatusFilter);
            this.pnlFilters.Controls.Add(this.cmbStatus);
            this.pnlFilters.Controls.Add(this.lblSearchFilter);
            this.pnlFilters.Controls.Add(this.txtSearch);
            this.pnlFilters.Controls.Add(this.btnSearch);
            this.pnlFilters.Controls.Add(this.btnExport);

            this.lblFrom.Text = "From:";
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(8, 20);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 22);

            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpFrom.Location = new System.Drawing.Point(48, 17);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(95, 26);

            this.lblTo.Text = "To:";
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(150, 20);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 22);

            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpTo.Location = new System.Drawing.Point(172, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(95, 26);

            this.lblStatusFilter.Text = "Status:";
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatusFilter.Location = new System.Drawing.Point(275, 20);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(45, 22);

            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbStatus.Location = new System.Drawing.Point(320, 17);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(110, 26);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Borrowed", "Returned", "Active", "Late" });
            this.cmbStatus.SelectedIndex = 0;

            this.lblSearchFilter.Text = "Search:";
            this.lblSearchFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSearchFilter.Location = new System.Drawing.Point(440, 20);
            this.lblSearchFilter.Name = "lblSearchFilter";
            this.lblSearchFilter.Size = new System.Drawing.Size(48, 22);

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtSearch.Location = new System.Drawing.Point(490, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 26);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(660, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 30);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            this.btnExport.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(753, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 30);
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            // pnlSummary
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(240, 246, 255);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Size = new System.Drawing.Size(1020, 80);
            this.pnlSummary.AutoScroll = true;
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Controls.Add(this.lblSumTitle);
            this.pnlSummary.Controls.Add(this.lblTotalAmountLbl);
            this.pnlSummary.Controls.Add(this.lblTotalAmount);
            this.pnlSummary.Controls.Add(this.lblTotalPaidLbl);
            this.pnlSummary.Controls.Add(this.lblTotalPaid);
            this.pnlSummary.Controls.Add(this.lblTotalRemainingLbl);
            this.pnlSummary.Controls.Add(this.lblTotalRemaining);
            this.pnlSummary.Controls.Add(this.lblBorrowedLbl);
            this.pnlSummary.Controls.Add(this.lblBorrowed);
            this.pnlSummary.Controls.Add(this.lblReturnedLbl);
            this.pnlSummary.Controls.Add(this.lblReturned);
            this.pnlSummary.Controls.Add(this.lblLateLbl);
            this.pnlSummary.Controls.Add(this.lblLate);

            this.lblSumTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSumTitle.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblSumTitle.Location = new System.Drawing.Point(10, 8);
            this.lblSumTitle.Name = "lblSumTitle";
            this.lblSumTitle.Size = new System.Drawing.Size(100, 20);
            this.lblSumTitle.Text = "Summary";

            this.lblTotalAmountLbl.Text = "Total Amount";
            this.lblTotalAmountLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalAmountLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalAmountLbl.Location = new System.Drawing.Point(10, 32);
            this.lblTotalAmountLbl.Name = "lblTotalAmountLbl";
            this.lblTotalAmountLbl.Size = new System.Drawing.Size(120, 18);

            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.lblTotalAmount.Location = new System.Drawing.Point(10, 50);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(140, 24);
            this.lblTotalAmount.Text = "0.00";

            this.lblTotalPaidLbl.Text = "Total Paid";
            this.lblTotalPaidLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalPaidLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalPaidLbl.Location = new System.Drawing.Point(160, 32);
            this.lblTotalPaidLbl.Name = "lblTotalPaidLbl";
            this.lblTotalPaidLbl.Size = new System.Drawing.Size(90, 18);

            this.lblTotalPaid.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalPaid.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblTotalPaid.Location = new System.Drawing.Point(160, 50);
            this.lblTotalPaid.Name = "lblTotalPaid";
            this.lblTotalPaid.Size = new System.Drawing.Size(140, 24);
            this.lblTotalPaid.Text = "0.00";

            this.lblTotalRemainingLbl.Text = "Remaining";
            this.lblTotalRemainingLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalRemainingLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalRemainingLbl.Location = new System.Drawing.Point(310, 32);
            this.lblTotalRemainingLbl.Name = "lblTotalRemainingLbl";
            this.lblTotalRemainingLbl.Size = new System.Drawing.Size(90, 18);

            this.lblTotalRemaining.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalRemaining.ForeColor = System.Drawing.Color.FromArgb(200, 80, 0);
            this.lblTotalRemaining.Location = new System.Drawing.Point(310, 50);
            this.lblTotalRemaining.Name = "lblTotalRemaining";
            this.lblTotalRemaining.Size = new System.Drawing.Size(140, 24);
            this.lblTotalRemaining.Text = "0.00";

            this.lblBorrowedLbl.Text = "Borrowed";
            this.lblBorrowedLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblBorrowedLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblBorrowedLbl.Location = new System.Drawing.Point(460, 32);
            this.lblBorrowedLbl.Name = "lblBorrowedLbl";
            this.lblBorrowedLbl.Size = new System.Drawing.Size(80, 18);

            this.lblBorrowed.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblBorrowed.ForeColor = System.Drawing.Color.FromArgb(180, 120, 0);
            this.lblBorrowed.Location = new System.Drawing.Point(460, 50);
            this.lblBorrowed.Name = "lblBorrowed";
            this.lblBorrowed.Size = new System.Drawing.Size(100, 24);
            this.lblBorrowed.Text = "0";

            this.lblReturnedLbl.Text = "Returned";
            this.lblReturnedLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblReturnedLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblReturnedLbl.Location = new System.Drawing.Point(570, 32);
            this.lblReturnedLbl.Name = "lblReturnedLbl";
            this.lblReturnedLbl.Size = new System.Drawing.Size(80, 18);

            this.lblReturned.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblReturned.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblReturned.Location = new System.Drawing.Point(570, 50);
            this.lblReturned.Name = "lblReturned";
            this.lblReturned.Size = new System.Drawing.Size(100, 24);
            this.lblReturned.Text = "0";

            this.lblLateLbl.Text = "Late";
            this.lblLateLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLateLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblLateLbl.Location = new System.Drawing.Point(680, 32);
            this.lblLateLbl.Name = "lblLateLbl";
            this.lblLateLbl.Size = new System.Drawing.Size(80, 18);

            this.lblLate.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblLate.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblLate.Location = new System.Drawing.Point(680, 50);
            this.lblLate.Name = "lblLate";
            this.lblLate.Size = new System.Drawing.Size(100, 24);
            this.lblLate.Text = "0";

            // pnlGrid
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Controls.Add(this.dgvReport);

            // dgvReport
            altStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvReport.AlternatingRowsDefaultCellStyle = altStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReport.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReport.ColumnHeadersHeight = 42;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowTemplate.Height = 36;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvReport_CellFormatting);

            this.colID.HeaderText = "ID"; this.colID.Name = "colID"; this.colID.Visible = false;
            this.colBorrowingNo.HeaderText = "Borrowing No"; this.colBorrowingNo.Name = "colBorrowingNo"; this.colBorrowingNo.FillWeight = 13f;
            this.colDate.HeaderText = "Date"; this.colDate.Name = "colDate"; this.colDate.FillWeight = 9f;
            this.colCustomer.HeaderText = "Customer"; this.colCustomer.Name = "colCustomer"; this.colCustomer.FillWeight = 15f;
            this.colExpectedReturn.HeaderText = "Expected Return"; this.colExpectedReturn.Name = "colExpectedReturn"; this.colExpectedReturn.FillWeight = 11f;
            this.colDays.HeaderText = "Days"; this.colDays.Name = "colDays"; this.colDays.FillWeight = 6f;
            this.colTotal.HeaderText = "Total"; this.colTotal.Name = "colTotal"; this.colTotal.FillWeight = 9f;
            this.colPaid.HeaderText = "Paid"; this.colPaid.Name = "colPaid"; this.colPaid.FillWeight = 9f;
            this.colRemaining.HeaderText = "Remaining"; this.colRemaining.Name = "colRemaining"; this.colRemaining.FillWeight = 9f;
            this.colStatus.HeaderText = "Status"; this.colStatus.Name = "colStatus"; this.colStatus.FillWeight = 8f;
            this.colCreatedBy.HeaderText = "Created By"; this.colCreatedBy.Name = "colCreatedBy"; this.colCreatedBy.FillWeight = 11f;

            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colBorrowingNo, this.colDate, this.colCustomer,
                this.colExpectedReturn, this.colDays, this.colTotal, this.colPaid,
                this.colRemaining, this.colStatus, this.colCreatedBy
            });

            // Form
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1020, 700);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.Name = "FrmBorrowReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrow Reports";
            this.Load += new System.EventHandler(this.FrmBorrowReports_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCount;

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblSearchFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSumTitle;
        private System.Windows.Forms.Label lblTotalAmountLbl, lblTotalAmount;
        private System.Windows.Forms.Label lblTotalPaidLbl, lblTotalPaid;
        private System.Windows.Forms.Label lblTotalRemainingLbl, lblTotalRemaining;
        private System.Windows.Forms.Label lblBorrowedLbl, lblBorrowed;
        private System.Windows.Forms.Label lblReturnedLbl, lblReturned;
        private System.Windows.Forms.Label lblLateLbl, lblLate;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBorrowingNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpectedReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;

        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}