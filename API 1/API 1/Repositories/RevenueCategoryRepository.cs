using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class RevenueCategoryRepository : IRevenueCategoryRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public RevenueCategoryRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(RevenueCategory category)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@CategoryNameAr", category.CategoryNameAr),
                new SqlParameter("@Description", (object?)category.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)category.CreatedBy ?? DBNull.Value),
                new SqlParameter("@RevenueCategoryID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_RevenueCategories_Insert", parameters));

            return (int)parameters[4].Value;
        }
        public async Task<bool> UpdateAsync(RevenueCategory category)
        {
            var parameters = new[]
            {
                new SqlParameter("@RevenueCategoryID", category.RevenueCategoryID),
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@CategoryNameAr", category.CategoryNameAr),
                new SqlParameter("@Description", (object?)category.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", category.IsActive)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_RevenueCategories_Update", parameters));
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@RevenueCategoryID", categoryId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_RevenueCategories_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RevenueCategory?> GetByIdAsync(int categoryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@RevenueCategoryID", categoryId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_RevenueCategories_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToRevenueCategory(dataTable.Rows[0]);
        }
        public async Task<List<RevenueCategory>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_RevenueCategories_GetAll", parameters);

            var categories = new List<RevenueCategory>();
            foreach (DataRow row in dataTable.Rows)
            {
                categories.Add(MapToRevenueCategory(row));
            }

            return categories;
        }
        public async Task<List<RevenueCategory>> GetWithTotalsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_RevenueCategories_GetWithTotals", parameters);

            var categories = new List<RevenueCategory>();
            foreach (DataRow row in dataTable.Rows)
            {
                categories.Add(MapToRevenueCategoryWithTotals(row));
            }

            return categories;
        }
        private RevenueCategory MapToRevenueCategory(DataRow row)
        {
            return new RevenueCategory
            {
                RevenueCategoryID = Convert.ToInt32(row["RevenueCategoryID"]),
                CategoryName = row["CategoryName"].ToString() ?? string.Empty,
                CategoryNameAr = row["CategoryNameAr"].ToString() ?? string.Empty,
                Description = row["Description"] == DBNull.Value ? null : row["Description"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"])
                    : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString()
                    : null
            };
        }
        private RevenueCategory MapToRevenueCategoryWithTotals(DataRow row)
        {
            var category = MapToRevenueCategory(row);

            category.RevenueCount = row.Table.Columns.Contains("RevenueCount")
                ? Convert.ToInt32(row["RevenueCount"])
                : 0;

            category.TotalAmount = row.Table.Columns.Contains("TotalAmount")
                ? Convert.ToDecimal(row["TotalAmount"])
                : 0;

            return category;
        }
    }
}