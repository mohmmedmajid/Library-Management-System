using API_1.DTOs.InvoiceTax;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IInvoiceTaxService
    {
        Task<int> CreateAsync(CreateInvoiceTaxDTO dto);
        Task<bool> UpdateAsync(UpdateInvoiceTaxDTO dto);
        Task<bool> DeleteAsync(int invoiceTaxId);
        Task<InvoiceTax?> GetByIdAsync(int invoiceTaxId);
        Task<List<InvoiceTax>> GetByInvoiceIdAsync(int invoiceId);
        Task<List<InvoiceTax>> GetAllAsync(GetAllInvoiceTaxesDTO dto);
        Task<List<InvoiceTax>> GetSummaryAsync(GetTaxSummaryDTO dto);
    }
}
