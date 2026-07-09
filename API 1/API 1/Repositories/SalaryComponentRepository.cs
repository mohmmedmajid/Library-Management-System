using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class SalaryComponentRepository : ISalaryComponentRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public SalaryComponentRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(SalaryComponent component)
        {
            var parameters = new[]
            {
                new SqlParameter("@ComponentCode", component.ComponentCode),
                new SqlParameter("@ComponentName", component.ComponentName),
                new SqlParameter("@ComponentNameAr", component.ComponentNameAr),
                new SqlParameter("@ComponentType", component.ComponentType),
                new SqlParameter("@IsFixed", component.IsFixed),
                new SqlParameter("@IsTaxable", component.IsTaxable),
                new SqlParameter("@DefaultAmount", component.DefaultAmount),
                new SqlParameter("@Description", (object?)component.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)component.CreatedBy ?? DBNull.Value),
                new SqlParameter("@ComponentID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_SalaryComponents_Insert", parameters);
                return (int)parameters[9].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting salary component: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(SalaryComponent component)
        {
            var parameters = new[]
            {
                new SqlParameter("@ComponentID", component.ComponentID),
                new SqlParameter("@ComponentCode", component.ComponentCode),
                new SqlParameter("@ComponentName", component.ComponentName),
                new SqlParameter("@ComponentNameAr", component.ComponentNameAr),
                new SqlParameter("@ComponentType", component.ComponentType),
                new SqlParameter("@IsFixed", component.IsFixed),
                new SqlParameter("@IsTaxable", component.IsTaxable),
                new SqlParameter("@DefaultAmount", component.DefaultAmount),
                new SqlParameter("@Description", (object?)component.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", component.IsActive)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_SalaryComponents_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating salary component: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int componentId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ComponentID", componentId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_SalaryComponents_Delete", parameters);
            return result > 0;
        }

        public async Task<SalaryComponent?> GetByIdAsync(int componentId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ComponentID", componentId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SalaryComponents_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToSalaryComponent(dataTable.Rows[0]);
        }

        public async Task<List<SalaryComponent>> GetAllAsync(string? componentType = null, bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@ComponentType", (object?)componentType ?? DBNull.Value),
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SalaryComponents_GetAll", parameters);

            var components = new List<SalaryComponent>();
            foreach (DataRow row in dataTable.Rows)
            {
                components.Add(MapToSalaryComponent(row));
            }

            return components;
        }

        private SalaryComponent MapToSalaryComponent(DataRow row)
        {
            return new SalaryComponent
            {
                ComponentID = Convert.ToInt32(row["ComponentID"]),
                ComponentCode = row["ComponentCode"].ToString() ?? string.Empty,
                ComponentName = row["ComponentName"].ToString() ?? string.Empty,
                ComponentNameAr = row["ComponentNameAr"].ToString() ?? string.Empty,
                ComponentType = row.Table.Columns.Contains("ComponentType") && row["ComponentType"] != DBNull.Value
                    ? row["ComponentType"].ToString() ?? string.Empty : string.Empty,
                IsFixed = row.Table.Columns.Contains("IsFixed") && row["IsFixed"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsFixed"]) : true,
                IsTaxable = row.Table.Columns.Contains("IsTaxable") && row["IsTaxable"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsTaxable"]) : true,
                DefaultAmount = row.Table.Columns.Contains("DefaultAmount") && row["DefaultAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["DefaultAmount"]) : 0,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null
            };
        }
    }
}