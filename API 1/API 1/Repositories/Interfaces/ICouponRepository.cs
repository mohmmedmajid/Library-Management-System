using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ICouponRepository
    {
        Task<int> InsertAsync(Coupon coupon);
        Task<bool> UpdateAsync(Coupon coupon);
        Task<bool> DeleteAsync(int couponId);
        Task<Coupon?> GetByIdAsync(int couponId);
        Task<Coupon?> GetByCodeAsync(string couponCode);
        Task<List<Coupon>> GetAllAsync(bool? isActive = null, bool currentOnly = false);
        Task<bool> ValidateCouponAsync(string couponCode, int customerId, int productId, int categoryId, decimal purchaseAmount);
        Task<bool> IncrementUsageAsync(int couponId);
    }
}