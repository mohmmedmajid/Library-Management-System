using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class LateFeeRepository : ILateFeeRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public LateFeeRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(LateFee lateFee)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", lateFee.BorrowingID),
                new SqlParameter("@CustomerID", lateFee.CustomerID),
                new SqlParameter("@LateDays", lateFee.LateDays),
                new SqlParameter("@FeePerDay", lateFee.FeePerDay),
                new SqlParameter("@TotalFee", lateFee.TotalFee),
                new SqlParameter("@PaidAmount", lateFee.PaidAmount),
                new SqlParameter("@RemainingAmount", lateFee.RemainingAmount),
                new SqlParameter("@Status", lateFee.Status),
                new SqlParameter("@Notes", (object?)lateFee.Notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)lateFee.CreatedBy ?? DBNull.Value),
                new SqlParameter("@LateFeeID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_LateFees_Insert", parameters);

            return (int)parameters[10].Value;
        }

        public async Task<bool> UpdateAsync(LateFee lateFee)
        {
            var parameters = new[]
            {
                new SqlParameter("@LateFeeID", lateFee.LateFeeID),
                new SqlParameter("@PaidAmount", lateFee.PaidAmount),
                new SqlParameter("@RemainingAmount", lateFee.RemainingAmount),
                new SqlParameter("@Status", lateFee.Status),
                new SqlParameter("@Notes", (object?)lateFee.Notes ?? DBNull.Value)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_LateFees_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int lateFeeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@LateFeeID", lateFeeId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_LateFees_Delete", parameters);
            return result > 0;
        }

        public async Task<LateFee?> GetByIdAsync(int lateFeeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@LateFeeID", lateFeeId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LateFees_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToLateFee(dataTable.Rows[0]);
        }

        public async Task<List<LateFee>> GetByCustomerAsync(int customerId, string? status = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LateFees_GetByCustomer", parameters);

            var lateFees = new List<LateFee>();
            foreach (DataRow row in dataTable.Rows)
            {
                lateFees.Add(MapToLateFee(row));
            }

            return lateFees;
        }

        public async Task<List<LateFee>> GetAllAsync(string? status = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LateFees_GetAll", parameters);

            var lateFees = new List<LateFee>();
            foreach (DataRow row in dataTable.Rows)
            {
                lateFees.Add(MapToLateFee(row));
            }

            return lateFees;
        }

        public async Task<bool> UpdatePaymentAsync(int lateFeeId, decimal paymentAmount)
        {
            var parameters = new[]
            {
                new SqlParameter("@LateFeeID", lateFeeId),
                new SqlParameter("@PaymentAmount", paymentAmount)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_LateFees_UpdatePayment", parameters);
            return result > 0;
        }

        public async Task<bool> WaiveAsync(int lateFeeId, string? notes)
        {
            var parameters = new[]
            {
                new SqlParameter("@LateFeeID", lateFeeId),
                new SqlParameter("@Notes", (object?)notes ?? DBNull.Value)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_LateFees_Waive", parameters);
            return result > 0;
        }

        private LateFee MapToLateFee(DataRow row)
        {
            return new LateFee
            {
                LateFeeID = Convert.ToInt32(row["LateFeeID"]),
                BorrowingID = Convert.ToInt32(row["BorrowingID"]),
                CustomerID = Convert.ToInt32(row["CustomerID"]),
                LateDays = Convert.ToInt32(row["LateDays"]),
                FeePerDay = Convert.ToDecimal(row["FeePerDay"]),
                TotalFee = Convert.ToDecimal(row["TotalFee"]),
                PaidAmount = Convert.ToDecimal(row["PaidAmount"]),
                RemainingAmount = Convert.ToDecimal(row["RemainingAmount"]),
                Status = row["Status"].ToString() ?? "Pending",
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value
                    ? row["Notes"].ToString() : null,
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,
                BorrowingNumber = row.Table.Columns.Contains("BorrowingNumber") && row["BorrowingNumber"] != DBNull.Value
                    ? row["BorrowingNumber"].ToString() : null,
                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value
                    ? row["CustomerName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}