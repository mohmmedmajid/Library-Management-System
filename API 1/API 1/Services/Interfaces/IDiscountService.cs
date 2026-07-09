using API_1.DTOs.Discount;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<int> CreateAsync(CreateDiscountDTO dto);
        Task<bool> UpdateAsync(UpdateDiscountDTO dto);
        Task<bool> DeleteAsync(int discountId);
        Task<Discount?> GetByIdAsync(int discountId);
        Task<List<Discount>> GetAllAsync(GetAllDiscountsDTO dto);
        Task<List<Discount>> GetActiveDiscountsAsync();
        Task<List<Discount>> GetApplicableDiscountsAsync(GetApplicableDiscountsDTO dto);
        Task<bool> IncrementUsageAsync(int discountId);
        Task<decimal> CalculateDiscountAmountAsync(int discountId, decimal purchaseAmount);
    }
}