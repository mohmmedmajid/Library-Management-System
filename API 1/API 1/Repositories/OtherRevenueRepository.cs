using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class OtherRevenueRepository : IOtherRevenueRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public OtherRevenueRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(OtherRevenue revenue)
        {
            var parameters = new[]
            {
                new SqlParameter("@RevenueCategoryID", revenue.RevenueCategoryID),
                new SqlParameter("@RevenueDate", revenue.RevenueDate),
                new SqlParameter("@Amount", revenue.Amount),
                new SqlParameter("@PaymentMethodID", revenue.PaymentMethodID),
                new SqlParameter("@ReferenceNumber", (object?)revenue.ReferenceNumber ?? DBNull.Value),
                new SqlParameter("@Description", (object?)revenue.Description ?? DBNull.Value),
                new SqlParameter("@CustomerID", (object?)revenue.CustomerID ?? DBNull.Value),
                new SqlParameter("@ReceiptNumber", (object?)revenue.ReceiptNumber ?? DBNull.Value),
                new SqlParameter("@IsRecurring", revenue.IsRecurring),
                new SqlParameter("@RecurringPeriod", (object?)revenue.RecurringPeriod ?? DBNull.Value),
                new SqlParameter("@Status", revenue.Status),
                new SqlParameter("@CreatedBy", (object?)revenue.CreatedBy ?? DBNull.Value),
                new SqlParameter("@RevenueID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_OtherRevenues_Insert", parameters));

            return (int)parameters[12].Value;
        }

        public async Task<bool> UpdateAsync(OtherRevenue revenue)
        {
            var parameters = new[]
            {
                new SqlParameter("@RevenueID", revenue.RevenueID),
                new SqlParameter("@RevenueCategoryID", revenue.RevenueCategoryID),
                new SqlParameter("@RevenueDate", revenue.RevenueDate),
                new SqlParameter("@Amount", revenue.Amount),
                new SqlParameter("@PaymentMethodID", revenue.PaymentMethodID),
                new SqlParameter("@ReferenceNumber", (object?)revenue.ReferenceNumber ?? DBNull.Value),
                new SqlParameter("@Description", (object?)revenue.Description ?? DBNull.Value),
                new SqlParameter("@CustomerID", (object?)revenue.CustomerID ?? DBNull.Value),
                new SqlParameter("@ReceiptNumber", (object?)revenue.ReceiptNumber ?? DBNull.Value),
                new SqlParameter("@Status", revenue.Status)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_OtherRevenues_Update", parameters));
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int revenueId)
        {
            var parameters = new[]
            {
                new SqlParameter("@RevenueID", revenueId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_OtherRevenues_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OtherRevenue?> GetByIdAsync(int revenueId)
        {
            var parameters = new[]
            {
                new SqlParameter("@RevenueID", revenueId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_OtherRevenues_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToOtherRevenue(dataTable.Rows[0]);
        }

        public async Task<List<OtherRevenue>> GetAllAsync(int? categoryId = null, int? customerId = null, string? status = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@RevenueCategoryID", (object?)categoryId ?? DBNull.Value),
                new SqlParameter("@CustomerID", (object?)customerId ?? DBNull.Value),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_OtherRevenues_GetAll", parameters);

            var revenues = new List<OtherRevenue>();
            foreach (DataRow row in dataTable.Rows)
            {
                revenues.Add(MapToOtherRevenue(row));
            }

            return revenues;
        }

        public async Task<List<OtherRevenue>> GetByCategoryAsync(int categoryId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@RevenueCategoryID", categoryId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_OtherRevenues_GetByCategory", parameters);

            var revenues = new List<OtherRevenue>();
            foreach (DataRow row in dataTable.Rows)
            {
                revenues.Add(MapToOtherRevenue(row));
            }

            return revenues;
        }

        public async Task<List<OtherRevenue>> GetByCustomerAsync(int customerId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_OtherRevenues_GetByCustomer", parameters);

            var revenues = new List<OtherRevenue>();
            foreach (DataRow row in dataTable.Rows)
            {
                revenues.Add(MapToOtherRevenue(row));
            }

            return revenues;
        }

        public async Task<(decimal TotalAmount, int TotalCount)> GetSummaryAsync(DateTime startDate, DateTime endDate)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_OtherRevenues_GetSummary", parameters);

            if (dataTable.Rows.Count == 0)
                return (0, 0);

            var row = dataTable.Rows[0];
            var totalAmount = row["TotalAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TotalAmount"]);
            var totalCount = row["TotalCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalCount"]);

            return (totalAmount, totalCount);
        }

        public async Task<List<OtherRevenue>> GetRecurringRevenuesAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_OtherRevenues_GetRecurring", null);

            var revenues = new List<OtherRevenue>();
            foreach (DataRow row in dataTable.Rows)
            {
                revenues.Add(MapToOtherRevenue(row));
            }

            return revenues;
        }

        private OtherRevenue MapToOtherRevenue(DataRow row)
        {
            return new OtherRevenue
            {
                RevenueID = Convert.ToInt32(row["RevenueID"]),
                RevenueCategoryID = Convert.ToInt32(row["RevenueCategoryID"]),
                CategoryName = row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != DBNull.Value
                    ? row["CategoryName"].ToString()
                    : null,
                CategoryNameAr = row.Table.Columns.Contains("CategoryNameAr") && row["CategoryNameAr"] != DBNull.Value
                    ? row["CategoryNameAr"].ToString()
                    : null,
                RevenueDate = Convert.ToDateTime(row["RevenueDate"]),
                Amount = Convert.ToDecimal(row["Amount"]),
                PaymentMethodID = Convert.ToInt32(row["PaymentMethodID"]),
                MethodName = row.Table.Columns.Contains("MethodName") && row["MethodName"] != DBNull.Value
                    ? row["MethodName"].ToString()
                    : null,
                MethodNameAr = row.Table.Columns.Contains("MethodNameAr") && row["MethodNameAr"] != DBNull.Value
                    ? row["MethodNameAr"].ToString()
                    : null,
                ReferenceNumber = row["ReferenceNumber"] == DBNull.Value ? null : row["ReferenceNumber"].ToString(),
                Description = row["Description"] == DBNull.Value ? null : row["Description"].ToString(),
                CustomerID = row["CustomerID"] == DBNull.Value ? null : Convert.ToInt32(row["CustomerID"]),
                CustomerName = row.Table.Columns.Contains("CustomerName") && row["CustomerName"] != DBNull.Value
                    ? row["CustomerName"].ToString()
                    : null,
                ReceiptNumber = row["ReceiptNumber"] == DBNull.Value ? null : row["ReceiptNumber"].ToString(),
                IsRecurring = Convert.ToBoolean(row["IsRecurring"]),
                RecurringPeriod = row["RecurringPeriod"] == DBNull.Value ? null : row["RecurringPeriod"].ToString(),
                Status = row["Status"].ToString() ?? "Received",
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
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