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
    public partial class FrmPaymentMethods : Form
    {
        private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();

        public FrmPaymentMethods()
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

            dgvPaymentMethods.CellFormatting += DgvPaymentMethods_CellFormatting;
        }

        // ─────────────────────────────────────────────
        //  CELL FORMATTING
        // ─────────────────────────────────────────────
        private void DgvPaymentMethods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvPaymentMethods.Columns["colEdit"].Index;
            int delCol = dgvPaymentMethods.Columns["colDelete"].Index;

            if (e.ColumnIndex == editCol)
            {
                if (SessionManager.IsAdmin)
                {
                    e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(20, 80, 160);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(230, 232, 235);
                    e.CellStyle.ForeColor = Color.FromArgb(230, 232, 235);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(230, 232, 235);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(230, 232, 235);
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
            else if (e.ColumnIndex == delCol)
            {
                if (SessionManager.IsAdmin)
                {
                    e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(170, 30, 30);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(230, 232, 235);
                    e.CellStyle.ForeColor = Color.FromArgb(230, 232, 235);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(230, 232, 235);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(230, 232, 235);
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }

        // ─────────────────────────────────────────────
        //  LOAD
        // ─────────────────────────────────────────────
        private async void FrmPaymentMethods_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;

            // Hide columns entirely for non-admin
            dgvPaymentMethods.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvPaymentMethods.Columns["colDelete"].Visible = SessionManager.IsAdmin;

            await LoadPaymentMethods();
        }

        private async System.Threading.Tasks.Task LoadPaymentMethods()
        {
            try
            {
                spinner.Start();
                _paymentMethods = await ApiHelper.GetAsync<List<PaymentMethod>>("paymentmethods")
                                  ?? new List<PaymentMethod>();
                BindGrid(_paymentMethods);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading payment methods: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        // ─────────────────────────────────────────────
        //  BIND GRID
        // ─────────────────────────────────────────────
        private void BindGrid(List<PaymentMethod> list)
        {
            dgvPaymentMethods.Rows.Clear();
            foreach (var p in list)
            {
                dgvPaymentMethods.Rows.Add(
                    p.PaymentMethodID,
                    p.MethodName,
                    p.MethodNameAr,
                    p.DisplayOrder,
                    p.IsActive ? "✓ Active" : "✗ Inactive",
                    SessionManager.IsAdmin ? "✏️ Edit" : "",
                    SessionManager.IsAdmin ? "🗑 Delete" : ""
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        // ─────────────────────────────────────────────
        //  GRID CELL CLICK
        // ─────────────────────────────────────────────
        private void dgvPaymentMethods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return; // block non-admin clicks

            int id = Convert.ToInt32(dgvPaymentMethods.Rows[e.RowIndex].Cells["colID"].Value);
            var pm = _paymentMethods.Find(p => p.PaymentMethodID == id);
            if (pm == null) return;

            if (e.ColumnIndex == dgvPaymentMethods.Columns["colEdit"].Index)
                OpenEditDialog(pm);
            else if (e.ColumnIndex == dgvPaymentMethods.Columns["colDelete"].Index)
                DeletePaymentMethod(pm);
        }

        // ─────────────────────────────────────────────
        //  OPEN EDIT DIALOG
        // ─────────────────────────────────────────────
        private void OpenEditDialog(PaymentMethod pm = null)
        {
            bool isNew = pm == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Payment Method" : "✏️ Edit Payment Method",
                Size = new Size(440, 440),
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
                Text = isNew ? "➕ Add Payment Method" : "✏️ Edit Payment Method",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(400, 28)
            });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 390;

            // ── Method Name ──
            dlg.Controls.Add(new Label { Text = "Method Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtMethodName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : pm.MethodName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtMethodName);
            y += 45;

            // ── Arabic Name ──
            dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtMethodNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : pm.MethodNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtMethodNameAr);
            y += 45;

            // ── Display Order ──
            dlg.Controls.Add(new Label { Text = "Display Order", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var numOrder = new NumericUpDown { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), Minimum = 0, Maximum = 100, Value = isNew ? 0 : pm.DisplayOrder };
            dlg.Controls.Add(numOrder);
            y += 45;

            // ── IsActive ──
            var chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = isNew || pm.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkActive);
            y += 45;

            // ── Buttons ──
            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(185, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 200, y), Size = new Size(185, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            // ── Save Logic ──
            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtMethodName.Text))
                { MessageHelper.ShowWarning("Please enter method name."); return; }

                try
                {
                    btnSave.Enabled = false;
                    btnSave.Text = "Saving...";

                    if (isNew)
                    {
                        var dto = new CreatePaymentMethodDTO
                        {
                            MethodName = txtMethodName.Text.Trim(),
                            MethodNameAr = txtMethodNameAr.Text.Trim(),
                            DisplayOrder = (int)numOrder.Value
                        };
                        if (await ApiHelper.PostAsync<PaymentMethod>("paymentmethods", dto) != null)
                        { MessageHelper.ShowSuccess("Payment method added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdatePaymentMethodDTO
                        {
                            PaymentMethodID = pm.PaymentMethodID,
                            MethodName = txtMethodName.Text.Trim(),
                            MethodNameAr = txtMethodNameAr.Text.Trim(),
                            DisplayOrder = (int)numOrder.Value,
                            IsActive = chkActive.Checked
                        };
                        if (await ApiHelper.PutAsync<PaymentMethod>("paymentmethods/" + pm.PaymentMethodID, dto) != null)
                        { MessageHelper.ShowSuccess("Payment method updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Error: " + ex.Message);
                    btnSave.Enabled = true;
                    btnSave.Text = "💾 Save";
                }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadPaymentMethods();
        }

        // ─────────────────────────────────────────────
        //  DELETE
        // ─────────────────────────────────────────────
        private async void DeletePaymentMethod(PaymentMethod pm)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{pm.MethodName}\"?\nThis action cannot be undone."))
                return;

            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("paymentmethods/" + pm.PaymentMethodID);
                MessageHelper.ShowSuccess("Payment method deleted successfully.");
                await LoadPaymentMethods();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        // ─────────────────────────────────────────────
        //  SEARCH
        // ─────────────────────────────────────────────
        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_paymentMethods); return; }
            string s = text.ToLower();
            var filtered = new List<PaymentMethod>();
            foreach (var p in _paymentMethods)
                if (p.MethodName.ToLower().Contains(s) ||
                   (p.MethodNameAr != null && p.MethodNameAr.ToLower().Contains(s)))
                    filtered.Add(p);
            BindGrid(filtered);
        }

        // ─────────────────────────────────────────────
        //  TOP BUTTONS
        // ─────────────────────────────────────────────
        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadPaymentMethods();
        }
    }
}