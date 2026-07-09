using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<int> InsertAsync(PaymentMethod paymentMethod);
        Task<bool> UpdateAsync(PaymentMethod paymentMethod);
        Task<bool> DeleteAsync(int paymentMethodId);
        Task<PaymentMethod?> GetByIdAsync(int paymentMethodId);
        Task<List<PaymentMethod>> GetAllAsync(bool? isActive = null);
    }
}