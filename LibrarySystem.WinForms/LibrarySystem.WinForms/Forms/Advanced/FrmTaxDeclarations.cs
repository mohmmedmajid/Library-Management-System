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
    public partial class FrmTaxDeclarations : Form
    {
        private List<TaxDeclaration> _declarations = new List<TaxDeclaration>();
        private List<TaxType> _taxTypes = new List<TaxType>();

        public FrmTaxDeclarations()
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

            dgvDeclarations.CellFormatting += DgvDeclarations_CellFormatting;
        }

        private void DgvDeclarations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int submitCol = dgvDeclarations.Columns["colSubmit"].Index;
            int payCol = dgvDeclarations.Columns["colPay"].Index;

            if (e.ColumnIndex == submitCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == payCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(40, 160, 100);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(40, 160, 100);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private async void FrmTaxDeclarations_Load(object sender, EventArgs e)
        {
            await LoadTaxTypes();
            await LoadDeclarations();
        }

        private async System.Threading.Tasks.Task LoadTaxTypes()
        {
            try
            {
                _taxTypes = await ApiHelper.GetAsync<List<TaxType>>("TaxTypes") ?? new List<TaxType>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading tax types: " + ex.Message);
            }
        }

        private async System.Threading.Tasks.Task LoadDeclarations()
        {
            try
            {
                spinner.Start();
                _declarations = await ApiHelper.GetAsync<List<TaxDeclaration>>("TaxDeclarations")
                                ?? new List<TaxDeclaration>();
                BindGrid(_declarations);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading tax declarations: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<TaxDeclaration> list)
        {
            dgvDeclarations.Rows.Clear();
            foreach (var d in list)
            {
                int rowIndex = dgvDeclarations.Rows.Add(
                    d.DeclarationID,
                    d.DeclarationNumber,
                    d.TaxName,
                    d.DeclarationType,
                    d.FiscalYear,
                    d.FiscalMonth,
                    d.PeriodStartDate.ToShortDateString(),
                    d.PeriodEndDate.ToShortDateString(),
                    d.NetTaxDue.ToString("N2"),
                    d.PaidAmount.ToString("N2"),
                    d.RemainingAmount.ToString("N2"),
                    d.Status,
                    d.Status == "Draft" ? "📤 Submit" : "",
                    d.Status == "Submitted" ? "💰 Pay" : ""
                );

                if (d.Status == "Paid")
                    dgvDeclarations.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(225, 245, 235);
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvDeclarations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvDeclarations.Rows[e.RowIndex].Cells["colID"].Value);
            var dec = _declarations.Find(x => x.DeclarationID == id);
            if (dec == null) return;

            if (e.ColumnIndex == dgvDeclarations.Columns["colSubmit"].Index)
                SubmitDeclaration(dec);
            else if (e.ColumnIndex == dgvDeclarations.Columns["colPay"].Index)
                OpenPayDialog(dec);
        }

        private void OpenAddDialog()
        {
            var dlg = new Form
            {
                Text = "➕ New Tax Declaration",
                Size = new Size(440, 480),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(440, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = "➕ New Tax Declaration", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(400, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 390;

            dlg.Controls.Add(new Label { Text = "Tax Type *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbTaxType = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList, DataSource = _taxTypes, DisplayMember = "TaxName", ValueMember = "TaxTypeID" };
            cmbTaxType.SelectedIndex = -1;
            dlg.Controls.Add(cmbTaxType); y += 42;

            dlg.Controls.Add(new Label { Text = "Declaration Type *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbDeclarationType = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbDeclarationType.Items.AddRange(new object[] { "Monthly", "Quarterly", "Annual" });
            dlg.Controls.Add(cmbDeclarationType); y += 42;

            dlg.Controls.Add(new Label { Text = "Fiscal Year *", Location = new Point(lx, y), Size = new Size(120, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Month *", Location = new Point(lx + 135, y), Size = new Size(80, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Quarter *", Location = new Point(lx + 270, y), Size = new Size(120, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtFiscalYear = new TextBox { Location = new Point(fx, y), Size = new Size(120, 30), Text = DateTime.Now.Year.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            var txtFiscalMonth = new TextBox { Location = new Point(fx + 135, y), Size = new Size(120, 30), Text = DateTime.Now.Month.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            var txtFiscalQuarter = new TextBox { Location = new Point(fx + 270, y), Size = new Size(120, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtFiscalYear); dlg.Controls.Add(txtFiscalMonth); dlg.Controls.Add(txtFiscalQuarter); y += 42;

            dlg.Controls.Add(new Label { Text = "Period Start *", Location = new Point(lx, y), Size = new Size(185, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Period End *", Location = new Point(lx + 205, y), Size = new Size(185, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var dtpStart = new DateTimePicker { Location = new Point(fx, y), Size = new Size(185, 30), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10f) };
            var dtpEnd = new DateTimePicker { Location = new Point(fx + 205, y), Size = new Size(185, 30), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(dtpStart); dlg.Controls.Add(dtpEnd); y += 55;

            var btnSave = new Button { Text = "💾 Create", Location = new Point(fx, y), Size = new Size(185, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 200, y), Size = new Size(185, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (cmbTaxType.SelectedValue == null)
                { MessageHelper.ShowWarning("Please select a tax type."); return; }
                if (string.IsNullOrWhiteSpace(cmbDeclarationType.Text))
                { MessageHelper.ShowWarning("Please select a declaration type."); return; }
                if (!ValidationHelper.IsValidInteger(txtFiscalYear.Text))
                { MessageHelper.ShowWarning("Please enter a valid fiscal year."); return; }
                if (!ValidationHelper.IsValidInteger(txtFiscalMonth.Text))
                { MessageHelper.ShowWarning("Please enter a valid fiscal month."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";

                    int? fiscalQuarter = null;
                    if (!string.IsNullOrWhiteSpace(txtFiscalQuarter.Text) && ValidationHelper.IsValidInteger(txtFiscalQuarter.Text))
                        fiscalQuarter = int.Parse(txtFiscalQuarter.Text);

                    var dto = new CreateTaxDeclarationDTO
                    {
                        TaxTypeID = (int)cmbTaxType.SelectedValue,
                        DeclarationType = cmbDeclarationType.Text,
                        FiscalYear = int.Parse(txtFiscalYear.Text),
                        FiscalMonth = int.Parse(txtFiscalMonth.Text),
                        FiscalQuarter = (!string.IsNullOrWhiteSpace(txtFiscalQuarter.Text) && ValidationHelper.IsValidInteger(txtFiscalQuarter.Text))
                        ? (int?)int.Parse(txtFiscalQuarter.Text)
                        : null,
                        PeriodStartDate = dtpStart.Value,
                        PeriodEndDate = dtpEnd.Value,
                        CreatedBy = SessionManager.UserId
                    };

                    if (await ApiHelper.PostAsync<TaxDeclaration>("TaxDeclarations", dto) != null)
                    { MessageHelper.ShowSuccess("Tax declaration created!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Create"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadDeclarations();
        }

        private async void SubmitDeclaration(TaxDeclaration dec)
        {
            if (dec.Status != "Draft")
            { MessageHelper.ShowWarning("Only draft declarations can be submitted."); return; }

            if (!MessageHelper.ShowConfirm($"Submit declaration \"{dec.DeclarationNumber}\"?"))
                return;

            try
            {
                spinner.Start();
                var dto = new SubmitTaxDeclarationDTO { DeclarationID = dec.DeclarationID };
                await ApiHelper.PutAsync<object>("TaxDeclarations/" + dec.DeclarationID + "/submit", dto);
                MessageHelper.ShowSuccess("Declaration submitted successfully.");
                await LoadDeclarations();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void OpenPayDialog(TaxDeclaration dec)
        {
            if (dec.Status != "Submitted")
            { MessageHelper.ShowWarning("Only submitted declarations can be paid."); return; }

            var dlg = new Form
            {
                Text = "💰 Pay Tax Declaration",
                Size = new Size(400, 320),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(400, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = "💰 Pay Declaration", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(360, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int fx = 20; int fw = 350;

            dlg.Controls.Add(new Label { Text = "Net Tax Due: " + dec.NetTaxDue.ToString("N2"), Location = new Point(fx, y), Size = new Size(fw, 24), Font = new Font("Segoe UI", 10f, FontStyle.Bold) });
            y += 35;

            dlg.Controls.Add(new Label { Text = "Paid Amount *", Location = new Point(fx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtPaidAmount = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtPaidAmount); y += 42;

            dlg.Controls.Add(new Label { Text = "Payment Reference *", Location = new Point(fx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtPaymentReference = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtPaymentReference); y += 50;

            var btnSave = new Button { Text = "💾 Confirm Payment", Location = new Point(fx, y), Size = new Size(350, 42), BackColor = Color.FromArgb(40, 160, 100), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            btnSave.Click += async (s, ev) =>
            {
                if (!ValidationHelper.IsValidPrice(txtPaidAmount.Text))
                { MessageHelper.ShowWarning("Please enter a valid paid amount."); return; }
                if (string.IsNullOrWhiteSpace(txtPaymentReference.Text))
                { MessageHelper.ShowWarning("Please enter a payment reference."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Processing...";
                    var dto = new PayTaxDeclarationDTO
                    {
                        DeclarationID = dec.DeclarationID,
                        PaidAmount = decimal.Parse(txtPaidAmount.Text),
                        PaymentReference = txtPaymentReference.Text.Trim()
                    };
                    await ApiHelper.PutAsync<object>("TaxDeclarations/" + dec.DeclarationID + "/pay", dto);
                    MessageHelper.ShowSuccess("Declaration marked as paid!");
                    dlg.DialogResult = DialogResult.OK; dlg.Close();
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Confirm Payment"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadDeclarations();
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_declarations); return; }
            string s = text.ToLower();
            var filtered = new List<TaxDeclaration>();
            foreach (var d in _declarations)
                if ((d.DeclarationNumber != null && d.DeclarationNumber.ToLower().Contains(s)) ||
                    (d.TaxName != null && d.TaxName.ToLower().Contains(s)) ||
                    (d.Status != null && d.Status.ToLower().Contains(s)))
                    filtered.Add(d);
            BindGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenAddDialog();

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadDeclarations();
        }
    }
}