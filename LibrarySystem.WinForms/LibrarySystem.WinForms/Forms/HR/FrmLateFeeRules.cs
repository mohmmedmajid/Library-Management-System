using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.HR;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.HR
{
    public partial class FrmLateFeeRules : Form
    {
        private List<LateFeeRule> _rules = new List<LateFeeRule>();

        public FrmLateFeeRules()
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

            dgvRules.CellFormatting += DgvRules_CellFormatting;
            dgvRules.CellClick += DgvRules_CellClick;
        }

        private void DgvRules_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvRules.Columns["colEdit"] != null && e.ColumnIndex == dgvRules.Columns["colEdit"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (dgvRules.Columns["colDelete"] != null && e.ColumnIndex == dgvRules.Columns["colDelete"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private async void FrmLateFeeRules_Load(object sender, EventArgs e)
        {
            await LoadRulesAsync();
        }

        private async Task LoadRulesAsync()
        {
            try
            {
                spinner.Start();
                _rules = await ApiHelper.GetAsync<List<LateFeeRule>>("LateFeeRules") ?? new List<LateFeeRule>();
                BindGrid(_rules);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Failed to load late fee rules: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<LateFeeRule> data)
        {
            dgvRules.Rows.Clear();
            foreach (var r in data)
            {
                dgvRules.Rows.Add(
                    r.RuleID,
                    r.RuleName,
                    r.RuleNameAr,
                    r.FeePerDay.ToString("N2"),
                    r.GracePeriodDays,
                    r.MaximumFee?.ToString("N2") ?? "-",
                    r.ApplicableFrom.ToString("yyyy-MM-dd"),
                    r.IsActive ? "✓ Active" : "✗ Inactive",
                    r.Description,
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + data.Count;
        }

        private void DgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvRules.Rows[e.RowIndex].Cells["colID"].Value);
            var rule = _rules.Find(r => r.RuleID == id);
            if (rule == null) return;

            if (dgvRules.Columns["colEdit"] != null && e.ColumnIndex == dgvRules.Columns["colEdit"].Index)
                OpenEditDialog(rule);
            else if (dgvRules.Columns["colDelete"] != null && e.ColumnIndex == dgvRules.Columns["colDelete"].Index)
                DeleteRule(rule);
        }

        private void OpenEditDialog(LateFeeRule rule = null)
        {
            bool isNew = rule == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Late Fee Rule" : "✏️ Edit Late Fee Rule",
                Size = new Size(460, 600),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHead = new Panel { Location = new Point(0, 0), Size = new Size(460, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHead.Controls.Add(new Label { Text = isNew ? "➕ Add Late Fee Rule" : "✏️ Edit Late Fee Rule", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(420, 28) });
            dlg.Controls.Add(pnlHead);

            int y = 70; int lx = 20; int fx = 20; int fw = 410;

            // Rule Name
            dlg.Controls.Add(new Label { Text = "Rule Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtRuleName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : rule.RuleName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtRuleName); y += 45;

            // Arabic Name
            dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtRuleNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : rule.RuleNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtRuleNameAr); y += 45;

            // Fee Per Day
            dlg.Controls.Add(new Label { Text = "Fee Per Day *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtFeePerDay = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : rule.FeePerDay.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtFeePerDay); y += 45;

            // Grace Period Days
            dlg.Controls.Add(new Label { Text = "Grace Period Days *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtGracePeriod = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "0" : rule.GracePeriodDays.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtGracePeriod); y += 45;

            // Maximum Fee
            dlg.Controls.Add(new Label { Text = "Maximum Fee", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtMaxFee = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : rule.MaximumFee?.ToString() ?? "", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtMaxFee); y += 45;

            // Applicable From
            dlg.Controls.Add(new Label { Text = "Applicable From *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var dtpFrom = new DateTimePicker { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), Format = DateTimePickerFormat.Short };
            dtpFrom.Value = isNew ? DateTime.Now : rule.ApplicableFrom;
            dlg.Controls.Add(dtpFrom); y += 45;

            // Description
            dlg.Controls.Add(new Label { Text = "Description", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtDesc = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 50), Text = isNew ? "" : rule.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtDesc); y += 65;

            // Is Active (edit only)
            CheckBox chkActive = null;
            if (!isNew)
            {
                chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = rule.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
                dlg.Controls.Add(chkActive); y += 42;
            }

            // Buttons
            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(195, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 210, y), Size = new Size(195, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtRuleName.Text)) { MessageHelper.ShowWarning("Please enter the rule name."); return; }
                if (!ValidationHelper.IsValidPrice(txtFeePerDay.Text)) { MessageHelper.ShowWarning("Invalid fee per day."); return; }
                if (!int.TryParse(txtGracePeriod.Text, out _)) { MessageHelper.ShowWarning("Invalid grace period days."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";

                    decimal? maxFee = null;
                    if (!string.IsNullOrWhiteSpace(txtMaxFee.Text) && decimal.TryParse(txtMaxFee.Text, out decimal mf))
                        maxFee = mf;

                    if (isNew)
                    {
                        var dto = new CreateLateFeeRuleDTO
                        {
                            RuleName = txtRuleName.Text.Trim(),
                            RuleNameAr = txtRuleNameAr.Text.Trim(),
                            FeePerDay = decimal.Parse(txtFeePerDay.Text),
                            GracePeriodDays = int.Parse(txtGracePeriod.Text),
                            MaximumFee = maxFee,
                            ApplicableFrom = dtpFrom.Value,
                            Description = txtDesc.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<LateFeeRule>("LateFeeRules", dto) != null)
                        { MessageHelper.ShowSuccess("Rule added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateLateFeeRuleDTO
                        {
                            RuleID = rule.RuleID,
                            RuleName = txtRuleName.Text.Trim(),
                            RuleNameAr = txtRuleNameAr.Text.Trim(),
                            FeePerDay = decimal.Parse(txtFeePerDay.Text),
                            GracePeriodDays = int.Parse(txtGracePeriod.Text),
                            MaximumFee = maxFee,
                            Description = txtDesc.Text.Trim(),
                            IsActive = chkActive?.Checked ?? true
                        };
                        if (await ApiHelper.PutAsync<LateFeeRule>("LateFeeRules/" + rule.RuleID, dto) != null)
                        { MessageHelper.ShowSuccess("Rule updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            dlg.Height = y + 110;
            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadRulesAsync();
        }

        private async void DeleteRule(LateFeeRule rule)
        {
            if (!MessageHelper.ShowConfirm($"Delete rule \"{rule.RuleName}\"?")) return;
            try
            {
                spinner.Start();
                var result = await ApiHelper.DeleteAsync("LateFeeRules/" + rule.RuleID);
                if (result) { MessageHelper.ShowSuccess("Deleted successfully"); await LoadRulesAsync(); }
                else MessageHelper.ShowError("Delete failed");
            }
            catch (Exception ex) { MessageHelper.ShowError("Delete failed: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText)) { BindGrid(_rules); return; }
            var filtered = _rules.Where(r =>
                (r.RuleName != null && r.RuleName.ToLower().Contains(searchText.ToLower())) ||
                (r.RuleNameAr != null && r.RuleNameAr.ToLower().Contains(searchText.ToLower()))
            ).ToList();
            BindGrid(filtered);
        }

        private void BtnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadRulesAsync();
        }
    }
}