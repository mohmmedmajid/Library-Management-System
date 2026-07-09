using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class ChartOfAccountRepository : IChartOfAccountRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public ChartOfAccountRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(ChartOfAccount account)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountCode", account.AccountCode),
                new SqlParameter("@AccountName", account.AccountName),
                new SqlParameter("@AccountNameAr", account.AccountNameAr),
                new SqlParameter("@AccountTypeID", account.AccountTypeID),
                new SqlParameter("@ParentAccountID", (object?)account.ParentAccountID ?? DBNull.Value),
                new SqlParameter("@Level", account.Level),
                new SqlParameter("@IsParent", account.IsParent),
                new SqlParameter("@OpeningBalance", account.OpeningBalance),
                new SqlParameter("@CurrencyCode", account.CurrencyCode),
                new SqlParameter("@AllowPosting", account.AllowPosting),
                new SqlParameter("@Description", (object?)account.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)account.CreatedBy ?? DBNull.Value),
                new SqlParameter("@AccountID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_ChartOfAccounts_Insert", parameters);
                return (int)parameters[12].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting account: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(ChartOfAccount account)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountID", account.AccountID),
                new SqlParameter("@AccountCode", account.AccountCode),
                new SqlParameter("@AccountName", account.AccountName),
                new SqlParameter("@AccountNameAr", account.AccountNameAr),
                new SqlParameter("@AccountTypeID", account.AccountTypeID),
                new SqlParameter("@AllowPosting", account.AllowPosting),
                new SqlParameter("@Description", (object?)account.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", account.IsActive)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_ChartOfAccounts_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating account: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int accountId)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountID", accountId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_ChartOfAccounts_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting account: {ex.Message}", ex);
            }
        }

        public async Task<ChartOfAccount?> GetByIdAsync(int accountId)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountID", accountId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ChartOfAccounts_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToChartOfAccount(dataTable.Rows[0]);
        }

        public async Task<ChartOfAccount?> GetByCodeAsync(string accountCode)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountCode", accountCode)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ChartOfAccounts_GetByCode", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToChartOfAccount(dataTable.Rows[0]);
        }

        public async Task<List<ChartOfAccount>> GetAllAsync(int? accountTypeId = null, bool? isActive = null, bool? allowPosting = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountTypeID", (object?)accountTypeId ?? DBNull.Value),
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value),
                new SqlParameter("@AllowPosting", (object?)allowPosting ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ChartOfAccounts_GetAll", parameters);

            var accounts = new List<ChartOfAccount>();
            foreach (DataRow row in dataTable.Rows)
            {
                accounts.Add(MapToChartOfAccount(row));
            }

            return accounts;
        }

        public async Task<List<ChartOfAccount>> GetTreeAsync(int? accountTypeId = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountTypeID", (object?)accountTypeId ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ChartOfAccounts_GetTree", parameters);

            var accounts = new List<ChartOfAccount>();
            foreach (DataRow row in dataTable.Rows)
            {
                accounts.Add(MapToChartOfAccount(row));
            }

            return accounts;
        }

        public async Task<List<ChartOfAccount>> GetLeafAccountsAsync(int? accountTypeId = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountTypeID", (object?)accountTypeId ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ChartOfAccounts_GetLeafAccounts", parameters);

            var accounts = new List<ChartOfAccount>();
            foreach (DataRow row in dataTable.Rows)
            {
                accounts.Add(MapToChartOfAccount(row));
            }

            return accounts;
        }

        public async Task<bool> UpdateBalanceAsync(int accountId, decimal amount, bool isDebit)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountID", accountId),
                new SqlParameter("@Amount", amount),
                new SqlParameter("@IsDebit", isDebit)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_ChartOfAccounts_UpdateBalance", parameters);
            return result > 0;
        }

        public async Task<List<ChartOfAccount>> SearchAsync(string searchTerm)
        {
            var parameters = new[]
            {
                new SqlParameter("@SearchTerm", searchTerm)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_ChartOfAccounts_Search", parameters);

            var accounts = new List<ChartOfAccount>();
            foreach (DataRow row in dataTable.Rows)
            {
                accounts.Add(MapToChartOfAccount(row));
            }

            return accounts;
        }

        private ChartOfAccount MapToChartOfAccount(DataRow row)
        {
            return new ChartOfAccount
            {
                AccountID = Convert.ToInt32(row["AccountID"]),
                AccountCode = row["AccountCode"].ToString() ?? string.Empty,
                AccountName = row["AccountName"].ToString() ?? string.Empty,
                AccountNameAr = row["AccountNameAr"].ToString() ?? string.Empty,
                AccountTypeID = Convert.ToInt32(row["AccountTypeID"]),
                ParentAccountID = row.Table.Columns.Contains("ParentAccountID") && row["ParentAccountID"] != DBNull.Value
                    ? Convert.ToInt32(row["ParentAccountID"]) : null,
                Level = row.Table.Columns.Contains("Level") && row["Level"] != DBNull.Value
                    ? Convert.ToInt32(row["Level"]) : 1,
                IsParent = row.Table.Columns.Contains("IsParent") && row["IsParent"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsParent"]) : false,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                OpeningBalance = row.Table.Columns.Contains("OpeningBalance") && row["OpeningBalance"] != DBNull.Value
                    ? Convert.ToDecimal(row["OpeningBalance"]) : 0,
                CurrentBalance = row.Table.Columns.Contains("CurrentBalance") && row["CurrentBalance"] != DBNull.Value
                    ? Convert.ToDecimal(row["CurrentBalance"]) : 0,
                CurrencyCode = row.Table.Columns.Contains("CurrencyCode") && row["CurrencyCode"] != DBNull.Value
                    ? row["CurrencyCode"].ToString() ?? "JOD" : "JOD",
                AllowPosting = row.Table.Columns.Contains("AllowPosting") && row["AllowPosting"] != DBNull.Value
                    ? Convert.ToBoolean(row["AllowPosting"]) : true,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                TypeName = row.Table.Columns.Contains("TypeName") && row["TypeName"] != DBNull.Value
                    ? row["TypeName"].ToString() : null,
                TypeNameAr = row.Table.Columns.Contains("TypeNameAr") && row["TypeNameAr"] != DBNull.Value
                    ? row["TypeNameAr"].ToString() : null,
                NormalBalance = row.Table.Columns.Contains("NormalBalance") && row["NormalBalance"] != DBNull.Value
                    ? row["NormalBalance"].ToString() : null,
                ParentAccountName = row.Table.Columns.Contains("ParentAccountName") && row["ParentAccountName"] != DBNull.Value
                    ? row["ParentAccountName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null,
                Path = row.Table.Columns.Contains("Path") && row["Path"] != DBNull.Value
                    ? row["Path"].ToString() : null,
                Depth = row.Table.Columns.Contains("Depth") && row["Depth"] != DBNull.Value
                    ? Convert.ToInt32(row["Depth"]) : 0,
                IndentedName = row.Table.Columns.Contains("IndentedName") && row["IndentedName"] != DBNull.Value
                    ? row["IndentedName"].ToString() : null
            };
        }
    }
}