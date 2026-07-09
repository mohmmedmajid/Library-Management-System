using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public InvoiceDetailRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(InvoiceDetail invoiceDetail)
        {
            var parameters = new[]
 {
                new SqlParameter("@InvoiceID", invoiceDetail.InvoiceID),
                new SqlParameter("@ProductID", invoiceDetail.ProductID),
                new SqlParameter("@Quantity", invoiceDetail.Quantity),
                new SqlParameter("@UnitPrice", invoiceDetail.UnitPrice),
                new SqlParameter("@DiscountAmount", invoiceDetail.DiscountAmount),
                new SqlParameter("@DiscountPercent", invoiceDetail.DiscountPercent),
                new SqlParameter("@TotalPrice", invoiceDetail.TotalPrice),
                new SqlParameter("@Notes", (object?)invoiceDetail.Notes ?? DBNull.Value),
                new SqlParameter("@InvoiceDetailID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };
            await _dbHelper.ExecuteNonQueryAsync("SP_InvoiceDetails_Insert", parameters);
            return (int)parameters[8].Value;
        }

        public async Task<bool> UpdateAsync(InvoiceDetail invoiceDetail)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceDetailID", invoiceDetail.InvoiceDetailID),
                new SqlParameter("@Quantity", invoiceDetail.Quantity),
                new SqlParameter("@UnitPrice", invoiceDetail.UnitPrice),
                new SqlParameter("@DiscountAmount", invoiceDetail.DiscountAmount),
                new SqlParameter("@DiscountPercent", invoiceDetail.DiscountPercent),
                new SqlParameter("@TotalPrice", invoiceDetail.TotalPrice),
                new SqlParameter("@Notes", (object?)invoiceDetail.Notes ?? DBNull.Value)
            };
            var result = await _dbHelper.ExecuteNonQueryAsync("SP_InvoiceDetails_Update", parameters);
            return result > 0;
        }
        public async Task<bool> DeleteAsync(int invoiceDetailId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceDetailID", invoiceDetailId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_InvoiceDetails_Delete", parameters);
            return result > 0;
        }

        public async Task<List<InvoiceDetail>> GetByInvoiceIdAsync(int invoiceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceID", invoiceId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InvoiceDetails_GetByInvoiceID", parameters);

            var details = new List<InvoiceDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapToInvoiceDetail(row));
            }

            return details;
        }

        public async Task<List<InvoiceDetail>> GetAllAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InvoiceDetails_GetAll", null);

            var details = new List<InvoiceDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapToInvoiceDetail(row));
            }

            return details;
        }

        private InvoiceDetail MapToInvoiceDetail(DataRow row)
        {
            return new InvoiceDetail
            {
                InvoiceDetailID = Convert.ToInt32(row["InvoiceDetailID"]),
                InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                ProductID = Convert.ToInt32(row["ProductID"]),
                Quantity = Convert.ToInt32(row["Quantity"]),
                UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                DiscountAmount = Convert.ToDecimal(row["DiscountAmount"]),
                DiscountPercent = Convert.ToDecimal(row["DiscountPercent"]),
                TotalPrice = Convert.ToDecimal(row["TotalPrice"]),
                Notes = row["Notes"] == DBNull.Value ? null : row["Notes"].ToString(),
                
                
                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value 
                    ? row["ProductName"].ToString() : null,
                ProductNameAr = row.Table.Columns.Contains("ProductNameAr") && row["ProductNameAr"] != DBNull.Value 
                    ? row["ProductNameAr"].ToString() : null,
                Barcode = row.Table.Columns.Contains("Barcode") && row["Barcode"] != DBNull.Value 
                    ? row["Barcode"].ToString() : null,
                InvoiceNumber = row.Table.Columns.Contains("InvoiceNumber") && row["InvoiceNumber"] != DBNull.Value 
                    ? row["InvoiceNumber"].ToString() : null
            };
        }
    }
}
