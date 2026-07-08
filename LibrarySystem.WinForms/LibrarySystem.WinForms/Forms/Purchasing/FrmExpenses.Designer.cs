namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmExpenses
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
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.lblStatPaid = new System.Windows.Forms.Label();
            this.lblStatPending = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearchDate = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();

            this.pnlTop.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "Expenses Management";
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
            this.pnlStats.Controls.Add(this.lblStatPending);
            this.pnlStats.Controls.Add(this.lblStatPaid);
            this.pnlStats.Controls.Add(this.lblStatTotal);

            this.lblStatTotal.AutoSize = true;
            this.lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblStatTotal.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblStatTotal.Location = new System.Drawing.Point(10, 15);
            this.lblStatTotal.Text = "Total Expenses: --";

            this.lblStatPaid.AutoSize = true;
            this.lblStatPaid.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblStatPaid.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblStatPaid.Location = new System.Drawing.Point(250, 15);
            this.lblStatPaid.Text = "Paid: --";

            this.lblStatPending.AutoSize = true;
            this.lblStatPending.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblStatPending.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblStatPending.Location = new System.Drawing.Point(480, 15);
            this.lblStatPending.Text = "Pending: --";

            // ── pnlSearch ──
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Height = 50;
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlSearch.Controls.Add(this.btnSearchDate);
            this.pnlSearch.Controls.Add(this.dtpTo);
            this.pnlSearch.Controls.Add(this.lblTo);
            this.pnlSearch.Controls.Add(this.dtpFrom);
            this.pnlSearch.Controls.Add(this.lblFrom);
            this.pnlSearch.Controls.Add(this.cmbFilter);
            this.pnlSearch.Controls.Add(this.lblFilter);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSearch.Location = new System.Drawing.Point(10, 16);
            this.lblSearch.Text = "Search:";

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtSearch.Location = new System.Drawing.Point(60, 12);
            this.txtSearch.Size = new System.Drawing.Size(160, 26);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblFilter.Location = new System.Drawing.Point(230, 16);
            this.lblFilter.Text = "Status:";

            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cmbFilter.Location = new System.Drawing.Point(275, 12);
            this.cmbFilter.Size = new System.Drawing.Size(110, 25);
            this.cmbFilter.Items.AddRange(new object[] { "All", "Paid", "Pending" });
            this.cmbFilter.SelectedIndex = 0;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);

            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblFrom.Location = new System.Drawing.Point(398, 16);
            this.lblFrom.Text = "From:";

            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(438, 12);
            this.dtpFrom.Size = new System.Drawing.Size(110, 25);
            this.dtpFrom.MinDate = new System.DateTime(2000, 1, 1);
            this.dtpFrom.MaxDate = System.DateTime.MaxValue;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);

            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblTo.Location = new System.Drawing.Point(558, 16);
            this.lblTo.Text = "To:";

            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(583, 12);
            this.dtpTo.Size = new System.Drawing.Size(110, 25);
            this.dtpTo.MinDate = new System.DateTime(2000, 1, 1);
            this.dtpTo.MaxDate = System.DateTime.MaxValue;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);

            this.btnSearchDate.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.btnSearchDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDate.FlatAppearance.BorderSize = 0;
            this.btnSearchDate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSearchDate.ForeColor = System.Drawing.Color.White;
            this.btnSearchDate.Location = new System.Drawing.Point(703, 10);
            this.btnSearchDate.Size = new System.Drawing.Size(80, 30);
            this.btnSearchDate.Text = "Search";
            this.btnSearchDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchDate.Click += new System.EventHandler(this.btnSearchDate_Click);

            // ── pnlButtons ──
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Height = 48;
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAdd);

            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(10, 8);
            this.btnAdd.Size = new System.Drawing.Size(110, 32);
            this.btnAdd.Text = "Add New";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(130, 8);
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
            this.btnDelete.Location = new System.Drawing.Point(240, 8);
            this.btnDelete.Size = new System.Drawing.Size(100, 32);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(350, 8);
            this.btnRefresh.Size = new System.Drawing.Size(100, 32);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── dgvExpenses ──
            this.dgvExpenses.AllowUserToAddRows = false;
            this.dgvExpenses.AllowUserToDeleteRows = false;
            this.dgvExpenses.ReadOnly = true;
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenses.MultiSelect = false;
            this.dgvExpenses.AutoGenerateColumns = false;
            this.dgvExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpenses.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dgvExpenses.RowHeadersVisible = false;
            this.dgvExpenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExpenses.ColumnHeadersHeight = 36;
            this.dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvExpenses.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.dgvExpenses.EnableHeadersVisualStyles = false;
            this.dgvExpenses.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            this.dgvExpenses.RowTemplate.Height = 32;
            this.dgvExpenses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpenses_CellClick);
            this.dgvExpenses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpenses_CellDoubleClick);

            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.DataPropertyName = "ExpenseID";
            this.colID.FillWeight = 5;
            this.colID.MinimumWidth = 50;

            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.DataPropertyName = "CategoryName";
            this.colCategory.FillWeight = 15;

            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.DataPropertyName = "ExpenseDate";
            this.colDate.FillWeight = 10;
            this.colDate.DefaultCellStyle.Format = "yyyy/MM/dd";
            this.colDate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.FillWeight = 10;
            this.colAmount.DefaultCellStyle.Format = "N2";
            this.colAmount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colPaymentMethod.HeaderText = "Payment Method";
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.DataPropertyName = "MethodName";
            this.colPaymentMethod.FillWeight = 12;

            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.DataPropertyName = "SupplierName";
            this.colSupplier.FillWeight = 13;

            this.colReference.HeaderText = "Reference No.";
            this.colReference.Name = "colReference";
            this.colReference.DataPropertyName = "ReferenceNumber";
            this.colReference.FillWeight = 11;

            this.colReceipt.HeaderText = "Receipt No.";
            this.colReceipt.Name = "colReceipt";
            this.colReceipt.DataPropertyName = "ReceiptNumber";
            this.colReceipt.FillWeight = 10;

            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.FillWeight = 8;
            this.colStatus.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.FillWeight = 16;

            this.dgvExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colCategory, this.colDate, this.colAmount,
                this.colPaymentMethod, this.colSupplier, this.colReference,
                this.colReceipt, this.colStatus, this.colDescription
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
            this.lblCount.Text = "Total: 0 expenses";

            // ── Form ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgvExpenses);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.Name = "FrmExpenses";
            this.Text = "Expenses Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmExpenses_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblStatPaid;
        private System.Windows.Forms.Label lblStatPending;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearchDate;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblCount;
    }
}