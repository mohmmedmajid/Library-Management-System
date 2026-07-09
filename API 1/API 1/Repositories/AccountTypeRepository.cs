using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public AccountTypeRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(AccountType accountType)
        {
            var parameters = new[]
            {
                new SqlParameter("@TypeName", accountType.TypeName),
                new SqlParameter("@TypeNameAr", accountType.TypeNameAr),
                new SqlParameter("@NormalBalance", accountType.NormalBalance),
                new SqlParameter("@Description", (object?)accountType.Description ?? DBNull.Value),
                new SqlParameter("@DisplayOrder", accountType.DisplayOrder),
                new SqlParameter("@AccountTypeID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_AccountTypes_Insert", parameters);

            return (int)parameters[5].Value;
        }

        public async Task<bool> UpdateAsync(AccountType accountType)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountTypeID", accountType.AccountTypeID),
                new SqlParameter("@TypeName", accountType.TypeName),
                new SqlParameter("@TypeNameAr", accountType.TypeNameAr),
                new SqlParameter("@NormalBalance", accountType.NormalBalance),
                new SqlParameter("@Description", (object?)accountType.Description ?? DBNull.Value),
                new SqlParameter("@DisplayOrder", accountType.DisplayOrder),
                new SqlParameter("@IsActive", accountType.IsActive)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_AccountTypes_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int accountTypeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountTypeID", accountTypeId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_AccountTypes_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting account type: {ex.Message}", ex);
            }
        }

        public async Task<AccountType?> GetByIdAsync(int accountTypeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountTypeID", accountTypeId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AccountTypes_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToAccountType(dataTable.Rows[0]);
        }

        public async Task<List<AccountType>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AccountTypes_GetAll", parameters);

            var accountTypes = new List<AccountType>();
            foreach (DataRow row in dataTable.Rows)
            {
                accountTypes.Add(MapToAccountType(row));
            }

            return accountTypes;
        }

        private AccountType MapToAccountType(DataRow row)
        {
            return new AccountType
            {
                AccountTypeID = Convert.ToInt32(row["AccountTypeID"]),
                TypeName = row["TypeName"].ToString() ?? string.Empty,
                TypeNameAr = row["TypeNameAr"].ToString() ?? string.Empty,
                NormalBalance = row["NormalBalance"].ToString() ?? string.Empty,
                Description = row["Description"] == DBNull.Value ? null : row["Description"].ToString(),
                DisplayOrder = Convert.ToInt32(row["DisplayOrder"]),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now
            };
        }
    }
}