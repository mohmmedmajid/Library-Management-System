using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Main
{
    public partial class FrmSettings : Form
    {
        private List<SystemSetting> _settings = new List<SystemSetting>();

        public FrmSettings()
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

            dgvSettings.CellFormatting += DgvSettings_CellFormatting;
        }

        // ─────────────────────────────────────────────
        //  CELL FORMATTING - Fix button colors
        // ─────────────────────────────────────────────
        private void DgvSettings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvSettings.Columns["colEdit"].Index;

            if (e.ColumnIndex == editCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(20, 80, 160);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        // ─────────────────────────────────────────────
        //  LOAD
        // ─────────────────────────────────────────────
        private async void FrmSettings_Load(object sender, EventArgs e)
        {
            await LoadSettings();
        }

        private async System.Threading.Tasks.Task LoadSettings()
        {
            try
            {
                spinner.Start();
                _settings = await ApiHelper.GetAsync<List<SystemSetting>>("systemsettings")
                            ?? new List<SystemSetting>();
                BindGrid(_settings);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading settings: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
            }
        }

        // ─────────────────────────────────────────────
        //  BIND GRID
        // ─────────────────────────────────────────────
        private void BindGrid(List<SystemSetting> list)
        {
            dgvSettings.Rows.Clear();
            foreach (var s in list)
            {
                dgvSettings.Rows.Add(
                    s.SettingID,
                    s.SettingKey,
                    s.SettingValue,
                    s.Description,
                    "✏️ Edit"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        // ─────────────────────────────────────────────
        //  GRID CELL CLICK
        // ─────────────────────────────────────────────
        private void dgvSettings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int settingId = Convert.ToInt32(dgvSettings.Rows[e.RowIndex].Cells["colID"].Value);
            var setting = _settings.Find(s => s.SettingID == settingId);
            if (setting == null) return;

            if (e.ColumnIndex == dgvSettings.Columns["colEdit"].Index)
                OpenEditDialog(setting);
        }

        // ─────────────────────────────────────────────
        //  OPEN EDIT DIALOG
        // ─────────────────────────────────────────────
        private void OpenEditDialog(SystemSetting setting)
        {
            var dlg = new Form
            {
                Text = "✏️ Edit Setting",
                Size = new Size(440, 320),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            // ── Header ──
            var pnlHeader = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(440, 50),
                BackColor = Color.FromArgb(22, 32, 50)
            };
            pnlHeader.Controls.Add(new Label
            {
                Text = "✏️ Edit Setting",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(400, 28)
            });
            dlg.Controls.Add(pnlHeader);

            int y = 70;
            int lx = 20;
            int fx = 20;
            int fw = 390;

            // ── Setting Key (readonly) ──
            dlg.Controls.Add(new Label
            {
                Text = "Setting Key",
                Location = new Point(lx, y),
                Size = new Size(fw, 22),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            });
            y += 25;
            dlg.Controls.Add(new TextBox
            {
                Location = new Point(fx, y),
                Size = new Size(fw, 30),
                Text = setting.SettingKey,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f),
                ReadOnly = true,
                BackColor = Color.FromArgb(245, 247, 250)
            });
            y += 45;

            // ── Setting Value ──
            dlg.Controls.Add(new Label
            {
                Text = "Setting Value ✏",
                Location = new Point(lx, y),
                Size = new Size(fw, 22),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 100, 180)
            });
            y += 25;
            var txtValue = new TextBox
            {
                Location = new Point(fx, y),
                Size = new Size(fw, 30),
                Text = setting.SettingValue,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f)
            };
            dlg.Controls.Add(txtValue);
            y += 50;

            // ── Buttons ──
            var btnSave = new Button
            {
                Text = "💾 Save",
                Location = new Point(fx, y),
                Size = new Size(185, 42),
                BackColor = Color.FromArgb(30, 100, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button
            {
                Text = "✕ Cancel",
                Location = new Point(fx + 200, y),
                Size = new Size(185, 42),
                BackColor = Color.FromArgb(160, 160, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            // ── Save Logic ──
            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtValue.Text))
                { MessageHelper.ShowWarning("Please enter setting value."); return; }

                try
                {
                    btnSave.Enabled = false;
                    btnSave.Text = "Saving...";

                    var dto = new UpdateSystemSettingDTO
                    {
                        SettingID = setting.SettingID,
                        SettingValue = txtValue.Text.Trim(),
                        LastUpdatedBy = SessionManager.UserId
                    };

                    if (await ApiHelper.PutAsync<SystemSetting>("systemsettings/" + setting.SettingID, dto) != null)
                    { MessageHelper.ShowSuccess("Setting updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Error: " + ex.Message);
                    btnSave.Enabled = true;
                    btnSave.Text = "💾 Save";
                }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadSettings();
        }

        // ─────────────────────────────────────────────
        //  SEARCH
        // ─────────────────────────────────────────────
        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_settings); return; }
            string s = text.ToLower();
            var filtered = new List<SystemSetting>();
            foreach (var st in _settings)
                if (st.SettingKey.ToLower().Contains(s) ||
                   (st.SettingValue != null && st.SettingValue.ToLower().Contains(s)) ||
                   (st.Description != null && st.Description.ToLower().Contains(s)))
                    filtered.Add(st);
            BindGrid(filtered);
        }

        // ─────────────────────────────────────────────
        //  TOP BUTTONS
        // ─────────────────────────────────────────────
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadSettings();
        }
    }
}