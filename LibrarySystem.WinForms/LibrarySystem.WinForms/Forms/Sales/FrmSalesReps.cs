using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Sales;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmSalesReps : Form
    {
        private List<SalesRepresentative> _reps = new List<SalesRepresentative>();

        public FrmSalesReps()
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

            dgvReps.CellFormatting += DgvReps_CellFormatting;
        }

        private void DgvReps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvReps.Columns["colEdit"].Index;
            int delCol = dgvReps.Columns["colDeactivate"].Index;
            int statusCol = dgvReps.Columns["colStatus"].Index;

            if (e.ColumnIndex == editCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(20, 80, 160);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == delCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(170, 30, 30);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == statusCol && e.RowIndex >= 0)
            {
                var val = dgvReps.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString() ?? "";
                if (val.Contains("Active"))
                    e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                else
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
        }

        private async void FrmSalesReps_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvReps.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvReps.Columns["colDeactivate"].Visible = SessionManager.IsAdmin;
            await LoadReps();
        }

        private async System.Threading.Tasks.Task LoadReps()
        {
            try
            {
                spinner.Start();
                _reps = await ApiHelper.GetAsync<List<SalesRepresentative>>("salesrepresentatives")
                        ?? new List<SalesRepresentative>();
                BindGrid(_reps);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading sales reps: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<SalesRepresentative> list)
        {
            dgvReps.Rows.Clear();
            foreach (var r in list)
            {
                dgvReps.Rows.Add(
                    r.SalesRepID,
                    r.RepName,
                    r.Phone,
                    r.Email,
                    r.CommissionPercent.ToString("F2"),
                    r.TotalSales.ToString("F2"),
                    r.TotalCommissions.ToString("F2"),
                    r.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    r.IsActive ? "🚫 Deactivate" : "✔ Activate"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvReps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvReps.Rows[e.RowIndex].Cells["colSalesRepID"].Value);
            var rep = _reps.Find(r => r.SalesRepID == id);
            if (rep == null) return;

            if (e.ColumnIndex == dgvReps.Columns["colEdit"].Index && SessionManager.IsAdmin)
            { OpenEditDialog(rep); return; }

            if (e.ColumnIndex == dgvReps.Columns["colDeactivate"].Index && SessionManager.IsAdmin)
                ToggleActive(rep);
        }

        private void OpenEditDialog(SalesRepresentative rep = null)
        {
            bool isNew = rep == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Sales Representative" : "✏️ Edit Sales Representative",
                Size = new Size(480, 420),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(480, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label
            {
                Text = isNew ? "➕ Add Sales Representative" : "✏️ Edit Sales Representative",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(450, 28)
            });
            dlg.Controls.Add(pnlHeader);

            int y = 68; int lx = 20; int fx = 20; int fw = 430;

            dlg.Controls.Add(new Label { Text = "Full Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
            var txtName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = rep?.RepName ?? "", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtName); y += 44;

            dlg.Controls.Add(new Label { Text = "Phone", Location = new Point(lx, y), Size = new Size(200, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Email", Location = new Point(235, y), Size = new Size(215, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
            var txtPhone = new TextBox { Location = new Point(fx, y), Size = new Size(200, 30), Text = rep?.Phone ?? "", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtPhone);
            var txtEmail = new TextBox { Location = new Point(235, y), Size = new Size(215, 30), Text = rep?.Email ?? "", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtEmail); y += 44;

            dlg.Controls.Add(new Label { Text = "Commission Rate % *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
            var txtCommission = new TextBox { Location = new Point(fx, y), Size = new Size(150, 30), Text = rep?.CommissionPercent.ToString("F2") ?? "", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f, FontStyle.Bold) };
            dlg.Controls.Add(txtCommission); y += 44;

            CheckBox chkActive = null;
            if (!isNew)
            {
                chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 28), Checked = rep.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
                dlg.Controls.Add(chkActive); y += 40;
            }

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(205, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 220, y), Size = new Size(205, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            dlg.Size = new Size(480, y + 100);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                { MessageHelper.ShowWarning("Please enter the representative's name."); return; }

                if (!ValidationHelper.IsValidNumber(txtCommission.Text))
                { MessageHelper.ShowWarning("Please enter a valid commission rate."); return; }

                decimal commission = decimal.Parse(txtCommission.Text);
                if (commission < 0 || commission > 100)
                { MessageHelper.ShowWarning("Commission rate must be between 0 and 100."); return; }

                if (!string.IsNullOrWhiteSpace(txtPhone.Text) && !ValidationHelper.IsValidPhone(txtPhone.Text))
                { MessageHelper.ShowWarning("Please enter a valid phone number."); return; }

                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ValidationHelper.IsValidEmail(txtEmail.Text))
                { MessageHelper.ShowWarning("Please enter a valid email address."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";

                    if (isNew)
                    {
                        var dto = new CreateSalesRepresentativeDTO
                        {
                            RepName = txtName.Text.Trim(),
                            Phone = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            CommissionPercent = commission,
                            CreatedBy = SessionManager.UserId
                        };
                        await ApiHelper.PostAsync<object>("salesrepresentatives", dto);
                        MessageHelper.ShowSuccess("Sales representative added successfully!");
                        dlg.DialogResult = DialogResult.OK; dlg.Close();
                    }
                    else
                    {
                        var dto = new UpdateSalesRepresentativeDTO
                        {
                            SalesRepID = rep.SalesRepID,
                            RepName = txtName.Text.Trim(),
                            Phone = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            CommissionPercent = commission,
                            IsActive = chkActive?.Checked ?? true
                        };
                        await ApiHelper.PutAsync<object>("salesrepresentatives/" + rep.SalesRepID, dto);
                        MessageHelper.ShowSuccess("Sales representative updated successfully!");
                        dlg.DialogResult = DialogResult.OK; dlg.Close();
                    }
                }
                catch (Exception ex)
                { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadReps();
        }

        private async void ToggleActive(SalesRepresentative rep)
        {
            bool willActivate = !rep.IsActive;
            string action = willActivate ? "activate" : "deactivate";

            if (!MessageHelper.ShowConfirm($"Are you sure you want to {action} \"{rep.RepName}\"?")) return;

            try
            {
                spinner.Start();
                var dto = new UpdateSalesRepresentativeDTO
                {
                    SalesRepID = rep.SalesRepID,
                    RepName = rep.RepName,
                    Phone = rep.Phone,
                    Email = rep.Email,
                    CommissionPercent = rep.CommissionPercent,
                    IsActive = willActivate
                };
                await ApiHelper.PutAsync<object>("salesrepresentatives/" + rep.SalesRepID, dto);
                MessageHelper.ShowSuccess($"Sales representative {action}d successfully!");
                await LoadReps();
            }
            catch (Exception ex) { MessageHelper.ShowError($"Error trying to {action}: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_reps); return; }
            string s = text.ToLower();
            var filtered = new List<SalesRepresentative>();
            foreach (var r in _reps)
                if (r.RepName.ToLower().Contains(s) ||
                   (!string.IsNullOrEmpty(r.Phone) && r.Phone.ToLower().Contains(s)) ||
                   (!string.IsNullOrEmpty(r.Email) && r.Email.ToLower().Contains(s)))
                    filtered.Add(r);
            BindGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadReps();
        }
    }
}