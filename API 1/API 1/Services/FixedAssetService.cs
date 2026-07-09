using API_1.DTOs.FixedAsset;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class FixedAssetService : IFixedAssetService
    {
        private readonly IFixedAssetRepository _assetRepository;
        private readonly IFixedAssetCategoryRepository _categoryRepository;

        public FixedAssetService(
            IFixedAssetRepository assetRepository,
            IFixedAssetCategoryRepository categoryRepository)
        {
            _assetRepository = assetRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateAsync(CreateFixedAssetDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.AssetName))
                throw new ArgumentException("Asset name is required");

            if (string.IsNullOrWhiteSpace(dto.AssetNameAr))
                throw new ArgumentException("Asset name in Arabic is required");

            if (dto.CategoryID <= 0)
                throw new ArgumentException("Invalid category ID");

            if (dto.PurchaseDate > DateTime.Now)
                throw new ArgumentException("Purchase date cannot be in the future");

            if (dto.PurchasePrice <= 0)
                throw new ArgumentException("Purchase price must be greater than zero");

            if (dto.SalvageValue < 0)
                throw new ArgumentException("Salvage value cannot be negative");

            if (dto.SalvageValue >= dto.PurchasePrice)
                throw new ArgumentException("Salvage value must be less than purchase price");

            if (dto.WarrantyExpiry.HasValue && dto.WarrantyExpiry < dto.PurchaseDate)
                throw new ArgumentException("Warranty expiry cannot be before purchase date");

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryID);
            if (category == null)
                throw new InvalidOperationException("Fixed asset category not found");

            if (!category.IsActive)
                throw new InvalidOperationException("Fixed asset category is not active");

            var asset = new FixedAsset
            {
                AssetName = dto.AssetName.Trim(),
                AssetNameAr = dto.AssetNameAr.Trim(),
                CategoryID = dto.CategoryID,
                PurchaseDate = dto.PurchaseDate,
                PurchasePrice = dto.PurchasePrice,
                SalvageValue = dto.SalvageValue,
                Location = dto.Location?.Trim(),
                ResponsibleEmployee = dto.ResponsibleEmployee,
                SerialNumber = dto.SerialNumber?.Trim(),
                Manufacturer = dto.Manufacturer?.Trim(),
                Model = dto.Model?.Trim(),
                WarrantyExpiry = dto.WarrantyExpiry,
                Notes = dto.Notes?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _assetRepository.InsertAsync(asset);
        }

        public async Task<bool> UpdateAsync(UpdateFixedAssetDTO dto)
        {
            if (dto.AssetID <= 0)
                throw new ArgumentException("Invalid asset ID");

            if (string.IsNullOrWhiteSpace(dto.AssetName))
                throw new ArgumentException("Asset name is required");

            if (string.IsNullOrWhiteSpace(dto.AssetNameAr))
                throw new ArgumentException("Asset name in Arabic is required");

            if (dto.CategoryID <= 0)
                throw new ArgumentException("Invalid category ID");

            var validStatuses = new[] { "InUse", "UnderMaintenance", "Disposed", "Sold" };
            if (!validStatuses.Contains(dto.Status.Trim()))
                throw new ArgumentException($"Invalid status. Must be one of: {string.Join(", ", validStatuses)}");

            if (dto.LastMaintenanceDate.HasValue && dto.NextMaintenanceDate.HasValue
                && dto.NextMaintenanceDate <= dto.LastMaintenanceDate)
                throw new ArgumentException("Next maintenance date must be after last maintenance date");

            var existing = await _assetRepository.GetByIdAsync(dto.AssetID);
            if (existing == null)
                throw new InvalidOperationException("Fixed asset not found");

            if (existing.Status == "Disposed" || existing.Status == "Sold")
                throw new InvalidOperationException("Cannot update a disposed or sold asset");

            var asset = new FixedAsset
            {
                AssetID = dto.AssetID,
                AssetName = dto.AssetName.Trim(),
                AssetNameAr = dto.AssetNameAr.Trim(),
                CategoryID = dto.CategoryID,
                Location = dto.Location?.Trim(),
                ResponsibleEmployee = dto.ResponsibleEmployee,
                Status = dto.Status.Trim(),
                SerialNumber = dto.SerialNumber?.Trim(),
                Manufacturer = dto.Manufacturer?.Trim(),
                Model = dto.Model?.Trim(),
                WarrantyExpiry = dto.WarrantyExpiry,
                LastMaintenanceDate = dto.LastMaintenanceDate,
                NextMaintenanceDate = dto.NextMaintenanceDate,
                Notes = dto.Notes?.Trim()
            };

            return await _assetRepository.UpdateAsync(asset);
        }

        public async Task<bool> DisposeAsync(DisposeFixedAssetDTO dto)
        {
            if (dto.AssetID <= 0)
                throw new ArgumentException("Invalid asset ID");

            if (dto.DisposalDate > DateTime.Now)
                throw new ArgumentException("Disposal date cannot be in the future");

            if (dto.DisposalValue < 0)
                throw new ArgumentException("Disposal value cannot be negative");

            var existing = await _assetRepository.GetByIdAsync(dto.AssetID);
            if (existing == null)
                throw new InvalidOperationException("Fixed asset not found");

            if (existing.Status == "Disposed" || existing.Status == "Sold")
                throw new InvalidOperationException("Asset is already disposed or sold");

            if (dto.DisposalDate < existing.PurchaseDate)
                throw new ArgumentException("Disposal date cannot be before purchase date");

            return await _assetRepository.DisposeAsync(
                dto.AssetID,
                dto.DisposalDate,
                dto.DisposalValue,
                dto.Notes?.Trim()
            );
        }

        public async Task<FixedAsset?> GetByIdAsync(int assetId)
        {
            if (assetId <= 0)
                throw new ArgumentException("Invalid asset ID");

            return await _assetRepository.GetByIdAsync(assetId);
        }

        public async Task<List<FixedAsset>> GetAllAsync(GetAllFixedAssetsDTO dto)
        {
            return await _assetRepository.GetAllAsync(
                dto.CategoryID,
                dto.Status,
                dto.ResponsibleEmployee
            );
        }

        public async Task<List<FixedAsset>> GetDueForMaintenanceAsync()
        {
            return await _assetRepository.GetDueForMaintenanceAsync();
        }

        public async Task<List<FixedAsset>> GetSummaryAsync()
        {
            return await _assetRepository.GetSummaryAsync();
        }
    }
}
