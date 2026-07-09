namespace LibrarySystem.WinForms.Forms.HR
{
    partial class FrmPayrollDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTotals = new System.Windows.Forms.Panel();
            this.lblTotalBasic = new System.Windows.Forms.Label();
            this.lblTotalAdd = new System.Windows.Forms.Label();
            this.lblTotalDed = new System.Windows.Forms.Label();
            this.lblTotalNet = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdditions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.pnlTotals.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 65);
            this.pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Payroll Details";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(774, 15);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(100, 25);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Total: 0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(880, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(990, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "✕ Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTotals
            // 
            this.pnlTotals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.pnlTotals.Controls.Add(this.lblTotalBasic);
            this.pnlTotals.Controls.Add(this.lblTotalAdd);
            this.pnlTotals.Controls.Add(this.lblTotalDed);
            this.pnlTotals.Controls.Add(this.lblTotalNet);
            this.pnlTotals.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotals.Location = new System.Drawing.Point(0, 602);
            this.pnlTotals.Name = "pnlTotals";
            this.pnlTotals.Size = new System.Drawing.Size(1100, 48);
            this.pnlTotals.TabIndex = 1;
            // 
            // lblTotalBasic
            // 
            this.lblTotalBasic.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalBasic.ForeColor = System.Drawing.Color.White;
            this.lblTotalBasic.Location = new System.Drawing.Point(20, 14);
            this.lblTotalBasic.Name = "lblTotalBasic";
            this.lblTotalBasic.Size = new System.Drawing.Size(220, 22);
            this.lblTotalBasic.TabIndex = 0;
            this.lblTotalBasic.Text = "Basic: 0.00";
            // 
            // lblTotalAdd
            // 
            this.lblTotalAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(220)))), ((int)(((byte)(150)))));
            this.lblTotalAdd.Location = new System.Drawing.Point(260, 14);
            this.lblTotalAdd.Name = "lblTotalAdd";
            this.lblTotalAdd.Size = new System.Drawing.Size(220, 22);
            this.lblTotalAdd.TabIndex = 1;
            this.lblTotalAdd.Text = "Additions: 0.00";
            // 
            // lblTotalDed
            // 
            this.lblTotalDed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalDed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblTotalDed.Location = new System.Drawing.Point(500, 14);
            this.lblTotalDed.Name = "lblTotalDed";
            this.lblTotalDed.Size = new System.Drawing.Size(220, 22);
            this.lblTotalDed.TabIndex = 2;
            this.lblTotalDed.Text = "Deductions: 0.00";
            // 
            // lblTotalNet
            // 
            this.lblTotalNet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalNet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(80)))));
            this.lblTotalNet.Location = new System.Drawing.Point(740, 14);
            this.lblTotalNet.Name = "lblTotalNet";
            this.lblTotalNet.Size = new System.Drawing.Size(260, 22);
            this.lblTotalNet.TabIndex = 3;
            this.lblTotalNet.Text = "Net: 0.00";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvDetails);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 65);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1100, 537);
            this.pnlGrid.TabIndex = 0;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetails.ColumnHeadersHeight = 42;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colEmpCode,
            this.colEmpName,
            this.colDept,
            this.colJob,
            this.colBasicSalary,
            this.colAdditions,
            this.colDeductions,
            this.colNetSalary,
            this.colNotes});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.RowTemplate.Height = 38;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1100, 537);
            this.dgvDetails.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colEmpCode
            // 
            this.colEmpCode.FillWeight = 9F;
            this.colEmpCode.HeaderText = "Code";
            this.colEmpCode.Name = "colEmpCode";
            this.colEmpCode.ReadOnly = true;
            // 
            // colEmpName
            // 
            this.colEmpName.FillWeight = 18F;
            this.colEmpName.HeaderText = "Employee Name";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.ReadOnly = true;
            // 
            // colDept
            // 
            this.colDept.FillWeight = 14F;
            this.colDept.HeaderText = "Department";
            this.colDept.Name = "colDept";
            this.colDept.ReadOnly = true;
            // 
            // colJob
            // 
            this.colJob.FillWeight = 13F;
            this.colJob.HeaderText = "Job Title";
            this.colJob.Name = "colJob";
            this.colJob.ReadOnly = true;
            // 
            // colBasicSalary
            // 
            this.colBasicSalary.FillWeight = 11F;
            this.colBasicSalary.HeaderText = "Basic Salary";
            this.colBasicSalary.Name = "colBasicSalary";
            this.colBasicSalary.ReadOnly = true;
            // 
            // colAdditions
            // 
            this.colAdditions.FillWeight = 10F;
            this.colAdditions.HeaderText = "Additions";
            this.colAdditions.Name = "colAdditions";
            this.colAdditions.ReadOnly = true;
            // 
            // colDeductions
            // 
            this.colDeductions.FillWeight = 10F;
            this.colDeductions.HeaderText = "Deductions";
            this.colDeductions.Name = "colDeductions";
            this.colDeductions.ReadOnly = true;
            // 
            // colNetSalary
            // 
            this.colNetSalary.FillWeight = 10F;
            this.colNetSalary.HeaderText = "Net Salary";
            this.colNetSalary.Name = "colNetSalary";
            this.colNetSalary.ReadOnly = true;
            // 
            // colNotes
            // 
            this.colNotes.FillWeight = 15F;
            this.colNotes.HeaderText = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.ReadOnly = true;
            // 
            // FrmPayrollDetails
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTotals);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmPayrollDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll Details";
            this.Load += new System.EventHandler(this.FrmPayrollDetails_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTotals.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlTotals;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTotalBasic;
        private System.Windows.Forms.Label lblTotalAdd;
        private System.Windows.Forms.Label lblTotalDed;
        private System.Windows.Forms.Label lblTotalNet;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private LibrarySystem.WinForms.UserControls.SearchBoxControl searchBox;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdditions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
    }
}