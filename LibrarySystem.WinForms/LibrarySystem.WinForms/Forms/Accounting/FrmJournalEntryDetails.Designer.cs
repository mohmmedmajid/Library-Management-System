// FrmJournalEntryDetails.Designer.cs
namespace LibrarySystem.WinForms.Forms.Accounting
{
    partial class FrmJournalEntryDetails
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
            System.Windows.Forms.DataGridViewCellStyle altRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEntryNumberValue = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();

            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblEntryId = new System.Windows.Forms.Label();
            this.txtEntryId = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearchByDate = new System.Windows.Forms.Button();

            this.pnlEntryInfo = new System.Windows.Forms.Panel();
            this.lblInfoEntryNum = new System.Windows.Forms.Label();
            this.lblInfoEntryNumVal = new System.Windows.Forms.Label();
            this.lblInfoDate = new System.Windows.Forms.Label();
            this.lblInfoDateVal = new System.Windows.Forms.Label();
            this.lblInfoType = new System.Windows.Forms.Label();
            this.lblInfoTypeVal = new System.Windows.Forms.Label();
            this.lblInfoStatus = new System.Windows.Forms.Label();
            this.lblInfoStatusVal = new System.Windows.Forms.Label();
            this.lblInfoDesc = new System.Windows.Forms.Label();
            this.lblInfoDescVal = new System.Windows.Forms.Label();
            this.lblInfoDebit = new System.Windows.Forms.Label();
            this.lblInfoDebitVal = new System.Windows.Forms.Label();
            this.lblInfoCredit = new System.Windows.Forms.Label();
            this.lblInfoCreditVal = new System.Windows.Forms.Label();

            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colLineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotalDebitLabel = new System.Windows.Forms.Label();
            this.lblTotalDebitVal = new System.Windows.Forms.Label();
            this.lblTotalCreditLabel = new System.Windows.Forms.Label();
            this.lblTotalCreditVal = new System.Windows.Forms.Label();
            this.lblBalanceLabel = new System.Windows.Forms.Label();
            this.lblBalanceVal = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlEntryInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════
            // pnlHeader
            // ══════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 58;
            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblEntryNumberValue, this.lblDateValue });

            this.lblTitle.Text = "Journal Entry Details";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 13);
            this.lblTitle.Size = new System.Drawing.Size(300, 32);

            this.lblEntryNumberValue.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblEntryNumberValue.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblEntryNumberValue.Location = new System.Drawing.Point(330, 16);
            this.lblEntryNumberValue.Size = new System.Drawing.Size(300, 26);
            this.lblEntryNumberValue.Text = "";

            this.lblDateValue.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblDateValue.ForeColor = System.Drawing.Color.White;
            this.lblDateValue.Location = new System.Drawing.Point(820, 20);
            this.lblDateValue.Size = new System.Drawing.Size(260, 20);
            this.lblDateValue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblDateValue.Text = "";

            // ══════════════════════════════════════
            // pnlFilter
            // ══════════════════════════════════════
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Height = 54;
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(8, 8, 8, 6);
            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEntryId, this.txtEntryId, this.btnLoad,
                this.lblAccountId, this.txtAccountId,
                this.lblStartDate, this.dtpStartDate,
                this.lblEndDate, this.dtpEndDate, this.btnSearchByDate });

            this.lblEntryId.Text = "Entry ID:";
            this.lblEntryId.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblEntryId.Location = new System.Drawing.Point(8, 18);
            this.lblEntryId.Size = new System.Drawing.Size(65, 20);

            this.txtEntryId.Location = new System.Drawing.Point(76, 15);
            this.txtEntryId.Size = new System.Drawing.Size(80, 26);
            this.txtEntryId.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            this.btnLoad.Text = "Load";
            this.btnLoad.Location = new System.Drawing.Point(164, 14);
            this.btnLoad.Size = new System.Drawing.Size(70, 28);
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.lblAccountId.Text = "Account ID:";
            this.lblAccountId.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblAccountId.Location = new System.Drawing.Point(250, 18);
            this.lblAccountId.Size = new System.Drawing.Size(70, 20);

            this.txtAccountId.Location = new System.Drawing.Point(322, 15);
            this.txtAccountId.Size = new System.Drawing.Size(70, 26);
            this.txtAccountId.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblStartDate.Text = "From:";
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblStartDate.Location = new System.Drawing.Point(404, 18);
            this.lblStartDate.Size = new System.Drawing.Size(40, 20);

            this.dtpStartDate.Location = new System.Drawing.Point(448, 15);
            this.dtpStartDate.Size = new System.Drawing.Size(130, 26);
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Value = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1);

            this.lblEndDate.Text = "To:";
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblEndDate.Location = new System.Drawing.Point(586, 18);
            this.lblEndDate.Size = new System.Drawing.Size(28, 20);

            this.dtpEndDate.Location = new System.Drawing.Point(616, 15);
            this.dtpEndDate.Size = new System.Drawing.Size(130, 26);
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnSearchByDate.Text = "Search by Date";
            this.btnSearchByDate.Location = new System.Drawing.Point(754, 14);
            this.btnSearchByDate.Size = new System.Drawing.Size(130, 28);
            this.btnSearchByDate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSearchByDate.BackColor = System.Drawing.Color.FromArgb(60, 120, 60);
            this.btnSearchByDate.ForeColor = System.Drawing.Color.White;
            this.btnSearchByDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchByDate.FlatAppearance.BorderSize = 0;
            this.btnSearchByDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchByDate.Click += new System.EventHandler(this.btnSearchByDate_Click);

            // ══════════════════════════════════════
            // pnlEntryInfo
            // ══════════════════════════════════════
            this.pnlEntryInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEntryInfo.Height = 76;
            this.pnlEntryInfo.BackColor = System.Drawing.Color.White;
            this.pnlEntryInfo.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlEntryInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblInfoEntryNum, this.lblInfoEntryNumVal,
                this.lblInfoDate, this.lblInfoDateVal,
                this.lblInfoType, this.lblInfoTypeVal,
                this.lblInfoStatus, this.lblInfoStatusVal,
                this.lblInfoDesc, this.lblInfoDescVal,
                this.lblInfoDebit, this.lblInfoDebitVal,
                this.lblInfoCredit, this.lblInfoCreditVal });

            // Row 1
            this.lblInfoEntryNum.Text = "Entry #:";
            this.lblInfoEntryNum.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblInfoEntryNum.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoEntryNum.Location = new System.Drawing.Point(8, 8);
            this.lblInfoEntryNum.Size = new System.Drawing.Size(60, 18);

            this.lblInfoEntryNumVal.Text = "-";
            this.lblInfoEntryNumVal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblInfoEntryNumVal.ForeColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.lblInfoEntryNumVal.Location = new System.Drawing.Point(70, 8);
            this.lblInfoEntryNumVal.Size = new System.Drawing.Size(120, 18);

            this.lblInfoDate.Text = "Date:";
            this.lblInfoDate.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblInfoDate.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoDate.Location = new System.Drawing.Point(200, 8);
            this.lblInfoDate.Size = new System.Drawing.Size(40, 18);

            this.lblInfoDateVal.Text = "-";
            this.lblInfoDateVal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblInfoDateVal.ForeColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.lblInfoDateVal.Location = new System.Drawing.Point(244, 8);
            this.lblInfoDateVal.Size = new System.Drawing.Size(120, 18);

            this.lblInfoType.Text = "Type:";
            this.lblInfoType.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblInfoType.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoType.Location = new System.Drawing.Point(380, 8);
            this.lblInfoType.Size = new System.Drawing.Size(40, 18);

            this.lblInfoTypeVal.Text = "-";
            this.lblInfoTypeVal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblInfoTypeVal.ForeColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.lblInfoTypeVal.Location = new System.Drawing.Point(424, 8);
            this.lblInfoTypeVal.Size = new System.Drawing.Size(120, 18);

            this.lblInfoStatus.Text = "Status:";
            this.lblInfoStatus.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblInfoStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoStatus.Location = new System.Drawing.Point(560, 8);
            this.lblInfoStatus.Size = new System.Drawing.Size(50, 18);

            this.lblInfoStatusVal.Text = "-";
            this.lblInfoStatusVal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblInfoStatusVal.ForeColor = System.Drawing.Color.FromArgb(150, 90, 0);
            this.lblInfoStatusVal.Location = new System.Drawing.Point(614, 8);
            this.lblInfoStatusVal.Size = new System.Drawing.Size(100, 18);

            // Row 2
            this.lblInfoDesc.Text = "Description:";
            this.lblInfoDesc.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblInfoDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoDesc.Location = new System.Drawing.Point(8, 38);
            this.lblInfoDesc.Size = new System.Drawing.Size(80, 18);

            this.lblInfoDescVal.Text = "-";
            this.lblInfoDescVal.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblInfoDescVal.ForeColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.lblInfoDescVal.Location = new System.Drawing.Point(90, 38);
            this.lblInfoDescVal.Size = new System.Drawing.Size(400, 18);

            this.lblInfoDebit.Text = "Total Debit:";
            this.lblInfoDebit.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblInfoDebit.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoDebit.Location = new System.Drawing.Point(510, 38);
            this.lblInfoDebit.Size = new System.Drawing.Size(80, 18);

            this.lblInfoDebitVal.Text = "0.000";
            this.lblInfoDebitVal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblInfoDebitVal.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblInfoDebitVal.Location = new System.Drawing.Point(594, 38);
            this.lblInfoDebitVal.Size = new System.Drawing.Size(100, 18);

            this.lblInfoCredit.Text = "Total Credit:";
            this.lblInfoCredit.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblInfoCredit.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoCredit.Location = new System.Drawing.Point(700, 38);
            this.lblInfoCredit.Size = new System.Drawing.Size(80, 18);

            this.lblInfoCreditVal.Text = "0.000";
            this.lblInfoCreditVal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblInfoCreditVal.ForeColor = System.Drawing.Color.FromArgb(40, 140, 80);
            this.lblInfoCreditVal.Location = new System.Drawing.Point(784, 38);
            this.lblInfoCreditVal.Size = new System.Drawing.Size(100, 18);

            // ══════════════════════════════════════
            // pnlFooter
            // ══════════════════════════════════════
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 52;
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTotalDebitLabel, this.lblTotalDebitVal,
                this.lblTotalCreditLabel, this.lblTotalCreditVal,
                this.lblBalanceLabel, this.lblBalanceVal,
                this.btnPrint, this.btnClose });
            this.pnlFooter.Resize += new System.EventHandler(this.PnlFooter_Resize);

            this.lblTotalDebitLabel.Text = "Debit:";
            this.lblTotalDebitLabel.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblTotalDebitLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalDebitLabel.Location = new System.Drawing.Point(12, 16);
            this.lblTotalDebitLabel.Size = new System.Drawing.Size(46, 20);

            this.lblTotalDebitVal.Text = "0.000";
            this.lblTotalDebitVal.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalDebitVal.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblTotalDebitVal.Location = new System.Drawing.Point(60, 14);
            this.lblTotalDebitVal.Size = new System.Drawing.Size(140, 24);

            this.lblTotalCreditLabel.Text = "Credit:";
            this.lblTotalCreditLabel.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblTotalCreditLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalCreditLabel.Location = new System.Drawing.Point(210, 16);
            this.lblTotalCreditLabel.Size = new System.Drawing.Size(50, 20);

            this.lblTotalCreditVal.Text = "0.000";
            this.lblTotalCreditVal.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalCreditVal.ForeColor = System.Drawing.Color.FromArgb(40, 140, 80);
            this.lblTotalCreditVal.Location = new System.Drawing.Point(262, 14);
            this.lblTotalCreditVal.Size = new System.Drawing.Size(140, 24);

            this.lblBalanceLabel.Text = "Difference:";
            this.lblBalanceLabel.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblBalanceLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblBalanceLabel.Location = new System.Drawing.Point(414, 16);
            this.lblBalanceLabel.Size = new System.Drawing.Size(76, 20);

            this.lblBalanceVal.Text = "0.000";
            this.lblBalanceVal.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblBalanceVal.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblBalanceVal.Location = new System.Drawing.Point(492, 14);
            this.lblBalanceVal.Size = new System.Drawing.Size(200, 24);

            this.btnPrint.Text = "🖨 Print";
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnPrint.Size = new System.Drawing.Size(100, 34);
            this.btnPrint.Location = new System.Drawing.Point(870, 9);
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(80, 140, 60);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            this.btnClose.Text = "Close";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnClose.Size = new System.Drawing.Size(100, 34);
            this.btnClose.Location = new System.Drawing.Point(980, 9);
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(100, 110, 130);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ══════════════════════════════════════
            // dgvDetails
            // ══════════════════════════════════════
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            headerStyle.ForeColor = System.Drawing.Color.White;

            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetails.RowTemplate.Height = 36;
            this.dgvDetails.ColumnHeadersHeight = 42;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvDetails.AlternatingRowsDefaultCellStyle = altRowStyle;
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colLineNum.HeaderText = "#";
            this.colLineNum.Name = "colLineNum";
            this.colLineNum.FillWeight = 5f;

            this.colAccountCode.HeaderText = "Account Code";
            this.colAccountCode.Name = "colAccountCode";
            this.colAccountCode.FillWeight = 14f;

            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.FillWeight = 38f;

            this.colDebit.HeaderText = "Debit";
            this.colDebit.Name = "colDebit";
            this.colDebit.FillWeight = 16f;

            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.FillWeight = 16f;

            this.colDescription.HeaderText = "Note";
            this.colDescription.Name = "colDescription";
            this.colDescription.FillWeight = 22f;

            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colLineNum, this.colAccountCode, this.colAccountName,
                this.colDebit, this.colCredit, this.colDescription });

            // ══════════════════════════════════════
            // Form
            // ══════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.MinimumSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.pnlEntryInfo);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.Name = "FrmJournalEntryDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Journal Entry Details";
            this.Load += new System.EventHandler(this.FrmJournalEntryDetails_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlEntryInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEntryNumberValue;
        private System.Windows.Forms.Label lblDateValue;

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblEntryId;
        private System.Windows.Forms.TextBox txtEntryId;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnSearchByDate;

        private System.Windows.Forms.Panel pnlEntryInfo;
        private System.Windows.Forms.Label lblInfoEntryNum;
        private System.Windows.Forms.Label lblInfoEntryNumVal;
        private System.Windows.Forms.Label lblInfoDate;
        private System.Windows.Forms.Label lblInfoDateVal;
        private System.Windows.Forms.Label lblInfoType;
        private System.Windows.Forms.Label lblInfoTypeVal;
        private System.Windows.Forms.Label lblInfoStatus;
        private System.Windows.Forms.Label lblInfoStatusVal;
        private System.Windows.Forms.Label lblInfoDesc;
        private System.Windows.Forms.Label lblInfoDescVal;
        private System.Windows.Forms.Label lblInfoDebit;
        private System.Windows.Forms.Label lblInfoDebitVal;
        private System.Windows.Forms.Label lblInfoCredit;
        private System.Windows.Forms.Label lblInfoCreditVal;

        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotalDebitLabel;
        private System.Windows.Forms.Label lblTotalDebitVal;
        private System.Windows.Forms.Label lblTotalCreditLabel;
        private System.Windows.Forms.Label lblTotalCreditVal;
        private System.Windows.Forms.Label lblBalanceLabel;
        private System.Windows.Forms.Label lblBalanceVal;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}