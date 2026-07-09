using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public ProductRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public async Task<int> InsertAsync(Product product)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductName", product.ProductName),
                new SqlParameter("@ProductNameAr", product.ProductNameAr),
                new SqlParameter("@CategoryID", product.CategoryID),
                new SqlParameter("@Barcode", (object?)product.Barcode ?? DBNull.Value),
                new SqlParameter("@UnitPrice", product.UnitPrice),
                new SqlParameter("@CostPrice", product.CostPrice),
                new SqlParameter("@Description", (object?)product.Description ?? DBNull.Value),
                new SqlParameter("@ProductType", product.ProductType),
                new SqlParameter("@CreatedBy", (object?)product.CreatedBy ?? DBNull.Value),
                new SqlParameter("@ProductID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Products_Insert", parameters));
                return (int)parameters[9].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> UpdateAsync(Product product)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", product.ProductID),
                new SqlParameter("@ProductName", product.ProductName),
                new SqlParameter("@ProductNameAr", product.ProductNameAr),
                new SqlParameter("@CategoryID", product.CategoryID),
                new SqlParameter("@Barcode", (object?)product.Barcode ?? DBNull.Value),
                new SqlParameter("@UnitPrice", product.UnitPrice),
                new SqlParameter("@CostPrice", product.CostPrice),
                new SqlParameter("@Description", (object?)product.Description ?? DBNull.Value),
                new SqlParameter("@ProductType", product.ProductType),
                new SqlParameter("@IsActive", product.IsActive)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Products_Update", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> DeleteAsync(int productId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Products_Delete", parameters));
            return result > 0;
        }


        public async Task<Product?> GetByIdAsync(int productId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Products_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToProduct(dataTable.Rows[0]);
        }


        public async Task<List<Product>> GetAllAsync(bool? isActive = null, int? categoryId = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value),
                new SqlParameter("@CategoryID", (object?)categoryId ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Products_GetAll", parameters);

            var products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(MapToProduct(row));
            }

            return products;
        }


        public async Task<List<Product>> SearchAsync(string searchTerm)
        {
            var parameters = new[]
            {
                new SqlParameter("@SearchTerm", searchTerm)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Products_Search", parameters);

            var products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(MapToProductSearch(row));
            }

            return products;
        }


        public async Task<Product?> GetByBarcodeAsync(string barcode)
        {
            var parameters = new[]
            {
                new SqlParameter("@Barcode", barcode)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Products_GetByBarcode", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToProduct(dataTable.Rows[0]);
        }


        private Product MapToProduct(DataRow row)
        {
            return new Product
            {
                ProductID = Convert.ToInt32(row["ProductID"]),
                ProductName = row["ProductName"].ToString() ?? string.Empty,
                ProductNameAr = row["ProductNameAr"].ToString() ?? string.Empty,
                CategoryID = row.Table.Columns.Contains("CategoryID") && row["CategoryID"] != DBNull.Value
                    ? Convert.ToInt32(row["CategoryID"]) : 0,
                CategoryName = row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != DBNull.Value
                    ? row["CategoryName"].ToString() : null,
                Barcode = row.Table.Columns.Contains("Barcode") && row["Barcode"] != DBNull.Value
                    ? row["Barcode"].ToString() : null,
                UnitPrice = row.Table.Columns.Contains("UnitPrice") && row["UnitPrice"] != DBNull.Value
                    ? Convert.ToDecimal(row["UnitPrice"]) : 0,
                CostPrice = row.Table.Columns.Contains("CostPrice") && row["CostPrice"] != DBNull.Value
                    ? Convert.ToDecimal(row["CostPrice"]) : 0,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
                ProductType = row.Table.Columns.Contains("ProductType") && row["ProductType"] != DBNull.Value
                    ? row["ProductType"].ToString() ?? "Other" : "Other",
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                QuantityInStock = row.Table.Columns.Contains("QuantityInStock") && row["QuantityInStock"] != DBNull.Value
                    ? Convert.ToInt32(row["QuantityInStock"]) : 0,
                QuantityBorrowed = row.Table.Columns.Contains("QuantityBorrowed") && row["QuantityBorrowed"] != DBNull.Value
                    ? Convert.ToInt32(row["QuantityBorrowed"]) : 0,
                AvailableQuantity = row.Table.Columns.Contains("AvailableQuantity") && row["AvailableQuantity"] != DBNull.Value
                    ? Convert.ToInt32(row["AvailableQuantity"]) : 0
            };
        }

        private Product MapToProductSearch(DataRow row)
        {
            return new Product
            {
                ProductID = Convert.ToInt32(row["ProductID"]),
                ProductName = row["ProductName"].ToString() ?? string.Empty,
                ProductNameAr = row["ProductNameAr"].ToString() ?? string.Empty,
                CategoryName = row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != DBNull.Value
                    ? row["CategoryName"].ToString() : null,
                Barcode = row.Table.Columns.Contains("Barcode") && row["Barcode"] != DBNull.Value
                    ? row["Barcode"].ToString() : null,
                UnitPrice = row.Table.Columns.Contains("UnitPrice") && row["UnitPrice"] != DBNull.Value
                    ? Convert.ToDecimal(row["UnitPrice"]) : 0,
                AvailableQuantity = row.Table.Columns.Contains("AvailableQuantity") && row["AvailableQuantity"] != DBNull.Value
                    ? Convert.ToInt32(row["AvailableQuantity"]) : 0
            };
        }
    }
}
