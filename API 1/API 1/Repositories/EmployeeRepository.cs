using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public EmployeeRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(Employee employee)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeCode", employee.EmployeeCode),
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@FullNameAr", employee.FullNameAr),
                new SqlParameter("@NationalID", (object?)employee.NationalID ?? DBNull.Value),
                new SqlParameter("@BirthDate", (object?)employee.BirthDate ?? DBNull.Value),
                new SqlParameter("@Gender", (object?)employee.Gender ?? DBNull.Value),
                new SqlParameter("@Phone", (object?)employee.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object?)employee.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object?)employee.Address ?? DBNull.Value),
                new SqlParameter("@DepartmentID", (object?)employee.DepartmentID ?? DBNull.Value),
                new SqlParameter("@JobTitle", (object?)employee.JobTitle ?? DBNull.Value),
                new SqlParameter("@JobTitleAr", (object?)employee.JobTitleAr ?? DBNull.Value),
                new SqlParameter("@HireDate", employee.HireDate),
                new SqlParameter("@BasicSalary", employee.BasicSalary),
                new SqlParameter("@BankAccountNumber", (object?)employee.BankAccountNumber ?? DBNull.Value),
                new SqlParameter("@BankName", (object?)employee.BankName ?? DBNull.Value),
                new SqlParameter("@EmergencyContactName", (object?)employee.EmergencyContactName ?? DBNull.Value),
                new SqlParameter("@EmergencyContactPhone", (object?)employee.EmergencyContactPhone ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)employee.CreatedBy ?? DBNull.Value),
                new SqlParameter("@EmployeeID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_Employees_Insert", parameters);
                return (int)parameters[19].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting employee: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", employee.EmployeeID),
                new SqlParameter("@EmployeeCode", employee.EmployeeCode),
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@FullNameAr", employee.FullNameAr),
                new SqlParameter("@NationalID", (object?)employee.NationalID ?? DBNull.Value),
                new SqlParameter("@BirthDate", (object?)employee.BirthDate ?? DBNull.Value),
                new SqlParameter("@Gender", (object?)employee.Gender ?? DBNull.Value),
                new SqlParameter("@Phone", (object?)employee.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object?)employee.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object?)employee.Address ?? DBNull.Value),
                new SqlParameter("@DepartmentID", (object?)employee.DepartmentID ?? DBNull.Value),
                new SqlParameter("@JobTitle", (object?)employee.JobTitle ?? DBNull.Value),
                new SqlParameter("@JobTitleAr", (object?)employee.JobTitleAr ?? DBNull.Value),
                new SqlParameter("@BasicSalary", employee.BasicSalary),
                new SqlParameter("@BankAccountNumber", (object?)employee.BankAccountNumber ?? DBNull.Value),
                new SqlParameter("@BankName", (object?)employee.BankName ?? DBNull.Value),
                new SqlParameter("@EmergencyContactName", (object?)employee.EmergencyContactName ?? DBNull.Value),
                new SqlParameter("@EmergencyContactPhone", (object?)employee.EmergencyContactPhone ?? DBNull.Value),
                new SqlParameter("@Status", employee.Status),
                new SqlParameter("@IsActive", employee.IsActive)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Employees_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating employee: {ex.Message}", ex);
            }
        }

        public async Task<bool> TerminateAsync(int employeeId, DateTime terminationDate)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@TerminationDate", terminationDate)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_Employees_Terminate", parameters);
            return result > 0;
        }

        public async Task<Employee?> GetByIdAsync(int employeeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", employeeId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Employees_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToEmployee(dataTable.Rows[0]);
        }

        public async Task<List<Employee>> GetAllAsync(int? departmentId = null, string? status = null, bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@DepartmentID", (object?)departmentId ?? DBNull.Value),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Employees_GetAll", parameters);

            var employees = new List<Employee>();
            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(MapToEmployee(row));
            }

            return employees;
        }

        public async Task<List<Employee>> SearchAsync(string searchTerm)
        {
            var parameters = new[]
            {
                new SqlParameter("@SearchTerm", searchTerm)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Employees_Search", parameters);

            var employees = new List<Employee>();
            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(MapToEmployee(row));
            }

            return employees;
        }

        private Employee MapToEmployee(DataRow row)
        {
            return new Employee
            {
                EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                EmployeeCode = row["EmployeeCode"].ToString() ?? string.Empty,
                FullName = row["FullName"].ToString() ?? string.Empty,
                FullNameAr = row["FullNameAr"].ToString() ?? string.Empty,
                NationalID = row.Table.Columns.Contains("NationalID") && row["NationalID"] != DBNull.Value
                    ? row["NationalID"].ToString() : null,
                BirthDate = row.Table.Columns.Contains("BirthDate") && row["BirthDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["BirthDate"]) : null,
                Gender = row.Table.Columns.Contains("Gender") && row["Gender"] != DBNull.Value
                    ? row["Gender"].ToString() : null,
                Phone = row.Table.Columns.Contains("Phone") && row["Phone"] != DBNull.Value
                    ? row["Phone"].ToString() : null,
                Email = row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value
                    ? row["Email"].ToString() : null,
                Address = row.Table.Columns.Contains("Address") && row["Address"] != DBNull.Value
                    ? row["Address"].ToString() : null,
                DepartmentID = row.Table.Columns.Contains("DepartmentID") && row["DepartmentID"] != DBNull.Value
                    ? Convert.ToInt32(row["DepartmentID"]) : null,
                JobTitle = row.Table.Columns.Contains("JobTitle") && row["JobTitle"] != DBNull.Value
                    ? row["JobTitle"].ToString() : null,
                JobTitleAr = row.Table.Columns.Contains("JobTitleAr") && row["JobTitleAr"] != DBNull.Value
                    ? row["JobTitleAr"].ToString() : null,
                HireDate = row.Table.Columns.Contains("HireDate") && row["HireDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["HireDate"]) : DateTime.Now,
                TerminationDate = row.Table.Columns.Contains("TerminationDate") && row["TerminationDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["TerminationDate"]) : null,
                BasicSalary = row.Table.Columns.Contains("BasicSalary") && row["BasicSalary"] != DBNull.Value
                    ? Convert.ToDecimal(row["BasicSalary"]) : 0,
                BankAccountNumber = row.Table.Columns.Contains("BankAccountNumber") && row["BankAccountNumber"] != DBNull.Value
                    ? row["BankAccountNumber"].ToString() : null,
                BankName = row.Table.Columns.Contains("BankName") && row["BankName"] != DBNull.Value
                    ? row["BankName"].ToString() : null,
                EmergencyContactName = row.Table.Columns.Contains("EmergencyContactName") && row["EmergencyContactName"] != DBNull.Value
                    ? row["EmergencyContactName"].ToString() : null,
                EmergencyContactPhone = row.Table.Columns.Contains("EmergencyContactPhone") && row["EmergencyContactPhone"] != DBNull.Value
                    ? row["EmergencyContactPhone"].ToString() : null,
                Status = row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value
                    ? row["Status"].ToString() ?? "Active" : "Active",
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                DepartmentName = row.Table.Columns.Contains("DepartmentName") && row["DepartmentName"] != DBNull.Value
                    ? row["DepartmentName"].ToString() : null,
                DepartmentNameAr = row.Table.Columns.Contains("DepartmentNameAr") && row["DepartmentNameAr"] != DBNull.Value
                    ? row["DepartmentNameAr"].ToString() : null,
                YearsOfService = row.Table.Columns.Contains("YearsOfService") && row["YearsOfService"] != DBNull.Value
                    ? Convert.ToInt32(row["YearsOfService"]) : 0
            };
        }
    }
}