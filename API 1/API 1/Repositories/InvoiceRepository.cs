using API_1.Models;
using API_1.Data;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class InvoiceRepository : IInvoiceRepository 
    {
        private readonly DatabaseHelper _dbHelper;

        public InvoiceRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(Invoice invoice)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceNumber", invoice.InvoiceNumber),
                new SqlParameter("@InvoiceDate", invoice.InvoiceDate),
                new SqlParameter("@InvoiceTypeID", invoice.InvoiceTypeID),
                new SqlParameter("@CustomerID", (object?)invoice.CustomerID ?? DBNull.Value),
                new SqlParameter("@PaymentMethodID", invoice.PaymentMethodID),
                new SqlParameter("@PaymentType", invoice.PaymentType),
                new SqlParameter("@SalesRepID", (object?)invoice.SalesRepID ?? DBNull.Value),
                new SqlParameter("@SubTotal", invoice.SubTotal),
                new SqlParameter("@DiscountAmount", invoice.DiscountAmount),
                new SqlParameter("@DiscountPercent", invoice.DiscountPercent),
                new SqlParameter("@TaxAmount", invoice.TaxAmount),
                new SqlParameter("@TaxPercent", invoice.TaxPercent),
                new SqlParameter("@TotalAmount", invoice.TotalAmount),
                new SqlParameter("@PaidAmount", invoice.PaidAmount),
                new SqlParameter("@RemainingAmount", invoice.RemainingAmount),
                new SqlParameter("@Notes", (object?)invoice.Notes ?? DBNull.Value),
                new SqlParameter("@Status", invoice.Status),
                new SqlParameter("@CreatedBy", (object?)invoice.CreatedBy ?? DBNull.Value),
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Direction = ParameterDirection.Output }  
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_Invoices_Insert", parameters);
                return (int)parameters[18].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting invoice: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(Invoice invoice)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceID", invoice.InvoiceID),
                new SqlParameter("@InvoiceDate", invoice.InvoiceDate),
                new SqlParameter("@CustomerID", (object?)invoice.CustomerID ?? DBNull.Value),
                new SqlParameter("@PaymentMethodID", invoice.PaymentMethodID),
                new SqlParameter("@SalesRepID", (object?)invoice.SalesRepID ?? DBNull.Value),
                new SqlParameter("@DiscountAmount", invoice.DiscountAmount),
                new SqlParameter("@DiscountPercent", invoice.DiscountPercent),
                new SqlParameter("@Notes", (object?)invoice.Notes ?? DBNull.Value),
                new SqlParameter("@Status", invoice.Status)
            };
            var result = await _dbHelper.ExecuteNonQueryAsync("SP_Invoices_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int invoiceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceID", invoiceId)
            };
            var result = await _dbHelper.ExecuteNonQueryAsync("SP_Invoices_Delete", parameters);
            return result > 0;
        }

        public async Task<Invoice?> GetByIdAsync(int invoiceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceID", invoiceId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Invoices_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToInvoice(dataTable.Rows[0]);
        }

        public async Task<Invoice?> GetByNumberAsync(string invoiceNumber)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceNumber", invoiceNumber)  
            };
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Invoices_GetByNumber", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToInvoice(dataTable.Rows[0]);
        }

        public async Task<List<Invoice>> GetAllAsync(int? invoiceTypeId = null, int? customerId = null,
            string? status = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceTypeID", (object?)invoiceTypeId ?? DBNull.Value),
                new SqlParameter("@CustomerID", (object?)customerId ?? DBNull.Value),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Invoices_GetAll", parameters);

            var invoices = new List<Invoice>();
            foreach (DataRow row in dataTable.Rows)
            {
                invoices.Add(MapToInvoice(row));
            }

            return invoices;
        }

        private Invoice MapToInvoice(DataRow row)
        {
            return new Invoice
            {
                InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                InvoiceNumber = row["InvoiceNumber"].ToString() ?? string.Empty,
                InvoiceDate = row.Table.Columns.Contains("InvoiceDate") && row["InvoiceDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["InvoiceDate"]) : DateTime.Now,
                InvoiceTypeID = row.Table.Columns.Contains("InvoiceTypeID") && row["InvoiceTypeID"] != DBNull.Value
                    ? Convert.ToInt32(row["InvoiceTypeID"]) : 0,
                CustomerID = row.Table.Columns.Contains("CustomerID") && row["CustomerID"] != DBNull.Value
                    ? Convert.ToInt32(row["CustomerID"]) : null,
                PaymentMethodID = row.Table.Columns.Contains("PaymentMethodID") && row["PaymentMethodID"] != DBNull.Value
                    ? Convert.ToInt32(row["PaymentMethodID"]) : 0,
                PaymentType = row.Table.Columns.Contains("PaymentType") && row["PaymentType"] != DBNull.Value
                    ? row["PaymentType"].ToString() ?? "Cash" : "Cash",
                SalesRepID = row.Table.Columns.Contains("SalesRepID") && row["SalesRepID"] != DBNull.Value
                    ? Convert.ToInt32(row["SalesRepID"]) : null,
                SubTotal = row.Table.Columns.Contains("SubTotal") && row["SubTotal"] != DBNull.Value
                    ? Convert.ToDecimal(row["SubTotal"]) : 0,
                DiscountAmount = row.Table.Columns.Contains("DiscountAmount") && row["DiscountAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["DiscountAmount"]) : 0,
                DiscountPercent = row.Table.Columns.Contains("DiscountPercent") && row["DiscountPercent"] != DBNull.Value
                    ? Convert.ToDecimal(row["DiscountPercent"]) : 0,
                TaxAmount = row.Table.Columns.Contains("TaxAmount") && row["TaxAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["TaxAmount"]) : 0,
                TaxPercent = row.Table.Columns.Contains("TaxPercent") && row["TaxPercent"] != DBNull.Value
                    ? Convert.ToDecimal(row["TaxPercent"]) : 0,
                TotalAmount = row.Table.Columns.Contains("TotalAmount") && row["TotalAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalAmount"]) : 0,
                PaidAmount = row.Table.Columns.Contains("PaidAmount") && row["PaidAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["PaidAmount"]) : 0,
                RemainingAmount = row.Table.Columns.Contains("RemainingAmount") && row["RemainingAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["RemainingAmount"]) : 0,
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value
                    ? row["Notes"].ToString() : null,
                Status = row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value
                    ? row["Status"].ToString() ?? "Completed" : "Completed",
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

              
                TypeName = row.Table.Columns.Contains("TypeName") && row["TypeName"] != DBNull.Value
                    ? row["TypeName"].ToString() : null,
                TypeNameAr = row.Table.Columns.Contains("TypeNameAr") && row["TypeNameAr"] != DBNull.Value
                    ? row["TypeNameAr"].ToString() : null,
                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value
                    ? row["CustomerName"].ToString() : null,
                MethodName = row.Table.Columns.Contains("MethodName") && row["MethodName"] != DBNull.Value
                    ? row["MethodName"].ToString() : null,
                MethodNameAr = row.Table.Columns.Contains("MethodNameAr") && row["MethodNameAr"] != DBNull.Value
                    ? row["MethodNameAr"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null,


            };
        }
    }
}