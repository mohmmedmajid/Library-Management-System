using API_1.DTOs.AllInvoices;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IAllInvoicesService
    {
        Task<List<AllInvoiceItem>> GetAllAsync(GetAllInvoicesDTO dto);
    }
}