using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class FixedAssetCategoryRepository : IFixedAssetCategoryRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public FixedAssetCategoryRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(FixedAssetCategory category)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryCode", category.CategoryCode),
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@CategoryNameAr", category.CategoryNameAr),
                new SqlParameter("@DepreciationMethod", category.DepreciationMethod),
                new SqlParameter("@UsefulLifeYears", category.UsefulLifeYears),
                new SqlParameter("@AnnualDepreciationRate", category.AnnualDepreciationRate),
                new SqlParameter("@SalvageValuePercent", category.SalvageValuePercent),
                new SqlParameter("@Description", (object?)category.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)category.CreatedBy ?? DBNull.Value),
                new SqlParameter("@CategoryID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_FixedAssetCategories_Insert", parameters);
                return (int)parameters[9].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting fixed asset category: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(FixedAssetCategory category)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryID", category.CategoryID),
                new SqlParameter("@CategoryCode", category.CategoryCode),
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@CategoryNameAr", category.CategoryNameAr),
                new SqlParameter("@DepreciationMethod", category.DepreciationMethod),
                new SqlParameter("@UsefulLifeYears", category.UsefulLifeYears),
                new SqlParameter("@AnnualDepreciationRate", category.AnnualDepreciationRate),
                new SqlParameter("@SalvageValuePercent", category.SalvageValuePercent),
                new SqlParameter("@Description", (object?)category.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", category.IsActive)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_FixedAssetCategories_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating fixed asset category: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryID", categoryId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_FixedAssetCategories_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting fixed asset category: {ex.Message}", ex);
            }
        }

        public async Task<FixedAssetCategory?> GetByIdAsync(int categoryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryID", categoryId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_FixedAssetCategories_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToFixedAssetCategory(dataTable.Rows[0]);
        }

        public async Task<List<FixedAssetCategory>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_FixedAssetCategories_GetAll", parameters);

            var categories = new List<FixedAssetCategory>();
            foreach (DataRow row in dataTable.Rows)
            {
                categories.Add(MapToFixedAssetCategory(row));
            }

            return categories;
        }

        private FixedAssetCategory MapToFixedAssetCategory(DataRow row)
        {
            return new FixedAssetCategory
            {
                CategoryID = Convert.ToInt32(row["CategoryID"]),
                CategoryCode = row["CategoryCode"]?.ToString() ?? string.Empty,
                CategoryName = row["CategoryName"]?.ToString() ?? string.Empty,
                CategoryNameAr = row["CategoryNameAr"]?.ToString() ?? string.Empty,
                DepreciationMethod = row["DepreciationMethod"]?.ToString() ?? string.Empty,
                UsefulLifeYears = row.Table.Columns.Contains("UsefulLifeYears") && row["UsefulLifeYears"] != DBNull.Value
                                         ? Convert.ToInt32(row["UsefulLifeYears"]) : 0,
                AnnualDepreciationRate = row.Table.Columns.Contains("AnnualDepreciationRate") && row["AnnualDepreciationRate"] != DBNull.Value
                                         ? Convert.ToDecimal(row["AnnualDepreciationRate"]) : 0,
                SalvageValuePercent = row.Table.Columns.Contains("SalvageValuePercent") && row["SalvageValuePercent"] != DBNull.Value
                                         ? Convert.ToDecimal(row["SalvageValuePercent"]) : 0,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                                         ? row["Description"].ToString() : null,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                                         && Convert.ToBoolean(row["IsActive"]),
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
