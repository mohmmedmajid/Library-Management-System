using API_1.DTOs.Supplier;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<int> CreateAsync(CreateSupplierDTO dto);
        Task<bool> UpdateAsync(UpdateSupplierDTO dto);
        Task<bool> UpdateTotalsAsync(UpdateSupplierTotalsDTO dto);
        Task<bool> DeleteAsync(int supplierId);
        Task<Supplier?> GetByIdAsync(int supplierId);
        Task<List<Supplier>> GetAllAsync(bool? isActive = null);
        Task<List<Supplier>> SearchAsync(string searchTerm);
        Task<List<Supplier>> GetSuppliersWithDebtAsync();
        Task<(decimal TotalPurchases, decimal TotalDebt, int SupplierCount)> GetSupplierStatisticsAsync();
    }
}