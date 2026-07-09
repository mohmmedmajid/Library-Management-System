namespace LibrarySystem.WinForms.Forms.Accounting
{
    partial class FrmJournalEntry
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

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.pnlEntries = new System.Windows.Forms.Panel();
            this.dgvEntries = new System.Windows.Forms.DataGridView();

            this.colEntryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntryDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalanced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntryStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostCenter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntryView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEntryPost = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEntryEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEntryDelete = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlTop.SuspendLayout();
            this.pnlEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntries)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnNew);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Size = new System.Drawing.Size(1100, 65);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(320, 35);
            this.lblTitle.Text = "📝 Journal Entries";

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
            this.btnNew.UseVisualStyleBackColor = false;
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
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // pnlEntries
            this.pnlEntries.BackColor = System.Drawing.Color.White;
            this.pnlEntries.Controls.Add(this.dgvEntries);
            this.pnlEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEntries.Location = new System.Drawing.Point(0, 65);
            this.pnlEntries.Padding = new System.Windows.Forms.Padding(10);
            this.pnlEntries.Size = new System.Drawing.Size(1100, 625);

            // dgvEntries
            this.dgvEntries.AllowUserToAddRows = false;
            this.dgvEntries.AllowUserToDeleteRows = false;
            this.dgvEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntries.BackgroundColor = System.Drawing.Color.White;
            this.dgvEntries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEntries.Dock = System.Windows.Forms.DockStyle.Fill;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvEntries.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntries.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvEntries.ColumnHeadersHeight = 42;

            this.dgvEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colEntryID, this.colEntryNumber, this.colEntryDate, this.colEntryType,
                this.colEntryDescription, this.colTotalDebit, this.colTotalCredit,
                this.colBalanced, this.colEntryStatus, this.colCostCenter, this.colCreatedBy,
                this.colEntryView, this.colEntryPost, this.colEntryEdit, this.colEntryDelete
            });

            this.dgvEntries.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvEntries.Location = new System.Drawing.Point(0, 0);
            this.dgvEntries.MultiSelect = false;
            this.dgvEntries.RowHeadersVisible = false;
            this.dgvEntries.RowTemplate.Height = 38;
            this.dgvEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntries.Size = new System.Drawing.Size(1080, 605);
            this.dgvEntries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntries_CellClick);

            this.colEntryID.HeaderText = "ID"; this.colEntryID.Name = "colEntryID"; this.colEntryID.Visible = false;
            this.colEntryNumber.HeaderText = "Entry Number"; this.colEntryNumber.Name = "colEntryNumber"; this.colEntryNumber.FillWeight = 13F;
            this.colEntryDate.HeaderText = "Date"; this.colEntryDate.Name = "colEntryDate"; this.colEntryDate.FillWeight = 8F;
            this.colEntryType.HeaderText = "Type"; this.colEntryType.Name = "colEntryType"; this.colEntryType.FillWeight = 8F;
            this.colEntryDescription.HeaderText = "Description"; this.colEntryDescription.Name = "colEntryDescription"; this.colEntryDescription.FillWeight = 16F;
            this.colTotalDebit.HeaderText = "Total Debit"; this.colTotalDebit.Name = "colTotalDebit"; this.colTotalDebit.FillWeight = 8F;
            this.colTotalCredit.HeaderText = "Total Credit"; this.colTotalCredit.Name = "colTotalCredit"; this.colTotalCredit.FillWeight = 8F;
            this.colBalanced.HeaderText = "Balanced"; this.colBalanced.Name = "colBalanced"; this.colBalanced.FillWeight = 8F;
            this.colEntryStatus.HeaderText = "Status"; this.colEntryStatus.Name = "colEntryStatus"; this.colEntryStatus.FillWeight = 6F;
            this.colCostCenter.HeaderText = "Cost Center"; this.colCostCenter.Name = "colCostCenter"; this.colCostCenter.FillWeight = 8F;
            this.colCreatedBy.HeaderText = "Created By"; this.colCreatedBy.Name = "colCreatedBy"; this.colCreatedBy.FillWeight = 7F;

            var viewStyle = new System.Windows.Forms.DataGridViewCellStyle();
            viewStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            viewStyle.BackColor = System.Drawing.Color.FromArgb(90, 90, 110);
            viewStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            viewStyle.ForeColor = System.Drawing.Color.White;
            this.colEntryView.DefaultCellStyle = viewStyle;
            this.colEntryView.FillWeight = 6F;
            this.colEntryView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEntryView.HeaderText = "";
            this.colEntryView.Name = "colEntryView";

            var postStyle = new System.Windows.Forms.DataGridViewCellStyle();
            postStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            postStyle.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            postStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            postStyle.ForeColor = System.Drawing.Color.White;
            this.colEntryPost.DefaultCellStyle = postStyle;
            this.colEntryPost.FillWeight = 6F;
            this.colEntryPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEntryPost.HeaderText = "";
            this.colEntryPost.Name = "colEntryPost";

            var editStyle = new System.Windows.Forms.DataGridViewCellStyle();
            editStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            editStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            editStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            editStyle.ForeColor = System.Drawing.Color.White;
            this.colEntryEdit.DefaultCellStyle = editStyle;
            this.colEntryEdit.FillWeight = 6F;
            this.colEntryEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEntryEdit.HeaderText = "";
            this.colEntryEdit.Name = "colEntryEdit";

            var deleteStyle = new System.Windows.Forms.DataGridViewCellStyle();
            deleteStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            deleteStyle.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            deleteStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            deleteStyle.ForeColor = System.Drawing.Color.White;
            this.colEntryDelete.DefaultCellStyle = deleteStyle;
            this.colEntryDelete.FillWeight = 6F;
            this.colEntryDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEntryDelete.HeaderText = "";
            this.colEntryDelete.Name = "colEntryDelete";

            // Form
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 690);
            this.Controls.Add(this.pnlEntries);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmJournalEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journal Entry";
            this.Load += new System.EventHandler(this.FrmJournalEntry_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlEntries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntries)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlEntries;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private LibrarySystem.WinForms.UserControls.SearchBoxControl searchBox;
        private System.Windows.Forms.DataGridView dgvEntries;

        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalanced;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostCenter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
        private System.Windows.Forms.DataGridViewButtonColumn colEntryView;
        private System.Windows.Forms.DataGridViewButtonColumn colEntryPost;
        private System.Windows.Forms.DataGridViewButtonColumn colEntryEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colEntryDelete;
    }
}