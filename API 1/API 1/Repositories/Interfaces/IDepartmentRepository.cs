using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<int> InsertAsync(Department department);
        Task<bool> UpdateAsync(Department department);
        Task<bool> DeleteAsync(int departmentId);
        Task<Department?> GetByIdAsync(int departmentId);
        Task<List<Department>> GetAllAsync(bool? isActive = null);
        Task<List<Department>> GetByCostCenterAsync(int costCenterId);
    }
}