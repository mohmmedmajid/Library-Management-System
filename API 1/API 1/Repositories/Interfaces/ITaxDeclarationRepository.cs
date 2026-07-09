using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ITaxDeclarationRepository
    {
        Task<int> CreateAsync(TaxDeclaration declaration);
        Task<bool> SubmitAsync(int declarationId);
        Task<bool> MarkAsPaidAsync(int declarationId, decimal paidAmount, string paymentReference);
        Task<TaxDeclaration?> GetByIdAsync(int declarationId);
        Task<List<TaxDeclaration>> GetAllAsync(int? taxTypeId = null, string? declarationType = null, int? fiscalYear = null, string? status = null);
    }
}
