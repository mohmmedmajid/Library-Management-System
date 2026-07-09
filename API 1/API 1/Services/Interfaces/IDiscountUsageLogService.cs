using API_1.DTOs.DiscountUsageLog;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IDiscountUsageLogService
    {
        Task<int> CreateAsync(CreateDiscountUsageLogDTO dto);
        Task<DiscountUsageLog?> GetByIdAsync(int usageId);
        Task<List<DiscountUsageLog>> GetAllAsync(GetAllUsageLogsDTO dto);
        Task<List<DiscountUsageLog>> GetByInvoiceAsync(int invoiceId);
        Task<List<DiscountUsageLog>> GetByCustomerAsync(GetUsageByCustomerDTO dto);
        Task<List<UsageStatisticsResultDTO>> GetUsageStatisticsAsync(GetUsageStatisticsDTO dto);
        Task<List<TopDiscountResultDTO>> GetTopDiscountsAsync(GetTopDiscountsDTO dto);
        Task<List<TopCouponResultDTO>> GetTopCouponsAsync(GetTopCouponsDTO dto);
    }
}