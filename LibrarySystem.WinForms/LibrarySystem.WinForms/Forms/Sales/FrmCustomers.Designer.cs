namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmCustomers
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
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colTransStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colEditStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colDeleteStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();

            this.colCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPurchases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalBorrow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalDebt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalLateFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransactions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnNew);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1134, 65);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.TabIndex = 0;

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(250, 35);
            this.lblTitle.Text = "👥 Customers";

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(280, 22);
            this.lblCount.Size = new System.Drawing.Size(100, 25);
            this.lblCount.Text = "Total: 0";

            this.btnNew.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(920, 15);
            this.btnNew.Size = new System.Drawing.Size(95, 36);
            this.btnNew.Text = "+ New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1025, 15);
            this.btnRefresh.Size = new System.Drawing.Size(105, 36);
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlGrid ──
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvCustomers);
            this.pnlGrid.Location = new System.Drawing.Point(10, 75);
            this.pnlGrid.Size = new System.Drawing.Size(1114, 600);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.TabIndex = 1;

            // ── dgvCustomers ──
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvCustomers.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvCustomers.ColumnHeadersHeight = 42;

            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCustomerID,
                this.colCustomerName,
                this.colPhone,
                this.colEmail,
                this.colTotalPurchases,
                this.colTotalBorrow,
                this.colTotalDebt,
                this.colTotalLateFees,
                this.colStatus,
                this.colTransactions,
                this.colEdit,
                this.colDelete
            });

            this.dgvCustomers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvCustomers.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowTemplate.Height = 38;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1114, 590);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);

            // ── Columns ──
            this.colCustomerID.HeaderText = "ID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.Visible = false;

            this.colCustomerName.FillWeight = 20F;
            this.colCustomerName.HeaderText = "Customer Name";
            this.colCustomerName.Name = "colCustomerName";

            this.colPhone.FillWeight = 11F;
            this.colPhone.HeaderText = "Phone";
            this.colPhone.Name = "colPhone";

            this.colEmail.FillWeight = 16F;
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";

            this.colTotalPurchases.FillWeight = 10F;
            this.colTotalPurchases.HeaderText = "Purchases";
            this.colTotalPurchases.Name = "colTotalPurchases";

            this.colTotalBorrow.FillWeight = 9F;
            this.colTotalBorrow.HeaderText = "Borrowings";
            this.colTotalBorrow.Name = "colTotalBorrow";

            this.colTotalDebt.FillWeight = 9F;
            this.colTotalDebt.HeaderText = "Debt";
            this.colTotalDebt.Name = "colTotalDebt";

            this.colTotalLateFees.FillWeight = 9F;
            this.colTotalLateFees.HeaderText = "Late Fees";
            this.colTotalLateFees.Name = "colTotalLateFees";

            this.colStatus.FillWeight = 8F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";

            // colTransactions - purple
            colTransStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colTransStyle.BackColor = System.Drawing.Color.FromArgb(100, 60, 160);
            colTransStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colTransStyle.ForeColor = System.Drawing.Color.White;
            colTransStyle.SelectionBackColor = System.Drawing.Color.FromArgb(80, 40, 140);
            colTransStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colTransactions.DefaultCellStyle = colTransStyle;
            this.colTransactions.FillWeight = 10F;
            this.colTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colTransactions.HeaderText = "";
            this.colTransactions.Name = "colTransactions";

            // colEdit - blue
            colEditStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colEditStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colEditStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colEditStyle.ForeColor = System.Drawing.Color.White;
            colEditStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 80, 160);
            colEditStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colEdit.DefaultCellStyle = colEditStyle;
            this.colEdit.FillWeight = 7F;
            this.colEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";

            // colDelete - red
            colDeleteStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colDeleteStyle.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            colDeleteStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colDeleteStyle.ForeColor = System.Drawing.Color.White;
            colDeleteStyle.SelectionBackColor = System.Drawing.Color.FromArgb(170, 30, 30);
            colDeleteStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colDelete.DefaultCellStyle = colDeleteStyle;
            this.colDelete.FillWeight = 7F;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";

            // ── FrmCustomers ──
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1134, 690);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlGrid);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers";
            this.Load += new System.EventHandler(this.FrmCustomers_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private LibrarySystem.WinForms.UserControls.SearchBoxControl searchBox;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPurchases;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalBorrow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalDebt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLateFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colTransactions;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}