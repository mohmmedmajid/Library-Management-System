using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class InventoryMovementRepository : IInventoryMovementRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public InventoryMovementRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public async Task<int> InsertAsync(InventoryMovement movement)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", movement.ProductID),
                new SqlParameter("@MovementType", movement.MovementType),
                new SqlParameter("@Quantity", movement.Quantity),
                new SqlParameter("@UnitPrice", (object?)movement.UnitPrice ?? DBNull.Value),
                new SqlParameter("@TotalAmount", (object?)movement.TotalAmount ?? DBNull.Value),
                new SqlParameter("@ReferenceType", (object?)movement.ReferenceType ?? DBNull.Value),
                new SqlParameter("@ReferenceID", (object?)movement.ReferenceID ?? DBNull.Value),
                new SqlParameter("@Notes", (object?)movement.Notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)movement.CreatedBy ?? DBNull.Value),
                new SqlParameter("@MovementID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_InventoryMovements_Insert", parameters));

            return (int)parameters[9].Value;
        }


        public async Task<List<InventoryMovement>> GetByProductAsync(int productId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InventoryMovements_GetByProduct", parameters);

            var movements = new List<InventoryMovement>();
            foreach (DataRow row in dataTable.Rows)
            {
                movements.Add(MapToInventoryMovement(row));
            }

            return movements;
        }


        public async Task<List<InventoryMovement>> GetAllAsync(string? movementType = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@MovementType", (object?)movementType ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InventoryMovements_GetAll", parameters);

            var movements = new List<InventoryMovement>();
            foreach (DataRow row in dataTable.Rows)
            {
                movements.Add(MapToInventoryMovement(row));
            }

            return movements;
        }


        public async Task<DataTable> GetSummaryAsync(DateTime startDate, DateTime endDate)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InventoryMovements_GetSummary", parameters);

            return dataTable;
        }


        private InventoryMovement MapToInventoryMovement(DataRow row)
        {
            return new InventoryMovement
            {
                MovementID = Convert.ToInt32(row["MovementID"]),
                ProductID = Convert.ToInt32(row["ProductID"]),
                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value ? row["ProductName"].ToString() : null,
                MovementType = row["MovementType"].ToString() ?? string.Empty,
                Quantity = Convert.ToInt32(row["Quantity"]),
                UnitPrice = row["UnitPrice"] == DBNull.Value ? null : Convert.ToDecimal(row["UnitPrice"]),
                TotalAmount = row["TotalAmount"] == DBNull.Value ? null : Convert.ToDecimal(row["TotalAmount"]),
                ReferenceType = row["ReferenceType"] == DBNull.Value ? null : row["ReferenceType"].ToString(),
                ReferenceID = row["ReferenceID"] == DBNull.Value ? null : Convert.ToInt32(row["ReferenceID"]),
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value ? row["Notes"].ToString() : null,
                MovementDate = Convert.ToDateTime(row["MovementDate"]),
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value ? Convert.ToInt32(row["CreatedBy"]) : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value ? row["CreatedByName"].ToString() : null
            };
        }
    }
}