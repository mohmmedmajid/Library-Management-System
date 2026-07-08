namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmSalesReps
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
            System.Windows.Forms.DataGridViewCellStyle colEditStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colDeactivateStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReps = new System.Windows.Forms.DataGridView();

            this.colSalesRepID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCommissions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDeactivate = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReps)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(280, 35);
            this.lblTitle.Text = "🧑‍💼 Sales Representatives";

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(300, 22);
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
            this.pnlGrid.Controls.Add(this.dgvReps);
            this.pnlGrid.Location = new System.Drawing.Point(10, 75);
            this.pnlGrid.Size = new System.Drawing.Size(1114, 600);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.TabIndex = 1;

            // ── dgvReps ──
            this.dgvReps.AllowUserToAddRows = false;
            this.dgvReps.AllowUserToDeleteRows = false;
            this.dgvReps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReps.BackgroundColor = System.Drawing.Color.White;
            this.dgvReps.BorderStyle = System.Windows.Forms.BorderStyle.None;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvReps.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReps.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvReps.ColumnHeadersHeight = 42;

            this.dgvReps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colSalesRepID,
                this.colRepName,
                this.colPhone,
                this.colEmail,
                this.colCommission,
                this.colTotalSales,
                this.colTotalCommissions,
                this.colStatus,
                this.colEdit,
                this.colDeactivate
            });

            this.dgvReps.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvReps.Location = new System.Drawing.Point(0, 0);
            this.dgvReps.MultiSelect = false;
            this.dgvReps.Name = "dgvReps";
            this.dgvReps.RowHeadersVisible = false;
            this.dgvReps.RowTemplate.Height = 38;
            this.dgvReps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReps.Size = new System.Drawing.Size(1114, 590);
            this.dgvReps.TabIndex = 0;
            this.dgvReps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReps_CellClick);

            // ── Columns ──
            this.colSalesRepID.HeaderText = "ID";
            this.colSalesRepID.Name = "colSalesRepID";
            this.colSalesRepID.Visible = false;

            this.colRepName.FillWeight = 20F;
            this.colRepName.HeaderText = "Name";
            this.colRepName.Name = "colRepName";

            this.colPhone.FillWeight = 12F;
            this.colPhone.HeaderText = "Phone";
            this.colPhone.Name = "colPhone";

            this.colEmail.FillWeight = 16F;
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";

            this.colCommission.FillWeight = 9F;
            this.colCommission.HeaderText = "Comm %";
            this.colCommission.Name = "colCommission";

            this.colTotalSales.FillWeight = 11F;
            this.colTotalSales.HeaderText = "Total Sales";
            this.colTotalSales.Name = "colTotalSales";

            this.colTotalCommissions.FillWeight = 11F;
            this.colTotalCommissions.HeaderText = "Commissions";
            this.colTotalCommissions.Name = "colTotalCommissions";

            this.colStatus.FillWeight = 9F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";

            // colEdit - blue
            colEditStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colEditStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colEditStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colEditStyle.ForeColor = System.Drawing.Color.White;
            colEditStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 80, 160);
            colEditStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colEdit.DefaultCellStyle = colEditStyle;
            this.colEdit.FillWeight = 8F;
            this.colEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";

            // colDeactivate - red
            colDeactivateStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colDeactivateStyle.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            colDeactivateStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colDeactivateStyle.ForeColor = System.Drawing.Color.White;
            colDeactivateStyle.SelectionBackColor = System.Drawing.Color.FromArgb(170, 30, 30);
            colDeactivateStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colDeactivate.DefaultCellStyle = colDeactivateStyle;
            this.colDeactivate.FillWeight = 9F;
            this.colDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDeactivate.HeaderText = "";
            this.colDeactivate.Name = "colDeactivate";

            // ── FrmSalesReps ──
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1134, 690);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlGrid);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmSalesReps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Representatives";
            this.Load += new System.EventHandler(this.FrmSalesReps_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReps)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvReps;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesRepID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCommissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDeactivate;
    }
}