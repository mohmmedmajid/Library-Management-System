using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmExpenseCategories : Form
    {
        private List<ExpenseCategory> _allCategories = new List<ExpenseCategory>();
        private int _selectedCategoryId = 0;

        public FrmExpenseCategories()
        {
            InitializeComponent();
            dgvCategories.CellFormatting += dgvCategories_CellFormatting;
        }

        private async void FrmExpenseCategories_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string url = "ExpenseCategories";
                if (cmbFilter.SelectedIndex == 1) url += "?isActive=true";
                else if (cmbFilter.SelectedIndex == 2) url += "?isActive=false";

                _allCategories = await ApiHelper.GetAsync<List<ExpenseCategory>>(url) ?? new List<ExpenseCategory>();

                ApplySearchFilter();
                UpdateStats();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading categories: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ApplySearchFilter()
        {
            string search = txtSearch.Text.Trim().ToLower();

            var filtered = string.IsNullOrEmpty(search)
                ? _allCategories
                : _allCategories.Where(c =>
                    c.CategoryName.ToLower().Contains(search) ||
                    c.CategoryNameAr.ToLower().Contains(search) ||
                    c.Description.ToLower().Contains(search)).ToList();

            dgvCategories.DataSource = null;
            dgvCategories.DataSource = filtered;

            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (row.DataBoundItem is ExpenseCategory cat)
                {
                    row.DefaultCellStyle.ForeColor = cat.IsActive ? Color.Black : Color.Gray;
                }
            }

            lblCount.Text = $"Total: {filtered.Count} categories";
            ResetSelection();
        }

        private void dgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCategories.Columns[e.ColumnIndex].Name != "colStatus") return;
            if (e.RowIndex < 0 || e.RowIndex >= dgvCategories.Rows.Count) return;

            if (dgvCategories.Rows[e.RowIndex].DataBoundItem is ExpenseCategory cat)
            {
                e.Value = cat.IsActive ? "Active" : "Inactive";
                e.FormattingApplied = true;
            }
        }

        private void UpdateStats()
        {
            lblStatTotal.Text = $"Total Categories: {_allCategories.Count}";
            lblStatActive.Text = $"Active: {_allCategories.Count(c => c.IsActive)}";
            lblStatAmount.Text = $"Total Expenses: {_allCategories.Sum(c => c.TotalAmount):N2}";
        }

        private void ResetSelection()
        {
            _selectedCategoryId = 0;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCategories.Rows[e.RowIndex].DataBoundItem is ExpenseCategory cat)
            {
                _selectedCategoryId = cat.ExpenseCategoryID;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnEdit_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmExpenseCategoryDialog())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    _ = LoadCategoriesAsync();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == 0) { MessageHelper.ShowWarning("Please select a category first."); return; }
            var cat = _allCategories.FirstOrDefault(c => c.ExpenseCategoryID == _selectedCategoryId);
            if (cat == null) return;

            using (var frm = new FrmExpenseCategoryDialog(cat))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    _ = LoadCategoriesAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == 0) { MessageHelper.ShowWarning("Please select a category first."); return; }
            if (!MessageHelper.ShowConfirm("Are you sure you want to delete this category?")) return;

            try
            {
                bool ok = await ApiHelper.DeleteAsync($"ExpenseCategories/{_selectedCategoryId}");
                if (ok) { MessageHelper.ShowSuccess("Category deleted successfully."); await LoadCategoriesAsync(); }
                else { MessageHelper.ShowError("Failed to delete category."); }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private async void btnRefresh_Click(object sender, EventArgs e) => await LoadCategoriesAsync();

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplySearchFilter();

        private async void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => await LoadCategoriesAsync();
    }
}