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
    public partial class FrmTaxTypes : Form
    {
        private List<TaxType> _taxTypes = new List<TaxType>();

        public FrmTaxTypes()
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

            dgvTaxTypes.CellFormatting += DgvTaxTypes_CellFormatting;
            dgvTaxTypes.CellClick += DgvTaxTypes_CellClick;
        }

        private void DgvTaxTypes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvTaxTypes.Columns["colEdit"].Index;
            int delCol = dgvTaxTypes.Columns["colDelete"].Index;

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

        private async void FrmTaxTypes_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvTaxTypes.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvTaxTypes.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadTaxTypes();
        }

        private async System.Threading.Tasks.Task LoadTaxTypes()
        {
            try
            {
                spinner.Start();
                _taxTypes = await ApiHelper.GetAsync<List<TaxType>>("taxtypes")
                            ?? new List<TaxType>();
                BindGrid(_taxTypes);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading tax types: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<TaxType> list)
        {
            dgvTaxTypes.Rows.Clear();
            foreach (var t in list)
            {
                dgvTaxTypes.Rows.Add(
                    t.TaxTypeID,
                    t.TaxCode,
                    t.TaxName,
                    t.TaxNameAr,
                    t.TaxRate.ToString("N2") + " %",
                    t.TaxCategory,
                    t.Description,
                    t.EffectiveFrom.ToString("yyyy-MM-dd"),
                    t.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void DgvTaxTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvTaxTypes.Rows[e.RowIndex].Cells["colID"].Value);
            var tax = _taxTypes.Find(t => t.TaxTypeID == id);
            if (tax == null) return;

            if (e.ColumnIndex == dgvTaxTypes.Columns["colEdit"].Index)
                OpenEditDialog(tax);
            else if (e.ColumnIndex == dgvTaxTypes.Columns["colDelete"].Index)
                DeleteTaxType(tax);
        }

        private void OpenEditDialog(TaxType tax = null)
        {
            bool isNew = tax == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Tax Type" : "✏️ Edit Tax Type",
                Size = new Size(500, 530),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(500, 50),
                BackColor = Color.FromArgb(22, 32, 50)
            };
            pnlHeader.Controls.Add(new Label
            {
                Text = isNew ? "➕ Add Tax Type" : "✏️ Edit Tax Type",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(460, 28)
            });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 450;

            Label MakeLabel(string text, int ly) => new Label
            {
                Text = text,
                Location = new Point(lx, ly),
                Size = new Size(fw, 22),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            };

            TextBox MakeTextBox(int ty, string val, bool rtl = false) => new TextBox
            {
                Location = new Point(fx, ty),
                Size = new Size(fw, 30),
                Text = val,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f),
                RightToLeft = rtl ? RightToLeft.Yes : RightToLeft.No
            };

            dlg.Controls.Add(MakeLabel("Tax Code *", y)); y += 25;
            var txtCode = MakeTextBox(y, isNew ? "" : tax.TaxCode);
            dlg.Controls.Add(txtCode); y += 45;

            dlg.Controls.Add(MakeLabel("Tax Name *", y)); y += 25;
            var txtName = MakeTextBox(y, isNew ? "" : tax.TaxName);
            dlg.Controls.Add(txtName); y += 45;

            dlg.Controls.Add(MakeLabel("Arabic Name", y)); y += 25;
            var txtNameAr = MakeTextBox(y, isNew ? "" : tax.TaxNameAr, rtl: true);
            dlg.Controls.Add(txtNameAr); y += 45;

            dlg.Controls.Add(new Label { Text = "Rate (%) *", Location = new Point(lx, y), Size = new Size(210, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Category *", Location = new Point(245, y), Size = new Size(210, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtRate = new TextBox { Location = new Point(fx, y), Size = new Size(210, 30), Text = isNew ? "" : tax.TaxRate.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            var cmbCategory = new ComboBox { Location = new Point(245, y), Size = new Size(225, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10f) };
            cmbCategory.Items.AddRange(new object[] { "Sales", "Purchase", "Withholding", "Income" });
            cmbCategory.SelectedItem = isNew ? "Sales" : tax.TaxCategory;
            if (cmbCategory.SelectedIndex < 0) cmbCategory.SelectedIndex = 0;
            dlg.Controls.Add(txtRate);
            dlg.Controls.Add(cmbCategory);
            y += 45;

            dlg.Controls.Add(MakeLabel("Effective From *", y)); y += 25;
            var dtpEff = new DateTimePicker { Location = new Point(fx, y), Size = new Size(fw, 30), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10f), Value = isNew ? DateTime.Today : tax.EffectiveFrom };
            dlg.Controls.Add(dtpEff); y += 45;

            dlg.Controls.Add(MakeLabel("Description", y)); y += 25;
            var txtDesc = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 55), Text = isNew ? "" : tax.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtDesc); y += 70;

            CheckBox chkActive = null;
            if (!isNew)
            {
                chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = tax.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
                dlg.Controls.Add(chkActive);
                y += 42;
            }

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(215, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 235, y), Size = new Size(215, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            dlg.Height = y + 110;

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                { MessageHelper.ShowWarning("Please enter tax code."); return; }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                { MessageHelper.ShowWarning("Please enter tax name."); return; }
                if (!decimal.TryParse(txtRate.Text, out decimal rate) || rate < 0)
                { MessageHelper.ShowWarning("Please enter a valid rate."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    if (isNew)
                    {
                        var dto = new CreateTaxTypeDTO
                        {
                            TaxCode = txtCode.Text.Trim(),
                            TaxName = txtName.Text.Trim(),
                            TaxNameAr = txtNameAr.Text.Trim(),
                            TaxRate = rate,
                            TaxCategory = cmbCategory.SelectedItem.ToString(),
                            Description = txtDesc.Text.Trim(),
                            EffectiveFrom = dtpEff.Value,
                            CreatedBy = SessionManager.UserId
                        };
                        await ApiHelper.PostAsync<object>("taxtypes", dto);
                        MessageHelper.ShowSuccess("Tax type added!");
                    }
                    else
                    {
                        var dto = new UpdateTaxTypeDTO
                        {
                            TaxTypeID = tax.TaxTypeID,
                            TaxCode = txtCode.Text.Trim(),
                            TaxName = txtName.Text.Trim(),
                            TaxNameAr = txtNameAr.Text.Trim(),
                            TaxRate = rate,
                            TaxCategory = cmbCategory.SelectedItem.ToString(),
                            Description = txtDesc.Text.Trim(),
                            EffectiveFrom = dtpEff.Value,
                            IsActive = chkActive?.Checked ?? true
                        };
                        await ApiHelper.PutAsync<object>("taxtypes/" + tax.TaxTypeID, dto);
                        MessageHelper.ShowSuccess("Tax type updated!");
                    }
                    dlg.DialogResult = DialogResult.OK;
                    dlg.Close();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Error: " + ex.Message);
                    btnSave.Enabled = true;
                    btnSave.Text = "💾 Save";
                }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadTaxTypes();
        }

        private async void DeleteTaxType(TaxType tax)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{tax.TaxName}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("taxtypes/" + tax.TaxTypeID);
                MessageHelper.ShowSuccess("Tax type deleted successfully.");
                await LoadTaxTypes();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_taxTypes); return; }
            string s = text.ToLower();
            var filtered = new List<TaxType>();
            foreach (var t in _taxTypes)
                if (t.TaxCode.ToLower().Contains(s) ||
                    t.TaxName.ToLower().Contains(s) ||
                   (t.TaxNameAr != null && t.TaxNameAr.ToLower().Contains(s)) ||
                    t.TaxCategory.ToLower().Contains(s))
                    filtered.Add(t);
            BindGrid(filtered);
        }

        private void BtnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadTaxTypes();
        }
    }
}