using API_1.DTOs.User;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace API_1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        public async Task<int> CreateAsync(CreateUserDTO dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new ArgumentException("Username is required");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Password is required");

            if (dto.Password.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters");
        
            var passwordHash = HashPassword(dto.Password);
          
            var user = new User
            {
                Username = dto.Username.Trim(),
                PasswordHash = passwordHash,
                FullName = dto.FullName.Trim(),
                Email = dto.Email?.Trim(),
                Phone = dto.Phone?.Trim(),
                RoleID = dto.RoleID,
                CreatedBy = dto.CreatedBy
            };         
            return await _userRepository.InsertAsync(user);
        }

       
        public async Task<bool> UpdateAsync(UpdateUserDTO dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new ArgumentException("Username is required");

            
            var user = new User
            {
                UserID = dto.UserID,
                Username = dto.Username.Trim(),
                FullName = dto.FullName.Trim(),
                Email = dto.Email?.Trim(),
                Phone = dto.Phone?.Trim(),
                RoleID = dto.RoleID,
                IsActive = dto.IsActive
            };

            return await _userRepository.UpdateAsync(user);
        }
  
        public async Task<bool> ChangePasswordAsync(ChangePasswordDTO dto)
        {
           
            if (string.IsNullOrWhiteSpace(dto.CurrentPassword))
                throw new ArgumentException("Current password is required");

            if (string.IsNullOrWhiteSpace(dto.NewPassword))
                throw new ArgumentException("New password is required");

            if (dto.NewPassword.Length < 6)
                throw new ArgumentException("New password must be at least 6 characters");

            var user = await _userRepository.GetByIdAsync(dto.UserID);
            if (user == null)
                throw new Exception("User not found");

           
            var currentPasswordHash = HashPassword(dto.CurrentPassword);
            if (user.PasswordHash != currentPasswordHash)
                throw new Exception("Current password is incorrect");

            var newPasswordHash = HashPassword(dto.NewPassword);

            return await _userRepository.UpdatePasswordAsync(dto.UserID, newPasswordHash);
        }

     
        public async Task<bool> DeleteAsync(int userId)
        {
          
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

           
            return await _userRepository.DeleteAsync(userId);
        }

        
        public async Task<UserResponseDTO?> GetByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
                return null;

            
            return new UserResponseDTO
            {
                UserID = user.UserID,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                RoleID = user.RoleID,
                RoleName = user.RoleName,
                IsActive = user.IsActive,
                IsLocked = user.IsLocked,
                LastLoginDate = user.LastLoginDate
            };
        }

       
        public async Task<List<UserResponseDTO>> GetAllAsync(bool? isActive = null, int? roleId = null)
        {
            var users = await _userRepository.GetAllAsync(isActive, roleId);

          
            return users.Select(u => new UserResponseDTO
            {
                UserID = u.UserID,
                Username = u.Username,
                FullName = u.FullName,
                Email = u.Email,
                Phone = u.Phone,
                RoleID = u.RoleID,
                RoleName = u.RoleName,
                IsActive = u.IsActive,
                IsLocked = u.IsLocked,
                LastLoginDate = u.LastLoginDate
            }).ToList();
        }

       
        public async Task<UserResponseDTO?> LoginAsync(LoginDTO dto)
        {
           
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new ArgumentException("Username is required");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Password is required");

            
            var passwordHash = HashPassword(dto.Password);

            
            var user = await _userRepository.LoginAsync(dto.Username, passwordHash);

            if (user == null)
                return null;

           
            return new UserResponseDTO
            {
                UserID = user.UserID,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                RoleID = user.RoleID,
                RoleName = user.RoleName,
                IsActive = user.IsActive,
                IsLocked = user.IsLocked,
                LastLoginDate = user.LastLoginDate
            };
        }

      
        public async Task<bool> UnlockAccountAsync(int userId)
        {
            
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            return await _userRepository.UnlockAccountAsync(userId);
        }

       
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}