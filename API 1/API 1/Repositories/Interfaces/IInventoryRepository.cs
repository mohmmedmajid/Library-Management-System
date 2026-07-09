using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        Task<bool> UpdateStockAsync(int productId, int quantity, string movementType);
        Task<bool> UpdateBorrowedAsync(int productId, int quantity, string operation);
        Task<Inventory?> GetByProductIdAsync(int productId);
        Task<List<Inventory>> GetAllAsync();
        Task<List<Inventory>> GetLowStockAsync();
        Task<bool> SetMinimumLevelAsync(int productId, int minimumStockLevel);
    }
}