namespace LibrarySystem.WinForms.Forms.HR
{
    partial class FrmPayroll
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
            System.Windows.Forms.DataGridViewCellStyle colApproveStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colPostStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colDetailsStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colDeleteStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbFilterYear = new System.Windows.Forms.ComboBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvPayroll = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdditions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colApprove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPost = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnNew);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 65;
            this.pnlTop.Name = "pnlTop";

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(260, 35);
            this.lblTitle.Text = "📊 Payroll";

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(290, 22);
            this.lblCount.Size = new System.Drawing.Size(100, 25);
            this.lblCount.Text = "Total: 0";

            this.btnNew.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(880, 15);
            this.btnNew.Size = new System.Drawing.Size(110, 36);
            this.btnNew.Text = "+ New Payroll";
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(995, 15);
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlFilters ──
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.pnlFilters.Controls.Add(this.lblStatus);
            this.pnlFilters.Controls.Add(this.cmbFilterStatus);
            this.pnlFilters.Controls.Add(this.lblYear);
            this.pnlFilters.Controls.Add(this.cmbFilterYear);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Height = 50;
            this.pnlFilters.Name = "pnlFilters";

            this.lblStatus.Text = "Status:";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(20, 14);
            this.lblStatus.Size = new System.Drawing.Size(55, 22);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);

            this.cmbFilterStatus.Location = new System.Drawing.Point(80, 11);
            this.cmbFilterStatus.Size = new System.Drawing.Size(150, 28);
            this.cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Items.AddRange(new object[] { "All", "Draft", "Approved", "Posted", "Paid" });
            this.cmbFilterStatus.SelectedIndex = 0;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);

            this.lblYear.Text = "Year:";
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYear.Location = new System.Drawing.Point(255, 14);
            this.lblYear.Size = new System.Drawing.Size(45, 22);
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);

            this.cmbFilterYear.Location = new System.Drawing.Point(305, 11);
            this.cmbFilterYear.Size = new System.Drawing.Size(130, 28);
            this.cmbFilterYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterYear.SelectedIndexChanged += new System.EventHandler(this.cmbFilterYear_SelectedIndexChanged);

            // ── pnlGrid ──
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvPayroll);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name = "pnlGrid";

            // ── dgvPayroll ──
            this.dgvPayroll.AllowUserToAddRows = false;
            this.dgvPayroll.AllowUserToDeleteRows = false;
            this.dgvPayroll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayroll.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayroll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayroll.Dock = System.Windows.Forms.DockStyle.Fill;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvPayroll.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayroll.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvPayroll.ColumnHeadersHeight = 42;

            this.dgvPayroll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colNumber, this.colPeriod, this.colDate,
                this.colEmployees, this.colBasicSalary, this.colAdditions,
                this.colDeductions, this.colNetSalary, this.colStatus,
                this.colDetails, this.colApprove, this.colPost, this.colDelete });

            this.dgvPayroll.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvPayroll.MultiSelect = false;
            this.dgvPayroll.RowHeadersVisible = false;
            this.dgvPayroll.RowTemplate.Height = 38;
            this.dgvPayroll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayroll.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayroll_CellClick);

            // Columns
            this.colID.HeaderText = "ID"; this.colID.Name = "colID"; this.colID.Visible = false;
            this.colNumber.FillWeight = 12F; this.colNumber.HeaderText = "Payroll #"; this.colNumber.Name = "colNumber";
            this.colPeriod.FillWeight = 14F; this.colPeriod.HeaderText = "Period"; this.colPeriod.Name = "colPeriod";
            this.colDate.FillWeight = 11F; this.colDate.HeaderText = "Date"; this.colDate.Name = "colDate";
            this.colEmployees.FillWeight = 8F; this.colEmployees.HeaderText = "Employees"; this.colEmployees.Name = "colEmployees";
            this.colBasicSalary.FillWeight = 11F; this.colBasicSalary.HeaderText = "Basic Salary"; this.colBasicSalary.Name = "colBasicSalary";
            this.colAdditions.FillWeight = 9F; this.colAdditions.HeaderText = "Additions"; this.colAdditions.Name = "colAdditions";
            this.colDeductions.FillWeight = 9F; this.colDeductions.HeaderText = "Deductions"; this.colDeductions.Name = "colDeductions";
            this.colNetSalary.FillWeight = 10F; this.colNetSalary.HeaderText = "Net Salary"; this.colNetSalary.Name = "colNetSalary";
            this.colStatus.FillWeight = 8F; this.colStatus.HeaderText = "Status"; this.colStatus.Name = "colStatus";

            colDetailsStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colDetailsStyle.BackColor = System.Drawing.Color.FromArgb(120, 80, 180);
            colDetailsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colDetailsStyle.ForeColor = System.Drawing.Color.White;
            this.colDetails.DefaultCellStyle = colDetailsStyle;
            this.colDetails.FillWeight = 7F; this.colDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDetails.HeaderText = ""; this.colDetails.Name = "colDetails";

            colApproveStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colApproveStyle.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            colApproveStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colApproveStyle.ForeColor = System.Drawing.Color.White;
            this.colApprove.DefaultCellStyle = colApproveStyle;
            this.colApprove.FillWeight = 7F; this.colApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colApprove.HeaderText = ""; this.colApprove.Name = "colApprove";

            colPostStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colPostStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colPostStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colPostStyle.ForeColor = System.Drawing.Color.White;
            this.colPost.DefaultCellStyle = colPostStyle;
            this.colPost.FillWeight = 6F; this.colPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colPost.HeaderText = ""; this.colPost.Name = "colPost";

            colDeleteStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colDeleteStyle.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            colDeleteStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colDeleteStyle.ForeColor = System.Drawing.Color.White;
            this.colDelete.DefaultCellStyle = colDeleteStyle;
            this.colDelete.FillWeight = 6F; this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = ""; this.colDelete.Name = "colDelete";

            // ── Form ──
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 690);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmPayroll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll";
            this.Load += new System.EventHandler(this.FrmPayroll_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterYear;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvPayroll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdditions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colDetails;
        private System.Windows.Forms.DataGridViewButtonColumn colApprove;
        private System.Windows.Forms.DataGridViewButtonColumn colPost;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}