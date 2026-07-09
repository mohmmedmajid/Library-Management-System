using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ILateFeeRepository
    {
        Task<int> InsertAsync(LateFee lateFee);
        Task<bool> UpdateAsync(LateFee lateFee);
        Task<bool> DeleteAsync(int lateFeeId);
        Task<LateFee?> GetByIdAsync(int lateFeeId);
        Task<List<LateFee>> GetByCustomerAsync(int customerId, string? status = null);
        Task<List<LateFee>> GetAllAsync(string? status = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<bool> UpdatePaymentAsync(int lateFeeId, decimal paymentAmount);
        Task<bool> WaiveAsync(int lateFeeId, string? notes);
    }
}
