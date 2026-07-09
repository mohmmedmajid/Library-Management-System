using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Accounting;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Accounting
{
    public partial class FrmCostCenters : Form
    {
        private List<CostCenter> _costCenters = new List<CostCenter>();

        public FrmCostCenters()
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

            dgvCostCenters.CellFormatting += DgvCostCenters_CellFormatting;
        }


        private void DgvCostCenters_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvCostCenters.Columns["colEdit"].Index;
            int delCol = dgvCostCenters.Columns["colDelete"].Index;

            if (e.ColumnIndex == editCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == delCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private async void FrmCostCenters_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvCostCenters.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvCostCenters.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadCostCenters();
        }

        private async System.Threading.Tasks.Task LoadCostCenters()
        {
            try
            {
                spinner.Start();
                _costCenters = await ApiHelper.GetAsync<List<CostCenter>>("costcenters")
                               ?? new List<CostCenter>();
                BindGrid(_costCenters);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading cost centers: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }


        private void BindGrid(List<CostCenter> list)
        {
            dgvCostCenters.Rows.Clear();
            foreach (var c in list)
            {
                dgvCostCenters.Rows.Add(
                    c.CostCenterID,
                    c.CostCenterCode,
                    c.CostCenterName,
                    c.CostCenterNameAr,
                    c.Description,
                    c.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

 
        private void dgvCostCenters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvCostCenters.Rows[e.RowIndex].Cells["colID"].Value);
            var cc = _costCenters.Find(x => x.CostCenterID == id);
            if (cc == null) return;

            if (e.ColumnIndex == dgvCostCenters.Columns["colEdit"].Index)
                OpenEditDialog(cc);
            else if (e.ColumnIndex == dgvCostCenters.Columns["colDelete"].Index)
                DeleteCostCenter(cc);
        }

 
        private void OpenEditDialog(CostCenter cc = null)
        {
            bool isNew = cc == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Cost Center" : "✏️ Edit Cost Center",
                Size = new Size(440, 500),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(440, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = isNew ? "➕ Add Cost Center" : "✏️ Edit Cost Center", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(400, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 390;

            dlg.Controls.Add(new Label { Text = "Cost Center Code *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtCode = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : cc.CostCenterCode, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtCode); y += 45;

            dlg.Controls.Add(new Label { Text = "Cost Center Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : cc.CostCenterName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtName); y += 45;

            dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : cc.CostCenterNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtNameAr); y += 45;

            dlg.Controls.Add(new Label { Text = "Description", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtDescription = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 60), Text = isNew ? "" : cc.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtDescription); y += 75;

            var chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = isNew || cc.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkActive); y += 42;

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(185, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 200, y), Size = new Size(185, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                { MessageHelper.ShowWarning("Please enter cost center code."); return; }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                { MessageHelper.ShowWarning("Please enter cost center name."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    if (isNew)
                    {
                        var dto = new CreateCostCenterDTO
                        {
                            CostCenterCode = txtCode.Text.Trim(),
                            CostCenterName = txtName.Text.Trim(),
                            CostCenterNameAr = txtNameAr.Text.Trim(),
                            Description = txtDescription.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<CostCenter>("costcenters", dto) != null)
                        { MessageHelper.ShowSuccess("Cost center added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateCostCenterDTO
                        {
                            CostCenterID = cc.CostCenterID,
                            CostCenterCode = txtCode.Text.Trim(),
                            CostCenterName = txtName.Text.Trim(),
                            CostCenterNameAr = txtNameAr.Text.Trim(),
                            Description = txtDescription.Text.Trim(),
                            IsActive = chkActive.Checked
                        };
                        if (await ApiHelper.PutAsync<CostCenter>("costcenters/" + cc.CostCenterID, dto) != null)
                        { MessageHelper.ShowSuccess("Cost center updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadCostCenters();
        }


        private async void DeleteCostCenter(CostCenter cc)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{cc.CostCenterName}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("costcenters/" + cc.CostCenterID);
                MessageHelper.ShowSuccess("Cost center deleted successfully.");
                await LoadCostCenters();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }


        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_costCenters); return; }
            string s = text.ToLower();
            var filtered = new List<CostCenter>();
            foreach (var c in _costCenters)
                if (c.CostCenterCode.ToLower().Contains(s) ||
                    c.CostCenterName.ToLower().Contains(s) ||
                   (c.CostCenterNameAr != null && c.CostCenterNameAr.ToLower().Contains(s)) ||
                   (c.Description != null && c.Description.ToLower().Contains(s)))
                    filtered.Add(c);
            BindGrid(filtered);
        }


        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadCostCenters();
        }
    }
}