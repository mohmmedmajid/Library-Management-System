using API_1.Models;
using API_1.DTOs.SalesRepresentative;

namespace API_1.Services.Interfaces
{
    public interface ISalesRepresentativeService
    {
        Task<int> CreateAsync(CreateSalesRepresentativeDTO dto);
        Task<bool> UpdateAsync(UpdateSalesRepresentativeDTO dto);
        Task<bool> DeleteAsync(int salesRepId);
        Task<SalesRepresentative?> GetByIdAsync(int salesRepId);
        Task<List<SalesRepresentative>> GetAllAsync(bool? isActive = null);
        Task<bool> UpdateTotalsAsync(int salesRepId, decimal salesAmount, decimal commissionAmount);
    }
}
