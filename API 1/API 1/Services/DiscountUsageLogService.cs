using API_1.DTOs.DiscountUsageLog;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class DiscountUsageLogService : IDiscountUsageLogService
    {
        private readonly IDiscountUsageLogRepository _logRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IPromotionalOfferRepository _offerRepository;

        public DiscountUsageLogService(
            IDiscountUsageLogRepository logRepository,
            IInvoiceRepository invoiceRepository,
            IDiscountRepository discountRepository,
            ICouponRepository couponRepository,
            IPromotionalOfferRepository offerRepository)
        {
            _logRepository = logRepository;
            _invoiceRepository = invoiceRepository;
            _discountRepository = discountRepository;
            _couponRepository = couponRepository;
            _offerRepository = offerRepository;
        }

        public async Task<int> CreateAsync(CreateDiscountUsageLogDTO dto)
        {
            await ValidateLogDTO(dto);

            var log = new DiscountUsageLog
            {
                UsageType = dto.UsageType.Trim(),
                DiscountID = dto.DiscountID,
                CouponID = dto.CouponID,
                OfferID = dto.OfferID,
                InvoiceID = dto.InvoiceID,
                CustomerID = dto.CustomerID,
                ProductID = dto.ProductID,
                OriginalAmount = dto.OriginalAmount,
                DiscountAmount = dto.DiscountAmount,
                FinalAmount = dto.FinalAmount,
                Notes = dto.Notes?.Trim()
            };

            return await _logRepository.InsertAsync(log);
        }

        public async Task<DiscountUsageLog?> GetByIdAsync(int usageId)
        {
            if (usageId <= 0)
                throw new ArgumentException("Invalid usage ID");

            return await _logRepository.GetByIdAsync(usageId);
        }

        public async Task<List<DiscountUsageLog>> GetAllAsync(GetAllUsageLogsDTO dto)
        {
            return await _logRepository.GetAllAsync(dto.UsageType, dto.StartDate, dto.EndDate);
        }

        public async Task<List<DiscountUsageLog>> GetByInvoiceAsync(int invoiceId)
        {
            if (invoiceId <= 0)
                throw new ArgumentException("Invalid invoice ID");

            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
                throw new InvalidOperationException("Invoice not found");

            return await _logRepository.GetByInvoiceAsync(invoiceId);
        }

        public async Task<List<DiscountUsageLog>> GetByCustomerAsync(GetUsageByCustomerDTO dto)
        {
            if (dto.CustomerID <= 0)
                throw new ArgumentException("Invalid customer ID");

            return await _logRepository.GetByCustomerAsync(dto.CustomerID, dto.StartDate, dto.EndDate);
        }

        public async Task<List<UsageStatisticsResultDTO>> GetUsageStatisticsAsync(GetUsageStatisticsDTO dto)
        {
            if (dto.EndDate < dto.StartDate)
                throw new ArgumentException("End date must be after start date");

            var result = await _logRepository.GetUsageStatisticsAsync(dto.StartDate, dto.EndDate);

            return MapToUsageStatisticsDTO(result);
        }

        public async Task<List<TopDiscountResultDTO>> GetTopDiscountsAsync(GetTopDiscountsDTO dto)
        {
            ValidateTopCount(dto.TopCount);

            if (dto.EndDate < dto.StartDate)
                throw new ArgumentException("End date must be after start date");

            var result = await _logRepository.GetTopDiscountsAsync(dto.StartDate, dto.EndDate, dto.TopCount);

            return MapToTopDiscountsDTO(result);
        }

        public async Task<List<TopCouponResultDTO>> GetTopCouponsAsync(GetTopCouponsDTO dto)
        {
            ValidateTopCount(dto.TopCount);

            if (dto.EndDate < dto.StartDate)
                throw new ArgumentException("End date must be after start date");

            var result = await _logRepository.GetTopCouponsAsync(dto.StartDate, dto.EndDate, dto.TopCount);

            return MapToTopCouponsDTO(result);
        }


        private async Task ValidateLogDTO(CreateDiscountUsageLogDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UsageType))
                throw new ArgumentException("Usage type is required");

            ValidateUsageType(dto.UsageType);
            ValidateAmounts(dto.OriginalAmount, dto.DiscountAmount, dto.FinalAmount);

            if (dto.InvoiceID <= 0)
                throw new ArgumentException("Invalid invoice ID");

            await ValidateInvoiceExists(dto.InvoiceID);
            await ValidateUsageTypeRequirements(dto);
        }

        private void ValidateUsageType(string usageType)
        {
            var validTypes = new[] { "Discount", "Coupon", "Offer" };
            if (!validTypes.Contains(usageType.Trim()))
                throw new ArgumentException($"Invalid usage type. Must be one of: {string.Join(", ", validTypes)}");
        }

        private void ValidateAmounts(decimal originalAmount, decimal discountAmount, decimal finalAmount)
        {
            if (originalAmount < 0)
                throw new ArgumentException("Original amount cannot be negative");

            if (discountAmount < 0)
                throw new ArgumentException("Discount amount cannot be negative");

            if (finalAmount < 0)
                throw new ArgumentException("Final amount cannot be negative");

            if (discountAmount > originalAmount)
                throw new ArgumentException("Discount amount cannot exceed original amount");

            if (finalAmount != (originalAmount - discountAmount))
                throw new ArgumentException("Final amount must equal original amount minus discount amount");
        }

        private async Task ValidateInvoiceExists(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
                throw new InvalidOperationException("Invoice not found");
        }

        private async Task ValidateUsageTypeRequirements(CreateDiscountUsageLogDTO dto)
        {
            if (dto.UsageType.Trim() == "Discount")
            {
                await ValidateDiscountUsage(dto.DiscountID);
            }
            else if (dto.UsageType.Trim() == "Coupon")
            {
                await ValidateCouponUsage(dto.CouponID);
            }
            else if (dto.UsageType.Trim() == "Offer")
            {
                await ValidateOfferUsage(dto.OfferID);
            }
        }

        private async Task ValidateDiscountUsage(int? discountId)
        {
            if (!discountId.HasValue || discountId <= 0)
                throw new ArgumentException("Discount ID is required for Discount usage type");

            var discount = await _discountRepository.GetByIdAsync(discountId.Value);
            if (discount == null)
                throw new InvalidOperationException("Discount not found");
        }

        private async Task ValidateCouponUsage(int? couponId)
        {
            if (!couponId.HasValue || couponId <= 0)
                throw new ArgumentException("Coupon ID is required for Coupon usage type");

            var coupon = await _couponRepository.GetByIdAsync(couponId.Value);
            if (coupon == null)
                throw new InvalidOperationException("Coupon not found");
        }

        private async Task ValidateOfferUsage(int? offerId)
        {
            if (!offerId.HasValue || offerId <= 0)
                throw new ArgumentException("Offer ID is required for Offer usage type");

            var offer = await _offerRepository.GetByIdAsync(offerId.Value);
            if (offer == null)
                throw new InvalidOperationException("Promotional offer not found");
        }

        private void ValidateTopCount(int topCount)
        {
            if (topCount <= 0)
                throw new ArgumentException("Top count must be greater than zero");

            if (topCount > 100)
                throw new ArgumentException("Top count cannot exceed 100");
        }

        private List<UsageStatisticsResultDTO> MapToUsageStatisticsDTO(List<Dictionary<string, object>> result)
        {
            var dtoList = new List<UsageStatisticsResultDTO>();

            foreach (var item in result)
            {
                dtoList.Add(new UsageStatisticsResultDTO
                {
                    UsageType = GetStringValue(item, "UsageType"),
                    UsageCount = GetIntValue(item, "UsageCount"),
                    TotalDiscountAmount = GetDecimalValue(item, "TotalDiscountAmount"),
                    AvgDiscountAmount = GetDecimalValue(item, "AvgDiscountAmount"),
                    TotalOriginalAmount = GetDecimalValue(item, "TotalOriginalAmount"),
                    TotalFinalAmount = GetDecimalValue(item, "TotalFinalAmount")
                });
            }

            return dtoList;
        }

        private List<TopDiscountResultDTO> MapToTopDiscountsDTO(List<Dictionary<string, object>> result)
        {
            var dtoList = new List<TopDiscountResultDTO>();

            foreach (var item in result)
            {
                dtoList.Add(new TopDiscountResultDTO
                {
                    DiscountID = GetIntValue(item, "DiscountID"),
                    DiscountName = GetStringValue(item, "DiscountName"),
                    DiscountNameAr = GetStringValue(item, "DiscountNameAr"),
                    UsageCount = GetIntValue(item, "UsageCount"),
                    TotalDiscountAmount = GetDecimalValue(item, "TotalDiscountAmount")
                });
            }

            return dtoList;
        }

        private List<TopCouponResultDTO> MapToTopCouponsDTO(List<Dictionary<string, object>> result)
        {
            var dtoList = new List<TopCouponResultDTO>();

            foreach (var item in result)
            {
                dtoList.Add(new TopCouponResultDTO
                {
                    CouponID = GetIntValue(item, "CouponID"),
                    CouponCode = GetStringValue(item, "CouponCode"),
                    CouponName = GetStringValue(item, "CouponName"),
                    CouponNameAr = GetStringValue(item, "CouponNameAr"),
                    UsageCount = GetIntValue(item, "UsageCount"),
                    TotalDiscountAmount = GetDecimalValue(item, "TotalDiscountAmount")
                });
            }

            return dtoList;
        }

        private int GetIntValue(Dictionary<string, object> dict, string key)
        {
            if (dict.TryGetValue(key, out var value) && value != null)
            {
                return Convert.ToInt32(value);
            }
            return 0;
        }

        private decimal GetDecimalValue(Dictionary<string, object> dict, string key)
        {
            if (dict.TryGetValue(key, out var value) && value != null)
            {
                return Convert.ToDecimal(value);
            }
            return 0m;
        }

        private string GetStringValue(Dictionary<string, object> dict, string key)
        {
            if (dict.TryGetValue(key, out var value) && value != null)
            {
                return value.ToString() ?? string.Empty;
            }
            return string.Empty;
        }
    }
}