using API_1.DTOs.AssetDepreciation;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class AssetDepreciationService : IAssetDepreciationService
    {
        private readonly IAssetDepreciationRepository _depreciationRepository;
        private readonly IFixedAssetRepository _assetRepository;

        public AssetDepreciationService(
            IAssetDepreciationRepository depreciationRepository,
            IFixedAssetRepository assetRepository)
        {
            _depreciationRepository = depreciationRepository;
            _assetRepository = assetRepository;
        }

        public async Task<int> CreateAsync(CreateAssetDepreciationDTO dto)
        {
            if (dto.AssetID <= 0)
                throw new ArgumentException("Invalid asset ID");

            var validPeriods = new[] { "Monthly", "Yearly" };
            if (!validPeriods.Contains(dto.DepreciationPeriod.Trim()))
                throw new ArgumentException($"Invalid depreciation period. Must be one of: {string.Join(", ", validPeriods)}");

            if (dto.FiscalYear < 2000 || dto.FiscalYear > DateTime.Now.Year + 1)
                throw new ArgumentException("Invalid fiscal year");

            if (dto.FiscalMonth.HasValue && (dto.FiscalMonth < 1 || dto.FiscalMonth > 12))
                throw new ArgumentException("Fiscal month must be between 1 and 12");

            if (dto.DepreciationPeriod == "Monthly" && !dto.FiscalMonth.HasValue)
                throw new ArgumentException("Fiscal month is required for monthly depreciation");

            var asset = await _assetRepository.GetByIdAsync(dto.AssetID);
            if (asset == null)
                throw new InvalidOperationException("Fixed asset not found");

            if (asset.Status != "InUse")
                throw new InvalidOperationException("Depreciation can only be created for assets in use");

            var depreciation = new AssetDepreciation
            {
                AssetID = dto.AssetID,
                DepreciationDate = dto.DepreciationDate,
                DepreciationPeriod = dto.DepreciationPeriod.Trim(),
                FiscalYear = dto.FiscalYear,
                FiscalMonth = dto.FiscalMonth,
                CreatedBy = dto.CreatedBy
            };

            return await _depreciationRepository.CreateAsync(depreciation);
        }

        public async Task<bool> PostAsync(PostAssetDepreciationDTO dto)
        {
            if (dto.DepreciationID <= 0)
                throw new ArgumentException("Invalid depreciation ID");

            if (dto.PostedBy <= 0)
                throw new ArgumentException("Invalid posted by user ID");

            var existing = await _depreciationRepository.GetByIdAsync(dto.DepreciationID);
            if (existing == null)
                throw new InvalidOperationException("Depreciation record not found");

            if (existing.Status == "Posted")
                throw new InvalidOperationException("Depreciation is already posted");

            return await _depreciationRepository.PostAsync(dto.DepreciationID, dto.PostedBy);
        }

        public async Task<bool> ProcessMonthlyAsync(ProcessMonthlyDepreciationDTO dto)
        {
            if (dto.FiscalYear < 2000 || dto.FiscalYear > DateTime.Now.Year + 1)
                throw new ArgumentException("Invalid fiscal year");

            if (dto.FiscalMonth < 1 || dto.FiscalMonth > 12)
                throw new ArgumentException("Fiscal month must be between 1 and 12");

            if (dto.CreatedBy <= 0)
                throw new ArgumentException("Invalid created by user ID");

            var targetDate = new DateTime(dto.FiscalYear, dto.FiscalMonth, 1);
            if (targetDate > DateTime.Now)
                throw new InvalidOperationException("Cannot process depreciation for future months");

            return await _depreciationRepository.ProcessMonthlyAsync(
                dto.FiscalYear,
                dto.FiscalMonth,
                dto.CreatedBy
            );
        }

        public async Task<AssetDepreciation?> GetByIdAsync(int depreciationId)
        {
            if (depreciationId <= 0)
                throw new ArgumentException("Invalid depreciation ID");

            return await _depreciationRepository.GetByIdAsync(depreciationId);
        }

        public async Task<List<AssetDepreciation>> GetByAssetAsync(GetDepreciationByAssetDTO dto)
        {
            if (dto.AssetID <= 0)
                throw new ArgumentException("Invalid asset ID");

            return await _depreciationRepository.GetByAssetAsync(dto.AssetID);
        }

        public async Task<List<AssetDepreciation>> GetAllAsync(GetAllDepreciationsDTO dto)
        {
            int? fiscalYear = (dto.FiscalYear.HasValue && dto.FiscalYear.Value >= 2000) ? dto.FiscalYear : null;
            int? fiscalMonth = (dto.FiscalMonth.HasValue && dto.FiscalMonth.Value >= 1 && dto.FiscalMonth.Value <= 12) ? dto.FiscalMonth : null;
            string? status = string.IsNullOrWhiteSpace(dto.Status) ? null : dto.Status;

            return await _depreciationRepository.GetAllAsync(fiscalYear, fiscalMonth, status);
        }

        public async Task<List<AssetDepreciation>> GetSummaryAsync(GetDepreciationSummaryDTO dto)
        {
            if (dto.FiscalYear < 2000 || dto.FiscalYear > DateTime.Now.Year + 1)
                throw new ArgumentException("Invalid fiscal year");

            return await _depreciationRepository.GetSummaryAsync(dto.FiscalYear);
        }
    }
}
