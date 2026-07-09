using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class InvoiceSearchRepository : IInvoiceSearchRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public InvoiceSearchRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<InvoiceSearchResult?> SearchByNumberAsync(string invoiceNumber)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceNumber", invoiceNumber)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Invoices_SearchByNumber", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToInvoiceSearchResult(dataTable.Rows[0]);
        }

        public async Task<List<InvoiceSearchResult>> SearchByBarcodeAsync(string barcode)
        {
            var parameters = new[]
            {
                new SqlParameter("@Barcode", barcode)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Invoices_SearchByBarcode", parameters);

            var results = new List<InvoiceSearchResult>();
            foreach (DataRow row in dataTable.Rows)
            {
                results.Add(MapToInvoiceSearchResult(row));
            }

            return results;
        }

        public async Task<List<InvoiceSearchResult>> SearchByCustomerNameAsync(string customerName)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerName", customerName)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Invoices_SearchByCustomerName", parameters);

            var results = new List<InvoiceSearchResult>();
            foreach (DataRow row in dataTable.Rows)
            {
                results.Add(MapToInvoiceSearchResult(row));
            }

            return results;
        }

        public async Task<List<ReturnableInvoiceDetail>> GetReturnableDetailsAsync(int invoiceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceID", invoiceId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InvoiceDetails_GetReturnableByInvoiceID", parameters);

            var results = new List<ReturnableInvoiceDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                results.Add(MapToReturnableInvoiceDetail(row));
            }

            return results;
        }

        public async Task<List<AllInvoiceItem>> GetAllInvoicesAsync(string? invoiceType, DateTime? startDate, DateTime? endDate, int? customerId)
        {
            var parameters = new[]
            {
                new SqlParameter("@TypeName", (object?)invoiceType ?? DBNull.Value),
                new SqlParameter("@CustomerID", (object?)customerId ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AllInvoices_GetAll", parameters);

            var results = new List<AllInvoiceItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                results.Add(MapToAllInvoiceItem(row));
            }

            return results;
        }

        private InvoiceSearchResult MapToInvoiceSearchResult(DataRow row)
        {
            return new InvoiceSearchResult
            {
                InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                InvoiceNumber = row["InvoiceNumber"].ToString() ?? string.Empty,
                InvoiceDate = row["InvoiceDate"] != DBNull.Value ? Convert.ToDateTime(row["InvoiceDate"]) : DateTime.MinValue,
                CustomerID = row.Table.Columns.Contains("CustomerID") && row["CustomerID"] != DBNull.Value ? Convert.ToInt32(row["CustomerID"]) : null,
                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value ? row["CustomerName"].ToString() : null,
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                InvoiceType = row.Table.Columns.Contains("InvoiceType") && row["InvoiceType"] != DBNull.Value ? row["InvoiceType"].ToString() ?? string.Empty : string.Empty
            };
        }

        private ReturnableInvoiceDetail MapToReturnableInvoiceDetail(DataRow row)
        {
            return new ReturnableInvoiceDetail
            {
                InvoiceDetailID = Convert.ToInt32(row["InvoiceDetailID"]),
                InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                ProductID = Convert.ToInt32(row["ProductID"]),
                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value ? row["ProductName"].ToString() : null,
                ProductNameAr = row.Table.Columns.Contains("ProductNameAr") && row["ProductNameAr"] != DBNull.Value ? row["ProductNameAr"].ToString() : null,
                Quantity = Convert.ToInt32(row["Quantity"]),
                AlreadyReturnedQuantity = Convert.ToInt32(row["AlreadyReturnedQuantity"]),
                ReturnableQuantity = Convert.ToInt32(row["ReturnableQuantity"]),
                UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                DiscountAmount = row.Table.Columns.Contains("DiscountAmount") ? Convert.ToDecimal(row["DiscountAmount"]) : 0,
                TaxAmount = row.Table.Columns.Contains("TaxAmount") ? Convert.ToDecimal(row["TaxAmount"]) : 0
            };
        }

        private AllInvoiceItem MapToAllInvoiceItem(DataRow row)
        {
            return new AllInvoiceItem
            {
                RecordID = Convert.ToInt32(row["RecordID"]),
                InvoiceNumber = row["InvoiceNumber"].ToString() ?? string.Empty,
                InvoiceDate = row["InvoiceDate"] != DBNull.Value ? Convert.ToDateTime(row["InvoiceDate"]) : DateTime.MinValue,
                TypeName = row["TypeName"].ToString() ?? string.Empty,
                TypeNameAr = row["TypeNameAr"] != DBNull.Value ? row["TypeNameAr"].ToString() : null,
                CustomerID = row["CustomerID"] != DBNull.Value ? Convert.ToInt32(row["CustomerID"]) : (int?)null,
                PartyName = row["PartyName"] != DBNull.Value ? row["PartyName"].ToString() : null,
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                PaidAmount = Convert.ToDecimal(row["PaidAmount"]),
                RemainingAmount = Convert.ToDecimal(row["RemainingAmount"]),
                Status = row["Status"] != DBNull.Value ? row["Status"].ToString() ?? string.Empty : string.Empty
            };
        }
    }
}