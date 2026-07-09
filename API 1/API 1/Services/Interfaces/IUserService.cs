using API_1.DTOs.User;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateAsync(CreateUserDTO dto);
        Task<bool> UpdateAsync(UpdateUserDTO dto);
        Task<bool> ChangePasswordAsync(ChangePasswordDTO dto);
        Task<bool> DeleteAsync(int userId);
        Task<UserResponseDTO?> GetByIdAsync(int userId);
        Task<List<UserResponseDTO>> GetAllAsync(bool? isActive = null, int? roleId = null);
        Task<UserResponseDTO?> LoginAsync(LoginDTO dto);
        Task<bool> UnlockAccountAsync(int userId);
    }
}