using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public DiscountRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(Discount discount)
        {
            var parameters = new[]
            {
                new SqlParameter("@DiscountName", discount.DiscountName),
                new SqlParameter("@DiscountNameAr", discount.DiscountNameAr),
                new SqlParameter("@DiscountType", discount.DiscountType),
                new SqlParameter("@DiscountValue", discount.DiscountValue),
                new SqlParameter("@MinimumPurchaseAmount", discount.MinimumPurchaseAmount),
                new SqlParameter("@MaximumDiscountAmount", (object?)discount.MaximumDiscountAmount ?? DBNull.Value),
                new SqlParameter("@ApplicableOn", discount.ApplicableOn),
                new SqlParameter("@CategoryID", (object?)discount.CategoryID ?? DBNull.Value),
                new SqlParameter("@ProductID", (object?)discount.ProductID ?? DBNull.Value),
                new SqlParameter("@StartDate", discount.StartDate),
                new SqlParameter("@EndDate", discount.EndDate),
                new SqlParameter("@UsageLimit", (object?)discount.UsageLimit ?? DBNull.Value),
                new SqlParameter("@Description", (object?)discount.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)discount.CreatedBy ?? DBNull.Value),
                new SqlParameter("@DiscountID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Discounts_Insert", parameters));

            return (int)parameters[14].Value;
        }

        public async Task<bool> UpdateAsync(Discount discount)
        {
            var parameters = new[]
            {
                new SqlParameter("@DiscountID", discount.DiscountID),
                new SqlParameter("@DiscountName", discount.DiscountName),
                new SqlParameter("@DiscountNameAr", discount.DiscountNameAr),
                new SqlParameter("@DiscountType", discount.DiscountType),
                new SqlParameter("@DiscountValue", discount.DiscountValue),
                new SqlParameter("@MinimumPurchaseAmount", discount.MinimumPurchaseAmount),
                new SqlParameter("@MaximumDiscountAmount", (object?)discount.MaximumDiscountAmount ?? DBNull.Value),
                new SqlParameter("@StartDate", discount.StartDate),
                new SqlParameter("@EndDate", discount.EndDate),
                new SqlParameter("@UsageLimit", (object?)discount.UsageLimit ?? DBNull.Value),
                new SqlParameter("@Description", (object?)discount.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", discount.IsActive)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Discounts_Update", parameters));
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int discountId)
        {
            var parameters = new[]
            {
                new SqlParameter("@DiscountID", discountId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Discounts_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Discount?> GetByIdAsync(int discountId)
        {
            var parameters = new[]
            {
                new SqlParameter("@DiscountID", discountId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Discounts_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToDiscount(dataTable.Rows[0]);
        }

        public async Task<List<Discount>> GetAllAsync(bool? isActive = null, bool currentOnly = false)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value),
                new SqlParameter("@CurrentOnly", currentOnly)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Discounts_GetAll", parameters);

            var discounts = new List<Discount>();
            foreach (DataRow row in dataTable.Rows)
            {
                discounts.Add(MapToDiscount(row));
            }

            return discounts;
        }

        public async Task<List<Discount>> GetApplicableDiscountsAsync(int productId, int categoryId, decimal purchaseAmount)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@CategoryID", categoryId),
                new SqlParameter("@PurchaseAmount", purchaseAmount)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Discounts_GetApplicable", parameters);

            var discounts = new List<Discount>();
            foreach (DataRow row in dataTable.Rows)
            {
                discounts.Add(MapToDiscount(row));
            }

            return discounts;
        }

        public async Task<bool> IncrementUsageAsync(int discountId)
        {
            var parameters = new[]
            {
                new SqlParameter("@DiscountID", discountId)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Discounts_IncrementUsage", parameters));
            return result > 0;
        }

        private Discount MapToDiscount(DataRow row)
        {
            return new Discount
            {
                DiscountID = Convert.ToInt32(row["DiscountID"]),
                DiscountName = row["DiscountName"].ToString() ?? string.Empty,
                DiscountNameAr = row["DiscountNameAr"].ToString() ?? string.Empty,
                DiscountType = row.Table.Columns.Contains("DiscountType") && row["DiscountType"] != DBNull.Value
                    ? row["DiscountType"].ToString() ?? string.Empty : string.Empty,
                DiscountValue = row.Table.Columns.Contains("DiscountValue") && row["DiscountValue"] != DBNull.Value
                    ? Convert.ToDecimal(row["DiscountValue"]) : 0,
                MinimumPurchaseAmount = row.Table.Columns.Contains("MinimumPurchaseAmount") && row["MinimumPurchaseAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["MinimumPurchaseAmount"]) : 0,
                MaximumDiscountAmount = row.Table.Columns.Contains("MaximumDiscountAmount") && row["MaximumDiscountAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["MaximumDiscountAmount"]) : null,
                ApplicableOn = row.Table.Columns.Contains("ApplicableOn") && row["ApplicableOn"] != DBNull.Value
                    ? row["ApplicableOn"].ToString() ?? string.Empty : string.Empty,
                CategoryID = row.Table.Columns.Contains("CategoryID") && row["CategoryID"] != DBNull.Value
                    ? Convert.ToInt32(row["CategoryID"]) : null,
                CategoryName = row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != DBNull.Value
                    ? row["CategoryName"].ToString() : null,
                ProductID = row.Table.Columns.Contains("ProductID") && row["ProductID"] != DBNull.Value
                    ? Convert.ToInt32(row["ProductID"]) : null,
                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value
                    ? row["ProductName"].ToString() : null,
                StartDate = row.Table.Columns.Contains("StartDate") && row["StartDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["StartDate"]) : DateTime.Now,
                EndDate = row.Table.Columns.Contains("EndDate") && row["EndDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["EndDate"]) : DateTime.Now,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                UsageLimit = row.Table.Columns.Contains("UsageLimit") && row["UsageLimit"] != DBNull.Value
                    ? Convert.ToInt32(row["UsageLimit"]) : null,
                UsageCount = row.Table.Columns.Contains("UsageCount") && row["UsageCount"] != DBNull.Value
                    ? Convert.ToInt32(row["UsageCount"]) : 0,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}