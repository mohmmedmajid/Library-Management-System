using API_1.DTOs.Coupon;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CouponService(
            ICouponRepository couponRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _couponRepository = couponRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<int> CreateAsync(CreateCouponDTO dto)
        {
            ValidateCouponDTO(dto);

            await CheckDuplicateCouponCode(dto.CouponCode);
            await ValidateApplicableOn(dto.ApplicableOn, dto.CategoryID, dto.ProductID);

            var coupon = new Coupon
            {
                CouponCode = dto.CouponCode.Trim().ToUpper(),
                CouponName = dto.CouponName.Trim(),
                CouponNameAr = dto.CouponNameAr.Trim(),
                DiscountType = dto.DiscountType.Trim(),
                DiscountValue = dto.DiscountValue,
                MinimumPurchaseAmount = dto.MinimumPurchaseAmount,
                MaximumDiscountAmount = dto.MaximumDiscountAmount,
                ApplicableOn = dto.ApplicableOn.Trim(),
                CategoryID = dto.CategoryID,
                ProductID = dto.ProductID,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                UsageLimit = dto.UsageLimit,
                UsageLimitPerCustomer = dto.UsageLimitPerCustomer,
                IsPublic = dto.IsPublic,
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _couponRepository.InsertAsync(coupon);
        }

        public async Task<bool> UpdateAsync(UpdateCouponDTO dto)
        {
            if (dto.CouponID <= 0)
                throw new ArgumentException("Invalid coupon ID");

            ValidateCouponDTO(new CreateCouponDTO
            {
                CouponCode = dto.CouponCode,
                CouponName = dto.CouponName,
                CouponNameAr = dto.CouponNameAr,
                DiscountType = dto.DiscountType,
                DiscountValue = dto.DiscountValue,
                MinimumPurchaseAmount = dto.MinimumPurchaseAmount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                UsageLimitPerCustomer = dto.UsageLimitPerCustomer
            });

            var existing = await _couponRepository.GetByIdAsync(dto.CouponID);
            if (existing == null)
                throw new InvalidOperationException("Coupon not found");

            await CheckDuplicateCouponCode(dto.CouponCode, dto.CouponID);

            var coupon = new Coupon
            {
                CouponID = dto.CouponID,
                CouponCode = dto.CouponCode.Trim().ToUpper(),
                CouponName = dto.CouponName.Trim(),
                CouponNameAr = dto.CouponNameAr.Trim(),
                DiscountType = dto.DiscountType.Trim(),
                DiscountValue = dto.DiscountValue,
                MinimumPurchaseAmount = dto.MinimumPurchaseAmount,
                MaximumDiscountAmount = dto.MaximumDiscountAmount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                UsageLimit = dto.UsageLimit,
                UsageLimitPerCustomer = dto.UsageLimitPerCustomer,
                IsPublic = dto.IsPublic,
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _couponRepository.UpdateAsync(coupon);
        }

        public async Task<bool> DeleteAsync(int couponId)
        {
            if (couponId <= 0)
                throw new ArgumentException("Invalid coupon ID");

            var existing = await _couponRepository.GetByIdAsync(couponId);
            if (existing == null)
                throw new InvalidOperationException("Coupon not found");

            return await _couponRepository.DeleteAsync(couponId);
        }

        public async Task<Coupon?> GetByIdAsync(int couponId)
        {
            if (couponId <= 0)
                throw new ArgumentException("Invalid coupon ID");

            return await _couponRepository.GetByIdAsync(couponId);
        }

        public async Task<Coupon?> GetByCodeAsync(string couponCode)
        {
            if (string.IsNullOrWhiteSpace(couponCode))
                throw new ArgumentException("Coupon code is required");

            return await _couponRepository.GetByCodeAsync(couponCode.Trim().ToUpper());
        }

        public async Task<List<Coupon>> GetAllAsync(GetAllCouponsDTO dto)
        {
            return await _couponRepository.GetAllAsync(dto.IsActive, dto.CurrentOnly);
        }

        public async Task<List<Coupon>> GetActiveCouponsAsync()
        {
            return await _couponRepository.GetAllAsync(isActive: true, currentOnly: true);
        }

        public async Task<(bool IsValid, string ErrorMessage)> ValidateCouponAsync(ValidateCouponDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CouponCode))
                return (false, "Coupon code is required");

            if (dto.CustomerID <= 0)
                return (false, "Invalid customer ID");

            if (dto.PurchaseAmount < 0)
                return (false, "Purchase amount cannot be negative");

            var isValid = await _couponRepository.ValidateCouponAsync(
                dto.CouponCode.Trim().ToUpper(),
                dto.CustomerID,
                dto.ProductID,
                dto.CategoryID,
                dto.PurchaseAmount
            );

            if (isValid)
                return (true, "Coupon is valid");
            else
                return (false, "Coupon validation failed");
        }

        public async Task<bool> IncrementUsageAsync(int couponId)
        {
            if (couponId <= 0)
                throw new ArgumentException("Invalid coupon ID");

            var coupon = await _couponRepository.GetByIdAsync(couponId);
            if (coupon == null)
                throw new InvalidOperationException("Coupon not found");

            if (coupon.UsageLimit.HasValue && coupon.UsageCount >= coupon.UsageLimit.Value)
                throw new InvalidOperationException("Coupon usage limit has been reached");

            return await _couponRepository.IncrementUsageAsync(couponId);
        }

        public async Task<decimal> CalculateCouponDiscountAsync(string couponCode, decimal purchaseAmount)
        {
            if (string.IsNullOrWhiteSpace(couponCode))
                throw new ArgumentException("Coupon code is required");

            if (purchaseAmount < 0)
                throw new ArgumentException("Purchase amount cannot be negative");

            var coupon = await _couponRepository.GetByCodeAsync(couponCode.Trim().ToUpper());
            if (coupon == null)
                throw new InvalidOperationException("Coupon not found");

            ValidateCouponActive(coupon);
            ValidateCouponDateRange(coupon);
            ValidateMinimumPurchaseAmount(coupon, purchaseAmount);

            return CalculateDiscount(coupon, purchaseAmount);
        }

        private void ValidateCouponDTO(CreateCouponDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CouponCode))
                throw new ArgumentException("Coupon code is required");

            ValidateCouponCodeLength(dto.CouponCode);

            if (string.IsNullOrWhiteSpace(dto.CouponName))
                throw new ArgumentException("Coupon name is required");

            if (string.IsNullOrWhiteSpace(dto.CouponNameAr))
                throw new ArgumentException("Coupon name in Arabic is required");

            if (string.IsNullOrWhiteSpace(dto.DiscountType))
                throw new ArgumentException("Discount type is required");

            ValidateDiscountType(dto.DiscountType);
            ValidateDiscountValue(dto.DiscountType, dto.DiscountValue);
            ValidateAmounts(dto.MinimumPurchaseAmount, dto.MaximumDiscountAmount);
            ValidateDates(dto.StartDate, dto.EndDate);
            ValidateUsageLimits(dto.UsageLimit, dto.UsageLimitPerCustomer);
            ValidateApplicableOnType(dto.ApplicableOn);
        }

        private void ValidateCouponCodeLength(string couponCode)
        {
            if (couponCode.Trim().Length < 3 || couponCode.Trim().Length > 20)
                throw new ArgumentException("Coupon code must be between 3 and 20 characters");
        }

        private void ValidateDiscountType(string discountType)
        {
            var validTypes = new[] { "Percentage", "FixedAmount" };
            if (!validTypes.Contains(discountType.Trim()))
                throw new ArgumentException($"Invalid discount type. Must be one of: {string.Join(", ", validTypes)}");
        }

        private void ValidateDiscountValue(string discountType, decimal discountValue)
        {
            if (discountValue <= 0)
                throw new ArgumentException("Discount value must be greater than zero");

            if (discountType.Trim() == "Percentage" && discountValue > 100)
                throw new ArgumentException("Percentage discount cannot exceed 100%");
        }

        private void ValidateAmounts(decimal minimumPurchaseAmount, decimal? maximumDiscountAmount)
        {
            if (minimumPurchaseAmount < 0)
                throw new ArgumentException("Minimum purchase amount cannot be negative");

            if (maximumDiscountAmount.HasValue && maximumDiscountAmount <= 0)
                throw new ArgumentException("Maximum discount amount must be greater than zero");
        }

        private void ValidateDates(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date");
        }

        private void ValidateUsageLimits(int? usageLimit, int usageLimitPerCustomer)
        {
            if (usageLimit.HasValue && usageLimit <= 0)
                throw new ArgumentException("Usage limit must be greater than zero");

            if (usageLimitPerCustomer <= 0)
                throw new ArgumentException("Usage limit per customer must be greater than zero");
        }

        private void ValidateApplicableOnType(string applicableOn)
        {
            if (string.IsNullOrWhiteSpace(applicableOn))
                return;

            var validApplicableOn = new[] { "All", "Category", "Product" };
            if (!validApplicableOn.Contains(applicableOn.Trim()))
                throw new ArgumentException($"Invalid ApplicableOn value. Must be one of: {string.Join(", ", validApplicableOn)}");
        }

        private async Task CheckDuplicateCouponCode(string couponCode, int? excludeId = null)
        {
            var existing = await _couponRepository.GetByCodeAsync(couponCode.Trim().ToUpper());

            if (existing != null && (!excludeId.HasValue || existing.CouponID != excludeId.Value))
                throw new InvalidOperationException("A coupon with this code already exists");
        }

        private async Task ValidateApplicableOn(string applicableOn, int? categoryId, int? productId)
        {
            if (applicableOn == "Category")
            {
                if (!categoryId.HasValue || categoryId <= 0)
                    throw new ArgumentException("Category ID is required when ApplicableOn is Category");

                var category = await _categoryRepository.GetByIdAsync(categoryId.Value);
                if (category == null)
                    throw new InvalidOperationException("Category not found");

                if (!category.IsActive)
                    throw new InvalidOperationException("This category is not active");
            }
            else if (applicableOn == "Product")
            {
                if (!productId.HasValue || productId <= 0)
                    throw new ArgumentException("Product ID is required when ApplicableOn is Product");

                var product = await _productRepository.GetByIdAsync(productId.Value);
                if (product == null)
                    throw new InvalidOperationException("Product not found");

                if (!product.IsActive)
                    throw new InvalidOperationException("This product is not active");
            }
        }

        private void ValidateCouponActive(Coupon coupon)
        {
            if (!coupon.IsActive)
                throw new InvalidOperationException("This coupon is not active");
        }

        private void ValidateCouponDateRange(Coupon coupon)
        {
            var now = DateTime.Now;
            if (now < coupon.StartDate || now > coupon.EndDate)
                throw new InvalidOperationException("This coupon is not valid at this time");
        }

        private void ValidateMinimumPurchaseAmount(Coupon coupon, decimal purchaseAmount)
        {
            if (purchaseAmount < coupon.MinimumPurchaseAmount)
                throw new InvalidOperationException($"Minimum purchase amount of {coupon.MinimumPurchaseAmount} is required");
        }

        private decimal CalculateDiscount(Coupon coupon, decimal purchaseAmount)
        {
            decimal discountAmount = 0;

            if (coupon.DiscountType == "Percentage")
            {
                discountAmount = purchaseAmount * (coupon.DiscountValue / 100);
            }
            else if (coupon.DiscountType == "FixedAmount")
            {
                discountAmount = coupon.DiscountValue;
            }

            if (coupon.MaximumDiscountAmount.HasValue && discountAmount > coupon.MaximumDiscountAmount.Value)
            {
                discountAmount = coupon.MaximumDiscountAmount.Value;
            }

            return discountAmount;
        }
    }
}