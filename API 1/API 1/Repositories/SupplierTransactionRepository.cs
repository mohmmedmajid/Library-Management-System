using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class SupplierTransactionRepository : ISupplierTransactionRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public SupplierTransactionRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(SupplierTransaction transaction)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierID", transaction.SupplierID),
                new SqlParameter("@TransactionType", transaction.TransactionType),
                new SqlParameter("@InvoiceID", (object?)transaction.InvoiceID ?? DBNull.Value),
                new SqlParameter("@Amount", transaction.Amount),
                new SqlParameter("@ReferenceNumber", (object?)transaction.ReferenceNumber ?? DBNull.Value),
                new SqlParameter("@Notes", (object?)transaction.Notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)transaction.CreatedBy ?? DBNull.Value),
                new SqlParameter("@TransactionID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_SupplierTransactions_Insert", parameters));

            return (int)parameters[7].Value;
        }

        public async Task<bool> UpdateAsync(SupplierTransaction transaction)
        {
            var parameters = new[]
            {
                new SqlParameter("@TransactionID", transaction.TransactionID),
                new SqlParameter("@Amount", transaction.Amount),
                new SqlParameter("@ReferenceNumber", (object?)transaction.ReferenceNumber ?? DBNull.Value),
                new SqlParameter("@Notes", (object?)transaction.Notes ?? DBNull.Value)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_SupplierTransactions_Update", parameters));
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int transactionId)
        {
            var parameters = new[]
            {
                new SqlParameter("@TransactionID", transactionId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_SupplierTransactions_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SupplierTransaction?> GetByIdAsync(int transactionId)
        {
            var parameters = new[]
            {
                new SqlParameter("@TransactionID", transactionId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SupplierTransactions_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToSupplierTransaction(dataTable.Rows[0]);
        }

        public async Task<List<SupplierTransaction>> GetAllAsync(string? transactionType = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@TransactionType", (object?)transactionType ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SupplierTransactions_GetAll", parameters);

            var transactions = new List<SupplierTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                transactions.Add(MapToSupplierTransaction(row));
            }

            return transactions;
        }

        public async Task<List<SupplierTransaction>> GetBySupplierAsync(int supplierId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierID", supplierId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SupplierTransactions_GetBySupplier", parameters);

            var transactions = new List<SupplierTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                transactions.Add(MapToSupplierTransaction(row));
            }

            return transactions;
        }

        public async Task<decimal> GetSupplierBalanceAsync(int supplierId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierID", supplierId)
            };

            var result = await _dbHelper.ExecuteScalarAsync("SP_SupplierTransactions_GetSupplierBalance", parameters);

            return result != null ? Convert.ToDecimal(result) : 0;
        }
        public async Task<List<SupplierTransaction>> GetByInvoiceAsync(int invoiceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceID", invoiceId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SupplierTransactions_GetByInvoice", parameters);

            var transactions = new List<SupplierTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                transactions.Add(MapToSupplierTransaction(row));
            }

            return transactions;
        }
        private SupplierTransaction MapToSupplierTransaction(DataRow row)
        {
            return new SupplierTransaction
            {
                TransactionID = Convert.ToInt32(row["TransactionID"]),
                SupplierID = Convert.ToInt32(row["SupplierID"]),
                SupplierName = row.Table.Columns.Contains("SupplierName") && row["SupplierName"] != DBNull.Value
                    ? row["SupplierName"].ToString()
                    : null,
                TransactionType = row["TransactionType"].ToString() ?? string.Empty,
                InvoiceID = row["InvoiceID"] == DBNull.Value ? null : Convert.ToInt32(row["InvoiceID"]),
                InvoiceNumber = row.Table.Columns.Contains("InvoiceNumber") && row["InvoiceNumber"] != DBNull.Value
                    ? row["InvoiceNumber"].ToString()
                    : null,
                Amount = Convert.ToDecimal(row["Amount"]),
                TransactionDate = Convert.ToDateTime(row["TransactionDate"]),
                ReferenceNumber = row["ReferenceNumber"] == DBNull.Value ? null : row["ReferenceNumber"].ToString(),
                Notes = row["Notes"] == DBNull.Value ? null : row["Notes"].ToString(),
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"])
                    : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString()
                    : null
            };
        }
    }
}