using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ISaleReturnRepository
    {
        Task<int> InsertHeaderAsync(int originalInvoiceId, int customerId, string refundMethod, int paymentMethodId, string? notes, int createdBy);
        Task<int> InsertDetailAsync(int saleReturnId, int invoiceDetailId, int returnedQuantity);
        Task<bool> FinalizeAsync(int saleReturnId, int createdBy);
        Task<SaleReturn?> GetByIdAsync(int saleReturnId);
        Task<List<SaleReturnDetail>> GetDetailsBySaleReturnIdAsync(int saleReturnId);
        Task<List<SaleReturn>> GetAllAsync(int? customerId = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}