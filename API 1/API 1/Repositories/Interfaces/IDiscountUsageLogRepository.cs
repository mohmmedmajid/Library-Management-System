using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IDiscountUsageLogRepository
    {
        Task<int> InsertAsync(DiscountUsageLog log);
        Task<DiscountUsageLog?> GetByIdAsync(int usageId);
        Task<List<DiscountUsageLog>> GetAllAsync(string? usageType = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<DiscountUsageLog>> GetByInvoiceAsync(int invoiceId);
        Task<List<DiscountUsageLog>> GetByCustomerAsync(int customerId, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<Dictionary<string, object>>> GetUsageStatisticsAsync(DateTime startDate, DateTime endDate);
        Task<List<Dictionary<string, object>>> GetTopDiscountsAsync(DateTime startDate, DateTime endDate, int topCount = 10);
        Task<List<Dictionary<string, object>>> GetTopCouponsAsync(DateTime startDate, DateTime endDate, int topCount = 10);
    }
}