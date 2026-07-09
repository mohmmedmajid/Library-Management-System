using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public CategoryRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public async Task<int> InsertAsync(Category category)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@CategoryNameAr", category.CategoryNameAr),
                new SqlParameter("@Description", (object?)category.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)category.CreatedBy ?? DBNull.Value),
                new SqlParameter("@CategoryID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Categories_Insert", parameters));

            return (int)parameters[4].Value;
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryID", category.CategoryID),
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@CategoryNameAr", category.CategoryNameAr),
                new SqlParameter("@Description", (object?)category.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", category.IsActive)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Categories_Update", parameters));
            return result > 0;
        }


        public async Task<bool> DeleteAsync(int categoryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryID", categoryId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Categories_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

     
        public async Task<Category?> GetByIdAsync(int categoryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryID", categoryId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Categories_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToCategory(dataTable.Rows[0]);
        }


        public async Task<List<Category>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Categories_GetAll", parameters);

            var categories = new List<Category>();
            foreach (DataRow row in dataTable.Rows)
            {
                categories.Add(MapToCategory(row));
            }

            return categories;
        }

    
        public async Task<List<Category>> GetWithProductCountAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Categories_GetWithProductCount", null);

            var categories = new List<Category>();
            foreach (DataRow row in dataTable.Rows)
            {
                categories.Add(MapToCategoryWithCount(row));
            }

            return categories;
        }


        private Category MapToCategory(DataRow row)
        {
            return new Category
            {
                CategoryID = Convert.ToInt32(row["CategoryID"]),
                CategoryName = row["CategoryName"].ToString() ?? string.Empty,
                CategoryNameAr = row["CategoryNameAr"].ToString() ?? string.Empty,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }

        private Category MapToCategoryWithCount(DataRow row)
        {
            var category = MapToCategory(row);
            category.ProductCount = row.Table.Columns.Contains("ProductCount") && row["ProductCount"] != DBNull.Value
                ? Convert.ToInt32(row["ProductCount"]) : 0;
            return category;
        }
    }
}