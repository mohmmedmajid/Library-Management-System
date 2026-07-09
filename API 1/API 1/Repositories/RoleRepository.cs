using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class RoleRepository : IRoleRepository
    {

        private readonly DatabaseHelper _dbHelper;

        public RoleRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        
        
        public async Task<int> InsertAsync(Role role)
        {
         
            var parameters = new[]
            {
                new SqlParameter("@RoleName", role.RoleName),
                new SqlParameter("@Description", (object?)role.Description ?? DBNull.Value),
             
                new SqlParameter("@RoleID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

          
            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Roles_Insert", parameters));

     
            return (int)parameters[2].Value;
        }

     
        public async Task<bool> UpdateAsync(Role role)
        {
            var parameters = new[]
            {
                new SqlParameter("@RoleID", role.RoleID),
                new SqlParameter("@RoleName", role.RoleName),
                new SqlParameter("@Description", (object?)role.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", role.IsActive)
            };

               var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Roles_Update", parameters));
            return result > 0;
        }        

       
        public async Task<bool> DeleteAsync(int roleId)
        {
            var parameters = new[]
            {
                new SqlParameter("@RoleID", roleId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Roles_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
               
                throw new Exception(ex.Message);
            }
        }


        public async Task<Role?> GetByIdAsync(int roleId)
        {
            var parameters = new[]
            {
                new SqlParameter("@RoleID", roleId)
            };


            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Roles_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToRole(dataTable.Rows[0]);
        }


        public async Task<List<Role>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Roles_GetAll", parameters);

            var roles = new List<Role>();

         
            foreach (DataRow row in dataTable.Rows)
            {
                roles.Add(MapToRole(row));
            }

            return roles;
        }


        private Role MapToRole(DataRow row)
        {
            return new Role
            {
                RoleID = Convert.ToInt32(row["RoleID"]),
                RoleName = row["RoleName"].ToString() ?? string.Empty,
                Description = row["Description"] == DBNull.Value ? null : row["Description"].ToString(),
                IsActive = row.Table.Columns.Contains("IsActive") ? Convert.ToBoolean(row["IsActive"]) : true,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
            };
        }
    }
}