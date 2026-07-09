using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Advanced;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Advanced
{
    public partial class FrmMessageTemplates : Form
    {
        private List<MessageTemplate> _templates = new List<MessageTemplate>();

        public FrmMessageTemplates()
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

            dgvTemplates.CellFormatting += DgvTemplates_CellFormatting;
        }

        private void DgvTemplates_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvTemplates.Columns["colEdit"].Index;
            int delCol = dgvTemplates.Columns["colDelete"].Index;

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

        private async void FrmMessageTemplates_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvTemplates.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvTemplates.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadTemplates();
        }

        private async System.Threading.Tasks.Task LoadTemplates()
        {
            try
            {
                spinner.Start();
                string endpoint = "messagetemplates";
                var filters = new List<string>();

                if (cmbTypeFilter.SelectedIndex > 0)
                    filters.Add("MessageType=" + cmbTypeFilter.SelectedItem.ToString());
                if (cmbStatusFilter.SelectedIndex > 0)
                    filters.Add("IsActive=" + (cmbStatusFilter.SelectedIndex == 1 ? "true" : "false"));

                if (filters.Count > 0)
                    endpoint += "?" + string.Join("&", filters);

                _templates = await ApiHelper.GetAsync<List<MessageTemplate>>(endpoint)
                             ?? new List<MessageTemplate>();
                BindGrid(_templates);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading templates: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<MessageTemplate> list)
        {
            dgvTemplates.Rows.Clear();
            foreach (var t in list)
            {
                dgvTemplates.Rows.Add(
                    t.TemplateID,
                    t.TemplateCode,
                    t.TemplateName,
                    t.TemplateNameAr,
                    t.MessageType,
                    t.Subject,
                    t.IsActive ? "✓ Active" : "✗ Inactive",
                    t.CreatedDate.ToString("yyyy-MM-dd"),
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvTemplates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvTemplates.Rows[e.RowIndex].Cells["colID"].Value);
            var tmpl = _templates.Find(t => t.TemplateID == id);
            if (tmpl == null) return;

            if (e.ColumnIndex == dgvTemplates.Columns["colEdit"].Index)
                OpenEditDialog(tmpl);
            else if (e.ColumnIndex == dgvTemplates.Columns["colDelete"].Index)
                DeleteTemplate(tmpl);
        }

        private void OpenEditDialog(MessageTemplate tmpl = null)
        {
            bool isNew = tmpl == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Template" : "✏️ Edit Template",
                Size = new Size(600, 750),
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
                Size = new Size(600, 50),
                BackColor = Color.FromArgb(22, 32, 50)
            };
            pnlHeader.Controls.Add(new Label
            {
                Text = isNew ? "➕ Add Template" : "✏️ Edit Template",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(560, 28)
            });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 550;

            dlg.Controls.Add(MakeLabel("Template Code *", lx, y, fw));
            y += 25;
            var txtCode = MakeTextBox(fx, y, fw, isNew ? "" : tmpl.TemplateCode);
            dlg.Controls.Add(txtCode); y += 45;

            dlg.Controls.Add(MakeLabel("Template Name *", lx, y, fw));
            y += 25;
            var txtName = MakeTextBox(fx, y, fw, isNew ? "" : tmpl.TemplateName);
            dlg.Controls.Add(txtName); y += 45;

            dlg.Controls.Add(MakeLabel("Arabic Name", lx, y, fw));
            y += 25;
            var txtNameAr = MakeTextBox(fx, y, fw, isNew ? "" : tmpl.TemplateNameAr, rtl: true);
            dlg.Controls.Add(txtNameAr); y += 45;

            dlg.Controls.Add(MakeLabel("Message Type *", lx, y, fw));
            y += 25;
            var cmbType = new ComboBox
            {
                Location = new Point(fx, y),
                Size = new Size(fw, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10f)
            };
            cmbType.Items.AddRange(new object[] { "SMS", "Email", "WhatsApp", "Notification" });
            cmbType.SelectedItem = isNew ? "SMS" : tmpl.MessageType;
            if (cmbType.SelectedIndex < 0) cmbType.SelectedIndex = 0;
            dlg.Controls.Add(cmbType); y += 45;

            dlg.Controls.Add(MakeLabel("Subject", lx, y, fw));
            y += 25;
            var txtSubject = MakeTextBox(fx, y, fw, isNew ? "" : tmpl.Subject);
            dlg.Controls.Add(txtSubject); y += 45;

            dlg.Controls.Add(MakeLabel("Message Body *", lx, y, fw));
            y += 25;
            var txtBody = new TextBox
            {
                Location = new Point(fx, y),
                Size = new Size(fw, 70),
                Text = isNew ? "" : tmpl.MessageBody,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            dlg.Controls.Add(txtBody); y += 85;

            dlg.Controls.Add(MakeLabel("Parameters (comma separated)", lx, y, fw));
            y += 25;
            var txtParams = MakeTextBox(fx, y, fw, isNew ? "" : tmpl.Parameters);
            dlg.Controls.Add(txtParams); y += 45;

            var chkActive = new CheckBox
            {
                Text = "✓ Active",
                Location = new Point(fx, y),
                Size = new Size(fw, 30),
                Checked = isNew || tmpl.IsActive,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 160, 100),
                Cursor = Cursors.Hand
            };
            dlg.Controls.Add(chkActive); y += 42;

            var btnSave = new Button
            {
                Text = "💾 Save",
                Location = new Point(fx, y),
                Size = new Size(265, 42),
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
                Location = new Point(fx + 285, y),
                Size = new Size(265, 42),
                BackColor = Color.FromArgb(160, 160, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                { MessageHelper.ShowWarning("Please enter template code."); return; }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                { MessageHelper.ShowWarning("Please enter template name."); return; }
                if (string.IsNullOrWhiteSpace(txtBody.Text))
                { MessageHelper.ShowWarning("Please enter message body."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";

                    if (isNew)
                    {
                        var dto = new CreateMessageTemplateDTO
                        {
                            TemplateCode = txtCode.Text.Trim(),
                            TemplateName = txtName.Text.Trim(),
                            TemplateNameAr = txtNameAr.Text.Trim(),
                            MessageType = cmbType.SelectedItem.ToString(),
                            Subject = txtSubject.Text.Trim(),
                            MessageBody = txtBody.Text.Trim(),
                            Parameters = txtParams.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        await ApiHelper.PostAsync<object>("messagetemplates", dto);
                        MessageHelper.ShowSuccess("Template added!");
                    }
                    else
                    {
                        var dto = new UpdateMessageTemplateDTO
                        {
                            TemplateID = tmpl.TemplateID,
                            TemplateCode = txtCode.Text.Trim(),
                            TemplateName = txtName.Text.Trim(),
                            TemplateNameAr = txtNameAr.Text.Trim(),
                            MessageType = cmbType.SelectedItem.ToString(),
                            Subject = txtSubject.Text.Trim(),
                            MessageBody = txtBody.Text.Trim(),
                            Parameters = txtParams.Text.Trim(),
                            IsActive = chkActive.Checked
                        };
                        await ApiHelper.PutAsync<object>("messagetemplates/" + tmpl.TemplateID, dto);
                        MessageHelper.ShowSuccess("Template updated!");
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
                _ = LoadTemplates();
        }

        private async void DeleteTemplate(MessageTemplate tmpl)
        {
            if (!MessageHelper.ShowConfirm($"Delete template \"{tmpl.TemplateName}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("messagetemplates/" + tmpl.TemplateID);
                MessageHelper.ShowSuccess("Template deleted successfully.");
                await LoadTemplates();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_templates); return; }
            string s = text.ToLower();
            var filtered = new List<MessageTemplate>();
            foreach (var t in _templates)
                if (t.TemplateCode.ToLower().Contains(s) ||
                    t.TemplateName.ToLower().Contains(s) ||
                    t.MessageType.ToLower().Contains(s) ||
                   (t.Subject != null && t.Subject.ToLower().Contains(s)))
                    filtered.Add(t);
            BindGrid(filtered);
        }

        private Label MakeLabel(string text, int x, int y, int w)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(w, 22),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            };
        }

        private TextBox MakeTextBox(int x, int y, int w, string text, bool rtl = false)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(w, 30),
                Text = text,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f),
                RightToLeft = rtl ? RightToLeft.Yes : RightToLeft.No
            };
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadTemplates();
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await LoadTemplates();
        }
    }
}