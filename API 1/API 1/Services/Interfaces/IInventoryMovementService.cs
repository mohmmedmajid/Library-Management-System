using API_1.DTOs.InventoryMovement;
using API_1.Models;
using System.Data;

namespace API_1.Services.Interfaces
{
    public interface IInventoryMovementService
    {
        Task<int> CreateAsync(CreateInventoryMovementDTO dto);
        Task<List<InventoryMovement>> GetByProductAsync(GetMovementsByProductDTO dto);
        Task<List<InventoryMovement>> GetAllAsync(GetAllMovementsDTO dto);
        Task<DataTable> GetSummaryAsync(GetMovementsSummaryDTO dto);
    }
}