using API_1.DTOs.TaxDeclaration;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ITaxDeclarationService
    {
        Task<int> CreateAsync(CreateTaxDeclarationDTO dto);
        Task<bool> SubmitAsync(SubmitTaxDeclarationDTO dto);
        Task<bool> MarkAsPaidAsync(PayTaxDeclarationDTO dto);
        Task<TaxDeclaration?> GetByIdAsync(int declarationId);
        Task<List<TaxDeclaration>> GetAllAsync(GetAllTaxDeclarationsDTO dto);
    }
}
