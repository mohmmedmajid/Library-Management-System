// FrmAuditLog.Designer.cs
namespace LibrarySystem.WinForms.Forms.Main
{
    partial class FrmAuditLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnDeleteOld = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblAction = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblOldValue = new System.Windows.Forms.Label();
            this.txtOldValue = new System.Windows.Forms.TextBox();
            this.lblNewValue = new System.Windows.Forms.Label();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnDeleteOld);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1116, 65);
            this.pnlTop.TabIndex = 2;

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Audit Log";

            // lblCount
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(225, 22);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(100, 25);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Total: 0";

            // btnDeleteOld
            this.btnDeleteOld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteOld.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnDeleteOld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteOld.FlatAppearance.BorderSize = 0;
            this.btnDeleteOld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOld.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteOld.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOld.Location = new System.Drawing.Point(870, 15);
            this.btnDeleteOld.Name = "btnDeleteOld";
            this.btnDeleteOld.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteOld.TabIndex = 2;
            this.btnDeleteOld.Text = "🗑 Delete Old";
            this.btnDeleteOld.UseVisualStyleBackColor = false;
            this.btnDeleteOld.Click += new System.EventHandler(this.btnDeleteOld_Click);

            // btnRefresh
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1000, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlFilter ──
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.lblFrom);
            this.pnlFilter.Controls.Add(this.dtpFrom);
            this.pnlFilter.Controls.Add(this.lblTo);
            this.pnlFilter.Controls.Add(this.dtpTo);
            this.pnlFilter.Controls.Add(this.lblAction);
            this.pnlFilter.Controls.Add(this.cmbAction);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 65);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlFilter.Size = new System.Drawing.Size(1116, 60);
            this.pnlFilter.TabIndex = 1;

            // lblFrom
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblFrom.Location = new System.Drawing.Point(15, 18);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(45, 22);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";

            // dtpFrom
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(60, 15);
            this.dtpFrom.MinDate = new System.DateTime(1990, 1, 1);
            this.dtpFrom.MaxDate = System.DateTime.Today;
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(140, 25);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.Value = System.DateTime.Today.AddDays(-30);

            // lblTo
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTo.Location = new System.Drawing.Point(210, 18);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(30, 22);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";

            // dtpTo
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(240, 15);
            this.dtpTo.MinDate = new System.DateTime(1990, 1, 1);
            this.dtpTo.MaxDate = System.DateTime.Today;
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(140, 25);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.Value = System.DateTime.Today;

            // lblAction
            this.lblAction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAction.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblAction.Location = new System.Drawing.Point(395, 18);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(55, 22);
            this.lblAction.TabIndex = 4;
            this.lblAction.Text = "Action:";

            // cmbAction
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAction.Location = new System.Drawing.Point(450, 15);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(130, 25);
            this.cmbAction.TabIndex = 5;

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(595, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // ── pnlGrid ──
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvLogs);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 125);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1116, 277);
            this.pnlGrid.TabIndex = 0;

            // ── dgvLogs ──
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLogs.ColumnHeadersHeight = 40;
            this.dgvLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID,
                this.colUsername,
                this.colAction,
                this.colTableName,
                this.colRecordID,
                this.colIPAddress,
                this.colCreatedAt });
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvLogs.Location = new System.Drawing.Point(0, 0);
            this.dgvLogs.Margin = new System.Windows.Forms.Padding(5);
            this.dgvLogs.MultiSelect = false;
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersVisible = false;
            this.dgvLogs.RowTemplate.Height = 33;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(1116, 277);
            this.dgvLogs.TabIndex = 0;
            this.dgvLogs.SelectionChanged += new System.EventHandler(this.dgvLogs_SelectionChanged);

            // ── Columns ──
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;

            this.colUsername.FillWeight = 15F;
            this.colUsername.HeaderText = "User";
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;

            this.colAction.FillWeight = 12F;
            this.colAction.HeaderText = "Action";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;

            this.colTableName.FillWeight = 18F;
            this.colTableName.HeaderText = "Table";
            this.colTableName.Name = "colTableName";
            this.colTableName.ReadOnly = true;

            this.colRecordID.FillWeight = 10F;
            this.colRecordID.HeaderText = "Record ID";
            this.colRecordID.Name = "colRecordID";
            this.colRecordID.ReadOnly = true;

            this.colIPAddress.FillWeight = 15F;
            this.colIPAddress.HeaderText = "IP Address";
            this.colIPAddress.Name = "colIPAddress";
            this.colIPAddress.ReadOnly = true;

            this.colCreatedAt.FillWeight = 20F;
            this.colCreatedAt.HeaderText = "Date & Time";
            this.colCreatedAt.Name = "colCreatedAt";
            this.colCreatedAt.ReadOnly = true;

            // ── pnlDetail ──
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.Controls.Add(this.lblOldValue);
            this.pnlDetail.Controls.Add(this.txtOldValue);
            this.pnlDetail.Controls.Add(this.lblNewValue);
            this.pnlDetail.Controls.Add(this.txtNewValue);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail.Location = new System.Drawing.Point(0, 402);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1116, 120);
            this.pnlDetail.TabIndex = 3;

            // lblOldValue
            this.lblOldValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOldValue.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblOldValue.Location = new System.Drawing.Point(10, 8);
            this.lblOldValue.Name = "lblOldValue";
            this.lblOldValue.Size = new System.Drawing.Size(80, 22);
            this.lblOldValue.TabIndex = 0;
            this.lblOldValue.Text = "Old Value:";

            // txtOldValue
            this.txtOldValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOldValue.BackColor = System.Drawing.Color.FromArgb(255, 245, 245);
            this.txtOldValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOldValue.Location = new System.Drawing.Point(10, 30);
            this.txtOldValue.Multiline = true;
            this.txtOldValue.Name = "txtOldValue";
            this.txtOldValue.ReadOnly = true;
            this.txtOldValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOldValue.Size = new System.Drawing.Size(480, 75);
            this.txtOldValue.TabIndex = 1;

            // lblNewValue
            this.lblNewValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNewValue.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblNewValue.Location = new System.Drawing.Point(505, 8);
            this.lblNewValue.Name = "lblNewValue";
            this.lblNewValue.Size = new System.Drawing.Size(80, 22);
            this.lblNewValue.TabIndex = 2;
            this.lblNewValue.Text = "New Value:";

            // txtNewValue
            this.txtNewValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewValue.BackColor = System.Drawing.Color.FromArgb(245, 255, 245);
            this.txtNewValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewValue.Location = new System.Drawing.Point(505, 30);
            this.txtNewValue.Multiline = true;
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.ReadOnly = true;
            this.txtNewValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewValue.Size = new System.Drawing.Size(480, 75);
            this.txtNewValue.TabIndex = 3;

            // ── FrmAuditLog ──
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1116, 522);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlDetail);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmAuditLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audit Log";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAuditLog_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private LibrarySystem.WinForms.UserControls.SearchBoxControl searchBox;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteOld;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedAt;
        private System.Windows.Forms.Label lblOldValue;
        private System.Windows.Forms.Label lblNewValue;
        private System.Windows.Forms.TextBox txtOldValue;
        private System.Windows.Forms.TextBox txtNewValue;
    }
}