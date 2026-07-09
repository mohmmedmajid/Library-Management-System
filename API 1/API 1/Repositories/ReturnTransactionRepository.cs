using API_1.Data;
using API_1.Models;
using LibrarySystem.WinForms.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories.Interfaces
{
    public class ReturnTransactionRepository : IReturnTransactionRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public ReturnTransactionRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(ReturnTransaction returnTransaction)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", returnTransaction.BorrowingID),
                new SqlParameter("@ReturnDate", returnTransaction.ReturnDate),
                new SqlParameter("@ActualDaysUsed", returnTransaction.ActualDaysUsed),
                new SqlParameter("@LateDays", returnTransaction.LateDays),
                new SqlParameter("@LateFeeAmount", returnTransaction.LateFeeAmount),
                new SqlParameter("@RefundAmount", returnTransaction.RefundAmount),
                new SqlParameter("@Notes", (object?)returnTransaction.Notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)returnTransaction.CreatedBy ?? DBNull.Value),
                new SqlParameter("@ReturnID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_ReturnTransactions_Insert", parameters);
                return (int)parameters[8].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting return transaction: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(ReturnTransaction returnTransaction)
        {
            var parameters = new[]
            {
                new SqlParameter("@ReturnID", returnTransaction.ReturnID),
                new SqlParameter("@ReturnDate", returnTransaction.ReturnDate),
                new SqlParameter("@ActualDaysUsed", returnTransaction.ActualDaysUsed),
                new SqlParameter("@LateDays", returnTransaction.LateDays),
                new SqlParameter("@LateFeeAmount", returnTransaction.LateFeeAmount),
                new SqlParameter("@RefundAmount", returnTransaction.RefundAmount),
                new SqlParameter("@Notes", (object?)returnTransaction.Notes ?? DBNull.Value)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_ReturnTransactions_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int returnId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ReturnID", returnId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_ReturnTransactions_Delete", parameters);
            return result > 0;
        }

        public async Task<ReturnTransaction?> GetByIdAsync(int returnId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ReturnID", returnId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ReturnTransactions_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToReturnTransaction(dataTable.Rows[0]);
        }

        public async Task<ReturnTransaction?> GetByBorrowingIdAsync(int borrowingId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", borrowingId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ReturnTransactions_GetByBorrowingID", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToReturnTransaction(dataTable.Rows[0]);
        }

        public async Task<List<ReturnTransaction>> GetAllAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ReturnTransactions_GetAll", parameters);

            var returns = new List<ReturnTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                returns.Add(MapToReturnTransaction(row));
            }

            return returns;
        }

        // ==================== جديد ====================

        public async Task<int> InsertDetailAsync(ReturnDetail detail)
        {
            var parameters = new[]
            {
                new SqlParameter("@ReturnID", detail.ReturnID),
                new SqlParameter("@BorrowingDetailID", detail.BorrowingDetailID),
                new SqlParameter("@ProductID", detail.ProductID),
                new SqlParameter("@ReturnQuantity", detail.ReturnQuantity),
                new SqlParameter("@LateDays", detail.LateDays),
                new SqlParameter("@LateFeeAmount", detail.LateFeeAmount),
                new SqlParameter("@RefundAmount", detail.RefundAmount),
                new SqlParameter("@Notes", (object?)detail.Notes ?? DBNull.Value),
                new SqlParameter("@ReturnDetailID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_ReturnDetails_Insert", parameters);
            return (int)parameters[8].Value;
        }

        public async Task<List<ReturnDetail>> GetDetailsByReturnIdAsync(int returnId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ReturnID", returnId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ReturnDetails_GetByReturnID", parameters);

            var list = new List<ReturnDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new ReturnDetail
                {
                    ReturnDetailID = Convert.ToInt32(row["ReturnDetailID"]),
                    ReturnID = Convert.ToInt32(row["ReturnID"]),
                    BorrowingDetailID = Convert.ToInt32(row["BorrowingDetailID"]),
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    ProductName = row["ProductName"]?.ToString() ?? string.Empty,
                    ProductNameAr = row["ProductNameAr"]?.ToString() ?? string.Empty,
                    ReturnQuantity = Convert.ToInt32(row["ReturnQuantity"]),
                    LateDays = Convert.ToInt32(row["LateDays"]),
                    LateFeeAmount = Convert.ToDecimal(row["LateFeeAmount"]),
                    RefundAmount = Convert.ToDecimal(row["RefundAmount"]),
                    Notes = row["Notes"] == DBNull.Value ? string.Empty : row["Notes"].ToString() ?? string.Empty
                });
            }

            return list;
        }

        public async Task RefreshBorrowingStatusAsync(int borrowingId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", borrowingId)
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_BorrowingTransactions_RefreshStatus", parameters);
        }

        private ReturnTransaction MapToReturnTransaction(DataRow row)
        {
            return new ReturnTransaction
            {
                ReturnID = Convert.ToInt32(row["ReturnID"]),
                BorrowingID = Convert.ToInt32(row["BorrowingID"]),
                ReturnDate = Convert.ToDateTime(row["ReturnDate"]),
                ActualDaysUsed = Convert.ToInt32(row["ActualDaysUsed"]),
                LateDays = Convert.ToInt32(row["LateDays"]),
                LateFeeAmount = Convert.ToDecimal(row["LateFeeAmount"]),
                RefundAmount = Convert.ToDecimal(row["RefundAmount"]),
                Notes = row["Notes"] == DBNull.Value ? null : row["Notes"].ToString(),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                CreatedBy = row["CreatedBy"] == DBNull.Value ? null : Convert.ToInt32(row["CreatedBy"]),

                BorrowingNumber = row.Table.Columns.Contains("BorrowingNumber") && row["BorrowingNumber"] != DBNull.Value
                    ? row["BorrowingNumber"].ToString() : null,
                CustomerID = row.Table.Columns.Contains("CustomerID") && row["CustomerID"] != DBNull.Value
                    ? Convert.ToInt32(row["CustomerID"]) : null,
                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value
                    ? row["CustomerName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}