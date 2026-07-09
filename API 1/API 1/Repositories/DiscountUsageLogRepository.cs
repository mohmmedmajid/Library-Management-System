using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class DiscountUsageLogRepository : IDiscountUsageLogRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public DiscountUsageLogRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(DiscountUsageLog log)
        {
            var parameters = new[]
            {
                new SqlParameter("@UsageType", log.UsageType),
                new SqlParameter("@DiscountID", (object?)log.DiscountID ?? DBNull.Value),
                new SqlParameter("@CouponID", (object?)log.CouponID ?? DBNull.Value),
                new SqlParameter("@OfferID", (object?)log.OfferID ?? DBNull.Value),
                new SqlParameter("@InvoiceID", log.InvoiceID),
                new SqlParameter("@CustomerID", (object?)log.CustomerID ?? DBNull.Value),
                new SqlParameter("@ProductID", (object?)log.ProductID ?? DBNull.Value),
                new SqlParameter("@OriginalAmount", log.OriginalAmount),
                new SqlParameter("@DiscountAmount", log.DiscountAmount),
                new SqlParameter("@FinalAmount", log.FinalAmount),
                new SqlParameter("@Notes", (object?)log.Notes ?? DBNull.Value),
                new SqlParameter("@UsageID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_DiscountUsageLog_Insert", parameters));

            return (int)parameters[11].Value;
        }

        public async Task<DiscountUsageLog?> GetByIdAsync(int usageId)
        {
            var parameters = new[]
            {
                new SqlParameter("@UsageID", usageId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_DiscountUsageLog_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToDiscountUsageLog(dataTable.Rows[0]);
        }

        public async Task<List<DiscountUsageLog>> GetAllAsync(string? usageType = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@UsageType", (object?)usageType ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_DiscountUsageLog_GetAll", parameters);

            var logs = new List<DiscountUsageLog>();
            foreach (DataRow row in dataTable.Rows)
            {
                logs.Add(MapToDiscountUsageLog(row));
            }

            return logs;
        }

        public async Task<List<DiscountUsageLog>> GetByInvoiceAsync(int invoiceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceID", invoiceId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_DiscountUsageLog_GetByInvoice", parameters);

            var logs = new List<DiscountUsageLog>();
            foreach (DataRow row in dataTable.Rows)
            {
                logs.Add(MapToDiscountUsageLog(row));
            }

            return logs;
        }

        public async Task<List<DiscountUsageLog>> GetByCustomerAsync(int customerId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_DiscountUsageLog_GetByCustomer", parameters);

            var logs = new List<DiscountUsageLog>();
            foreach (DataRow row in dataTable.Rows)
            {
                logs.Add(MapToDiscountUsageLog(row));
            }

            return logs;
        }

        public async Task<List<Dictionary<string, object>>> GetUsageStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_DiscountUsageLog_GetStatistics", parameters);

            var results = new List<Dictionary<string, object>>();

            foreach (DataRow row in dataTable.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    var value = row[column];
                    dict[column.ColumnName] = value == DBNull.Value ? (object?)null! : value;
                }
                results.Add(dict);
            }

            return results;
        }

        public async Task<List<Dictionary<string, object>>> GetTopDiscountsAsync(DateTime startDate, DateTime endDate, int topCount = 10)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate),
                new SqlParameter("@TopCount", topCount)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_DiscountUsageLog_GetTopDiscounts", parameters);

            var results = new List<Dictionary<string, object>>();

            foreach (DataRow row in dataTable.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    var value = row[column];
                    dict[column.ColumnName] = value == DBNull.Value ? (object?)null! : value;
                }
                results.Add(dict);
            }

            return results;
        }

        public async Task<List<Dictionary<string, object>>> GetTopCouponsAsync(DateTime startDate, DateTime endDate, int topCount = 10)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate),
                new SqlParameter("@TopCount", topCount)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_DiscountUsageLog_GetTopCoupons", parameters);

            var results = new List<Dictionary<string, object>>();

            foreach (DataRow row in dataTable.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    var value = row[column];
                    dict[column.ColumnName] = value == DBNull.Value ? (object?)null! : value;
                }
                results.Add(dict);
            }

            return results;
        }

        private DiscountUsageLog MapToDiscountUsageLog(DataRow row)
        {
            return new DiscountUsageLog
            {
                UsageID = Convert.ToInt32(row["UsageID"]),
                UsageType = row["UsageType"].ToString() ?? string.Empty,
                DiscountID = row["DiscountID"] == DBNull.Value ? null : Convert.ToInt32(row["DiscountID"]),
                DiscountName = row.Table.Columns.Contains("DiscountName") && row["DiscountName"] != DBNull.Value
                    ? row["DiscountName"].ToString()
                    : null,
                CouponID = row["CouponID"] == DBNull.Value ? null : Convert.ToInt32(row["CouponID"]),
                CouponCode = row.Table.Columns.Contains("CouponCode") && row["CouponCode"] != DBNull.Value
                    ? row["CouponCode"].ToString()
                    : null,
                CouponName = row.Table.Columns.Contains("CouponName") && row["CouponName"] != DBNull.Value
                    ? row["CouponName"].ToString()
                    : null,
                OfferID = row["OfferID"] == DBNull.Value ? null : Convert.ToInt32(row["OfferID"]),
                OfferName = row.Table.Columns.Contains("OfferName") && row["OfferName"] != DBNull.Value
                    ? row["OfferName"].ToString()
                    : null,
                InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                InvoiceNumber = row.Table.Columns.Contains("InvoiceNumber") && row["InvoiceNumber"] != DBNull.Value
                    ? row["InvoiceNumber"].ToString()
                    : null,
                CustomerID = row["CustomerID"] == DBNull.Value ? null : Convert.ToInt32(row["CustomerID"]),
                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value
                    ? row["CustomerName"].ToString()
                    : null,
                ProductID = row["ProductID"] == DBNull.Value ? null : Convert.ToInt32(row["ProductID"]),
                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value
                    ? row["ProductName"].ToString()
                    : null,
                OriginalAmount = Convert.ToDecimal(row["OriginalAmount"]),
                DiscountAmount = Convert.ToDecimal(row["DiscountAmount"]),
                FinalAmount = Convert.ToDecimal(row["FinalAmount"]),
                UsageDate = Convert.ToDateTime(row["UsageDate"]),
                Notes = row["Notes"] == DBNull.Value ? null : row["Notes"].ToString()
            };
        }
    }
}