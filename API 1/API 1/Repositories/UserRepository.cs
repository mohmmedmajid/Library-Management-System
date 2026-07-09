using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public UserRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

 
        public async Task<int> InsertAsync(User user)
        {
            var parameters = new[]
            {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@PasswordHash", user.PasswordHash),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Email", (object?)user.Email ?? DBNull.Value),
                new SqlParameter("@Phone", (object?)user.Phone ?? DBNull.Value),
                new SqlParameter("@RoleID", user.RoleID),
                new SqlParameter("@CreatedBy", (object?)user.CreatedBy ?? DBNull.Value),
                new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Users_Insert", parameters));

            return (int)parameters[7].Value;
        }

    
        public async Task<bool> UpdateAsync(User user)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", user.UserID),
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Email", (object?)user.Email ?? DBNull.Value),
                new SqlParameter("@Phone", (object?)user.Phone ?? DBNull.Value),
                new SqlParameter("@RoleID", user.RoleID),
                new SqlParameter("@IsActive", user.IsActive)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Users_Update", parameters));
            return result > 0;
        }

   
        public async Task<bool> UpdatePasswordAsync(int userId, string newPasswordHash)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@NewPasswordHash", newPasswordHash)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Users_UpdatePassword", parameters));
            return result > 0;
        }

 
        public async Task<bool> DeleteAsync(int userId)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", userId)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Users_Delete", parameters));
            return result > 0;
        }

    
        public async Task<User?> GetByIdAsync(int userId)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", userId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Users_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToUser(dataTable.Rows[0]);
        }

 
        public async Task<List<User>> GetAllAsync(bool? isActive = null, int? roleId = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value),
                new SqlParameter("@RoleID", (object?)roleId ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Users_GetAll", parameters);

            var users = new List<User>();
            foreach (DataRow row in dataTable.Rows)
            {
                users.Add(MapToUser(row));
            }

            return users;
        }


        public async Task<User?> LoginAsync(string username, string passwordHash)
        {
            var parameters = new[]
            {
        new SqlParameter("@Username", username),
        new SqlParameter("@PasswordHash", passwordHash)
    };

            try
            {
                var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Users_Login", parameters);

                if (dataTable.Rows.Count == 0)
                    return null;

                var row = dataTable.Rows[0];
                return new User
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString() ?? string.Empty,
                    FullName = row["FullName"].ToString() ?? string.Empty,
                    Email = row["Email"] == DBNull.Value ? null : row["Email"].ToString(),
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString(),
                    IsActive = true,  
                    IsLocked = false,
                };
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task FailedLoginAsync(string username)
        {
            var parameters = new[]
            {
                new SqlParameter("@Username", username)
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Users_FailedLogin", parameters));
        }

    
        public async Task<bool> UnlockAccountAsync(int userId)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", userId)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Users_UnlockAccount", parameters));
            return result > 0;
        }

    
        private User MapToUser(DataRow row)
        {
            return new User
            {
                UserID = Convert.ToInt32(row["UserID"]),
                Username = row["Username"].ToString() ?? string.Empty,
                FullName = row["FullName"].ToString() ?? string.Empty,
                Email = row["Email"] == DBNull.Value ? null : row["Email"].ToString(),
                Phone = row["Phone"] == DBNull.Value ? null : row["Phone"].ToString(),
                RoleID = Convert.ToInt32(row["RoleID"]),
                RoleName = row["RoleName"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                IsLocked = Convert.ToBoolean(row["IsLocked"]),
                LastLoginDate = row["LastLoginDate"] == DBNull.Value ? null : Convert.ToDateTime(row["LastLoginDate"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"])
            };
        }
    }
}