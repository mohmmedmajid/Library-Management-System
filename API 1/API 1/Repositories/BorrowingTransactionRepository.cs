using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class BorrowingTransactionRepository : IBorrowingTransactionRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public BorrowingTransactionRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(BorrowingTransaction borrowing)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingNumber", borrowing.BorrowingNumber),
                new SqlParameter("@CustomerID", borrowing.CustomerID),
                new SqlParameter("@BorrowingDate", borrowing.BorrowingDate),
                new SqlParameter("@ExpectedReturnDate", borrowing.ExpectedReturnDate),
                new SqlParameter("@TotalDays", borrowing.TotalDays),
                new SqlParameter("@TotalAmount", borrowing.TotalAmount),
                new SqlParameter("@PaidAmount", borrowing.PaidAmount),
                new SqlParameter("@Status", borrowing.Status),
                new SqlParameter("@Notes", (object?)borrowing.Notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)borrowing.CreatedBy ?? DBNull.Value),
                new SqlParameter("@BorrowingID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_BorrowingTransactions_Insert", parameters);
                return (int)parameters[10].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting borrowing transaction: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(BorrowingTransaction borrowing)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", borrowing.BorrowingID),
                new SqlParameter("@ExpectedReturnDate", borrowing.ExpectedReturnDate),
                new SqlParameter("@Status", borrowing.Status),
                new SqlParameter("@Notes", (object?)borrowing.Notes ?? DBNull.Value)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_BorrowingTransactions_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int borrowingId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", borrowingId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_BorrowingTransactions_Delete", parameters);
            return result > 0;
        }

        public async Task<BorrowingTransaction?> GetByIdAsync(int borrowingId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", borrowingId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_BorrowingTransactions_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToBorrowingTransaction(dataTable.Rows[0]);
        }

        public async Task<List<BorrowingTransaction>> GetAllAsync(int? customerId = null, string? status = null,
            DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", (object?)customerId ?? DBNull.Value),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_BorrowingTransactions_GetAll", parameters);

            var borrowings = new List<BorrowingTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                borrowings.Add(MapToBorrowingTransaction(row));
            }

            return borrowings;
        }

        public async Task<List<BorrowingTransaction>> GetActiveAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_BorrowingTransactions_GetActive", null);

            var borrowings = new List<BorrowingTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                borrowings.Add(MapToBorrowingTransaction(row));
            }

            return borrowings;
        }

        public async Task<List<BorrowingTransaction>> GetLateAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_BorrowingTransactions_GetLate", null);

            var borrowings = new List<BorrowingTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                borrowings.Add(MapToBorrowingTransaction(row));
            }

            return borrowings;
        }

        public async Task<bool> UpdateStatusAsync(int borrowingId, string status)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", borrowingId),
                new SqlParameter("@Status", status)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_BorrowingTransactions_UpdateStatus", parameters);
            return result > 0;
        }

        private BorrowingTransaction MapToBorrowingTransaction(DataRow row)
        {
            return new BorrowingTransaction
            {
                BorrowingID = Convert.ToInt32(row["BorrowingID"]),
                BorrowingNumber = row["BorrowingNumber"].ToString() ?? string.Empty,
                CustomerID = Convert.ToInt32(row["CustomerID"]),
                BorrowingDate = row.Table.Columns.Contains("BorrowingDate") && row["BorrowingDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["BorrowingDate"]) : DateTime.Now,
                ExpectedReturnDate = row.Table.Columns.Contains("ExpectedReturnDate") && row["ExpectedReturnDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["ExpectedReturnDate"]) : DateTime.Now,
                TotalDays = row.Table.Columns.Contains("TotalDays") && row["TotalDays"] != DBNull.Value
                    ? Convert.ToInt32(row["TotalDays"]) : 0,
                TotalAmount = row.Table.Columns.Contains("TotalAmount") && row["TotalAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalAmount"]) : 0,
                PaidAmount = row.Table.Columns.Contains("PaidAmount") && row["PaidAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["PaidAmount"]) : 0,
                Status = row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value
                    ? row["Status"].ToString() ?? "Borrowed" : "Borrowed",
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value
                    ? row["Notes"].ToString() : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value
                    ? row["CustomerName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null,              
            };
        }
    }
}
