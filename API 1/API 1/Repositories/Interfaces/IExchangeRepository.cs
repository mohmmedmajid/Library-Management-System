using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IExchangeRepository
    {
        Task<int> InsertAsync(int originalInvoiceId, int originalInvoiceDetailId, int customerId, int oldProductId, int oldQuantity, int newProductId, int newQuantity, int paymentMethodId, string? notes, int createdBy);
        Task<ExchangeTransaction?> GetByIdAsync(int exchangeId);
        Task<List<ExchangeTransaction>> GetAllAsync(int? customerId = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}