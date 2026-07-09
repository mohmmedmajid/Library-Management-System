using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IInvoiceSearchRepository
    {
        Task<InvoiceSearchResult?> SearchByNumberAsync(string invoiceNumber);
        Task<List<InvoiceSearchResult>> SearchByBarcodeAsync(string barcode);
        Task<List<InvoiceSearchResult>> SearchByCustomerNameAsync(string customerName);
        Task<List<ReturnableInvoiceDetail>> GetReturnableDetailsAsync(int invoiceId);
        Task<List<AllInvoiceItem>> GetAllInvoicesAsync(string? invoiceType, DateTime? startDate, DateTime? endDate, int? customerId);
    }
}