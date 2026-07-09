using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Advanced;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Advanced
{
    public partial class FrmAssetDepreciation : Form
    {
        private List<AssetDepreciation> _depreciations = new List<AssetDepreciation>();
        private List<FixedAsset> _assets = new List<FixedAsset>();

        public FrmAssetDepreciation()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(440, 8);
            spinner.Size = new Size(50, 50);
            pnlTop.Controls.Add(spinner);

            searchBox = new SearchBoxControl();
            searchBox.Location = new Point(510, 15);
            searchBox.Size = new Size(250, 35);
            searchBox.OnSearch += SearchBox_OnSearch;
            pnlTop.Controls.Add(searchBox);

            dgvDepreciations.CellFormatting += DgvDepreciations_CellFormatting;
        }

        private void DgvDepreciations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int viewCol = dgvDepreciations.Columns["colView"].Index;
            int postCol = dgvDepreciations.Columns["colPost"].Index;

            if (e.ColumnIndex == viewCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == postCol)
            {
                var row = dgvDepreciations.Rows[e.RowIndex];
                string status = row.Cells["colStatus"].Value?.ToString() ?? "";
                if (status == "Posted")
                {
                    e.CellStyle.BackColor = Color.FromArgb(150, 150, 150);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(150, 150, 150);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private async void FrmAssetDepreciation_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            btnProcessMonthly.Visible = SessionManager.IsAdmin;
            dgvDepreciations.Columns["colPost"].Visible = SessionManager.IsAdmin;

            await LoadAssets();
            await LoadDepreciations();
        }

        private async System.Threading.Tasks.Task LoadAssets()
        {
            try
            {
                _assets = await ApiHelper.GetAsync<List<FixedAsset>>("fixedassets")
                          ?? new List<FixedAsset>();
                cmbAssetFilter.Items.Clear();
                cmbAssetFilter.Items.Add("All Assets");
                foreach (var a in _assets)
                    cmbAssetFilter.Items.Add(a.AssetName + " (" + a.AssetCode + ")");
                cmbAssetFilter.SelectedIndex = 0;
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadDepreciations()
        {
            try
            {
                spinner.Start();

                int year = (int)nudYear.Value;
                int month = (int)nudMonth.Value;

                string endpoint = "assetdepreciations";
                var filters = new List<string>();

                if (year >= 2000)
                    filters.Add("FiscalYear=" + year);

                if (month >= 1 && month <= 12)
                    filters.Add("FiscalMonth=" + month);

                if (cmbStatusFilter.SelectedIndex > 0)
                    filters.Add("Status=" + cmbStatusFilter.SelectedItem.ToString());

                if (filters.Count > 0)
                    endpoint += "?" + string.Join("&", filters);

                _depreciations = await ApiHelper.GetAsync<List<AssetDepreciation>>(endpoint)
                                 ?? new List<AssetDepreciation>();
                BindGrid(_depreciations);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading depreciations: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<AssetDepreciation> list)
        {
            dgvDepreciations.Rows.Clear();
            foreach (var d in list)
            {
                int rowIndex = dgvDepreciations.Rows.Add(
                    d.DepreciationID,
                    d.AssetCode,
                    d.AssetName,
                    d.DepreciationDate.ToString("yyyy-MM-dd"),
                    d.FiscalYear + "/" + d.FiscalMonth.ToString("D2"),
                    d.DepreciationAmount.ToString("N2"),
                    d.AccumulatedDepreciation.ToString("N2"),
                    d.BookValue.ToString("N2"),
                    d.Status,
                    "👁 View",
                    d.Status == "Posted" ? "✓ Posted" : "✔ Post"
                );

                var row = dgvDepreciations.Rows[rowIndex];
                row.Cells["colView"].Value = "👁 View";
                row.Cells["colPost"].Value = d.Status == "Posted" ? "✓ Posted" : "✔ Post";
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void DgvDepreciations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvDepreciations.Rows[e.RowIndex].Cells["colID"].Value);
            var dep = _depreciations.Find(d => d.DepreciationID == id);
            if (dep == null) return;

            if (e.ColumnIndex == dgvDepreciations.Columns["colView"].Index)
                OpenViewDialog(dep);
            else if (e.ColumnIndex == dgvDepreciations.Columns["colPost"].Index && SessionManager.IsAdmin)
            {
                if (dep.Status != "Posted")
                    PostDepreciation(dep);
            }
        }

        private void OpenViewDialog(AssetDepreciation dep)
        {
            var dlg = new Form
            {
                Text = "📋 Depreciation Details",
                Size = new Size(500, 560),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(500, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = "📋 Depreciation Details", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(460, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int vx = 220; int lw = 190; int vw = 260;

            Action<string, string> addRow = (label, value) =>
            {
                dlg.Controls.Add(new Label { Text = label, Location = new Point(lx, y), Size = new Size(lw, 26), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(80, 80, 80) });
                dlg.Controls.Add(new Label { Text = value, Location = new Point(vx, y), Size = new Size(vw, 26), Font = new Font("Segoe UI", 9f), ForeColor = Color.FromArgb(30, 30, 30) });
                y += 34;
            };

            addRow("Asset Code:", dep.AssetCode);
            addRow("Asset Name:", dep.AssetName);
            addRow("Depreciation Date:", dep.DepreciationDate.ToString("yyyy-MM-dd"));
            addRow("Period:", dep.DepreciationPeriod);
            addRow("Fiscal Year:", dep.FiscalYear.ToString());
            addRow("Fiscal Month:", dep.FiscalMonth.ToString());
            addRow("Depreciation Amount:", dep.DepreciationAmount.ToString("N2"));
            addRow("Accumulated Depreciation:", dep.AccumulatedDepreciation.ToString("N2"));
            addRow("Book Value:", dep.BookValue.ToString("N2"));
            addRow("Status:", dep.Status);
            if (!string.IsNullOrEmpty(dep.JournalEntryNumber))
                addRow("Journal Entry:", dep.JournalEntryNumber);

            var btnClose = new Button
            {
                Text = "✕ Close",
                Location = new Point(180, y + 10),
                Size = new Size(140, 40),
                BackColor = Color.FromArgb(100, 100, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnClose);

            dlg.ShowDialog(this);
        }

        private async void PostDepreciation(AssetDepreciation dep)
        {
            if (!MessageHelper.ShowConfirm($"Post depreciation for \"{dep.AssetName}\"?\nPeriod: {dep.FiscalYear}/{dep.FiscalMonth:D2}"))
                return;
            try
            {
                spinner.Start();
                var dto = new PostAssetDepreciationDTO
                {
                    DepreciationID = dep.DepreciationID,
                    PostedBy = SessionManager.UserId
                };
                await ApiHelper.PutAsync<object>("assetdepreciations/" + dep.DepreciationID + "/post", dto);
                MessageHelper.ShowSuccess("Depreciation posted successfully.");
                await LoadDepreciations();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void OpenNewDepreciationDialog()
        {
            var dlg = new Form
            {
                Text = "➕ Add Depreciation",
                Size = new Size(460, 400),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(460, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = "➕ Add Depreciation", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(420, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 410;

            dlg.Controls.Add(new Label { Text = "Asset *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbAsset = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10f) };
            foreach (var a in _assets)
                cmbAsset.Items.Add(new { Text = a.AssetName + " (" + a.AssetCode + ")", Value = a.AssetID });
            cmbAsset.DisplayMember = "Text";
            dlg.Controls.Add(cmbAsset); y += 45;

            dlg.Controls.Add(new Label { Text = "Depreciation Date *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var dtpDate = new DateTimePicker { Location = new Point(fx, y), Size = new Size(fw, 30), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10f), Value = DateTime.Today };
            dlg.Controls.Add(dtpDate); y += 45;

            dlg.Controls.Add(new Label { Text = "Fiscal Year *", Location = new Point(lx, y), Size = new Size(200, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Fiscal Month *", Location = new Point(225, y), Size = new Size(200, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var nudFYear = new NumericUpDown { Location = new Point(fx, y), Size = new Size(195, 30), Minimum = 2000, Maximum = 2100, Value = DateTime.Today.Year, Font = new Font("Segoe UI", 10f) };
            var nudFMonth = new NumericUpDown { Location = new Point(225, y), Size = new Size(195, 30), Minimum = 1, Maximum = 12, Value = DateTime.Today.Month, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(nudFYear);
            dlg.Controls.Add(nudFMonth); y += 50;

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(195, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 215, y), Size = new Size(195, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (cmbAsset.SelectedItem == null)
                { MessageHelper.ShowWarning("Please select an asset."); return; }
                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    dynamic selected = cmbAsset.SelectedItem;
                    var dto = new CreateAssetDepreciationDTO
                    {
                        AssetID = selected.Value,
                        DepreciationDate = dtpDate.Value,
                        FiscalYear = (int)nudFYear.Value,
                        FiscalMonth = (int)nudFMonth.Value,
                        DepreciationPeriod = "Monthly",
                        CreatedBy = SessionManager.UserId
                    };
                    await ApiHelper.PostAsync<object>("assetdepreciations", dto);
                    MessageHelper.ShowSuccess("Depreciation record created!");
                    dlg.DialogResult = DialogResult.OK;
                    dlg.Close();
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadDepreciations();
        }

        private void OpenProcessMonthlyDialog()
        {
            var dlg = new Form
            {
                Text = "⚙️ Process Monthly Depreciation",
                Size = new Size(400, 280),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(400, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = "⚙️ Process Monthly Depreciation", Font = new Font("Segoe UI", 11f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(370, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20;

            dlg.Controls.Add(new Label { Text = "Fiscal Year *", Location = new Point(lx, y), Size = new Size(160, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Fiscal Month *", Location = new Point(195, y), Size = new Size(160, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var nudYear2 = new NumericUpDown { Location = new Point(fx, y), Size = new Size(160, 30), Minimum = 2000, Maximum = 2100, Value = DateTime.Today.Year, Font = new Font("Segoe UI", 10f) };
            var nudMonth2 = new NumericUpDown { Location = new Point(195, y), Size = new Size(160, 30), Minimum = 1, Maximum = 12, Value = DateTime.Today.Month, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(nudYear2);
            dlg.Controls.Add(nudMonth2); y += 55;

            var btnProcess = new Button { Text = "⚙️ Process", Location = new Point(fx, y), Size = new Size(165, 42), BackColor = Color.FromArgb(180, 100, 20), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnProcess.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnProcess);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(200, y), Size = new Size(165, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnProcess.Click += async (s, ev) =>
            {
                if (!MessageHelper.ShowConfirm($"Process monthly depreciation for {nudYear2.Value}/{((int)nudMonth2.Value):D2}?\nThis will create depreciation records for all active assets."))
                    return;
                try
                {
                    btnProcess.Enabled = false; btnProcess.Text = "Processing...";
                    var dto = new ProcessMonthlyDepreciationDTO
                    {
                        FiscalYear = (int)nudYear2.Value,
                        FiscalMonth = (int)nudMonth2.Value,
                        CreatedBy = SessionManager.UserId
                    };
                    await ApiHelper.PostAsync<object>("assetdepreciations/process-monthly", dto);
                    MessageHelper.ShowSuccess("Monthly depreciation processed successfully!");
                    dlg.DialogResult = DialogResult.OK;
                    dlg.Close();
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnProcess.Enabled = true; btnProcess.Text = "⚙️ Process"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadDepreciations();
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_depreciations); return; }
            string s = text.ToLower();
            var filtered = new List<AssetDepreciation>();
            foreach (var d in _depreciations)
                if (d.AssetName.ToLower().Contains(s) ||
                    d.AssetCode.ToLower().Contains(s) ||
                    d.DepreciationPeriod.ToLower().Contains(s))
                    filtered.Add(d);
            BindGrid(filtered);
        }

        private void BtnNew_Click(object sender, EventArgs e) => OpenNewDepreciationDialog();
        private void BtnProcessMonthly_Click(object sender, EventArgs e) => OpenProcessMonthlyDialog();

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadDepreciations();
        }

        private async void BtnFilter_Click(object sender, EventArgs e)
        {
            await LoadDepreciations();
        }
    }
}