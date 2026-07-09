using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        Task<int> InsertAsync(Discount discount);
        Task<bool> UpdateAsync(Discount discount);
        Task<bool> DeleteAsync(int discountId);
        Task<Discount?> GetByIdAsync(int discountId);
        Task<List<Discount>> GetAllAsync(bool? isActive = null, bool currentOnly = false);
        Task<List<Discount>> GetApplicableDiscountsAsync(int productId, int categoryId, decimal purchaseAmount);
        Task<bool> IncrementUsageAsync(int discountId);
    }
}