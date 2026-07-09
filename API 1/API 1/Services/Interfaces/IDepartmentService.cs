using API_1.DTOs.Department;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<int> CreateAsync(CreateDepartmentDTO dto);
        Task<bool> UpdateAsync(UpdateDepartmentDTO dto);
        Task<bool> DeleteAsync(int departmentId);
        Task<Department?> GetByIdAsync(int departmentId);
        Task<List<Department>> GetAllAsync(bool? isActive = null);
        Task<List<Department>> GetByCostCenterAsync(int costCenterId);
    }
}