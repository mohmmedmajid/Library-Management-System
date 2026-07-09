using API_1.DTOs.Invoice;
using API_1.Models;

namespace API.Application.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<int> CreateAsync(CreateInvoiceDTO dto);
        Task<int> CreateWithDetailsAsync(CreateInvoiceWithDetailsDTO dto);
        Task<bool> UpdateAsync(UpdateInvoiceDTO dto);
        Task<bool> DeleteAsync(int invoiceId);
        Task<Invoice?> GetByIdAsync(int invoiceId);
        Task<Invoice?> GetByNumberAsync(string invoiceNumber);
        Task<List<Invoice>> GetAllAsync(GetAllInvoicesDTO dto);
        Task<Dictionary<string, object>> GetInvoiceWithDetailsAsync(int invoiceId);
        Task<InvoiceFullDTO?> GetFullByNumberAsync(string invoiceNumber);
    }
}