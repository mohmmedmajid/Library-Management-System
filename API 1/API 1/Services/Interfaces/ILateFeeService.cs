using API_1.Models;
using API_1.DTOs.LateFee;

namespace API_1.Services.Interfaces
{
    public interface ILateFeeService
    {
        Task<int> CreateAsync(CreateLateFeeDTO dto);
        Task<bool> UpdateAsync(UpdateLateFeeDTO dto);
        Task<bool> DeleteAsync(int lateFeeId);
        Task<LateFee?> GetByIdAsync(int lateFeeId);
        Task<List<LateFee>> GetByCustomerAsync(GetLateFeesByCustomerDTO dto);
        Task<List<LateFee>> GetAllAsync(GetAllLateFeesDTO dto);
        Task<bool> UpdatePaymentAsync(int lateFeeId, decimal paymentAmount);
        Task<bool> WaiveAsync(int lateFeeId, string? notes);
    }
}
