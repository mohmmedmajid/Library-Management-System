using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class EmployeeAdvanceRepository : IEmployeeAdvanceRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public EmployeeAdvanceRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<string> GenerateNumberAsync()
        {
            var parameters = new[]
            {
                new SqlParameter("@AdvanceNumber", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_EmployeeAdvances_GenerateNumber", parameters);

            return parameters[0].Value?.ToString() ?? string.Empty;
        }

        public async Task<int> InsertAsync(EmployeeAdvance advance)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", advance.EmployeeID),
                new SqlParameter("@AdvanceDate", advance.AdvanceDate),
                new SqlParameter("@Amount", advance.Amount),
                new SqlParameter("@Reason", (object?)advance.Reason ?? DBNull.Value),
                new SqlParameter("@InstallmentMonths", advance.InstallmentMonths),
                new SqlParameter("@ApprovedBy", (object?)advance.ApprovedBy ?? DBNull.Value),
                new SqlParameter("@Notes", (object?)advance.Notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)advance.CreatedBy ?? DBNull.Value),
                new SqlParameter("@AdvanceID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_EmployeeAdvances_Insert", parameters);
                return (int)parameters[8].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting employee advance: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(EmployeeAdvance advance)
        {
            var parameters = new[]
            {
                new SqlParameter("@AdvanceID", advance.AdvanceID),
                new SqlParameter("@Amount", advance.Amount),
                new SqlParameter("@Reason", (object?)advance.Reason ?? DBNull.Value),
                new SqlParameter("@InstallmentMonths", advance.InstallmentMonths),
                new SqlParameter("@Notes", (object?)advance.Notes ?? DBNull.Value)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_EmployeeAdvances_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating employee advance: {ex.Message}", ex);
            }
        }

        public async Task<bool> CancelAsync(int advanceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@AdvanceID", advanceId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_EmployeeAdvances_Cancel", parameters);
            return result > 0;
        }

        public async Task<EmployeeAdvance?> GetByIdAsync(int advanceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@AdvanceID", advanceId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_EmployeeAdvances_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToEmployeeAdvance(dataTable.Rows[0]);
        }

        public async Task<List<EmployeeAdvance>> GetByEmployeeAsync(int employeeId, string? status = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_EmployeeAdvances_GetByEmployee", parameters);

            var advances = new List<EmployeeAdvance>();
            foreach (DataRow row in dataTable.Rows)
            {
                advances.Add(MapToEmployeeAdvance(row));
            }

            return advances;
        }

        public async Task<List<EmployeeAdvance>> GetAllAsync(string? status = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_EmployeeAdvances_GetAll", parameters);

            var advances = new List<EmployeeAdvance>();
            foreach (DataRow row in dataTable.Rows)
            {
                advances.Add(MapToEmployeeAdvance(row));
            }

            return advances;
        }

        private EmployeeAdvance MapToEmployeeAdvance(DataRow row)
        {
            return new EmployeeAdvance
            {
                AdvanceID = Convert.ToInt32(row["AdvanceID"]),
                AdvanceNumber = row["AdvanceNumber"].ToString() ?? string.Empty,
                EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                AdvanceDate = row.Table.Columns.Contains("AdvanceDate") && row["AdvanceDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["AdvanceDate"]) : DateTime.Now,
                Amount = row.Table.Columns.Contains("Amount") && row["Amount"] != DBNull.Value
                    ? Convert.ToDecimal(row["Amount"]) : 0,
                Reason = row.Table.Columns.Contains("Reason") && row["Reason"] != DBNull.Value
                    ? row["Reason"].ToString() : null,
                InstallmentMonths = row.Table.Columns.Contains("InstallmentMonths") && row["InstallmentMonths"] != DBNull.Value
                    ? Convert.ToInt32(row["InstallmentMonths"]) : 0,
                MonthlyDeduction = row.Table.Columns.Contains("MonthlyDeduction") && row["MonthlyDeduction"] != DBNull.Value
                    ? Convert.ToDecimal(row["MonthlyDeduction"]) : 0,
                PaidAmount = row.Table.Columns.Contains("PaidAmount") && row["PaidAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["PaidAmount"]) : 0,
                RemainingAmount = row.Table.Columns.Contains("RemainingAmount") && row["RemainingAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["RemainingAmount"]) : 0,
                Status = row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value
                    ? row["Status"].ToString() ?? "Active" : "Active",
                ApprovedBy = row.Table.Columns.Contains("ApprovedBy") && row["ApprovedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["ApprovedBy"]) : null,
                ApprovedDate = row.Table.Columns.Contains("ApprovedDate") && row["ApprovedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["ApprovedDate"]) : null,
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value
                    ? row["Notes"].ToString() : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                EmployeeCode = row.Table.Columns.Contains("EmployeeCode") && row["EmployeeCode"] != DBNull.Value
                    ? row["EmployeeCode"].ToString() : null,
                EmployeeName = row.Table.Columns.Contains("EmployeeName") && row["EmployeeName"] != DBNull.Value
                    ? row["EmployeeName"].ToString() : null,
                ApprovedByName = row.Table.Columns.Contains("ApprovedByName") && row["ApprovedByName"] != DBNull.Value
                    ? row["ApprovedByName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}