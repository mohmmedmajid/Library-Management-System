using API_1.DTOs.PromotionalOffer;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class PromotionalOfferService : IPromotionalOfferService
    {
        private readonly IPromotionalOfferRepository _offerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public PromotionalOfferService(
            IPromotionalOfferRepository offerRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _offerRepository = offerRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<int> CreateAsync(CreatePromotionalOfferDTO dto)
        {
            ValidateOfferDTO(dto);
            ValidateOfferTypeRequirements(dto);
            await ValidateApplicableOn(dto.ApplicableOn, dto.CategoryID, dto.BuyProductID, dto.GetProductID);

            var offer = new PromotionalOffer
            {
                OfferName = dto.OfferName.Trim(),
                OfferNameAr = dto.OfferNameAr.Trim(),
                OfferType = dto.OfferType.Trim(),
                BuyQuantity = dto.BuyQuantity,
                GetQuantity = dto.GetQuantity,
                BuyProductID = dto.BuyProductID,
                GetProductID = dto.GetProductID,
                DiscountPercent = dto.DiscountPercent,
                BundlePrice = dto.BundlePrice,
                ApplicableOn = dto.ApplicableOn.Trim(),
                CategoryID = dto.CategoryID,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Priority = dto.Priority,
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _offerRepository.InsertAsync(offer);
        }

        public async Task<bool> UpdateAsync(UpdatePromotionalOfferDTO dto)
        {
            if (dto.OfferID <= 0)
                throw new ArgumentException("Invalid offer ID");

            ValidateOfferDTO(new CreatePromotionalOfferDTO
            {
                OfferName = dto.OfferName,
                OfferNameAr = dto.OfferNameAr,
                OfferType = dto.OfferType,
                BuyQuantity = dto.BuyQuantity,
                GetQuantity = dto.GetQuantity,
                DiscountPercent = dto.DiscountPercent,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Priority = dto.Priority
            });

            var existing = await _offerRepository.GetByIdAsync(dto.OfferID);
            if (existing == null)
                throw new InvalidOperationException("Offer not found");

            var offer = new PromotionalOffer
            {
                OfferID = dto.OfferID,
                OfferName = dto.OfferName.Trim(),
                OfferNameAr = dto.OfferNameAr.Trim(),
                OfferType = dto.OfferType.Trim(),
                BuyQuantity = dto.BuyQuantity,
                GetQuantity = dto.GetQuantity,
                DiscountPercent = dto.DiscountPercent,
                BundlePrice = dto.BundlePrice,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Priority = dto.Priority,
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _offerRepository.UpdateAsync(offer);
        }

        public async Task<bool> DeleteAsync(int offerId)
        {
            if (offerId <= 0)
                throw new ArgumentException("Invalid offer ID");

            var existing = await _offerRepository.GetByIdAsync(offerId);
            if (existing == null)
                throw new InvalidOperationException("Offer not found");

            return await _offerRepository.DeleteAsync(offerId);
        }

        public async Task<PromotionalOffer?> GetByIdAsync(int offerId)
        {
            if (offerId <= 0)
                throw new ArgumentException("Invalid offer ID");

            return await _offerRepository.GetByIdAsync(offerId);
        }

        public async Task<List<PromotionalOffer>> GetAllAsync(GetAllOffersDTO dto)
        {
            return await _offerRepository.GetAllAsync(dto.IsActive, dto.CurrentOnly);
        }

        public async Task<List<PromotionalOffer>> GetActiveOffersAsync()
        {
            return await _offerRepository.GetAllAsync(isActive: true, currentOnly: true);
        }

        public async Task<List<PromotionalOffer>> GetActiveOffersForProductAsync(GetActiveOffersForProductDTO dto)
        {
            if (dto.ProductID <= 0)
                throw new ArgumentException("Invalid product ID");

            if (dto.CategoryID <= 0)
                throw new ArgumentException("Invalid category ID");

            return await _offerRepository.GetActiveOffersForProductAsync(dto.ProductID, dto.CategoryID);
        }

        private void ValidateOfferDTO(CreatePromotionalOfferDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.OfferName))
                throw new ArgumentException("Offer name is required");

            if (string.IsNullOrWhiteSpace(dto.OfferNameAr))
                throw new ArgumentException("Offer name in Arabic is required");

            if (string.IsNullOrWhiteSpace(dto.OfferType))
                throw new ArgumentException("Offer type is required");

            ValidateOfferType(dto.OfferType);
            ValidateDates(dto.StartDate, dto.EndDate);
            ValidatePriority(dto.Priority);
            ValidateApplicableOnType(dto.ApplicableOn);
        }

        private void ValidateOfferType(string offerType)
        {
            var validTypes = new[] { "BuyXGetY", "BuyXGetDiscount", "BundleDiscount" };
            if (!validTypes.Contains(offerType.Trim()))
                throw new ArgumentException($"Invalid offer type. Must be one of: {string.Join(", ", validTypes)}");
        }

        private void ValidateDates(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date");
        }

        private void ValidatePriority(int priority)
        {
            if (priority < 0)
                throw new ArgumentException("Priority cannot be negative");
        }

        private void ValidateApplicableOnType(string applicableOn)
        {
            if (string.IsNullOrWhiteSpace(applicableOn))
                return;

            var validApplicableOn = new[] { "Product", "Category" };
            if (!validApplicableOn.Contains(applicableOn.Trim()))
                throw new ArgumentException($"Invalid ApplicableOn value. Must be one of: {string.Join(", ", validApplicableOn)}");
        }

        private void ValidateOfferTypeRequirements(CreatePromotionalOfferDTO dto)
        {
            if (dto.OfferType.Trim() == "BuyXGetY")
            {
                ValidateBuyXGetY(dto.BuyQuantity, dto.GetQuantity);
            }
            else if (dto.OfferType.Trim() == "BuyXGetDiscount")
            {
                ValidateBuyXGetDiscount(dto.BuyQuantity, dto.DiscountPercent);
            }
            else if (dto.OfferType.Trim() == "BundleDiscount")
            {
                ValidateBundleDiscount(dto.BundlePrice);
            }
        }

        private void ValidateBuyXGetY(int? buyQuantity, int? getQuantity)
        {
            if (!buyQuantity.HasValue || buyQuantity <= 0)
                throw new ArgumentException("Buy quantity is required and must be greater than zero for BuyXGetY offers");

            if (!getQuantity.HasValue || getQuantity <= 0)
                throw new ArgumentException("Get quantity is required and must be greater than zero for BuyXGetY offers");
        }

        private void ValidateBuyXGetDiscount(int? buyQuantity, decimal? discountPercent)
        {
            if (!buyQuantity.HasValue || buyQuantity <= 0)
                throw new ArgumentException("Buy quantity is required and must be greater than zero for BuyXGetDiscount offers");

            if (!discountPercent.HasValue || discountPercent <= 0)
                throw new ArgumentException("Discount percent is required and must be greater than zero for BuyXGetDiscount offers");

            if (discountPercent > 100)
                throw new ArgumentException("Discount percent cannot exceed 100%");
        }

        private void ValidateBundleDiscount(decimal? bundlePrice)
        {
            if (!bundlePrice.HasValue || bundlePrice <= 0)
                throw new ArgumentException("Bundle price is required and must be greater than zero for BundleDiscount offers");
        }

        private async Task ValidateApplicableOn(string applicableOn, int? categoryId, int? buyProductId, int? getProductId)
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
                await ValidateBuyProduct(buyProductId);
                await ValidateGetProduct(getProductId);
            }
        }

        private async Task ValidateBuyProduct(int? buyProductId)
        {
            if (!buyProductId.HasValue || buyProductId <= 0)
                throw new ArgumentException("Buy product ID is required when ApplicableOn is Product");

            var buyProduct = await _productRepository.GetByIdAsync(buyProductId.Value);
            if (buyProduct == null)
                throw new InvalidOperationException("Buy product not found");

            if (!buyProduct.IsActive)
                throw new InvalidOperationException("Buy product is not active");
        }

        private async Task ValidateGetProduct(int? getProductId)
        {
            if (getProductId.HasValue && getProductId > 0)
            {
                var getProduct = await _productRepository.GetByIdAsync(getProductId.Value);
                if (getProduct == null)
                    throw new InvalidOperationException("Get product not found");

                if (!getProduct.IsActive)
                    throw new InvalidOperationException("Get product is not active");
            }
        }
    }
}