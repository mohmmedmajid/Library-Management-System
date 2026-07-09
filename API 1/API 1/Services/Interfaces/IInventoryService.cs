using API_1.DTOs.Inventory;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<bool> UpdateStockAsync(UpdateStockDTO dto);
        Task<bool> UpdateBorrowedAsync(UpdateBorrowedDTO dto);
        Task<Inventory?> GetByProductIdAsync(int productId);
        Task<List<Inventory>> GetAllAsync();
        Task<List<Inventory>> GetLowStockAsync();
        Task<bool> SetMinimumLevelAsync(SetMinimumLevelDTO dto);
    }
}