using API_1.Models;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using API_1.Repositories.Interfaces;

namespace API_1.Repositories
{
    public class BarcodeRepository : IBarcodeRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public BarcodeRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(Barcode barcode)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", barcode.ProductID),
                new SqlParameter("@BarcodeValue", barcode.BarcodeValue),
                new SqlParameter("@BarcodeType", barcode.BarcodeType),
                new SqlParameter("@IsDefault", barcode.IsDefault),
                new SqlParameter("@BarcodeID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_Barcodes_Insert", parameters);
                return (int)parameters[4].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting barcode: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(Barcode barcode)
        {
            var parameters = new[]
            {
                new SqlParameter("@BarcodeID", barcode.BarcodeID),
                new SqlParameter("@BarcodeValue", barcode.BarcodeValue),
                new SqlParameter("@BarcodeType", barcode.BarcodeType),
                new SqlParameter("@IsDefault", barcode.IsDefault)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Barcodes_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating barcode: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int barcodeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BarcodeID", barcodeId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_Barcodes_Delete", parameters);
            return result > 0;
        }

        public async Task<Barcode?> GetByIdAsync(int barcodeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BarcodeID", barcodeId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Barcodes_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToBarcode(dataTable.Rows[0]);
        }

        public async Task<List<Barcode>> GetByProductAsync(int productId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Barcodes_GetByProduct", parameters);

            var barcodes = new List<Barcode>();
            foreach (DataRow row in dataTable.Rows)
            {
                barcodes.Add(MapToBarcode(row));
            }

            return barcodes;
        }

        public async Task<List<Barcode>> GetAllAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Barcodes_GetAll", null);

            var barcodes = new List<Barcode>();
            foreach (DataRow row in dataTable.Rows)
            {
                barcodes.Add(MapToBarcode(row));
            }

            return barcodes;
        }

        public async Task<Barcode?> GetProductByBarcodeAsync(string barcodeValue)
        {
            var parameters = new[]
            {
                new SqlParameter("@BarcodeValue", barcodeValue)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Barcodes_GetProductByBarcode", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToBarcode(dataTable.Rows[0]);
        }

        private Barcode MapToBarcode(DataRow row)
        {
            return new Barcode
            {
                BarcodeID = Convert.ToInt32(row["BarcodeID"]),
                ProductID = Convert.ToInt32(row["ProductID"]),
                BarcodeValue = row["BarcodeValue"].ToString() ?? string.Empty,
                BarcodeType = row["BarcodeType"].ToString() ?? string.Empty,
                IsDefault = Convert.ToBoolean(row["IsDefault"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                
                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value
                    ? row["ProductName"].ToString() : null,
                UnitPrice = row.Table.Columns.Contains("UnitPrice") && row["UnitPrice"] != DBNull.Value
                    ? Convert.ToDecimal(row["UnitPrice"]) : null,
                AvailableQuantity = row.Table.Columns.Contains("AvailableQuantity") && row["AvailableQuantity"] != DBNull.Value
                    ? Convert.ToInt32(row["AvailableQuantity"]) : null
            };
        }
    }
}
