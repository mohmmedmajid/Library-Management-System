using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class EmployeeSalaryComponentRepository : IEmployeeSalaryComponentRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public EmployeeSalaryComponentRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(EmployeeSalaryComponent employeeComponent)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", employeeComponent.EmployeeID),
                new SqlParameter("@ComponentID", employeeComponent.ComponentID),
                new SqlParameter("@Amount", employeeComponent.Amount),
                new SqlParameter("@StartDate", employeeComponent.StartDate),
                new SqlParameter("@CreatedBy", (object?)employeeComponent.CreatedBy ?? DBNull.Value),
                new SqlParameter("@EmployeeSalaryComponentID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_EmployeeSalaryComponents_Insert", parameters);
                return (int)parameters[5].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting employee salary component: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(EmployeeSalaryComponent employeeComponent)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeSalaryComponentID", employeeComponent.EmployeeSalaryComponentID),
                new SqlParameter("@Amount", employeeComponent.Amount),
                new SqlParameter("@IsActive", employeeComponent.IsActive)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_EmployeeSalaryComponents_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int employeeSalaryComponentId)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeSalaryComponentID", employeeSalaryComponentId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_EmployeeSalaryComponents_Delete", parameters);
            return result > 0;
        }

        public async Task<List<EmployeeSalaryComponent>> GetByEmployeeAsync(int employeeId, bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_EmployeeSalaryComponents_GetByEmployee", parameters);

            var components = new List<EmployeeSalaryComponent>();
            foreach (DataRow row in dataTable.Rows)
            {
                components.Add(MapToEmployeeSalaryComponent(row));
            }

            return components;
        }

        public async Task<EmployeeSalaryComponent?> GetTotalsAsync(int employeeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", employeeId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_EmployeeSalaryComponents_GetTotals", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new EmployeeSalaryComponent
            {
                EmployeeID = Convert.ToInt32(row["EmployeeID"])
            };
        }

        private EmployeeSalaryComponent MapToEmployeeSalaryComponent(DataRow row)
        {
            return new EmployeeSalaryComponent
            {
                EmployeeSalaryComponentID = Convert.ToInt32(row["EmployeeSalaryComponentID"]),
                EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                ComponentID = Convert.ToInt32(row["ComponentID"]),
                Amount = row.Table.Columns.Contains("Amount") && row["Amount"] != DBNull.Value
                    ? Convert.ToDecimal(row["Amount"]) : 0,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                StartDate = row.Table.Columns.Contains("StartDate") && row["StartDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["StartDate"]) : DateTime.Now,
                EndDate = row.Table.Columns.Contains("EndDate") && row["EndDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["EndDate"]) : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                ComponentCode = row.Table.Columns.Contains("ComponentCode") && row["ComponentCode"] != DBNull.Value
                    ? row["ComponentCode"].ToString() : null,
                ComponentName = row.Table.Columns.Contains("ComponentName") && row["ComponentName"] != DBNull.Value
                    ? row["ComponentName"].ToString() : null,
                ComponentNameAr = row.Table.Columns.Contains("ComponentNameAr") && row["ComponentNameAr"] != DBNull.Value
                    ? row["ComponentNameAr"].ToString() : null,
                ComponentType = row.Table.Columns.Contains("ComponentType") && row["ComponentType"] != DBNull.Value
                    ? row["ComponentType"].ToString() : null
            };
        }
    }
}