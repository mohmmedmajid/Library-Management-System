using API_1.Models;
using API_1.DTOs.InvoiceDetail;

namespace API_1.Services.Interfaces
{
    public interface IInvoiceDetailService
    {
        Task<int> CreateAsync(CreateInvoiceDetailDTO dto);
        Task<bool> UpdateAsync(UpdateInvoiceDetailDTO dto);
        Task<bool> DeleteAsync(int invoiceDetailId);
        Task<List<InvoiceDetail>> GetByInvoiceIdAsync(int invoiceId);
        Task<List<InvoiceDetail>> GetAllAsync();
    }
}
