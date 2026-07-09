using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class LoginAttemptRepository : ILoginAttemptRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public LoginAttemptRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task LogAsync(LoginAttempt attempt)
        {
            var parameters = new[]
            {
                new SqlParameter("@Username", attempt.Username),
                new SqlParameter("@IPAddress", (object?)attempt.IPAddress ?? DBNull.Value),
                new SqlParameter("@IsSuccessful", attempt.IsSuccessful),
                new SqlParameter("@FailureReason", (object?)attempt.FailureReason ?? DBNull.Value),
                new SqlParameter("@UserAgent", (object?)attempt.UserAgent ?? DBNull.Value),
                new SqlParameter("@DeviceType", (object?)attempt.DeviceType ?? DBNull.Value)
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_LoginAttempts_Log", parameters);
        }

        public async Task<int> GetRecentFailedCountAsync(string username, int minutesAgo = 30)
        {
            var parameters = new[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@MinutesAgo", minutesAgo)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LoginAttempts_GetRecentFailed", parameters);

            if (dataTable.Rows.Count == 0)
                return 0;

            return Convert.ToInt32(dataTable.Rows[0]["FailedAttempts"]);
        }

        public async Task<List<LoginAttempt>> GetByUsernameAsync(string username, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LoginAttempts_GetByUsername", parameters);

            var attempts = new List<LoginAttempt>();
            foreach (DataRow row in dataTable.Rows)
            {
                attempts.Add(MapToLoginAttempt(row));
            }

            return attempts;
        }

        public async Task<List<LoginAttempt>> GetAllAsync(bool? isSuccessful = null, DateTime? startDate = null, DateTime? endDate = null, int top = 100)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsSuccessful", (object?)isSuccessful ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value),
                new SqlParameter("@Top", top)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LoginAttempts_GetAll", parameters);

            var attempts = new List<LoginAttempt>();
            foreach (DataRow row in dataTable.Rows)
            {
                attempts.Add(MapToLoginAttempt(row));
            }

            return attempts;
        }

        public async Task<List<LoginAttempt>> GetStatsAsync(DateTime startDate, DateTime endDate)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LoginAttempts_GetStats", parameters);

            var attempts = new List<LoginAttempt>();
            foreach (DataRow row in dataTable.Rows)
            {
                attempts.Add(MapToLoginAttempt(row));
            }

            return attempts;
        }

        public async Task<int> CleanOldAsync(int daysToKeep = 90)
        {
            var parameters = new[]
            {
                new SqlParameter("@DaysToKeep", daysToKeep)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LoginAttempts_CleanOld", parameters);

            if (dataTable.Rows.Count == 0)
                return 0;

            return Convert.ToInt32(dataTable.Rows[0]["DeletedRecords"]);
        }

        private LoginAttempt MapToLoginAttempt(DataRow row)
        {
            return new LoginAttempt
            {
                AttemptID = row.Table.Columns.Contains("AttemptID") && row["AttemptID"] != DBNull.Value
                    ? Convert.ToInt32(row["AttemptID"]) : 0,
                Username = row["Username"].ToString() ?? string.Empty,
                AttemptDate = row.Table.Columns.Contains("AttemptDate") && row["AttemptDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["AttemptDate"]) : DateTime.Now,
                IPAddress = row.Table.Columns.Contains("IPAddress") && row["IPAddress"] != DBNull.Value
                    ? row["IPAddress"].ToString() : null,
                IsSuccessful = row.Table.Columns.Contains("IsSuccessful") && row["IsSuccessful"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsSuccessful"]) : false,
                FailureReason = row.Table.Columns.Contains("FailureReason") && row["FailureReason"] != DBNull.Value
                    ? row["FailureReason"].ToString() : null,
                UserAgent = row.Table.Columns.Contains("UserAgent") && row["UserAgent"] != DBNull.Value
                    ? row["UserAgent"].ToString() : null,
                DeviceType = row.Table.Columns.Contains("DeviceType") && row["DeviceType"] != DBNull.Value
                    ? row["DeviceType"].ToString() : null
            };
        }
    }
}