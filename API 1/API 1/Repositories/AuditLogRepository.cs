using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public AuditLogRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public async Task InsertAsync(AuditLog auditLog)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", (object?)auditLog.UserID ?? DBNull.Value),
                new SqlParameter("@Action", auditLog.Action),
                new SqlParameter("@TableName", (object?)auditLog.TableName ?? DBNull.Value),
                new SqlParameter("@RecordID", (object?)auditLog.RecordID ?? DBNull.Value),
                new SqlParameter("@OldValue", (object?)auditLog.OldValue ?? DBNull.Value),
                new SqlParameter("@NewValue", (object?)auditLog.NewValue ?? DBNull.Value),
                new SqlParameter("@IPAddress", (object?)auditLog.IPAddress ?? DBNull.Value)
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_AuditLog_Insert", parameters));
        }


        public async Task<List<AuditLog>> GetByUserAsync(int userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AuditLog_GetByUser", parameters);

            var auditLogs = new List<AuditLog>();
            foreach (DataRow row in dataTable.Rows)
            {
                auditLogs.Add(MapToAuditLog(row));
            }

            return auditLogs;
        }


        public async Task<List<AuditLog>> GetByTableAsync(string tableName, int? recordId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@TableName", tableName),
                new SqlParameter("@RecordID", (object?)recordId ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AuditLog_GetByTable", parameters);

            var auditLogs = new List<AuditLog>();
            foreach (DataRow row in dataTable.Rows)
            {
                auditLogs.Add(MapToAuditLog(row));
            }

            return auditLogs;
        }


        public async Task<List<AuditLog>> GetAllAsync(string? action = null, DateTime? startDate = null, DateTime? endDate = null, int top = 100)
        {
            var parameters = new[]
            {
                new SqlParameter("@Action", (object?)action ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value),
                new SqlParameter("@Top", top)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AuditLog_GetAll", parameters);

            var auditLogs = new List<AuditLog>();
            foreach (DataRow row in dataTable.Rows)
            {
                auditLogs.Add(MapToAuditLog(row));
            }

            return auditLogs;
        }


        public async Task<int> DeleteOldAsync(int daysToKeep = 90)
        {
            var parameters = new[]
            {
                new SqlParameter("@DaysToKeep", daysToKeep)
            };

            var result = await _dbHelper.ExecuteScalarAsync("SP_AuditLog_DeleteOld", parameters);

            return result != null ? Convert.ToInt32(result) : 0;
        }

        private AuditLog MapToAuditLog(DataRow row)
        {
            return new AuditLog
            {
                AuditID = Convert.ToInt32(row["AuditID"]),
                UserID = row["UserID"] == DBNull.Value ? null : Convert.ToInt32(row["UserID"]),
                UserName = row.Table.Columns.Contains("UserName") && row["UserName"] != DBNull.Value ? row["UserName"].ToString() : null,
                Action = row["Action"].ToString() ?? string.Empty,
                TableName = row["TableName"] == DBNull.Value ? null : row["TableName"].ToString(),
                RecordID = row["RecordID"] == DBNull.Value ? null : Convert.ToInt32(row["RecordID"]),
                OldValue = row.Table.Columns.Contains("OldValue") && row["OldValue"] != DBNull.Value ? row["OldValue"].ToString() : null,
                NewValue = row.Table.Columns.Contains("NewValue") && row["NewValue"] != DBNull.Value ? row["NewValue"].ToString() : null,
                IPAddress = row.Table.Columns.Contains("IPAddress") && row["IPAddress"] != DBNull.Value ? row["IPAddress"].ToString() : null,
                ActionDate = Convert.ToDateTime(row["ActionDate"])
            };
        }
    }
}
