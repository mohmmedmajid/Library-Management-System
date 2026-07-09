using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class SystemSettingRepository : ISystemSettingRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public SystemSettingRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(SystemSetting setting)
        {
            var parameters = new[]
            {
                new SqlParameter("@SettingKey", setting.SettingKey),
                new SqlParameter("@SettingValue", setting.SettingValue),
                new SqlParameter("@Description", (object?)setting.Description ?? DBNull.Value),
                new SqlParameter("@DataType", setting.DataType),
                new SqlParameter("@LastUpdatedBy", (object?)setting.LastUpdatedBy ?? DBNull.Value),
                new SqlParameter("@SettingID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_SystemSettings_Insert", parameters));

            return (int)parameters[5].Value;
        }

     
        public async Task<bool> UpdateAsync(SystemSetting setting)
        {
            var parameters = new[]
            {
                new SqlParameter("@SettingID", setting.SettingID),
                new SqlParameter("@SettingValue", setting.SettingValue),
                new SqlParameter("@LastUpdatedBy", (object?)setting.LastUpdatedBy ?? DBNull.Value)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_SystemSettings_Update", parameters));
            return result > 0;
        }

   
        public async Task<bool> DeleteAsync(int settingId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SettingID", settingId)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_SystemSettings_Delete", parameters));
            return result > 0;
        }

  
        public async Task<SystemSetting?> GetByIdAsync(int settingId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SettingID", settingId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SystemSettings_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToSystemSetting(dataTable.Rows[0]);
        }

    
        public async Task<string?> GetByKeyAsync(string settingKey)
        {
            var parameters = new[]
            {
                new SqlParameter("@SettingKey", settingKey)
            };

            var result = await _dbHelper.ExecuteScalarAsync("SP_SystemSettings_GetByKey", parameters);

            return result?.ToString();
        }

      
        public async Task<List<SystemSetting>> GetAllAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SystemSettings_GetAll", null);

            var settings = new List<SystemSetting>();
            foreach (DataRow row in dataTable.Rows)
            {
                settings.Add(MapToSystemSetting(row));
            }

            return settings;
        }

        private SystemSetting MapToSystemSetting(DataRow row)
        {
            return new SystemSetting
            {
                SettingID = Convert.ToInt32(row["SettingID"]),
                SettingKey = row["SettingKey"].ToString() ?? string.Empty,
                SettingValue = row["SettingValue"].ToString() ?? string.Empty,
                Description = row["Description"] == DBNull.Value ? null : row["Description"].ToString(),
                DataType = row["DataType"].ToString() ?? "String",
                LastUpdatedDate = Convert.ToDateTime(row["LastUpdatedDate"]),
                LastUpdatedBy = row.Table.Columns.Contains("LastUpdatedBy") && row["LastUpdatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["LastUpdatedBy"])
                    : null,
                UpdatedByName = row.Table.Columns.Contains("UpdatedByName") && row["UpdatedByName"] != DBNull.Value
                    ? row["UpdatedByName"].ToString()
                    : null
            };
        }
    }
}