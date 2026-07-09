using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ISalesRepresentativeRepository
    {
        Task<int> InsertAsync(SalesRepresentative salesRep);
        Task<bool> UpdateAsync(SalesRepresentative salesRep);
        Task<bool> DeleteAsync(int salesRepId);
        Task<SalesRepresentative?> GetByIdAsync(int salesRepId);
        Task<List<SalesRepresentative>> GetAllAsync(bool? isActive = null);
        Task<bool> UpdateTotalsAsync(int salesRepId, decimal salesAmount, decimal commissionAmount);
    }
}
    

