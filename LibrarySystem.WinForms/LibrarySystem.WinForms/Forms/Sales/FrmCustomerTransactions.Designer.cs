namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmCustomerTransactions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblPurchasesLabel = new System.Windows.Forms.Label();
            this.lblTotalPurchases = new System.Windows.Forms.Label();
            this.lblBorrowLabel = new System.Windows.Forms.Label();
            this.lblTotalBorrow = new System.Windows.Forms.Label();
            this.lblDebtLabel = new System.Windows.Forms.Label();
            this.lblTotalDebt = new System.Windows.Forms.Label();
            this.lblLateFeesLabel = new System.Windows.Forms.Label();
            this.lblTotalLateFees = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.colTransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 55);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Customer Transactions";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.lblCustomerName.Location = new System.Drawing.Point(300, 16);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(350, 25);
            this.lblCustomerName.TabIndex = 1;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlSummary.Controls.Add(this.lblPurchasesLabel);
            this.pnlSummary.Controls.Add(this.lblTotalPurchases);
            this.pnlSummary.Controls.Add(this.lblBorrowLabel);
            this.pnlSummary.Controls.Add(this.lblTotalBorrow);
            this.pnlSummary.Controls.Add(this.lblDebtLabel);
            this.pnlSummary.Controls.Add(this.lblTotalDebt);
            this.pnlSummary.Controls.Add(this.lblLateFeesLabel);
            this.pnlSummary.Controls.Add(this.lblTotalLateFees);
            this.pnlSummary.Location = new System.Drawing.Point(0, 55);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(900, 70);
            this.pnlSummary.TabIndex = 1;
            // 
            // lblPurchasesLabel
            // 
            this.lblPurchasesLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPurchasesLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblPurchasesLabel.Location = new System.Drawing.Point(20, 10);
            this.lblPurchasesLabel.Name = "lblPurchasesLabel";
            this.lblPurchasesLabel.Size = new System.Drawing.Size(150, 18);
            this.lblPurchasesLabel.TabIndex = 0;
            this.lblPurchasesLabel.Text = "Total Purchases";
            // 
            // lblTotalPurchases
            // 
            this.lblTotalPurchases.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPurchases.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblTotalPurchases.Location = new System.Drawing.Point(20, 28);
            this.lblTotalPurchases.Name = "lblTotalPurchases";
            this.lblTotalPurchases.Size = new System.Drawing.Size(150, 30);
            this.lblTotalPurchases.TabIndex = 1;
            this.lblTotalPurchases.Text = "0.00";
            // 
            // lblBorrowLabel
            // 
            this.lblBorrowLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBorrowLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblBorrowLabel.Location = new System.Drawing.Point(220, 10);
            this.lblBorrowLabel.Name = "lblBorrowLabel";
            this.lblBorrowLabel.Size = new System.Drawing.Size(150, 18);
            this.lblBorrowLabel.TabIndex = 2;
            this.lblBorrowLabel.Text = "Total Borrowings";
            // 
            // lblTotalBorrow
            // 
            this.lblTotalBorrow.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalBorrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(160)))));
            this.lblTotalBorrow.Location = new System.Drawing.Point(220, 28);
            this.lblTotalBorrow.Name = "lblTotalBorrow";
            this.lblTotalBorrow.Size = new System.Drawing.Size(150, 30);
            this.lblTotalBorrow.TabIndex = 3;
            this.lblTotalBorrow.Text = "0";
            // 
            // lblDebtLabel
            // 
            this.lblDebtLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDebtLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblDebtLabel.Location = new System.Drawing.Point(420, 10);
            this.lblDebtLabel.Name = "lblDebtLabel";
            this.lblDebtLabel.Size = new System.Drawing.Size(150, 18);
            this.lblDebtLabel.TabIndex = 4;
            this.lblDebtLabel.Text = "Outstanding Debt";
            // 
            // lblTotalDebt
            // 
            this.lblTotalDebt.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalDebt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(100)))));
            this.lblTotalDebt.Location = new System.Drawing.Point(420, 28);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(150, 30);
            this.lblTotalDebt.TabIndex = 5;
            this.lblTotalDebt.Text = "0.00";
            // 
            // lblLateFeesLabel
            // 
            this.lblLateFeesLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLateFeesLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblLateFeesLabel.Location = new System.Drawing.Point(620, 10);
            this.lblLateFeesLabel.Name = "lblLateFeesLabel";
            this.lblLateFeesLabel.Size = new System.Drawing.Size(150, 18);
            this.lblLateFeesLabel.TabIndex = 6;
            this.lblLateFeesLabel.Text = "Total Late Fees";
            // 
            // lblTotalLateFees
            // 
            this.lblTotalLateFees.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalLateFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTotalLateFees.Location = new System.Drawing.Point(620, 28);
            this.lblTotalLateFees.Name = "lblTotalLateFees";
            this.lblTotalLateFees.Size = new System.Drawing.Size(150, 30);
            this.lblTotalLateFees.TabIndex = 7;
            this.lblTotalLateFees.Text = "0.00";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.lblFrom);
            this.pnlFilter.Controls.Add(this.dtpFrom);
            this.pnlFilter.Controls.Add(this.lblTo);
            this.pnlFilter.Controls.Add(this.dtpTo);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Controls.Add(this.lblCount);
            this.pnlFilter.Location = new System.Drawing.Point(0, 125);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(900, 55);
            this.pnlFilter.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFrom.Location = new System.Drawing.Point(70, 17);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(45, 22);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(118, 14);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 24);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTo.Location = new System.Drawing.Point(262, 17);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(30, 22);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(295, 14);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 24);
            this.dtpTo.TabIndex = 3;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(440, 13);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(90, 30);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "🔍 Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(544, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "↻ Reset";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(650, 17);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(120, 22);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Total: 0";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvTransactions);
            this.pnlGrid.Location = new System.Drawing.Point(0, 180);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(900, 430);
            this.pnlGrid.TabIndex = 3;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTransactions.ColumnHeadersHeight = 42;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTransactionID,
            this.colDate,
            this.colTransactionType,
            this.colInvoiceNumber,
            this.colAmount,
            this.colNotes,
            this.colCreatedBy});
            this.dgvTransactions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvTransactions.Location = new System.Drawing.Point(0, 0);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.RowTemplate.Height = 36;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(900, 430);
            this.dgvTransactions.TabIndex = 0;
            // 
            // colTransactionID
            // 
            this.colTransactionID.HeaderText = "ID";
            this.colTransactionID.Name = "colTransactionID";
            this.colTransactionID.ReadOnly = true;
            this.colTransactionID.Visible = false;
            // 
            // colDate
            // 
            this.colDate.FillWeight = 15F;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colTransactionType
            // 
            this.colTransactionType.FillWeight = 13F;
            this.colTransactionType.HeaderText = "Type";
            this.colTransactionType.Name = "colTransactionType";
            this.colTransactionType.ReadOnly = true;
            // 
            // colInvoiceNumber
            // 
            this.colInvoiceNumber.FillWeight = 14F;
            this.colInvoiceNumber.HeaderText = "Invoice #";
            this.colInvoiceNumber.Name = "colInvoiceNumber";
            this.colInvoiceNumber.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.FillWeight = 12F;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colNotes
            // 
            this.colNotes.FillWeight = 30F;
            this.colNotes.HeaderText = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.ReadOnly = true;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FillWeight = 16F;
            this.colCreatedBy.HeaderText = "Created By";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.ReadOnly = true;
            // 
            // FrmCustomerTransactions
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 610);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlGrid);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCustomerTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Transactions";
            this.Load += new System.EventHandler(this.FrmCustomerTransactions_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCustomerName;

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblPurchasesLabel;
        private System.Windows.Forms.Label lblTotalPurchases;
        private System.Windows.Forms.Label lblBorrowLabel;
        private System.Windows.Forms.Label lblTotalBorrow;
        private System.Windows.Forms.Label lblDebtLabel;
        private System.Windows.Forms.Label lblTotalDebt;
        private System.Windows.Forms.Label lblLateFeesLabel;
        private System.Windows.Forms.Label lblTotalLateFees;

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCount;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
    }
}