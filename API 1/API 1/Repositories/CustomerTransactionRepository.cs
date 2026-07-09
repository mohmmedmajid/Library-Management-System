using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class CustomerTransactionRepository : ICustomerTransactionRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public CustomerTransactionRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<int> InsertAsync(CustomerTransaction transaction)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", transaction.CustomerID),
                new SqlParameter("@TransactionType", transaction.TransactionType),
                new SqlParameter("@InvoiceID", (object?)transaction.InvoiceID ?? DBNull.Value),
                new SqlParameter("@Amount", transaction.Amount),
                new SqlParameter("@Notes", (object?)transaction.Notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)transaction.CreatedBy ?? DBNull.Value),
                new SqlParameter("@TransactionID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_CustomerTransactions_Insert", parameters);

            return (int)parameters[6].Value;
        }

        public async Task<bool> UpdateAsync(CustomerTransaction transaction)
        {
            var parameters = new[]
            {
                new SqlParameter("@TransactionID", transaction.TransactionID),
                new SqlParameter("@Amount", transaction.Amount),
                new SqlParameter("@Notes", (object?)transaction.Notes ?? DBNull.Value)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_CustomerTransactions_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int transactionId)
        {
            var parameters = new[]
            {
                new SqlParameter("@TransactionID", transactionId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_CustomerTransactions_Delete", parameters);
            return result > 0;
        }

        public async Task<CustomerTransaction?> GetByIdAsync(int transactionId)
        {
            var parameters = new[]
            {
                new SqlParameter("@TransactionID", transactionId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_CustomerTransactions_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToCustomerTransaction(dataTable.Rows[0]);
        }

        public async Task<List<CustomerTransaction>> GetByCustomerAsync(int customerId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_CustomerTransactions_GetByCustomer", parameters);

            var transactions = new List<CustomerTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                transactions.Add(MapToCustomerTransaction(row));
            }

            return transactions;
        }

        public async Task<List<CustomerTransaction>> GetAllAsync(string? transactionType = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@TransactionType", (object?)transactionType ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_CustomerTransactions_GetAll", parameters);

            var transactions = new List<CustomerTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                transactions.Add(MapToCustomerTransaction(row));
            }

            return transactions;
        }

        private CustomerTransaction MapToCustomerTransaction(DataRow row)
        {
            return new CustomerTransaction
            {
                TransactionID = Convert.ToInt32(row["TransactionID"]),
                CustomerID = Convert.ToInt32(row["CustomerID"]),
                TransactionType = row.Table.Columns.Contains("TransactionType") && row["TransactionType"] != DBNull.Value
                    ? row["TransactionType"].ToString() ?? string.Empty : string.Empty,
                InvoiceID = row.Table.Columns.Contains("InvoiceID") && row["InvoiceID"] != DBNull.Value
                    ? Convert.ToInt32(row["InvoiceID"]) : null,
                Amount = row.Table.Columns.Contains("Amount") && row["Amount"] != DBNull.Value
                    ? Convert.ToDecimal(row["Amount"]) : 0,
                TransactionDate = row.Table.Columns.Contains("TransactionDate") && row["TransactionDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["TransactionDate"]) : DateTime.Now,
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value
                    ? row["Notes"].ToString() : null,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value
                    ? row["CustomerName"].ToString() : null,
                InvoiceNumber = row.Table.Columns.Contains("InvoiceNumber") && row["InvoiceNumber"] != DBNull.Value
                    ? row["InvoiceNumber"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}
