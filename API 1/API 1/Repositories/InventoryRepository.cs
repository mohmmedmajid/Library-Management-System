using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public InventoryRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public async Task<bool> UpdateStockAsync(int productId, int quantity, string movementType)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@MovementType", movementType)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Inventory_UpdateStock", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> UpdateBorrowedAsync(int productId, int quantity, string operation)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@Operation", operation)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Inventory_UpdateBorrowed", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Inventory?> GetByProductIdAsync(int productId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Inventory_GetByProductID", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToInventory(dataTable.Rows[0]);
        }


        public async Task<List<Inventory>> GetAllAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Inventory_GetAll", null);

            var inventories = new List<Inventory>();
            foreach (DataRow row in dataTable.Rows)
            {
                inventories.Add(MapToInventory(row));
            }

            return inventories;
        }


        public async Task<List<Inventory>> GetLowStockAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Inventory_GetLowStock", null);

            var inventories = new List<Inventory>();
            foreach (DataRow row in dataTable.Rows)
            {
                inventories.Add(MapToInventory(row));
            }

            return inventories;
        }

        public async Task<bool> SetMinimumLevelAsync(int productId, int minimumStockLevel)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@MinimumStockLevel", minimumStockLevel)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Inventory_SetMinimumLevel", parameters));
            return result > 0;
        }


        private Inventory MapToInventory(DataRow row)
        {
            return new Inventory
            {
                InventoryID = Convert.ToInt32(row["InventoryID"]),
                ProductID = Convert.ToInt32(row["ProductID"]),
                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value ? row["ProductName"].ToString() : null,
                ProductNameAr = row.Table.Columns.Contains("ProductNameAr") && row["ProductNameAr"] != DBNull.Value ? row["ProductNameAr"].ToString() : null,
                CategoryName = row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != DBNull.Value ? row["CategoryName"].ToString() : null,
                QuantityInStock = Convert.ToInt32(row["QuantityInStock"]),
                QuantityBorrowed = Convert.ToInt32(row["QuantityBorrowed"]),
                AvailableQuantity = Convert.ToInt32(row["AvailableQuantity"]),
                MinimumStockLevel = Convert.ToInt32(row["MinimumStockLevel"]),
                LastRestockDate = row["LastRestockDate"] == DBNull.Value ? null : Convert.ToDateTime(row["LastRestockDate"]),
                LastUpdatedDate = row.Table.Columns.Contains("LastUpdatedDate") ? Convert.ToDateTime(row["LastUpdatedDate"]) : DateTime.Now
            };
        }
    }
}