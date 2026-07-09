using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Inventory
{
    public partial class FrmCategories : Form
    {
        private List<Category> _categories = new List<Category>();

        public FrmCategories()
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

            dgvCategories.CellFormatting += DgvCategories_CellFormatting;
        }

        // ─────────────────────────────────────────────
        //  CELL FORMATTING
        // ─────────────────────────────────────────────
        private void DgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvCategories.Columns["colEdit"].Index;
            int delCol = dgvCategories.Columns["colDelete"].Index;

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

        // ─────────────────────────────────────────────
        //  LOAD
        // ─────────────────────────────────────────────
        private async void FrmCategories_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvCategories.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvCategories.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadCategories();
        }

        private async System.Threading.Tasks.Task LoadCategories()
        {
            try
            {
                spinner.Start();
                _categories = await ApiHelper.GetAsync<List<Category>>("categories")
                              ?? new List<Category>();
                BindGrid(_categories);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading categories: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        // ─────────────────────────────────────────────
        //  BIND GRID
        // ─────────────────────────────────────────────
        private void BindGrid(List<Category> list)
        {
            dgvCategories.Rows.Clear();
            foreach (var c in list)
            {
                dgvCategories.Rows.Add(
                    c.CategoryID,
                    c.CategoryName,
                    c.CategoryNameAr,
                    c.Description,
                    c.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        // ─────────────────────────────────────────────
        //  GRID CELL CLICK
        // ─────────────────────────────────────────────
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["colID"].Value);
            var cat = _categories.Find(c => c.CategoryID == id);
            if (cat == null) return;

            if (e.ColumnIndex == dgvCategories.Columns["colEdit"].Index)
                OpenEditDialog(cat);
            else if (e.ColumnIndex == dgvCategories.Columns["colDelete"].Index)
                DeleteCategory(cat);
        }

        // ─────────────────────────────────────────────
        //  OPEN EDIT DIALOG
        // ─────────────────────────────────────────────
        private void OpenEditDialog(Category cat = null)
        {
            bool isNew = cat == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Category" : "✏️ Edit Category",
                Size = new Size(440, 460),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(440, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = isNew ? "➕ Add Category" : "✏️ Edit Category", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(400, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 390;

            dlg.Controls.Add(new Label { Text = "Category Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtCategoryName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : cat.CategoryName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtCategoryName); y += 45;

            dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtCategoryNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : cat.CategoryNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtCategoryNameAr); y += 45;

            dlg.Controls.Add(new Label { Text = "Description", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtDescription = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 60), Text = isNew ? "" : cat.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtDescription); y += 75;

            var chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = isNew || cat.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
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
                if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                { MessageHelper.ShowWarning("Please enter category name."); return; }
                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    if (isNew)
                    {
                        var dto = new CreateCategoryDTO { CategoryName = txtCategoryName.Text.Trim(), CategoryNameAr = txtCategoryNameAr.Text.Trim(), Description = txtDescription.Text.Trim(), CreatedBy = SessionManager.UserId };
                        if (await ApiHelper.PostAsync<Category>("categories", dto) != null)
                        { MessageHelper.ShowSuccess("Category added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateCategoryDTO { CategoryID = cat.CategoryID, CategoryName = txtCategoryName.Text.Trim(), CategoryNameAr = txtCategoryNameAr.Text.Trim(), Description = txtDescription.Text.Trim(), IsActive = chkActive.Checked };
                        if (await ApiHelper.PutAsync<Category>("categories/" + cat.CategoryID, dto) != null)
                        { MessageHelper.ShowSuccess("Category updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadCategories();
        }

        // ─────────────────────────────────────────────
        //  DELETE
        // ─────────────────────────────────────────────
        private async void DeleteCategory(Category cat)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{cat.CategoryName}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("categories/" + cat.CategoryID);
                MessageHelper.ShowSuccess("Category deleted successfully.");
                await LoadCategories();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        // ─────────────────────────────────────────────
        //  SEARCH
        // ─────────────────────────────────────────────
        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_categories); return; }
            string s = text.ToLower();
            var filtered = new List<Category>();
            foreach (var c in _categories)
                if (c.CategoryName.ToLower().Contains(s) ||
                   (c.CategoryNameAr != null && c.CategoryNameAr.ToLower().Contains(s)) ||
                   (c.Description != null && c.Description.ToLower().Contains(s)))
                    filtered.Add(c);
            BindGrid(filtered);
        }

        // ─────────────────────────────────────────────
        //  TOP BUTTONS
        // ─────────────────────────────────────────────
        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadCategories();
        }
    }
}