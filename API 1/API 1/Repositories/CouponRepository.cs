using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public CouponRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(Coupon coupon)
        {
            var parameters = new[]
            {
                new SqlParameter("@CouponCode", coupon.CouponCode),
                new SqlParameter("@CouponName", coupon.CouponName),
                new SqlParameter("@CouponNameAr", coupon.CouponNameAr),
                new SqlParameter("@DiscountType", coupon.DiscountType),
                new SqlParameter("@DiscountValue", coupon.DiscountValue),
                new SqlParameter("@MinimumPurchaseAmount", coupon.MinimumPurchaseAmount),
                new SqlParameter("@MaximumDiscountAmount", (object?)coupon.MaximumDiscountAmount ?? DBNull.Value),
                new SqlParameter("@ApplicableOn", coupon.ApplicableOn),
                new SqlParameter("@CategoryID", coupon.CategoryID.HasValue && coupon.CategoryID > 0 ? coupon.CategoryID : DBNull.Value),
                new SqlParameter("@ProductID", coupon.ProductID.HasValue && coupon.ProductID > 0 ? coupon.ProductID : DBNull.Value),
                new SqlParameter("@StartDate", coupon.StartDate),
                new SqlParameter("@EndDate", coupon.EndDate),
                new SqlParameter("@UsageLimit", (object?)coupon.UsageLimit ?? DBNull.Value),
                new SqlParameter("@UsageLimitPerCustomer", coupon.UsageLimitPerCustomer),
                new SqlParameter("@IsPublic", coupon.IsPublic),
                new SqlParameter("@Description", (object?)coupon.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)coupon.CreatedBy ?? DBNull.Value),
                new SqlParameter("@CouponID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Coupons_Insert", parameters));

            return (int)parameters[17].Value;
        }

        public async Task<bool> UpdateAsync(Coupon coupon)
        {
            var parameters = new[]
            {
                new SqlParameter("@CouponID", coupon.CouponID),
                new SqlParameter("@CouponCode", coupon.CouponCode),
                new SqlParameter("@CouponName", coupon.CouponName),
                new SqlParameter("@CouponNameAr", coupon.CouponNameAr),
                new SqlParameter("@DiscountType", coupon.DiscountType),
                new SqlParameter("@DiscountValue", coupon.DiscountValue),
                new SqlParameter("@MinimumPurchaseAmount", coupon.MinimumPurchaseAmount),
                new SqlParameter("@MaximumDiscountAmount", (object?)coupon.MaximumDiscountAmount ?? DBNull.Value),
                new SqlParameter("@StartDate", coupon.StartDate),
                new SqlParameter("@EndDate", coupon.EndDate),
                new SqlParameter("@UsageLimit", (object?)coupon.UsageLimit ?? DBNull.Value),
                new SqlParameter("@UsageLimitPerCustomer", coupon.UsageLimitPerCustomer),
                new SqlParameter("@IsPublic", coupon.IsPublic),
                new SqlParameter("@Description", (object?)coupon.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", coupon.IsActive)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Coupons_Update", parameters));
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int couponId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CouponID", couponId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Coupons_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Coupon?> GetByIdAsync(int couponId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CouponID", couponId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Coupons_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToCoupon(dataTable.Rows[0]);
        }

        public async Task<Coupon?> GetByCodeAsync(string couponCode)
        {
            var parameters = new[]
            {
                new SqlParameter("@CouponCode", couponCode)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Coupons_GetByCode", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToCoupon(dataTable.Rows[0]);
        }

        public async Task<List<Coupon>> GetAllAsync(bool? isActive = null, bool currentOnly = false)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value),
                new SqlParameter("@CurrentOnly", currentOnly)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Coupons_GetAll", parameters);

            var coupons = new List<Coupon>();
            foreach (DataRow row in dataTable.Rows)
            {
                coupons.Add(MapToCoupon(row));
            }

            return coupons;
        }

        public async Task<bool> ValidateCouponAsync(string couponCode, int customerId, int productId, int categoryId, decimal purchaseAmount)
        {
            var parameters = new[]
            {
                new SqlParameter("@CouponCode", couponCode),
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@CategoryID", categoryId),
                new SqlParameter("@PurchaseAmount", purchaseAmount)
            };

            try
            {
                var result = await _dbHelper.ExecuteScalarAsync("SP_Coupons_Validate", parameters);
                return result != null && Convert.ToInt32(result) == 1;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public async Task<bool> IncrementUsageAsync(int couponId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CouponID", couponId)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Coupons_IncrementUsage", parameters));
            return result > 0;
        }

        private Coupon MapToCoupon(DataRow row)
        {
            return new Coupon
            {
                CouponID = Convert.ToInt32(row["CouponID"]),
                CouponCode = row["CouponCode"].ToString() ?? string.Empty,
                CouponName = row["CouponName"].ToString() ?? string.Empty,
                CouponNameAr = row["CouponNameAr"].ToString() ?? string.Empty,
                DiscountType = row["DiscountType"].ToString() ?? string.Empty,
                DiscountValue = Convert.ToDecimal(row["DiscountValue"]),
                MinimumPurchaseAmount = Convert.ToDecimal(row["MinimumPurchaseAmount"]),
                MaximumDiscountAmount = row.Table.Columns.Contains("MaximumDiscountAmount") && row["MaximumDiscountAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["MaximumDiscountAmount"])
                    : null,
                ApplicableOn = row["ApplicableOn"].ToString() ?? string.Empty,
                CategoryID = row.Table.Columns.Contains("CategoryID") && row["CategoryID"] != DBNull.Value
                    ? Convert.ToInt32(row["CategoryID"])
                    : null,
                CategoryName = row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != DBNull.Value
                    ? row["CategoryName"].ToString()
                    : null,
                ProductID = row.Table.Columns.Contains("ProductID") && row["ProductID"] != DBNull.Value
                    ? Convert.ToInt32(row["ProductID"])
                    : null,
                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value
                    ? row["ProductName"].ToString()
                    : null,
                StartDate = Convert.ToDateTime(row["StartDate"]),
                EndDate = Convert.ToDateTime(row["EndDate"]),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                UsageLimit = row.Table.Columns.Contains("UsageLimit") && row["UsageLimit"] != DBNull.Value
                    ? Convert.ToInt32(row["UsageLimit"])
                    : null,
                UsageLimitPerCustomer = row.Table.Columns.Contains("UsageLimitPerCustomer") && row["UsageLimitPerCustomer"] != DBNull.Value
                    ? Convert.ToInt32(row["UsageLimitPerCustomer"])
                    : 0,
                UsageCount = row.Table.Columns.Contains("UsageCount") && row["UsageCount"] != DBNull.Value
                    ? Convert.ToInt32(row["UsageCount"])
                    : 0,
                IsPublic = row.Table.Columns.Contains("IsPublic") && row["IsPublic"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsPublic"])
                    : false,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString()
                    : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"])
                    : DateTime.MinValue,
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