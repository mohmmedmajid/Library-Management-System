using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        Task<int> InsertAsync(Supplier supplier);
        Task<bool> UpdateAsync(Supplier supplier);
        Task<bool> UpdateTotalsAsync(int supplierId, decimal purchaseAmount, decimal debtAmount);
        Task<bool> DeleteAsync(int supplierId);
        Task<Supplier?> GetByIdAsync(int supplierId);
        Task<List<Supplier>> GetAllAsync(bool? isActive = null);
        Task<List<Supplier>> SearchAsync(string searchTerm);
        Task<List<Supplier>> GetSuppliersWithDebtAsync();
    }
}