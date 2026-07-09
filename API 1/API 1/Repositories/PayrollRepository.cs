using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public PayrollRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<string> GenerateNumberAsync(int payrollYear, int payrollMonth)
        {
            var parameters = new[]
            {
                new SqlParameter("@PayrollYear", payrollYear),
                new SqlParameter("@PayrollMonth", payrollMonth),
                new SqlParameter("@PayrollNumber", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_Payroll_GenerateNumber", parameters);

            return parameters[2].Value?.ToString() ?? string.Empty;
        }

        public async Task<int> CreateAsync(int payrollMonth, int payrollYear, int? createdBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@PayrollMonth", payrollMonth),
                new SqlParameter("@PayrollYear", payrollYear),
                new SqlParameter("@CreatedBy", (object?)createdBy ?? DBNull.Value),
                new SqlParameter("@PayrollID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_Payroll_Create", parameters);
                return (int)parameters[3].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error creating payroll: {ex.Message}", ex);
            }
        }

        public async Task<bool> ApproveAsync(int payrollId, int approvedBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@PayrollID", payrollId),
                new SqlParameter("@ApprovedBy", approvedBy)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Payroll_Approve", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error approving payroll: {ex.Message}", ex);
            }
        }

        public async Task<bool> PostAsync(int payrollId, int postedBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@PayrollID", payrollId),
                new SqlParameter("@PostedBy", postedBy)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Payroll_Post", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error posting payroll: {ex.Message}", ex);
            }
        }

        public async Task<bool> MarkAsPaidAsync(int payrollId, int paidBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@PayrollID", payrollId),
                new SqlParameter("@PaidBy", paidBy)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Payroll_MarkAsPaid", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error marking payroll as paid: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int payrollId)
        {
            var parameters = new[]
            {
                new SqlParameter("@PayrollID", payrollId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Payroll_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting payroll: {ex.Message}", ex);
            }
        }

        public async Task<Payroll?> GetByIdAsync(int payrollId)
        {
            var parameters = new[]
            {
                new SqlParameter("@PayrollID", payrollId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Payroll_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToPayroll(dataTable.Rows[0]);
        }

        public async Task<List<Payroll>> GetAllAsync(string? status = null, int? payrollYear = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@PayrollYear", (object?)payrollYear ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Payroll_GetAll", parameters);

            var payrolls = new List<Payroll>();
            foreach (DataRow row in dataTable.Rows)
            {
                payrolls.Add(MapToPayroll(row));
            }

            return payrolls;
        }

        private Payroll MapToPayroll(DataRow row)
        {
            return new Payroll
            {
                PayrollID = Convert.ToInt32(row["PayrollID"]),
                PayrollNumber = row["PayrollNumber"].ToString() ?? string.Empty,
                PayrollMonth = row.Table.Columns.Contains("PayrollMonth") && row["PayrollMonth"] != DBNull.Value
                    ? Convert.ToInt32(row["PayrollMonth"]) : 0,
                PayrollYear = row.Table.Columns.Contains("PayrollYear") && row["PayrollYear"] != DBNull.Value
                    ? Convert.ToInt32(row["PayrollYear"]) : 0,
                PayrollDate = row.Table.Columns.Contains("PayrollDate") && row["PayrollDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["PayrollDate"]) : DateTime.Now,
                TotalEmployees = row.Table.Columns.Contains("TotalEmployees") && row["TotalEmployees"] != DBNull.Value
                    ? Convert.ToInt32(row["TotalEmployees"]) : 0,
                TotalBasicSalary = row.Table.Columns.Contains("TotalBasicSalary") && row["TotalBasicSalary"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalBasicSalary"]) : 0,
                TotalAdditions = row.Table.Columns.Contains("TotalAdditions") && row["TotalAdditions"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalAdditions"]) : 0,
                TotalDeductions = row.Table.Columns.Contains("TotalDeductions") && row["TotalDeductions"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalDeductions"]) : 0,
                TotalNetSalary = row.Table.Columns.Contains("TotalNetSalary") && row["TotalNetSalary"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalNetSalary"]) : 0,
                Status = row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value
                    ? row["Status"].ToString() ?? "Draft" : "Draft",
                ApprovedDate = row.Table.Columns.Contains("ApprovedDate") && row["ApprovedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["ApprovedDate"]) : null,
                ApprovedBy = row.Table.Columns.Contains("ApprovedBy") && row["ApprovedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["ApprovedBy"]) : null,
                PostedDate = row.Table.Columns.Contains("PostedDate") && row["PostedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["PostedDate"]) : null,
                PostedBy = row.Table.Columns.Contains("PostedBy") && row["PostedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["PostedBy"]) : null,
                PaidDate = row.Table.Columns.Contains("PaidDate") && row["PaidDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["PaidDate"]) : null,
                PaidBy = row.Table.Columns.Contains("PaidBy") && row["PaidBy"] != DBNull.Value
                    ? Convert.ToInt32(row["PaidBy"]) : null,
                JournalEntryID = row.Table.Columns.Contains("JournalEntryID") && row["JournalEntryID"] != DBNull.Value
                    ? Convert.ToInt32(row["JournalEntryID"]) : null,
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value
                    ? row["Notes"].ToString() : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                ApprovedByName = row.Table.Columns.Contains("ApprovedByName") && row["ApprovedByName"] != DBNull.Value
                    ? row["ApprovedByName"].ToString() : null,
                PostedByName = row.Table.Columns.Contains("PostedByName") && row["PostedByName"] != DBNull.Value
                    ? row["PostedByName"].ToString() : null,
                PaidByName = row.Table.Columns.Contains("PaidByName") && row["PaidByName"] != DBNull.Value
                    ? row["PaidByName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}