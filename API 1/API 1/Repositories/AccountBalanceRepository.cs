using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class AccountBalanceRepository : IAccountBalanceRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public AccountBalanceRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<bool> UpsertAsync(int accountId, int fiscalYear, int fiscalMonth, decimal debitAmount = 0, decimal creditAmount = 0)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountID", accountId),
                new SqlParameter("@FiscalYear", fiscalYear),
                new SqlParameter("@FiscalMonth", fiscalMonth),
                new SqlParameter("@DebitAmount", debitAmount),
                new SqlParameter("@CreditAmount", creditAmount)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_AccountBalances_Upsert", parameters);
            return result > 0;
        }

        public async Task<AccountBalance?> GetBalanceAsync(int accountId, int fiscalYear, int fiscalMonth)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountID", accountId),
                new SqlParameter("@FiscalYear", fiscalYear),
                new SqlParameter("@FiscalMonth", fiscalMonth)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AccountBalances_GetBalance", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToAccountBalance(dataTable.Rows[0]);
        }

        public async Task<List<AccountBalance>> GetByPeriodAsync(int fiscalYear, int fiscalMonth, int? accountTypeId = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@FiscalYear", fiscalYear),
                new SqlParameter("@FiscalMonth", fiscalMonth),
                new SqlParameter("@AccountTypeID", (object?)accountTypeId ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AccountBalances_GetByPeriod", parameters);

            var balances = new List<AccountBalance>();
            foreach (DataRow row in dataTable.Rows)
            {
                balances.Add(MapToAccountBalance(row));
            }

            return balances;
        }

        public async Task<List<AccountBalance>> GetYearToDateAsync(int accountId, int fiscalYear, int endMonth)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountID", accountId),
                new SqlParameter("@FiscalYear", fiscalYear),
                new SqlParameter("@EndMonth", endMonth)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AccountBalances_GetYearToDate", parameters);

            var balances = new List<AccountBalance>();
            foreach (DataRow row in dataTable.Rows)
            {
                balances.Add(MapToAccountBalance(row));
            }

            return balances;
        }

        private AccountBalance MapToAccountBalance(DataRow row)
        {
            return new AccountBalance
            {
                BalanceID = Convert.ToInt32(row["BalanceID"]),
                AccountID = Convert.ToInt32(row["AccountID"]),
                FiscalYear = row.Table.Columns.Contains("FiscalYear") && row["FiscalYear"] != DBNull.Value
                    ? Convert.ToInt32(row["FiscalYear"]) : 0,
                FiscalMonth = row.Table.Columns.Contains("FiscalMonth") && row["FiscalMonth"] != DBNull.Value
                    ? Convert.ToInt32(row["FiscalMonth"]) : 0,
                OpeningBalance = row.Table.Columns.Contains("OpeningBalance") && row["OpeningBalance"] != DBNull.Value
                    ? Convert.ToDecimal(row["OpeningBalance"]) : 0,
                DebitTotal = row.Table.Columns.Contains("DebitTotal") && row["DebitTotal"] != DBNull.Value
                    ? Convert.ToDecimal(row["DebitTotal"]) : 0,
                CreditTotal = row.Table.Columns.Contains("CreditTotal") && row["CreditTotal"] != DBNull.Value
                    ? Convert.ToDecimal(row["CreditTotal"]) : 0,
                ClosingBalance = row.Table.Columns.Contains("ClosingBalance") && row["ClosingBalance"] != DBNull.Value
                    ? Convert.ToDecimal(row["ClosingBalance"]) : 0,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,

                AccountCode = row.Table.Columns.Contains("AccountCode") && row["AccountCode"] != DBNull.Value
                    ? row["AccountCode"].ToString() : null,
                AccountName = row.Table.Columns.Contains("AccountName") && row["AccountName"] != DBNull.Value
                    ? row["AccountName"].ToString() : null,
                AccountNameAr = row.Table.Columns.Contains("AccountNameAr") && row["AccountNameAr"] != DBNull.Value
                    ? row["AccountNameAr"].ToString() : null,
                AccountType = row.Table.Columns.Contains("AccountType") && row["AccountType"] != DBNull.Value
                    ? row["AccountType"].ToString() : null
            };
        }
    }
}