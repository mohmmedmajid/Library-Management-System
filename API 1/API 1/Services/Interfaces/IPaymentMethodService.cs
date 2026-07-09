using API_1.DTOs.PaymentMethod;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<int> CreateAsync(CreatePaymentMethodDTO dto);
        Task<bool> UpdateAsync(UpdatePaymentMethodDTO dto);
        Task<bool> DeleteAsync(int paymentMethodId);
        Task<PaymentMethod?> GetByIdAsync(int paymentMethodId);
        Task<List<PaymentMethod>> GetAllAsync(bool? isActive = null);
    }
}