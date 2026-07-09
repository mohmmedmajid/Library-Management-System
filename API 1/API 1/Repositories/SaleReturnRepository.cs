using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class SaleReturnRepository : ISaleReturnRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public SaleReturnRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertHeaderAsync(int originalInvoiceId, int customerId, string refundMethod, int paymentMethodId, string? notes, int createdBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@OriginalInvoiceID", originalInvoiceId),
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@RefundMethod", refundMethod),
                new SqlParameter("@PaymentMethodID", paymentMethodId),
                new SqlParameter("@Notes", (object?)notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", createdBy),
                new SqlParameter("@SaleReturnID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_SaleReturns_InsertHeader", parameters));

            return (int)parameters[6].Value;
        }

        public async Task<int> InsertDetailAsync(int saleReturnId, int invoiceDetailId, int returnedQuantity)
        {
            var parameters = new[]
            {
                new SqlParameter("@SaleReturnID", saleReturnId),
                new SqlParameter("@InvoiceDetailID", invoiceDetailId),
                new SqlParameter("@ReturnedQuantity", returnedQuantity),
                new SqlParameter("@SaleReturnDetailID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_SaleReturns_InsertDetail", parameters));

            return (int)parameters[3].Value;
        }

        public async Task<bool> FinalizeAsync(int saleReturnId, int createdBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@SaleReturnID", saleReturnId),
                new SqlParameter("@CreatedBy", createdBy)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_SaleReturns_Finalize", parameters));
            return result >= 0;
        }

        public async Task<SaleReturn?> GetByIdAsync(int saleReturnId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SaleReturnID", saleReturnId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SaleReturns_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToSaleReturn(dataTable.Rows[0]);
        }

        public async Task<List<SaleReturnDetail>> GetDetailsBySaleReturnIdAsync(int saleReturnId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SaleReturnID", saleReturnId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SaleReturnDetails_GetBySaleReturnID", parameters);

            var details = new List<SaleReturnDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapToSaleReturnDetail(row));
            }

            return details;
        }

        public async Task<List<SaleReturn>> GetAllAsync(int? customerId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", (object?)customerId ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SaleReturns_GetAll", parameters);

            var saleReturns = new List<SaleReturn>();
            foreach (DataRow row in dataTable.Rows)
            {
                saleReturns.Add(MapToSaleReturn(row));
            }

            return saleReturns;
        }

        private SaleReturn MapToSaleReturn(DataRow row)
        {
            return new SaleReturn
            {
                SaleReturnID = Convert.ToInt32(row["SaleReturnID"]),
                SaleReturnNumber = row["SaleReturnNumber"].ToString() ?? string.Empty,
                OriginalInvoiceID = Convert.ToInt32(row["OriginalInvoiceID"]),
                OriginalInvoiceNumber = row.Table.Columns.Contains("OriginalInvoiceNumber") && row["OriginalInvoiceNumber"] != DBNull.Value ? row["OriginalInvoiceNumber"].ToString() : null,
                CustomerID = row.Table.Columns.Contains("CustomerID") && row["CustomerID"] != DBNull.Value ? Convert.ToInt32(row["CustomerID"]) : 0,
                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value ? row["CustomerName"].ToString() : null,
                ReturnDate = Convert.ToDateTime(row["ReturnDate"]),
                RefundMethod = row.Table.Columns.Contains("RefundMethod") && row["RefundMethod"] != DBNull.Value ? row["RefundMethod"].ToString() ?? string.Empty : string.Empty,
                PaymentMethodID = row.Table.Columns.Contains("PaymentMethodID") && row["PaymentMethodID"] != DBNull.Value ? Convert.ToInt32(row["PaymentMethodID"]) : 0,
                MethodNameAr = row.Table.Columns.Contains("MethodNameAr") && row["MethodNameAr"] != DBNull.Value ? row["MethodNameAr"].ToString() : null,
                TotalReturnedAmount = Convert.ToDecimal(row["TotalReturnedAmount"]),
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value ? row["Notes"].ToString() : null,
                Status = row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value ? row["Status"].ToString() ?? string.Empty : string.Empty,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value ? Convert.ToInt32(row["CreatedBy"]) : 0,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value ? row["CreatedByName"].ToString() : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now
            };
        }

        private SaleReturnDetail MapToSaleReturnDetail(DataRow row)
        {
            return new SaleReturnDetail
            {
                SaleReturnDetailID = Convert.ToInt32(row["SaleReturnDetailID"]),
                SaleReturnID = Convert.ToInt32(row["SaleReturnID"]),
                InvoiceDetailID = Convert.ToInt32(row["InvoiceDetailID"]),
                ProductID = Convert.ToInt32(row["ProductID"]),
                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value ? row["ProductName"].ToString() : null,
                ProductNameAr = row.Table.Columns.Contains("ProductNameAr") && row["ProductNameAr"] != DBNull.Value ? row["ProductNameAr"].ToString() : null,
                ReturnedQuantity = Convert.ToInt32(row["ReturnedQuantity"]),
                UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                RefundAmount = Convert.ToDecimal(row["RefundAmount"])
            };
        }
    }
}