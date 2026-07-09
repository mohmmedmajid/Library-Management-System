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
    public partial class FrmJournalEntry : Form
    {
        private List<JournalEntry> _entries = new List<JournalEntry>();
        private List<ChartOfAccount> _accounts = new List<ChartOfAccount>();
        private List<CostCenter> _costCenters = new List<CostCenter>();

        public FrmJournalEntry()
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

            dgvEntries.CellFormatting += DgvEntries_CellFormatting;
        }

        private void DgvEntries_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvEntries.Columns["colEntryView"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(90, 90, 110);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(90, 90, 110);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == dgvEntries.Columns["colEntryPost"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(40, 160, 100);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(40, 160, 100);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == dgvEntries.Columns["colEntryEdit"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == dgvEntries.Columns["colEntryDelete"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private async void FrmJournalEntry_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvEntries.Columns["colEntryEdit"].Visible = SessionManager.IsAdmin;
            dgvEntries.Columns["colEntryDelete"].Visible = SessionManager.IsAdmin;
            dgvEntries.Columns["colEntryPost"].Visible = SessionManager.IsAdmin;

            await LoadAccounts();
            await LoadCostCenters();
            await LoadEntries();
        }

        private async System.Threading.Tasks.Task LoadAccounts()
        {
            try
            {
                _accounts = await ApiHelper.GetAsync<List<ChartOfAccount>>("chartofaccounts")
                            ?? new List<ChartOfAccount>();
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadCostCenters()
        {
            try
            {
                _costCenters = await ApiHelper.GetAsync<List<CostCenter>>("costcenters")
                               ?? new List<CostCenter>();
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadEntries()
        {
            try
            {
                spinner.Start();
                _entries = await ApiHelper.GetAsync<List<JournalEntry>>("journalentries")
                           ?? new List<JournalEntry>();
                BindEntriesGrid(_entries);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading journal entries: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindEntriesGrid(List<JournalEntry> list)
        {
            dgvEntries.Rows.Clear();
            foreach (var j in list)
            {
                dgvEntries.Rows.Add(
                    j.JournalEntryID,
                    j.JournalEntryNumber,
                    j.EntryDate.ToString("yyyy-MM-dd"),
                    j.EntryType,
                    j.Description,
                    j.TotalDebit.ToString("N2"),
                    j.TotalCredit.ToString("N2"),
                    j.IsBalanced ? "✓ Balanced" : "✗ Unbalanced",
                    j.Status,
                    j.CostCenterName,
                    j.CreatedByName,
                    "👁 View",
                    j.Status == "Draft" ? "▶ Post" : "—",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private async void dgvEntries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvEntries.Rows[e.RowIndex].Cells["colEntryID"].Value);
            var item = _entries.Find(x => x.JournalEntryID == id);
            if (item == null) return;

            if (e.ColumnIndex == dgvEntries.Columns["colEntryView"].Index)
            {
                var frm = new FrmJournalEntryDetails(id);
                frm.ShowDialog(this);
            }
            else if (e.ColumnIndex == dgvEntries.Columns["colEntryPost"].Index)
            {
                if (item.Status != "Draft") return;
                await PostEntry(item);
            }
            else if (e.ColumnIndex == dgvEntries.Columns["colEntryEdit"].Index)
            {
                if (!SessionManager.IsAdmin) return;
                OpenEntryDialog(item);
            }
            else if (e.ColumnIndex == dgvEntries.Columns["colEntryDelete"].Index)
            {
                if (!SessionManager.IsAdmin) return;
                await DeleteEntry(item);
            }
        }

        private void OpenEntryDialog(JournalEntry je = null)
        {
            bool isNew = je == null;
            List<JournalEntryDetail> existingDetails = new List<JournalEntryDetail>();

            var dlg = new Form
            {
                Text = isNew ? "➕ New Journal Entry" : "✏️ Edit Journal Entry",
                Size = new Size(760, 700),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlH = new Panel { Location = new Point(0, 0), Size = new Size(760, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlH.Controls.Add(new Label
            {
                Text = isNew ? "➕ New Journal Entry" : "✏️ Edit Journal Entry",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(480, 28)
            });
            dlg.Controls.Add(pnlH);

            int y = 62; int lx = 20; int fx = 20; int fw = 340;

            dlg.Controls.Add(new Label { Text = "Entry Date *", Location = new Point(lx, y), Size = new Size(fw, 20), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Entry Type *", Location = new Point(lx + 360, y), Size = new Size(fw, 20), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 22;
            var dtpDate = new DateTimePicker { Location = new Point(fx, y), Size = new Size(fw, 28), Format = DateTimePickerFormat.Short, Value = isNew ? DateTime.Today : je.EntryDate, Font = new Font("Segoe UI", 9.5f) };
            var cmbEntryType = new ComboBox { Location = new Point(fx + 360, y), Size = new Size(fw, 28), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5f) };
            cmbEntryType.Items.AddRange(new object[] { "Manual", "Sales", "Purchase", "Payroll", "Adjustment", "Closing" });
            cmbEntryType.SelectedItem = isNew ? "Manual" : je.EntryType;
            if (cmbEntryType.SelectedIndex < 0) cmbEntryType.SelectedIndex = 0;
            dlg.Controls.Add(dtpDate);
            dlg.Controls.Add(cmbEntryType);
            y += 40;

            dlg.Controls.Add(new Label { Text = "Cost Center *", Location = new Point(lx, y), Size = new Size(fw, 20), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Reference Type", Location = new Point(lx + 360, y), Size = new Size(fw, 20), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 22;
            var cmbCostCenter = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 28), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5f) };
            foreach (var cc in _costCenters)
                cmbCostCenter.Items.Add(new { Text = cc.CostCenterName, Value = cc.CostCenterID });
            cmbCostCenter.DisplayMember = "Text";
            cmbCostCenter.ValueMember = "Value";
            if (!isNew)
            {
                for (int i = 0; i < cmbCostCenter.Items.Count; i++)
                {
                    dynamic item3 = cmbCostCenter.Items[i];
                    if (item3.Value == je.CostCenterID) { cmbCostCenter.SelectedIndex = i; break; }
                }
            }
            if (cmbCostCenter.SelectedIndex < 0 && cmbCostCenter.Items.Count > 0) cmbCostCenter.SelectedIndex = 0;
            var txtRefType = new TextBox { Location = new Point(fx + 360, y), Size = new Size(fw, 28), Text = isNew ? "" : je.ReferenceType, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 9.5f) };
            dlg.Controls.Add(cmbCostCenter);
            dlg.Controls.Add(txtRefType);
            y += 40;

            dlg.Controls.Add(new Label { Text = "Fiscal Year *", Location = new Point(lx, y), Size = new Size(fw, 20), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Fiscal Month *", Location = new Point(lx + 360, y), Size = new Size(fw, 20), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 22;
            var numYear = new NumericUpDown { Location = new Point(fx, y), Size = new Size(fw, 28), Minimum = 2000, Maximum = 2100, Value = isNew ? DateTime.Today.Year : (je.FiscalYear ?? DateTime.Today.Year), Font = new Font("Segoe UI", 9.5f) };
            var numMonth = new NumericUpDown { Location = new Point(fx + 360, y), Size = new Size(fw, 28), Minimum = 1, Maximum = 12, Value = isNew ? DateTime.Today.Month : (je.FiscalMonth ?? DateTime.Today.Month), Font = new Font("Segoe UI", 9.5f) };
            dlg.Controls.Add(numYear);
            dlg.Controls.Add(numMonth);
            y += 40;

            dlg.Controls.Add(new Label { Text = "Description", Location = new Point(lx, y), Size = new Size(720, 20), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 22;
            var txtDesc = new TextBox { Location = new Point(fx, y), Size = new Size(720, 40), Text = isNew ? "" : je.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 9.5f), Multiline = true };
            dlg.Controls.Add(txtDesc);
            y += 52;

            dlg.Controls.Add(new Label { Text = "Entry Lines", Location = new Point(lx, y), Size = new Size(200, 20), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 22;

            var dgvLines = new DataGridView
            {
                Location = new Point(fx, y),
                Size = new Size(720, 220),
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 9f),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            var colAccount = new DataGridViewComboBoxColumn { HeaderText = "Account", Name = "colLineAccount", DisplayMember = "Text", ValueMember = "Value", FillWeight = 45f };
            foreach (var acc in _accounts)
                colAccount.Items.Add(new { Text = acc.AccountCode + " - " + acc.AccountName, Value = acc.AccountID });

            var colDebit = new DataGridViewTextBoxColumn { HeaderText = "Debit", Name = "colLineDebit", FillWeight = 20f };
            var colCredit = new DataGridViewTextBoxColumn { HeaderText = "Credit", Name = "colLineCredit", FillWeight = 20f };
            var colNote = new DataGridViewTextBoxColumn { HeaderText = "Note", Name = "colLineNote", FillWeight = 30f };

            dgvLines.Columns.AddRange(colAccount, colDebit, colCredit, colNote);
            dlg.Controls.Add(dgvLines);
            y += 226;

            var btnAddLine = new Button { Text = "+ Add Line", Location = new Point(fx, y), Size = new Size(120, 30), BackColor = Color.FromArgb(60, 120, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnAddLine.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnAddLine);

            var btnRemoveLine = new Button { Text = "- Remove Line", Location = new Point(fx + 130, y), Size = new Size(120, 30), BackColor = Color.FromArgb(200, 50, 50), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnRemoveLine.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnRemoveLine);

            var lblTotals = new Label { Text = "Debit: 0.000   Credit: 0.000   Remaining: 0.000", Location = new Point(fx + 270, y + 5), Size = new Size(450, 22), Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), ForeColor = Color.FromArgb(200, 50, 50) };
            dlg.Controls.Add(lblTotals);
            y += 40;

            void RecalcTotals()
            {
                decimal totalDebit = 0, totalCredit = 0;
                foreach (DataGridViewRow row in dgvLines.Rows)
                {
                    decimal.TryParse(row.Cells["colLineDebit"].Value?.ToString(), out decimal d);
                    decimal.TryParse(row.Cells["colLineCredit"].Value?.ToString(), out decimal c);
                    totalDebit += d;
                    totalCredit += c;
                }
                decimal remaining = totalDebit - totalCredit;
                lblTotals.Text = string.Format("Debit: {0:N3}   Credit: {1:N3}   Remaining: {2:N3}", totalDebit, totalCredit, remaining);
                lblTotals.ForeColor = remaining == 0 ? Color.FromArgb(40, 140, 80) : Color.FromArgb(200, 50, 50);
            }

            dgvLines.CellValueChanged += (s, ev) => RecalcTotals();
            dgvLines.CurrentCellDirtyStateChanged += (s, ev) =>
            {
                if (dgvLines.IsCurrentCellDirty) dgvLines.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            btnAddLine.Click += (s, ev) => dgvLines.Rows.Add();
            btnRemoveLine.Click += (s, ev) =>
            {
                if (dgvLines.CurrentRow != null) dgvLines.Rows.Remove(dgvLines.CurrentRow);
                RecalcTotals();
            };

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(350, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 360, y), Size = new Size(360, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            dlg.ClientSize = new Size(760, y + 60);

            if (!isNew)
            {
                LoadExistingLinesAsync(je.JournalEntryID, dgvLines, existingDetails, RecalcTotals);
            }

            btnSave.Click += async (s, ev) =>
            {
                if (cmbCostCenter.SelectedIndex < 0) { MessageHelper.ShowWarning("Please select a cost center."); return; }
                dynamic selCC = cmbCostCenter.SelectedItem;

                decimal totalDebit = 0, totalCredit = 0;
                var lines = new List<(int accountId, decimal debit, decimal credit, string note)>();

                foreach (DataGridViewRow row in dgvLines.Rows)
                {
                    if (row.Cells["colLineAccount"].Value == null) continue;
                    var cellVal = row.Cells["colLineAccount"].Value;

                    int accId;
                    if (cellVal is int intVal)
                    {
                        accId = intVal;
                    }
                    else
                    {
                        dynamic accItem = cellVal;
                        accId = (int)accItem.Value;
                    }

                    decimal.TryParse(row.Cells["colLineDebit"].Value?.ToString(), out decimal d);
                    decimal.TryParse(row.Cells["colLineCredit"].Value?.ToString(), out decimal c);
                    if (d == 0 && c == 0) continue;

                    string note = row.Cells["colLineNote"].Value?.ToString() ?? "";
                    lines.Add((accId, d, c, note));
                    totalDebit += d;
                    totalCredit += c;
                }

                if (lines.Count == 0) { MessageHelper.ShowWarning("Please add at least one entry line."); return; }

                if (totalDebit != totalCredit)
                {
                    if (!MessageHelper.ShowConfirm(string.Format("Entry is not balanced. Debit: {0:N3}  Credit: {1:N3}\nSave as Draft anyway?", totalDebit, totalCredit)))
                        return;
                }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";

                    int journalEntryId;

                    if (isNew)
                    {
                        string number = "";
                        try
                        {
                            var numResult = await ApiHelper.GetAsync<dynamic>("journalentries/generate-number");
                            number = numResult?.JournalEntryNumber?.ToString() ?? "";
                        }
                        catch { number = "JE-" + DateTime.Now.ToString("yyyyMMddHHmmss"); }

                        var dto = new CreateJournalEntryDTO
                        {
                            JournalEntryNumber = number,
                            EntryDate = dtpDate.Value,
                            EntryType = cmbEntryType.SelectedItem?.ToString() ?? "Manual",
                            ReferenceType = txtRefType.Text.Trim(),
                            CostCenterID = (int)selCC.Value,
                            FiscalYear = (int)numYear.Value,
                            FiscalMonth = (int)numMonth.Value,
                            Description = txtDesc.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };

                        var created = await ApiHelper.PostAsync<dynamic>("journalentries", dto);
                        if (created == null) throw new Exception("Failed to create journal entry.");
                        journalEntryId = (int)created.JournalEntryID;
                    }
                    else
                    {
                        var dto = new UpdateJournalEntryDTO
                        {
                            JournalEntryID = je.JournalEntryID,
                            EntryDate = dtpDate.Value,
                            CostCenterID = (int)selCC.Value,
                            Description = txtDesc.Text.Trim()
                        };
                        var updated = await ApiHelper.PutAsync<JournalEntry>("journalentries/" + je.JournalEntryID, dto);
                        if (updated == null) throw new Exception("Failed to update journal entry.");
                        journalEntryId = je.JournalEntryID;

                        foreach (var existing in existingDetails)
                            await ApiHelper.DeleteAsync("journalentrydetails/" + existing.JournalEntryDetailID);
                    }

                    int lineNum = 1;
                    foreach (var line in lines)
                    {
                        var detailDto = new CreateJournalEntryDetailDTO
                        {
                            JournalEntryID = journalEntryId,
                            LineNumber = lineNum++,
                            AccountID = line.accountId,
                            Amount = line.debit > 0 ? line.debit : line.credit,
                            IsDebit = line.debit > 0,
                            Description = line.note
                        };
                        await ApiHelper.PostAsync<object>("journalentrydetails", detailDto);
                    }

                    MessageHelper.ShowSuccess(isNew ? "Journal entry created!" : "Journal entry updated!");
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
                _ = LoadEntries();
        }

        private async void LoadExistingLinesAsync(int journalEntryId, DataGridView dgvLines, List<JournalEntryDetail> existingDetails, Action recalc)
        {
            try
            {
                var details = await ApiHelper.GetAsync<List<JournalEntryDetail>>("journalentrydetails/by-journal-entry/" + journalEntryId);
                if (details == null) return;

                existingDetails.AddRange(details);

                foreach (var d in details)
                {
                    int rowIdx = dgvLines.Rows.Add();
                    var row = dgvLines.Rows[rowIdx];

                    var accCol = (DataGridViewComboBoxColumn)dgvLines.Columns["colLineAccount"];
                    foreach (var itemObj in accCol.Items)
                    {
                        dynamic item = itemObj;
                        if (item.Value == d.AccountID) { row.Cells["colLineAccount"].Value = itemObj; break; }
                    }

                    row.Cells["colLineDebit"].Value = d.IsDebit ? d.Amount.ToString("F3") : "0.000";
                    row.Cells["colLineCredit"].Value = !d.IsDebit ? d.Amount.ToString("F3") : "0.000";
                    row.Cells["colLineNote"].Value = d.Description;
                }
                recalc();
            }
            catch { }
        }

        private async System.Threading.Tasks.Task PostEntry(JournalEntry je)
        {
            if (!MessageHelper.ShowConfirm($"Post entry \"{je.JournalEntryNumber}\"?\nThis cannot be undone.")) return;
            try
            {
                spinner.Start();
                var dto = new PostJournalEntryDTO { JournalEntryID = je.JournalEntryID, PostedBy = SessionManager.UserId };
                await ApiHelper.PostAsync<object>("journalentries/" + je.JournalEntryID + "/post", dto);
                MessageHelper.ShowSuccess("Journal entry posted successfully.");
                await LoadEntries();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private async System.Threading.Tasks.Task DeleteEntry(JournalEntry je)
        {
            if (!MessageHelper.ShowConfirm($"Delete entry \"{je.JournalEntryNumber}\"?\nThis action cannot be undone.")) return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("journalentries/" + je.JournalEntryID);
                MessageHelper.ShowSuccess("Journal entry deleted.");
                await LoadEntries();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindEntriesGrid(_entries); return; }
            string s = text.ToLower();
            var filtered = new List<JournalEntry>();
            foreach (var j in _entries)
                if ((j.JournalEntryNumber != null && j.JournalEntryNumber.ToLower().Contains(s)) ||
                    (j.EntryType != null && j.EntryType.ToLower().Contains(s)) ||
                    (j.Description != null && j.Description.ToLower().Contains(s)) ||
                    (j.Status != null && j.Status.ToLower().Contains(s)))
                    filtered.Add(j);
            BindEntriesGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEntryDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadEntries();
        }
    }
}