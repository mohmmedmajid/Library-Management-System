using API_1.DTOs.Discount;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public DiscountService(
            IDiscountRepository discountRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _discountRepository = discountRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<int> CreateAsync(CreateDiscountDTO dto)
        {
            ValidateDiscountDTO(dto);

            await ValidateApplicableOn(dto.ApplicableOn, dto.CategoryID, dto.ProductID);

            var discount = new Discount
            {
                DiscountName = dto.DiscountName.Trim(),
                DiscountNameAr = dto.DiscountNameAr.Trim(),
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
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _discountRepository.InsertAsync(discount);
        }

        public async Task<bool> UpdateAsync(UpdateDiscountDTO dto)
        {
            if (dto.DiscountID <= 0)
                throw new ArgumentException("Invalid discount ID");

            ValidateDiscountDTO(new CreateDiscountDTO
            {
                DiscountName = dto.DiscountName,
                DiscountNameAr = dto.DiscountNameAr,
                DiscountType = dto.DiscountType,
                DiscountValue = dto.DiscountValue,
                MinimumPurchaseAmount = dto.MinimumPurchaseAmount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            });

            var existing = await _discountRepository.GetByIdAsync(dto.DiscountID);
            if (existing == null)
                throw new InvalidOperationException("Discount not found");

            var discount = new Discount
            {
                DiscountID = dto.DiscountID,
                DiscountName = dto.DiscountName.Trim(),
                DiscountNameAr = dto.DiscountNameAr.Trim(),
                DiscountType = dto.DiscountType.Trim(),
                DiscountValue = dto.DiscountValue,
                MinimumPurchaseAmount = dto.MinimumPurchaseAmount,
                MaximumDiscountAmount = dto.MaximumDiscountAmount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                UsageLimit = dto.UsageLimit,
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _discountRepository.UpdateAsync(discount);
        }

        public async Task<bool> DeleteAsync(int discountId)
        {
            if (discountId <= 0)
                throw new ArgumentException("Invalid discount ID");

            var existing = await _discountRepository.GetByIdAsync(discountId);
            if (existing == null)
                throw new InvalidOperationException("Discount not found");

            return await _discountRepository.DeleteAsync(discountId);
        }

        public async Task<Discount?> GetByIdAsync(int discountId)
        {
            if (discountId <= 0)
                throw new ArgumentException("Invalid discount ID");

            return await _discountRepository.GetByIdAsync(discountId);
        }

        public async Task<List<Discount>> GetAllAsync(GetAllDiscountsDTO dto)
        {
            return await _discountRepository.GetAllAsync(dto.IsActive, dto.CurrentOnly);
        }

        public async Task<List<Discount>> GetActiveDiscountsAsync()
        {
            return await _discountRepository.GetAllAsync(isActive: true, currentOnly: true);
        }

        public async Task<List<Discount>> GetApplicableDiscountsAsync(GetApplicableDiscountsDTO dto)
        {
            if (dto.ProductID <= 0)
                throw new ArgumentException("Invalid product ID");

            if (dto.CategoryID <= 0)
                throw new ArgumentException("Invalid category ID");

            if (dto.PurchaseAmount < 0)
                throw new ArgumentException("Purchase amount cannot be negative");

            return await _discountRepository.GetApplicableDiscountsAsync(
                dto.ProductID,
                dto.CategoryID,
                dto.PurchaseAmount
            );
        }

        public async Task<bool> IncrementUsageAsync(int discountId)
        {
            if (discountId <= 0)
                throw new ArgumentException("Invalid discount ID");

            var discount = await _discountRepository.GetByIdAsync(discountId);
            if (discount == null)
                throw new InvalidOperationException("Discount not found");

            if (discount.UsageLimit.HasValue && discount.UsageCount >= discount.UsageLimit.Value)
                throw new InvalidOperationException("Discount usage limit has been reached");

            return await _discountRepository.IncrementUsageAsync(discountId);
        }

        public async Task<decimal> CalculateDiscountAmountAsync(int discountId, decimal purchaseAmount)
        {
            if (discountId <= 0)
                throw new ArgumentException("Invalid discount ID");

            if (purchaseAmount < 0)
                throw new ArgumentException("Purchase amount cannot be negative");

            var discount = await _discountRepository.GetByIdAsync(discountId);
            if (discount == null)
                throw new InvalidOperationException("Discount not found");

            ValidateDiscountActive(discount);
            ValidateDiscountDateRange(discount);
            ValidateMinimumPurchaseAmount(discount, purchaseAmount);

            return CalculateDiscount(discount, purchaseAmount);
        }

        private void ValidateDiscountDTO(CreateDiscountDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.DiscountName))
                throw new ArgumentException("Discount name is required");

            if (string.IsNullOrWhiteSpace(dto.DiscountNameAr))
                throw new ArgumentException("Discount name in Arabic is required");

            if (string.IsNullOrWhiteSpace(dto.DiscountType))
                throw new ArgumentException("Discount type is required");

            ValidateDiscountType(dto.DiscountType);
            ValidateDiscountValue(dto.DiscountType, dto.DiscountValue);
            ValidateAmounts(dto.MinimumPurchaseAmount, dto.MaximumDiscountAmount);
            ValidateDates(dto.StartDate, dto.EndDate);
            ValidateApplicableOnType(dto.ApplicableOn);
            ValidateUsageLimit(dto.UsageLimit);
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

            if (startDate < DateTime.Now.Date)
                throw new ArgumentException("Start date cannot be in the past");
        }

        private void ValidateApplicableOnType(string applicableOn)
        {
            if (string.IsNullOrWhiteSpace(applicableOn))
                return;

            var validApplicableOn = new[] { "All", "Category", "Product" };
            if (!validApplicableOn.Contains(applicableOn.Trim()))
                throw new ArgumentException($"Invalid ApplicableOn value. Must be one of: {string.Join(", ", validApplicableOn)}");
        }

        private void ValidateUsageLimit(int? usageLimit)
        {
            if (usageLimit.HasValue && usageLimit <= 0)
                throw new ArgumentException("Usage limit must be greater than zero");
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

        private void ValidateDiscountActive(Discount discount)
        {
            if (!discount.IsActive)
                throw new InvalidOperationException("This discount is not active");
        }

        private void ValidateDiscountDateRange(Discount discount)
        {
            var now = DateTime.Now;
            if (now < discount.StartDate || now > discount.EndDate)
                throw new InvalidOperationException("This discount is not valid at this time");
        }

        private void ValidateMinimumPurchaseAmount(Discount discount, decimal purchaseAmount)
        {
            if (purchaseAmount < discount.MinimumPurchaseAmount)
                throw new InvalidOperationException($"Minimum purchase amount of {discount.MinimumPurchaseAmount} is required");
        }

        private decimal CalculateDiscount(Discount discount, decimal purchaseAmount)
        {
            decimal discountAmount = 0;

            if (discount.DiscountType == "Percentage")
            {
                discountAmount = purchaseAmount * (discount.DiscountValue / 100);
            }
            else if (discount.DiscountType == "FixedAmount")
            {
                discountAmount = discount.DiscountValue;
            }

            if (discount.MaximumDiscountAmount.HasValue && discountAmount > discount.MaximumDiscountAmount.Value)
            {
                discountAmount = discount.MaximumDiscountAmount.Value;
            }

            return discountAmount;
        }
    }
}