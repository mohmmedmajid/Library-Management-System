using API_1.DTOs.Coupon;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ICouponService
    {
        Task<int> CreateAsync(CreateCouponDTO dto);
        Task<bool> UpdateAsync(UpdateCouponDTO dto);
        Task<bool> DeleteAsync(int couponId);
        Task<Coupon?> GetByIdAsync(int couponId);
        Task<Coupon?> GetByCodeAsync(string couponCode);
        Task<List<Coupon>> GetAllAsync(GetAllCouponsDTO dto);
        Task<List<Coupon>> GetActiveCouponsAsync();
        Task<(bool IsValid, string ErrorMessage)> ValidateCouponAsync(ValidateCouponDTO dto);
        Task<bool> IncrementUsageAsync(int couponId);
        Task<decimal> CalculateCouponDiscountAsync(string couponCode, decimal purchaseAmount);
    }
}