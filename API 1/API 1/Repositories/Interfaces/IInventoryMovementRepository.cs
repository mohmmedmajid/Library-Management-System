using API_1.Models;
using System.Data;

namespace API_1.Repositories.Interfaces
{
    public interface IInventoryMovementRepository
    {
        Task<int> InsertAsync(InventoryMovement movement);
        Task<List<InventoryMovement>> GetByProductAsync(int productId, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<InventoryMovement>> GetAllAsync(string? movementType = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<DataTable> GetSummaryAsync(DateTime startDate, DateTime endDate);
    }
}