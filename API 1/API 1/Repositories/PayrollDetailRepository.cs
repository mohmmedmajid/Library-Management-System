using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class PayrollDetailRepository : IPayrollDetailRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public PayrollDetailRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<List<PayrollDetail>> GetByPayrollIdAsync(int payrollId)
        {
            var parameters = new[]
            {
                new SqlParameter("@PayrollID", payrollId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_PayrollDetails_GetByPayrollID", parameters);

            var details = new List<PayrollDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapToPayrollDetail(row));
            }

            return details;
        }

        public async Task<List<PayrollDetail>> GetByEmployeeAsync(int employeeId, int? payrollYear = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@PayrollYear", (object?)payrollYear ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_PayrollDetails_GetByEmployee", parameters);

            var details = new List<PayrollDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapToPayrollDetail(row));
            }

            return details;
        }

        public async Task<PayrollDetail?> GetBreakdownAsync(int payrollDetailId)
        {
            var parameters = new[]
            {
                new SqlParameter("@PayrollDetailID", payrollDetailId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_PayrollDetails_GetBreakdown", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToPayrollDetail(dataTable.Rows[0]);
        }

        private PayrollDetail MapToPayrollDetail(DataRow row)
        {
            return new PayrollDetail
            {
                PayrollDetailID = Convert.ToInt32(row["PayrollDetailID"]),
                PayrollID = Convert.ToInt32(row["PayrollID"]),
                EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                BasicSalary = row.Table.Columns.Contains("BasicSalary") && row["BasicSalary"] != DBNull.Value
                    ? Convert.ToDecimal(row["BasicSalary"]) : 0,
                TotalAdditions = row.Table.Columns.Contains("TotalAdditions") && row["TotalAdditions"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalAdditions"]) : 0,
                TotalDeductions = row.Table.Columns.Contains("TotalDeductions") && row["TotalDeductions"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalDeductions"]) : 0,
                NetSalary = row.Table.Columns.Contains("NetSalary") && row["NetSalary"] != DBNull.Value
                    ? Convert.ToDecimal(row["NetSalary"]) : 0,
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value
                    ? row["Notes"].ToString() : null,

                EmployeeCode = row.Table.Columns.Contains("EmployeeCode") && row["EmployeeCode"] != DBNull.Value
                    ? row["EmployeeCode"].ToString() : null,
                EmployeeName = row.Table.Columns.Contains("EmployeeName") && row["EmployeeName"] != DBNull.Value
                    ? row["EmployeeName"].ToString() : null,
                Department = row.Table.Columns.Contains("Department") && row["Department"] != DBNull.Value
                    ? row["Department"].ToString() : null,
                JobTitle = row.Table.Columns.Contains("JobTitle") && row["JobTitle"] != DBNull.Value
                    ? row["JobTitle"].ToString() : null
            };
        }
    }
}