namespace LibrarySystem.WinForms.Forms.HR
{
    partial class FrmEmployeeAdvances
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
            System.Windows.Forms.DataGridViewCellStyle colDeleteStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblEmp = new System.Windows.Forms.Label();
            this.cmbFilterEmployee = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalPaid = new System.Windows.Forms.Label();
            this.lblTotalRemaining = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvAdvances = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonthlyDed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApproved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvances)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(320, 35);
            this.lblTitle.Text = "💳 Employee Advances";

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(350, 22);
            this.lblCount.Size = new System.Drawing.Size(100, 25);
            this.lblCount.Text = "Total: 0";

            this.btnNew.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(890, 15);
            this.btnNew.Size = new System.Drawing.Size(95, 36);
            this.btnNew.Text = "+ New";
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
            this.pnlFilters.Controls.Add(this.lblEmp);
            this.pnlFilters.Controls.Add(this.cmbFilterEmployee);
            this.pnlFilters.Controls.Add(this.lblStatus);
            this.pnlFilters.Controls.Add(this.cmbFilterStatus);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Height = 50;
            this.pnlFilters.Name = "pnlFilters";

            this.lblEmp.Text = "Employee:";
            this.lblEmp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmp.Location = new System.Drawing.Point(20, 14);
            this.lblEmp.Size = new System.Drawing.Size(75, 22);
            this.lblEmp.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);

            this.cmbFilterEmployee.Location = new System.Drawing.Point(100, 11);
            this.cmbFilterEmployee.Size = new System.Drawing.Size(220, 28);
            this.cmbFilterEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbFilterEmployee_SelectedIndexChanged);

            this.lblStatus.Text = "Status:";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(345, 14);
            this.lblStatus.Size = new System.Drawing.Size(55, 22);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);

            this.cmbFilterStatus.Location = new System.Drawing.Point(405, 11);
            this.cmbFilterStatus.Size = new System.Drawing.Size(150, 28);
            this.cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Items.AddRange(new object[] { "All", "Active", "Completed", "Cancelled" });
            this.cmbFilterStatus.SelectedIndex = 0;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);

            // ── pnlSummary ──
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlSummary.Controls.Add(this.lblTotalAmount);
            this.pnlSummary.Controls.Add(this.lblTotalPaid);
            this.pnlSummary.Controls.Add(this.lblTotalRemaining);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummary.Height = 48;
            this.pnlSummary.Name = "pnlSummary";

            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 14);
            this.lblTotalAmount.Size = new System.Drawing.Size(260, 22);
            this.lblTotalAmount.Text = "Total: 0.00";

            this.lblTotalPaid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalPaid.ForeColor = System.Drawing.Color.FromArgb(100, 220, 150);
            this.lblTotalPaid.Location = new System.Drawing.Point(300, 14);
            this.lblTotalPaid.Size = new System.Drawing.Size(260, 22);
            this.lblTotalPaid.Text = "Paid: 0.00";

            this.lblTotalRemaining.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalRemaining.ForeColor = System.Drawing.Color.FromArgb(255, 140, 100);
            this.lblTotalRemaining.Location = new System.Drawing.Point(580, 14);
            this.lblTotalRemaining.Size = new System.Drawing.Size(260, 22);
            this.lblTotalRemaining.Text = "Remaining: 0.00";

            // ── pnlGrid ──
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvAdvances);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name = "pnlGrid";

            // ── dgvAdvances ──
            this.dgvAdvances.AllowUserToAddRows = false;
            this.dgvAdvances.AllowUserToDeleteRows = false;
            this.dgvAdvances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdvances.BackgroundColor = System.Drawing.Color.White;
            this.dgvAdvances.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdvances.Dock = System.Windows.Forms.DockStyle.Fill;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvAdvances.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAdvances.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvAdvances.ColumnHeadersHeight = 42;

            this.dgvAdvances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colNumber, this.colEmployee, this.colDate,
                this.colAmount, this.colMonths, this.colMonthlyDed,
                this.colPaid, this.colRemaining, this.colStatus,
                this.colApproved, this.colEdit, this.colDelete });

            this.dgvAdvances.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvAdvances.MultiSelect = false;
            this.dgvAdvances.RowHeadersVisible = false;
            this.dgvAdvances.RowTemplate.Height = 38;
            this.dgvAdvances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdvances.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdvances_CellClick);

            // Columns
            this.colID.HeaderText = "ID"; this.colID.Name = "colID"; this.colID.Visible = false;
            this.colNumber.FillWeight = 10F; this.colNumber.HeaderText = "Advance #"; this.colNumber.Name = "colNumber";
            this.colEmployee.FillWeight = 16F; this.colEmployee.HeaderText = "Employee"; this.colEmployee.Name = "colEmployee";
            this.colDate.FillWeight = 10F; this.colDate.HeaderText = "Date"; this.colDate.Name = "colDate";
            this.colAmount.FillWeight = 9F; this.colAmount.HeaderText = "Amount"; this.colAmount.Name = "colAmount";
            this.colMonths.FillWeight = 8F; this.colMonths.HeaderText = "Months"; this.colMonths.Name = "colMonths";
            this.colMonthlyDed.FillWeight = 9F; this.colMonthlyDed.HeaderText = "Monthly Ded."; this.colMonthlyDed.Name = "colMonthlyDed";
            this.colPaid.FillWeight = 9F; this.colPaid.HeaderText = "Paid"; this.colPaid.Name = "colPaid";
            this.colRemaining.FillWeight = 9F; this.colRemaining.HeaderText = "Remaining"; this.colRemaining.Name = "colRemaining";
            this.colStatus.FillWeight = 8F; this.colStatus.HeaderText = "Status"; this.colStatus.Name = "colStatus";
            this.colApproved.FillWeight = 10F; this.colApproved.HeaderText = "Approved By"; this.colApproved.Name = "colApproved";

            colEditStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colEditStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colEditStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colEditStyle.ForeColor = System.Drawing.Color.White;
            colEditStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 80, 160);
            colEditStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colEdit.DefaultCellStyle = colEditStyle;
            this.colEdit.FillWeight = 6F; this.colEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEdit.HeaderText = ""; this.colEdit.Name = "colEdit";

            colDeleteStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colDeleteStyle.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            colDeleteStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colDeleteStyle.ForeColor = System.Drawing.Color.White;
            colDeleteStyle.SelectionBackColor = System.Drawing.Color.FromArgb(170, 30, 30);
            colDeleteStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colDelete.DefaultCellStyle = colDeleteStyle;
            this.colDelete.FillWeight = 6F; this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = ""; this.colDelete.Name = "colDelete";

            // ── Form ──
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 690);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmEmployeeAdvances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Advances";
            this.Load += new System.EventHandler(this.FrmEmployeeAdvances_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvances)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblEmp;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalPaid;
        private System.Windows.Forms.Label lblTotalRemaining;
        private System.Windows.Forms.ComboBox cmbFilterEmployee;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private LibrarySystem.WinForms.UserControls.SearchBoxControl searchBox;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvAdvances;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonthlyDed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApproved;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}