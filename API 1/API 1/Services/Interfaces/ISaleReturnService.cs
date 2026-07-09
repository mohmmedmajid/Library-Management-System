using API_1.DTOs.SaleReturn;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ISaleReturnService
    {
        Task<int> CreateAsync(CreateSaleReturnDTO dto);
        Task<SaleReturn?> GetByIdAsync(int saleReturnId);
        Task<List<SaleReturnDetail>> GetDetailsAsync(int saleReturnId);
        Task<List<SaleReturn>> GetAllAsync(DateTime? startDate, DateTime? endDate);
        Task<InvoiceSearchResult?> SearchByNumberAsync(SearchInvoiceByNumberDTO dto);
        Task<List<InvoiceSearchResult>> SearchByBarcodeAsync(SearchInvoiceByBarcodeDTO dto);
        Task<List<InvoiceSearchResult>> SearchByCustomerNameAsync(SearchInvoiceByCustomerNameDTO dto);
        Task<List<ReturnableInvoiceDetail>> GetReturnableDetailsAsync(GetReturnableDetailsDTO dto);
    }
}