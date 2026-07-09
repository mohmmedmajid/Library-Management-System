using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Main
{
    public partial class FrmAuditLog : Form
    {
        private List<AuditLog> _logs = new List<AuditLog>();

        public FrmAuditLog()
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
        }

        private async void FrmAuditLog_Load(object sender, EventArgs e)
        {
            LoadActionFilter();
            await LoadLogs();
        }

        private void LoadActionFilter()
        {
            cmbAction.Items.Clear();
            cmbAction.Items.Add("All");
            cmbAction.Items.Add("Login");
            cmbAction.Items.Add("Logout");
            cmbAction.Items.Add("Insert");
            cmbAction.Items.Add("Update");
            cmbAction.Items.Add("Delete");
            cmbAction.SelectedIndex = 0;
        }

        private async System.Threading.Tasks.Task LoadLogs()
        {
            try
            {
                spinner.Start();

                var dto = new GetAllAuditLogsDTO
                {
                    Action = cmbAction.SelectedIndex == 0 ? null : cmbAction.SelectedItem.ToString(),
                    StartDate = dtpFrom.Value.Date,
                    EndDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1),
                    Top = 500
                };

                var result = await ApiHelper.PostAsync<List<AuditLog>>("auditlogs/all", dto);

                _logs = result ?? new List<AuditLog>();

                BindGrid(_logs);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading audit logs: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
            }
        }

        private void BindGrid(List<AuditLog> list)
        {
            dgvLogs.Rows.Clear();
            foreach (var log in list)
            {
                dgvLogs.Rows.Add(
                    log.AuditID,
                    log.UserName,
                    log.Action,
                    log.TableName,
                    log.RecordID.ToString(),
                    log.IPAddress,
                    log.ActionDate.ToString("yyyy-MM-dd HH:mm:ss")
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                BindGrid(_logs);
                return;
            }

            string search = text.ToLower();
            var filtered = new List<AuditLog>();

            foreach (var log in _logs)
            {
                if (log.UserName.ToLower().Contains(search) ||
                    log.Action.ToLower().Contains(search) ||
                    log.TableName.ToLower().Contains(search) ||
                    log.IPAddress.ToLower().Contains(search))
                {
                    filtered.Add(log);
                }
            }

            BindGrid(filtered);
        }

        private void dgvLogs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLogs.SelectedRows.Count == 0) return;

            var row = dgvLogs.SelectedRows[0];
            int logId = Convert.ToInt32(row.Cells["colID"].Value);
            var log = _logs.Find(l => l.AuditID == logId);
            if (log == null) return;

            txtOldValue.Text = log.OldValue;
            txtNewValue.Text = log.NewValue;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > DateTime.Today)
            {
                MessageHelper.ShowWarning("From date cannot be in the future.");
                dtpFrom.Value = DateTime.Today;
                return;
            }

            if (dtpTo.Value.Date > DateTime.Today)
            {
                MessageHelper.ShowWarning("To date cannot be in the future.");
                dtpTo.Value = DateTime.Today;
                return;
            }

            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageHelper.ShowWarning("From date cannot be greater than To date.");
                return;
            }

            searchBox.Clear();
            await LoadLogs();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            cmbAction.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
            await LoadLogs();
        }

        private async void btnDeleteOld_Click(object sender, EventArgs e)
        {
            if (!MessageHelper.ShowConfirm("Delete logs older than 90 days?"))
                return;

            try
            {
                spinner.Start();

                var dto = new DeleteOldAuditLogsDTO { DaysToKeep = 90 };
                var json = JsonSerializer.Serialize(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var httpClient = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri("http://localhost:5096/api/auditlogs/delete-old"),
                    Content = content
                };

                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    MessageHelper.ShowSuccess("Old logs deleted successfully.");
                    await LoadLogs();
                }
                else
                {
                    MessageHelper.ShowError("Error deleting old logs.");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error deleting old logs: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
            }
        }
    }
}