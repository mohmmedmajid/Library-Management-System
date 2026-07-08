namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmSupplierTransactions
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
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblTotalPurchases = new System.Windows.Forms.Label();
            this.lblTotalPayments = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblFilterSupplier = new System.Windows.Forms.Label();
            this.cmbFilterSupplier = new System.Windows.Forms.ComboBox();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();

            this.pnlTop.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "Supplier Transactions";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // ── pnlStats ──
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Height = 55;
            this.pnlStats.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlStats.Controls.Add(this.lblBalance);
            this.pnlStats.Controls.Add(this.lblTotalPayments);
            this.pnlStats.Controls.Add(this.lblTotalPurchases);

            this.lblTotalPurchases.AutoSize = true;
            this.lblTotalPurchases.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblTotalPurchases.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblTotalPurchases.Location = new System.Drawing.Point(10, 15);
            this.lblTotalPurchases.Text = "Total Purchases: --";

            this.lblTotalPayments.AutoSize = true;
            this.lblTotalPayments.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblTotalPayments.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblTotalPayments.Location = new System.Drawing.Point(230, 15);
            this.lblTotalPayments.Text = "Total Payments: --";

            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblBalance.Location = new System.Drawing.Point(480, 15);
            this.lblBalance.Text = "Balance: --";

            // ── pnlSearch ──
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Height = 50;
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearchIcon);
            this.pnlSearch.Controls.Add(this.dtpEndDate);
            this.pnlSearch.Controls.Add(this.lblTo);
            this.pnlSearch.Controls.Add(this.dtpStartDate);
            this.pnlSearch.Controls.Add(this.lblFrom);
            this.pnlSearch.Controls.Add(this.cmbTransactionType);
            this.pnlSearch.Controls.Add(this.lblFilterType);
            this.pnlSearch.Controls.Add(this.cmbFilterSupplier);
            this.pnlSearch.Controls.Add(this.lblFilterSupplier);

            this.lblFilterSupplier.AutoSize = true;
            this.lblFilterSupplier.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblFilterSupplier.Location = new System.Drawing.Point(10, 16);
            this.lblFilterSupplier.Text = "Supplier:";

            this.cmbFilterSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterSupplier.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cmbFilterSupplier.Location = new System.Drawing.Point(70, 12);
            this.cmbFilterSupplier.Size = new System.Drawing.Size(160, 25);

            this.lblFilterType.AutoSize = true;
            this.lblFilterType.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblFilterType.Location = new System.Drawing.Point(240, 16);
            this.lblFilterType.Text = "Type:";

            this.cmbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransactionType.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cmbTransactionType.Location = new System.Drawing.Point(280, 12);
            this.cmbTransactionType.Size = new System.Drawing.Size(120, 25);

            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblFrom.Location = new System.Drawing.Point(410, 16);
            this.lblFrom.Text = "From:";

            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(450, 12);
            this.dtpStartDate.Size = new System.Drawing.Size(110, 25);

            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblTo.Location = new System.Drawing.Point(568, 16);
            this.lblTo.Text = "To:";

            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(590, 12);
            this.dtpEndDate.Size = new System.Drawing.Size(110, 25);

            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSearchIcon.Location = new System.Drawing.Point(712, 16);
            this.lblSearchIcon.Text = "Search:";

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtSearch.Location = new System.Drawing.Point(760, 12);
            this.txtSearch.Size = new System.Drawing.Size(220, 26);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);

            // ── pnlButtons ──
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Height = 48;
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnSearch);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAdd);

            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(10, 8);
            this.btnAdd.Size = new System.Drawing.Size(130, 32);
            this.btnAdd.Text = "Add Transaction";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(150, 8);
            this.btnEdit.Size = new System.Drawing.Size(100, 32);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(260, 8);
            this.btnDelete.Size = new System.Drawing.Size(100, 32);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(370, 8);
            this.btnSearch.Size = new System.Drawing.Size(100, 32);
            this.btnSearch.Text = "Search";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(480, 8);
            this.btnRefresh.Size = new System.Drawing.Size(100, 32);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── dgvTransactions ──
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.ColumnHeadersHeight = 36;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            this.dgvTransactions.RowTemplate.Height = 32;
            this.dgvTransactions.SelectionChanged += new System.EventHandler(this.dgvTransactions_SelectionChanged);

            this.colID.HeaderText = "#";
            this.colID.Name = "colID";
            this.colID.DataPropertyName = "TransactionID";
            this.colID.FillWeight = 5;
            this.colID.MinimumWidth = 50;

            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.DataPropertyName = "SupplierName";
            this.colSupplier.FillWeight = 18;

            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.DataPropertyName = "TransactionType";
            this.colType.FillWeight = 10;
            this.colType.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colInvoice.HeaderText = "Invoice No.";
            this.colInvoice.Name = "colInvoice";
            this.colInvoice.DataPropertyName = "InvoiceNumber";
            this.colInvoice.FillWeight = 11;

            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.FillWeight = 10;
            this.colAmount.DefaultCellStyle.Format = "N2";
            this.colAmount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.DataPropertyName = "TransactionDate";
            this.colDate.FillWeight = 10;
            this.colDate.DefaultCellStyle.Format = "yyyy/MM/dd";
            this.colDate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colReference.HeaderText = "Reference No.";
            this.colReference.Name = "colReference";
            this.colReference.DataPropertyName = "ReferenceNumber";
            this.colReference.FillWeight = 11;

            this.colNotes.HeaderText = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.DataPropertyName = "Notes";
            this.colNotes.FillWeight = 25;

            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colSupplier, this.colType, this.colInvoice,
                this.colAmount, this.colDate, this.colReference, this.colNotes
            });

            // ── pnlBottom ──
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 30;
            this.pnlBottom.Controls.Add(this.lblCount);

            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblCount.Location = new System.Drawing.Point(10, 8);
            this.lblCount.Text = "Total: 0 transactions";

            // ── Form ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.Name = "FrmSupplierTransactions";
            this.Text = "Supplier Transactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.FrmSupplierTransactions_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblTotalPurchases;
        private System.Windows.Forms.Label lblTotalPayments;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblFilterSupplier;
        private System.Windows.Forms.ComboBox cmbFilterSupplier;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblCount;
    }
}