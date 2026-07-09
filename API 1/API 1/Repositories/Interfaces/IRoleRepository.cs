using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<int> InsertAsync(Role role);
        Task<bool> UpdateAsync(Role role);
        Task<bool> DeleteAsync(int roleId);
        Task<Role?> GetByIdAsync(int roleId);
        Task<List<Role>> GetAllAsync(bool? isActive = null);
    }
}
