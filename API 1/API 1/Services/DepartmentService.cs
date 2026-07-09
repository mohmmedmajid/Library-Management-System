using API_1.DTOs.Department;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICostCenterRepository _costCenterRepository;

        public DepartmentService(
            IDepartmentRepository departmentRepository,
            ICostCenterRepository costCenterRepository)
        {
            _departmentRepository = departmentRepository;
            _costCenterRepository = costCenterRepository;
        }

        public async Task<int> CreateAsync(CreateDepartmentDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.DepartmentCode))
                throw new ArgumentException("Department code is required");

            if (string.IsNullOrWhiteSpace(dto.DepartmentName))
                throw new ArgumentException("Department name is required");

            if (string.IsNullOrWhiteSpace(dto.DepartmentNameAr))
                throw new ArgumentException("Department name in Arabic is required");

            if (dto.CostCenterID.HasValue)
            {
                var costCenter = await _costCenterRepository.GetByIdAsync(dto.CostCenterID.Value);
                if (costCenter == null)
                    throw new InvalidOperationException("Cost center not found");
            }

            var department = new Department
            {
                DepartmentCode = dto.DepartmentCode.Trim(),
                DepartmentName = dto.DepartmentName.Trim(),
                DepartmentNameAr = dto.DepartmentNameAr.Trim(),
                ManagerID = dto.ManagerID,
                CostCenterID = dto.CostCenterID,
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _departmentRepository.InsertAsync(department);
        }

        public async Task<bool> UpdateAsync(UpdateDepartmentDTO dto)
        {
            if (dto.DepartmentID <= 0)
                throw new ArgumentException("Invalid department ID");

            if (string.IsNullOrWhiteSpace(dto.DepartmentCode))
                throw new ArgumentException("Department code is required");

            if (string.IsNullOrWhiteSpace(dto.DepartmentName))
                throw new ArgumentException("Department name is required");

            if (string.IsNullOrWhiteSpace(dto.DepartmentNameAr))
                throw new ArgumentException("Department name in Arabic is required");

            var existing = await _departmentRepository.GetByIdAsync(dto.DepartmentID);
            if (existing == null)
                throw new InvalidOperationException("Department not found");

            if (dto.CostCenterID.HasValue)
            {
                var costCenter = await _costCenterRepository.GetByIdAsync(dto.CostCenterID.Value);
                if (costCenter == null)
                    throw new InvalidOperationException("Cost center not found");
            }

            var department = new Department
            {
                DepartmentID = dto.DepartmentID,
                DepartmentCode = dto.DepartmentCode.Trim(),
                DepartmentName = dto.DepartmentName.Trim(),
                DepartmentNameAr = dto.DepartmentNameAr.Trim(),
                ManagerID = dto.ManagerID,
                CostCenterID = dto.CostCenterID,
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _departmentRepository.UpdateAsync(department);
        }

        public async Task<bool> DeleteAsync(int departmentId)
        {
            if (departmentId <= 0)
                throw new ArgumentException("Invalid department ID");

            var existing = await _departmentRepository.GetByIdAsync(departmentId);
            if (existing == null)
                throw new InvalidOperationException("Department not found");

            return await _departmentRepository.DeleteAsync(departmentId);
        }

        public async Task<Department?> GetByIdAsync(int departmentId)
        {
            if (departmentId <= 0)
                throw new ArgumentException("Invalid department ID");

            return await _departmentRepository.GetByIdAsync(departmentId);
        }

        public async Task<List<Department>> GetAllAsync(bool? isActive = null)
        {
            return await _departmentRepository.GetAllAsync(isActive);
        }

        public async Task<List<Department>> GetByCostCenterAsync(int costCenterId)
        {
            if (costCenterId <= 0)
                throw new ArgumentException("Invalid cost center ID");

            var costCenter = await _costCenterRepository.GetByIdAsync(costCenterId);
            if (costCenter == null)
                throw new InvalidOperationException("Cost center not found");

            return await _departmentRepository.GetByCostCenterAsync(costCenterId);
        }
    }
}