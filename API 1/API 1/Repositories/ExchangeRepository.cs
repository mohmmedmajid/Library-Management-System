// Repositories/ExchangeRepository.cs (محدث)
using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public ExchangeRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(int originalInvoiceId, int originalInvoiceDetailId, int customerId, int oldProductId, int oldQuantity, int newProductId, int newQuantity, int paymentMethodId, string? notes, int createdBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@OriginalInvoiceID", originalInvoiceId),
                new SqlParameter("@OriginalInvoiceDetailID", originalInvoiceDetailId),
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@OldProductID", oldProductId),
                new SqlParameter("@OldQuantity", oldQuantity),
                new SqlParameter("@NewProductID", newProductId),
                new SqlParameter("@NewQuantity", newQuantity),
                new SqlParameter("@PaymentMethodID", paymentMethodId),
                new SqlParameter("@Notes", (object?)notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", createdBy),
                new SqlParameter("@ExchangeID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Exchange_Insert", parameters));

            return (int)parameters[10].Value;
        }

        public async Task<ExchangeTransaction?> GetByIdAsync(int exchangeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExchangeID", exchangeId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Exchange_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToExchangeTransaction(dataTable.Rows[0]);
        }

        public async Task<List<ExchangeTransaction>> GetAllAsync(int? customerId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", (object?)customerId ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Exchange_GetAll", parameters);

            var exchanges = new List<ExchangeTransaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                exchanges.Add(MapToExchangeTransaction(row));
            }

            return exchanges;
        }

        private ExchangeTransaction MapToExchangeTransaction(DataRow row)
        {
            return new ExchangeTransaction
            {
                ExchangeID = Convert.ToInt32(row["ExchangeID"]),
                ExchangeNumber = row["ExchangeNumber"].ToString() ?? string.Empty,
                OriginalInvoiceID = Convert.ToInt32(row["OriginalInvoiceID"]),
                OriginalInvoiceNumber = row.Table.Columns.Contains("OriginalInvoiceNumber") && row["OriginalInvoiceNumber"] != DBNull.Value ? row["OriginalInvoiceNumber"].ToString() : null,
                OriginalInvoiceDetailID = row.Table.Columns.Contains("OriginalInvoiceDetailID") && row["OriginalInvoiceDetailID"] != DBNull.Value ? Convert.ToInt32(row["OriginalInvoiceDetailID"]) : 0,
                CustomerID = row.Table.Columns.Contains("CustomerID") && row["CustomerID"] != DBNull.Value ? Convert.ToInt32(row["CustomerID"]) : 0,
                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value ? row["CustomerName"].ToString() : null,
                ExchangeDate = Convert.ToDateTime(row["ExchangeDate"]),
                OldProductID = Convert.ToInt32(row["OldProductID"]),
                OldProductName = row.Table.Columns.Contains("OldProductName") && row["OldProductName"] != DBNull.Value ? row["OldProductName"].ToString() : null,
                OldQuantity = Convert.ToInt32(row["OldQuantity"]),
                NewProductID = Convert.ToInt32(row["NewProductID"]),
                NewProductName = row.Table.Columns.Contains("NewProductName") && row["NewProductName"] != DBNull.Value ? row["NewProductName"].ToString() : null,
                NewQuantity = Convert.ToInt32(row["NewQuantity"]),
                OldTotalAmount = row.Table.Columns.Contains("OldTotalAmount") ? Convert.ToDecimal(row["OldTotalAmount"]) : 0,
                NewTotalAmount = row.Table.Columns.Contains("NewTotalAmount") ? Convert.ToDecimal(row["NewTotalAmount"]) : 0,
                PriceDifference = Convert.ToDecimal(row["PriceDifference"]),
                PaymentMethodID = row.Table.Columns.Contains("PaymentMethodID") && row["PaymentMethodID"] != DBNull.Value ? Convert.ToInt32(row["PaymentMethodID"]) : 0,
                NewInvoiceID = row["NewInvoiceID"] == DBNull.Value ? null : Convert.ToInt32(row["NewInvoiceID"]),
                NewInvoiceNumber = row.Table.Columns.Contains("NewInvoiceNumber") && row["NewInvoiceNumber"] != DBNull.Value ? row["NewInvoiceNumber"].ToString() : null,
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value ? row["Notes"].ToString() : null,
                Status = row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value ? row["Status"].ToString() ?? string.Empty : string.Empty,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now
            };
        }
    }
}