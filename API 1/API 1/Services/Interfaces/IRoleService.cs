using API_1.DTOs.Role;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IRoleService
    {
        Task<int> CreateAsync(CreateRoleDTO dto);
        Task<bool> UpdateAsync(UpdateRoleDTO dto);
        Task<bool> DeleteAsync(int roleId);
        Task<Role?> GetByIdAsync(int roleId);
        Task<List<Role>> GetAllAsync(bool? isActive = null);
    }
}