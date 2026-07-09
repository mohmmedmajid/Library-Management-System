using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public ExpenseCategoryRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(ExpenseCategory category)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@CategoryNameAr", category.CategoryNameAr),
                new SqlParameter("@Description", (object?)category.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)category.CreatedBy ?? DBNull.Value),
                new SqlParameter("@ExpenseCategoryID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_ExpenseCategories_Insert", parameters));

            return (int)parameters[4].Value;
        }

        public async Task<bool> UpdateAsync(ExpenseCategory category)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseCategoryID", category.ExpenseCategoryID),
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@CategoryNameAr", category.CategoryNameAr),
                new SqlParameter("@Description", (object?)category.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", category.IsActive)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_ExpenseCategories_Update", parameters));
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseCategoryID", categoryId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_ExpenseCategories_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ExpenseCategory?> GetByIdAsync(int categoryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseCategoryID", categoryId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ExpenseCategories_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToExpenseCategory(dataTable.Rows[0]);
        }
        public async Task<List<ExpenseCategory>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ExpenseCategories_GetAll", parameters);

            var categories = new List<ExpenseCategory>();
            foreach (DataRow row in dataTable.Rows)
            {
                categories.Add(MapToExpenseCategory(row));
            }

            return categories;
        }
        public async Task<List<ExpenseCategory>> GetWithTotalsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ExpenseCategories_GetWithTotals", parameters);

            var categories = new List<ExpenseCategory>();
            foreach (DataRow row in dataTable.Rows)
            {
                categories.Add(MapToExpenseCategoryWithTotals(row));
            }

            return categories;
        }
        private ExpenseCategory MapToExpenseCategory(DataRow row)
        {
            return new ExpenseCategory
            {
                ExpenseCategoryID = Convert.ToInt32(row["ExpenseCategoryID"]),
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

        private ExpenseCategory MapToExpenseCategoryWithTotals(DataRow row)
        {
            var category = MapToExpenseCategory(row);

            category.ExpenseCount = row.Table.Columns.Contains("ExpenseCount")
                ? Convert.ToInt32(row["ExpenseCount"])
                : 0;

            category.TotalAmount = row.Table.Columns.Contains("TotalAmount")
                ? Convert.ToDecimal(row["TotalAmount"])
                : 0;

            return category;
        }
    }
}