using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public SessionRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<(int SessionID, string SessionToken)> CreateAsync(Session session)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", session.UserID),
                new SqlParameter("@IPAddress", (object?)session.IPAddress ?? DBNull.Value),
                new SqlParameter("@UserAgent", (object?)session.UserAgent ?? DBNull.Value),
                new SqlParameter("@DeviceType", (object?)session.DeviceType ?? DBNull.Value),
                new SqlParameter("@SessionToken", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output },
                new SqlParameter("@SessionID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_Sessions_Create", parameters);
                return ((int)parameters[5].Value, parameters[4].Value.ToString() ?? string.Empty);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error creating session: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateActivityAsync(string sessionToken)
        {
            var parameters = new[]
            {
                new SqlParameter("@SessionToken", sessionToken)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_Sessions_UpdateActivity", parameters);
            return result > 0;
        }

        public async Task<bool> EndAsync(string sessionToken)
        {
            var parameters = new[]
            {
                new SqlParameter("@SessionToken", sessionToken)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_Sessions_End", parameters);
            return result > 0;
        }

        public async Task<bool> EndAllForUserAsync(int userId)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", userId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_Sessions_EndAllForUser", parameters);
            return result > 0;
        }

        public async Task<Session?> GetByTokenAsync(string sessionToken)
        {
            var parameters = new[]
            {
                new SqlParameter("@SessionToken", sessionToken)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Sessions_GetByToken", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToSession(dataTable.Rows[0]);
        }

        public async Task<List<Session>> GetActiveByUserAsync(int userId)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", userId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Sessions_GetActiveByUser", parameters);

            var sessions = new List<Session>();
            foreach (DataRow row in dataTable.Rows)
            {
                sessions.Add(MapToSession(row));
            }

            return sessions;
        }

        public async Task<List<Session>> GetAllActiveAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Sessions_GetAllActive", null);

            var sessions = new List<Session>();
            foreach (DataRow row in dataTable.Rows)
            {
                sessions.Add(MapToSession(row));
            }

            return sessions;
        }

        public async Task<List<Session>> GetHistoryAsync(int? userId = null, DateTime? startDate = null, DateTime? endDate = null, int top = 100)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", (object?)userId ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value),
                new SqlParameter("@Top", top)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Sessions_GetHistory", parameters);

            var sessions = new List<Session>();
            foreach (DataRow row in dataTable.Rows)
            {
                sessions.Add(MapToSession(row));
            }

            return sessions;
        }

        public async Task<int> CleanInactiveAsync(int inactiveMinutes = 60)
        {
            var parameters = new[]
            {
                new SqlParameter("@InactiveMinutes", inactiveMinutes)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Sessions_CleanInactive", parameters);

            if (dataTable.Rows.Count == 0)
                return 0;

            return Convert.ToInt32(dataTable.Rows[0]["EndedSessions"]);
        }

        public async Task<int> CleanOldAsync(int daysToKeep = 30)
        {
            var parameters = new[]
            {
                new SqlParameter("@DaysToKeep", daysToKeep)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Sessions_CleanOld", parameters);

            if (dataTable.Rows.Count == 0)
                return 0;

            return Convert.ToInt32(dataTable.Rows[0]["DeletedSessions"]);
        }

        private Session MapToSession(DataRow row)
        {
            return new Session
            {
                SessionID = Convert.ToInt32(row["SessionID"]),
                SessionToken = row["SessionToken"].ToString() ?? string.Empty,
                UserID = Convert.ToInt32(row["UserID"]),
                LoginDate = Convert.ToDateTime(row["LoginDate"]),
                LastActivityDate = Convert.ToDateTime(row["LastActivityDate"]),
                LogoutDate = row["LogoutDate"] == DBNull.Value ? null : Convert.ToDateTime(row["LogoutDate"]),
                IPAddress = row["IPAddress"] == DBNull.Value ? null : row["IPAddress"].ToString(),
                UserAgent = row.Table.Columns.Contains("UserAgent") && row["UserAgent"] != DBNull.Value
                    ? row["UserAgent"].ToString() : null,
                DeviceType = row["DeviceType"] == DBNull.Value ? null : row["DeviceType"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),

                Username = row.Table.Columns.Contains("Username") && row["Username"] != DBNull.Value
                    ? row["Username"].ToString() : null,
                FullName = row.Table.Columns.Contains("FullName") && row["FullName"] != DBNull.Value
                    ? row["FullName"].ToString() : null,
                RoleID = row.Table.Columns.Contains("RoleID") && row["RoleID"] != DBNull.Value
                    ? Convert.ToInt32(row["RoleID"]) : null,
                RoleName = row.Table.Columns.Contains("RoleName") && row["RoleName"] != DBNull.Value
                    ? row["RoleName"].ToString() : null,
                MinutesSinceLastActivity = row.Table.Columns.Contains("MinutesSinceLastActivity") && row["MinutesSinceLastActivity"] != DBNull.Value
                    ? Convert.ToInt32(row["MinutesSinceLastActivity"]) : null,
                SessionDurationMinutes = row.Table.Columns.Contains("SessionDurationMinutes") && row["SessionDurationMinutes"] != DBNull.Value
                    ? Convert.ToInt32(row["SessionDurationMinutes"]) : null
            };
        }
    }
}