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
    public partial class FrmFixedAssets : Form
    {
        private List<FixedAsset> _assets = new List<FixedAsset>();
        private List<FixedAssetCategory> _categories = new List<FixedAssetCategory>();

        public FrmFixedAssets()
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

            dgvAssets.CellFormatting += DgvAssets_CellFormatting;
        }

        private void DgvAssets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!dgvAssets.Columns.Contains("colEdit") || !dgvAssets.Columns.Contains("colDispose")) return;

            int editCol = dgvAssets.Columns["colEdit"].Index;
            int disposeCol = dgvAssets.Columns["colDispose"].Index;

            var row = dgvAssets.Rows[e.RowIndex];
            string editText = row.Cells["colEdit"].Value?.ToString() ?? "";
            string disposeText = row.Cells["colDispose"].Value?.ToString() ?? "";

            if (e.ColumnIndex == editCol)
            {
                if (!string.IsNullOrEmpty(editText))
                {
                    e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.ForeColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(240, 240, 240);
                }
            }
            else if (e.ColumnIndex == disposeCol)
            {
                if (!string.IsNullOrEmpty(disposeText))
                {
                    e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.ForeColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(240, 240, 240);
                }
            }
        }

        private async void FrmFixedAssets_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvAssets.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvAssets.Columns["colDispose"].Visible = SessionManager.IsAdmin;
            await LoadCategories();
            await LoadAssets();
        }

        private async System.Threading.Tasks.Task LoadCategories()
        {
            try
            {
                _categories = await ApiHelper.GetAsync<List<FixedAssetCategory>>("FixedAssetCategories")
                              ?? new List<FixedAssetCategory>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading categories: " + ex.Message);
            }
        }

        private async System.Threading.Tasks.Task LoadAssets()
        {
            try
            {
                spinner.Start();
                _assets = await ApiHelper.GetAsync<List<FixedAsset>>("FixedAssets")
                          ?? new List<FixedAsset>();
                BindGrid(_assets);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading fixed assets: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<FixedAsset> list)
        {
            dgvAssets.Rows.Clear();
            foreach (var a in list)
            {
                string editVal = a.Status != "Disposed" ? "✏️ Edit" : "";
                string disposeVal = a.Status != "Disposed" ? "🗑 Dispose" : "";

                int rowIndex = dgvAssets.Rows.Add(
                    a.AssetID,
                    a.AssetCode,
                    a.AssetName,
                    a.CategoryName,
                    a.PurchaseDate.ToShortDateString(),
                    a.PurchasePrice.ToString("N2"),
                    a.AccumulatedDepreciation.ToString("N2"),
                    a.BookValue.ToString("N2"),
                    a.Status,
                    a.Location,
                    editVal,
                    disposeVal
                );

                var row = dgvAssets.Rows[rowIndex];
                row.Cells["colEdit"].Value = editVal;
                row.Cells["colDispose"].Value = disposeVal;

                if (a.Status == "Disposed")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(245, 230, 230);
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvAssets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvAssets.Rows[e.RowIndex].Cells["colID"].Value);
            var asset = _assets.Find(a => a.AssetID == id);
            if (asset == null) return;

            if (e.ColumnIndex == dgvAssets.Columns["colEdit"].Index)
                OpenEditDialog(asset);
            else if (e.ColumnIndex == dgvAssets.Columns["colDispose"].Index)
                OpenDisposeDialog(asset);
        }

        private void OpenEditDialog(FixedAsset asset = null)
        {
            bool isNew = asset == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Fixed Asset" : "✏️ Edit Fixed Asset",
                Size = new Size(460, 750),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(460, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = isNew ? "➕ Add Fixed Asset" : "✏️ Edit Fixed Asset", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(420, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 410;

            dlg.Controls.Add(new Label { Text = "Asset Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtAssetName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : asset.AssetName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtAssetName); y += 42;

            dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtAssetNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : asset.AssetNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtAssetNameAr); y += 42;

            dlg.Controls.Add(new Label { Text = "Category *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbCategory = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList, DataSource = _categories, DisplayMember = "CategoryName", ValueMember = "CategoryID" };
            if (!isNew) cmbCategory.SelectedValue = asset.CategoryID; else cmbCategory.SelectedIndex = -1;
            dlg.Controls.Add(cmbCategory); y += 42;

            DateTimePicker dtpPurchaseDate = null;
            TextBox txtPurchasePrice = null;
            TextBox txtSalvageValue = null;

            if (isNew)
            {
                dlg.Controls.Add(new Label { Text = "Purchase Date *", Location = new Point(lx, y), Size = new Size(195, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                dlg.Controls.Add(new Label { Text = "Purchase Price *", Location = new Point(lx + 215, y), Size = new Size(195, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                y += 25;
                dtpPurchaseDate = new DateTimePicker { Location = new Point(fx, y), Size = new Size(195, 30), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10f) };
                txtPurchasePrice = new TextBox { Location = new Point(fx + 215, y), Size = new Size(195, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
                dlg.Controls.Add(dtpPurchaseDate);
                dlg.Controls.Add(txtPurchasePrice);
                y += 42;

                dlg.Controls.Add(new Label { Text = "Salvage Value", Location = new Point(lx, y), Size = new Size(195, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                y += 25;
                txtSalvageValue = new TextBox { Location = new Point(fx, y), Size = new Size(195, 30), Text = "0", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
                dlg.Controls.Add(txtSalvageValue);
                y += 42;
            }

            dlg.Controls.Add(new Label { Text = "Location", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtLocation = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : asset.Location, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtLocation); y += 42;

            dlg.Controls.Add(new Label { Text = "Serial Number", Location = new Point(lx, y), Size = new Size(195, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Manufacturer", Location = new Point(lx + 215, y), Size = new Size(195, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtSerialNumber = new TextBox { Location = new Point(fx, y), Size = new Size(195, 30), Text = isNew ? "" : asset.SerialNumber, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            var txtManufacturer = new TextBox { Location = new Point(fx + 215, y), Size = new Size(195, 30), Text = isNew ? "" : asset.Manufacturer, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtSerialNumber); dlg.Controls.Add(txtManufacturer); y += 42;

            dlg.Controls.Add(new Label { Text = "Model", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtModel = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : asset.Model, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtModel); y += 42;

            dlg.Controls.Add(new Label { Text = "Notes", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtNotes = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 60), Text = isNew ? "" : asset.Notes, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtNotes); y += 75;

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(195, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 215, y), Size = new Size(195, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtAssetName.Text))
                { MessageHelper.ShowWarning("Please enter asset name."); return; }
                if (cmbCategory.SelectedValue == null)
                { MessageHelper.ShowWarning("Please select a category."); return; }
                if (isNew && !ValidationHelper.IsValidPrice(txtPurchasePrice.Text))
                { MessageHelper.ShowWarning("Please enter a valid purchase price."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    if (isNew)
                    {
                        var dto = new CreateFixedAssetDTO
                        {
                            AssetName = txtAssetName.Text.Trim(),
                            AssetNameAr = string.IsNullOrWhiteSpace(txtAssetNameAr.Text) ? txtAssetName.Text.Trim() : txtAssetNameAr.Text.Trim(),
                            CategoryID = (int)cmbCategory.SelectedValue,
                            PurchaseDate = dtpPurchaseDate.Value,
                            PurchasePrice = decimal.Parse(txtPurchasePrice.Text),
                            SalvageValue = ValidationHelper.IsValidPrice(txtSalvageValue.Text) ? decimal.Parse(txtSalvageValue.Text) : 0,
                            Location = txtLocation.Text.Trim(),
                            ResponsibleEmployee = null,
                            SerialNumber = txtSerialNumber.Text.Trim(),
                            Manufacturer = txtManufacturer.Text.Trim(),
                            Model = txtModel.Text.Trim(),
                            WarrantyExpiry = DateTime.Now.AddYears(1),
                            Notes = txtNotes.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<FixedAsset>("FixedAssets", dto) != null)
                        { MessageHelper.ShowSuccess("Asset added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateFixedAssetDTO
                        {
                            AssetID = asset.AssetID,
                            AssetName = txtAssetName.Text.Trim(),
                            AssetNameAr = string.IsNullOrWhiteSpace(txtAssetNameAr.Text) ? txtAssetName.Text.Trim() : txtAssetNameAr.Text.Trim(),
                            CategoryID = (int)cmbCategory.SelectedValue,
                            Location = txtLocation.Text.Trim(),
                            Status = asset.Status,
                            SerialNumber = txtSerialNumber.Text.Trim(),
                            Manufacturer = txtManufacturer.Text.Trim(),
                            Model = txtModel.Text.Trim(),
                            Notes = txtNotes.Text.Trim()
                        };
                        if (await ApiHelper.PutAsync<FixedAsset>("FixedAssets/" + asset.AssetID, dto) != null)
                        { MessageHelper.ShowSuccess("Asset updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            dlg.Height = y + 110;

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadAssets();
        }

        private void OpenDisposeDialog(FixedAsset asset)
        {
            var dlg = new Form
            {
                Text = "🗑 Dispose Asset",
                Size = new Size(400, 320),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(400, 50), BackColor = Color.FromArgb(200, 50, 50) };
            pnlHeader.Controls.Add(new Label { Text = "🗑 Dispose: " + asset.AssetName, Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(370, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int fx = 20; int fw = 350;

            dlg.Controls.Add(new Label { Text = "Book Value: " + asset.BookValue.ToString("N2"), Location = new Point(fx, y), Size = new Size(fw, 24), Font = new Font("Segoe UI", 10f, FontStyle.Bold) });
            y += 35;

            dlg.Controls.Add(new Label { Text = "Disposal Date *", Location = new Point(fx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var dtpDisposalDate = new DateTimePicker { Location = new Point(fx, y), Size = new Size(fw, 30), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(dtpDisposalDate); y += 42;

            dlg.Controls.Add(new Label { Text = "Disposal Value *", Location = new Point(fx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtDisposalValue = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtDisposalValue); y += 50;

            var btnSave = new Button { Text = "🗑 Confirm Dispose", Location = new Point(fx, y), Size = new Size(350, 42), BackColor = Color.FromArgb(200, 50, 50), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            btnSave.Click += async (s, ev) =>
            {
                if (!ValidationHelper.IsValidPrice(txtDisposalValue.Text))
                { MessageHelper.ShowWarning("Please enter a valid disposal value."); return; }

                if (!MessageHelper.ShowConfirm("Are you sure you want to dispose this asset?\nThis action cannot be undone."))
                    return;

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Processing...";
                    var dto = new DisposeFixedAssetDTO
                    {
                        AssetID = asset.AssetID,
                        DisposalDate = dtpDisposalDate.Value,
                        DisposalValue = decimal.Parse(txtDisposalValue.Text)
                    };
                    await ApiHelper.PutAsync<object>("FixedAssets/" + asset.AssetID + "/dispose", dto);
                    MessageHelper.ShowSuccess("Asset disposed successfully.");
                    dlg.DialogResult = DialogResult.OK; dlg.Close();
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "🗑 Confirm Dispose"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadAssets();
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_assets); return; }
            string s = text.ToLower();
            var filtered = new List<FixedAsset>();
            foreach (var a in _assets)
                if (a.AssetCode.ToLower().Contains(s) ||
                    a.AssetName.ToLower().Contains(s) ||
                   (a.CategoryName != null && a.CategoryName.ToLower().Contains(s)) ||
                   (a.SerialNumber != null && a.SerialNumber.ToLower().Contains(s)))
                    filtered.Add(a);
            BindGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadAssets();
        }
    }
}