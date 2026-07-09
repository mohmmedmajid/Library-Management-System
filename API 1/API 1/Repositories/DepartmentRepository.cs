using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public DepartmentRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(Department department)
        {
            var parameters = new[]
            {
                new SqlParameter("@DepartmentCode", department.DepartmentCode),
                new SqlParameter("@DepartmentName", department.DepartmentName),
                new SqlParameter("@DepartmentNameAr", department.DepartmentNameAr),
                new SqlParameter("@ManagerID", (object?)department.ManagerID ?? DBNull.Value),
                new SqlParameter("@CostCenterID", (object?)department.CostCenterID ?? DBNull.Value),
                new SqlParameter("@Description", (object?)department.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)department.CreatedBy ?? DBNull.Value),
                new SqlParameter("@DepartmentID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_Departments_Insert", parameters);
                return (int)parameters[7].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting department: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(Department department)
        {
            var parameters = new[]
            {
                new SqlParameter("@DepartmentID", department.DepartmentID),
                new SqlParameter("@DepartmentCode", department.DepartmentCode),
                new SqlParameter("@DepartmentName", department.DepartmentName),
                new SqlParameter("@DepartmentNameAr", department.DepartmentNameAr),
                new SqlParameter("@ManagerID", (object?)department.ManagerID ?? DBNull.Value),
                new SqlParameter("@CostCenterID", (object?)department.CostCenterID ?? DBNull.Value),
                new SqlParameter("@Description", (object?)department.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", department.IsActive)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Departments_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating department: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int departmentId)
        {
            var parameters = new[]
            {
                new SqlParameter("@DepartmentID", departmentId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Departments_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting department: {ex.Message}", ex);
            }
        }

        public async Task<Department?> GetByIdAsync(int departmentId)
        {
            var parameters = new[]
            {
                new SqlParameter("@DepartmentID", departmentId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Departments_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToDepartment(dataTable.Rows[0]);
        }

        public async Task<List<Department>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Departments_GetAll", parameters);

            var departments = new List<Department>();
            foreach (DataRow row in dataTable.Rows)
            {
                departments.Add(MapToDepartment(row));
            }

            return departments;
        }

        public async Task<List<Department>> GetByCostCenterAsync(int costCenterId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CostCenterID", costCenterId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Departments_GetByCostCenter", parameters);

            var departments = new List<Department>();
            foreach (DataRow row in dataTable.Rows)
            {
                departments.Add(MapToDepartment(row));
            }

            return departments;
        }

        private Department MapToDepartment(DataRow row)
        {
            return new Department
            {
                DepartmentID = Convert.ToInt32(row["DepartmentID"]),
                DepartmentCode = row["DepartmentCode"].ToString() ?? string.Empty,
                DepartmentName = row["DepartmentName"].ToString() ?? string.Empty,
                DepartmentNameAr = row["DepartmentNameAr"].ToString() ?? string.Empty,
                ManagerID = row.Table.Columns.Contains("ManagerID") && row["ManagerID"] != DBNull.Value
                    ? Convert.ToInt32(row["ManagerID"]) : null,
                CostCenterID = row.Table.Columns.Contains("CostCenterID") && row["CostCenterID"] != DBNull.Value
                    ? Convert.ToInt32(row["CostCenterID"]) : null,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                CostCenterName = row.Table.Columns.Contains("CostCenterName") && row["CostCenterName"] != DBNull.Value
                    ? row["CostCenterName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null,
                EmployeeCount = row.Table.Columns.Contains("EmployeeCount") && row["EmployeeCount"] != DBNull.Value
                    ? Convert.ToInt32(row["EmployeeCount"]) : 0
            };
        }
    }
}