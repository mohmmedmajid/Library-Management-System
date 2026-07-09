using System;

namespace LibrarySystem.WinForms.Forms.Advanced
{
    partial class FrmAssetDepreciation
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
            System.Windows.Forms.DataGridViewCellStyle colViewStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colPostStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnProcessMonthly = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblYearFilter = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.lblMonthFilter = new System.Windows.Forms.Label();
            this.nudMonth = new System.Windows.Forms.NumericUpDown();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblAssetFilter = new System.Windows.Forms.Label();
            this.cmbAssetFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();

            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvDepreciations = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccumulated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPost = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepreciations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonth)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnNew);
            this.pnlTop.Controls.Add(this.btnProcessMonthly);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1100, 65);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(15, 16);
            this.lblTitle.Size = new System.Drawing.Size(280, 30);
            this.lblTitle.Text = "📉 Asset Depreciation";

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(300, 22);
            this.lblCount.Size = new System.Drawing.Size(80, 22);
            this.lblCount.Text = "Total: 0";

            this.btnNew.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(770, 15);
            this.btnNew.Size = new System.Drawing.Size(90, 34);
            this.btnNew.Text = "+ New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);

            this.btnProcessMonthly.BackColor = System.Drawing.Color.FromArgb(180, 100, 20);
            this.btnProcessMonthly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessMonthly.FlatAppearance.BorderSize = 0;
            this.btnProcessMonthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessMonthly.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnProcessMonthly.ForeColor = System.Drawing.Color.White;
            this.btnProcessMonthly.Location = new System.Drawing.Point(870, 15);
            this.btnProcessMonthly.Size = new System.Drawing.Size(115, 34);
            this.btnProcessMonthly.Text = "⚙️ Monthly";
            this.btnProcessMonthly.UseVisualStyleBackColor = false;
            this.btnProcessMonthly.Visible = false;
            this.btnProcessMonthly.Click += new System.EventHandler(this.BtnProcessMonthly_Click);

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(995, 15);
            this.btnRefresh.Size = new System.Drawing.Size(95, 34);
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // ── pnlFilter ──
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.pnlFilter.Controls.Add(this.lblYearFilter);
            this.pnlFilter.Controls.Add(this.nudYear);
            this.pnlFilter.Controls.Add(this.lblMonthFilter);
            this.pnlFilter.Controls.Add(this.nudMonth);
            this.pnlFilter.Controls.Add(this.lblStatusFilter);
            this.pnlFilter.Controls.Add(this.cmbStatusFilter);
            this.pnlFilter.Controls.Add(this.lblAssetFilter);
            this.pnlFilter.Controls.Add(this.cmbAssetFilter);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Size = new System.Drawing.Size(1100, 55);

            this.lblYearFilter.Text = "Year:";
            this.lblYearFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYearFilter.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblYearFilter.Location = new System.Drawing.Point(10, 16);
            this.lblYearFilter.Size = new System.Drawing.Size(40, 22);

            this.nudYear.Location = new System.Drawing.Point(55, 13);
            this.nudYear.Size = new System.Drawing.Size(90, 28);
            this.nudYear.Minimum = 0;
            this.nudYear.Maximum = 2100;
            this.nudYear.Value = 0;
            this.nudYear.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.lblMonthFilter.Text = "Month:";
            this.lblMonthFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonthFilter.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblMonthFilter.Location = new System.Drawing.Point(160, 16);
            this.lblMonthFilter.Size = new System.Drawing.Size(50, 22);

            this.nudMonth.Location = new System.Drawing.Point(215, 13);
            this.nudMonth.Size = new System.Drawing.Size(70, 28);
            this.nudMonth.Minimum = 0;
            this.nudMonth.Maximum = 12;
            this.nudMonth.Value = 0;
            this.nudMonth.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.lblStatusFilter.Text = "Status:";
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusFilter.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblStatusFilter.Location = new System.Drawing.Point(300, 16);
            this.lblStatusFilter.Size = new System.Drawing.Size(50, 22);

            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatusFilter.Location = new System.Drawing.Point(355, 13);
            this.cmbStatusFilter.Size = new System.Drawing.Size(120, 28);
            this.cmbStatusFilter.Items.AddRange(new object[] { "All", "Draft", "Posted" });
            this.cmbStatusFilter.SelectedIndex = 0;

            this.lblAssetFilter.Text = "Asset:";
            this.lblAssetFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAssetFilter.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblAssetFilter.Location = new System.Drawing.Point(490, 16);
            this.lblAssetFilter.Size = new System.Drawing.Size(45, 22);

            this.cmbAssetFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssetFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbAssetFilter.Location = new System.Drawing.Point(540, 13);
            this.cmbAssetFilter.Size = new System.Drawing.Size(220, 28);

            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(775, 12);
            this.btnFilter.Size = new System.Drawing.Size(90, 30);
            this.btnFilter.Text = "🔍 Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);

            // ── pnlGrid ──
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvDepreciations);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);

            // ── dgvDepreciations ──
            this.dgvDepreciations.AllowUserToAddRows = false;
            this.dgvDepreciations.AllowUserToDeleteRows = false;
            this.dgvDepreciations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepreciations.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepreciations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDepreciations.Dock = System.Windows.Forms.DockStyle.Fill;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvDepreciations.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepreciations.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvDepreciations.ColumnHeadersHeight = 40;

            this.dgvDepreciations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colAssetCode, this.colAssetName,
                this.colDate, this.colPeriod, this.colAmount,
                this.colAccumulated, this.colBookValue, this.colStatus,
                this.colView, this.colPost
            });

            this.dgvDepreciations.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvDepreciations.MultiSelect = false;
            this.dgvDepreciations.RowHeadersVisible = false;
            this.dgvDepreciations.RowTemplate.Height = 36;
            this.dgvDepreciations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepreciations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDepreciations_CellClick);

            // ── Columns ──
            this.colID.HeaderText = "ID"; this.colID.Name = "colID"; this.colID.Visible = false;

            this.colAssetCode.FillWeight = 10F; this.colAssetCode.HeaderText = "Asset Code"; this.colAssetCode.Name = "colAssetCode";
            this.colAssetName.FillWeight = 20F; this.colAssetName.HeaderText = "Asset Name"; this.colAssetName.Name = "colAssetName";
            this.colDate.FillWeight = 10F; this.colDate.HeaderText = "Date"; this.colDate.Name = "colDate";
            this.colPeriod.FillWeight = 10F; this.colPeriod.HeaderText = "Period"; this.colPeriod.Name = "colPeriod";
            this.colAmount.FillWeight = 12F; this.colAmount.HeaderText = "Depr. Amount"; this.colAmount.Name = "colAmount";
            this.colAccumulated.FillWeight = 13F; this.colAccumulated.HeaderText = "Accumulated"; this.colAccumulated.Name = "colAccumulated";
            this.colBookValue.FillWeight = 12F; this.colBookValue.HeaderText = "Book Value"; this.colBookValue.Name = "colBookValue";
            this.colStatus.FillWeight = 8F; this.colStatus.HeaderText = "Status"; this.colStatus.Name = "colStatus";

            // ── colView ──
            colViewStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colViewStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colViewStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colViewStyle.ForeColor = System.Drawing.Color.White;
            colViewStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 80, 160);
            colViewStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colView.DefaultCellStyle = colViewStyle;
            this.colView.FillWeight = 6F;
            this.colView.HeaderText = "";
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;

            // ── colPost ──
            colPostStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colPostStyle.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            colPostStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colPostStyle.ForeColor = System.Drawing.Color.White;
            colPostStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 130, 80);
            colPostStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colPost.DefaultCellStyle = colPostStyle;
            this.colPost.FillWeight = 6F;
            this.colPost.HeaderText = "";
            this.colPost.Name = "colPost";
            this.colPost.ReadOnly = true;

            // ── Form ──
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmAssetDepreciation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asset Depreciation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAssetDepreciation_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepreciations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonth)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblYearFilter;
        private System.Windows.Forms.Label lblMonthFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.Label lblAssetFilter;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.NumericUpDown nudMonth;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.ComboBox cmbAssetFilter;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnProcessMonthly;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnFilter;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private LibrarySystem.WinForms.UserControls.SearchBoxControl searchBox;
        private System.Windows.Forms.DataGridView dgvDepreciations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccumulated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPost;
    }
}