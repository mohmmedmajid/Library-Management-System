using API_1.DTOs.CostCenter;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class CostCenterService : ICostCenterService
    {
        private readonly ICostCenterRepository _costCenterRepository;

        public CostCenterService(ICostCenterRepository costCenterRepository)
        {
            _costCenterRepository = costCenterRepository;
        }

        public async Task<int> CreateAsync(CreateCostCenterDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CostCenterCode))
                throw new ArgumentException("Cost center code is required");

            if (string.IsNullOrWhiteSpace(dto.CostCenterName))
                throw new ArgumentException("Cost center name is required");

            if (string.IsNullOrWhiteSpace(dto.CostCenterNameAr))
                throw new ArgumentException("Cost center name in Arabic is required");

            var costCenter = new CostCenter
            {
                CostCenterCode = dto.CostCenterCode.Trim(),
                CostCenterName = dto.CostCenterName.Trim(),
                CostCenterNameAr = dto.CostCenterNameAr.Trim(),
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _costCenterRepository.InsertAsync(costCenter);
        }

        public async Task<bool> UpdateAsync(UpdateCostCenterDTO dto)
        {
            if (dto.CostCenterID <= 0)
                throw new ArgumentException("Invalid cost center ID");

            if (string.IsNullOrWhiteSpace(dto.CostCenterCode))
                throw new ArgumentException("Cost center code is required");

            if (string.IsNullOrWhiteSpace(dto.CostCenterName))
                throw new ArgumentException("Cost center name is required");

            if (string.IsNullOrWhiteSpace(dto.CostCenterNameAr))
                throw new ArgumentException("Cost center name in Arabic is required");

            var existing = await _costCenterRepository.GetByIdAsync(dto.CostCenterID);
            if (existing == null)
                throw new InvalidOperationException("Cost center not found");

            var costCenter = new CostCenter
            {
                CostCenterID = dto.CostCenterID,
                CostCenterCode = dto.CostCenterCode.Trim(),
                CostCenterName = dto.CostCenterName.Trim(),
                CostCenterNameAr = dto.CostCenterNameAr.Trim(),
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _costCenterRepository.UpdateAsync(costCenter);
        }

        public async Task<bool> DeleteAsync(int costCenterId)
        {
            if (costCenterId <= 0)
                throw new ArgumentException("Invalid cost center ID");

            var existing = await _costCenterRepository.GetByIdAsync(costCenterId);
            if (existing == null)
                throw new InvalidOperationException("Cost center not found");

            return await _costCenterRepository.DeleteAsync(costCenterId);
        }

        public async Task<CostCenter?> GetByIdAsync(int costCenterId)
        {
            if (costCenterId <= 0)
                throw new ArgumentException("Invalid cost center ID");

            return await _costCenterRepository.GetByIdAsync(costCenterId);
        }

        public async Task<List<CostCenter>> GetAllAsync(bool? isActive = null)
        {
            return await _costCenterRepository.GetAllAsync(isActive);
        }
    }
}