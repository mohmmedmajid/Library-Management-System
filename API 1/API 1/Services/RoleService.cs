using API_1.DTOs.Role;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

   
        public async Task<int> CreateAsync(CreateRoleDTO dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.RoleName))
                throw new ArgumentException("Role name is required");

           
            var role = new Role
            {
                RoleName = dto.RoleName.Trim(),
                Description = dto.Description?.Trim()
            };

            
            return await _roleRepository.InsertAsync(role);
        }

  
        public async Task<bool> UpdateAsync(UpdateRoleDTO dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.RoleName))
                throw new ArgumentException("Role name is required");

           
            var role = new Role
            {
                RoleID = dto.RoleID,
                RoleName = dto.RoleName.Trim(),
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            
            return await _roleRepository.UpdateAsync(role);
        }


        public async Task<bool> DeleteAsync(int roleId)
        {
            
            var role = await _roleRepository.GetByIdAsync(roleId);
            if (role == null)
                throw new Exception("Role not found");

            
            return await _roleRepository.DeleteAsync(roleId);
        }

      
        public async Task<Role?> GetByIdAsync(int roleId)
        {
            return await _roleRepository.GetByIdAsync(roleId);
        }

     
        public async Task<List<Role>> GetAllAsync(bool? isActive = null)
        {
            return await _roleRepository.GetAllAsync(isActive);
        }
    }
}