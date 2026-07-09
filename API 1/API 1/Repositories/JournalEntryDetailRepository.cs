using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class JournalEntryDetailRepository : IJournalEntryDetailRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public JournalEntryDetailRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(JournalEntryDetail detail)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryID", detail.JournalEntryID),
                new SqlParameter("@LineNumber", detail.LineNumber),
                new SqlParameter("@AccountID", detail.AccountID),
                new SqlParameter("@Amount", detail.Amount),
                new SqlParameter("@IsDebit", detail.IsDebit),
                new SqlParameter("@Description", (object?)detail.Description ?? DBNull.Value),
                new SqlParameter("@JournalEntryDetailID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_JournalEntryDetails_Insert", parameters);
                return (int)parameters[6].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting journal entry detail: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(JournalEntryDetail detail)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryDetailID", detail.JournalEntryDetailID),
                new SqlParameter("@AccountID", detail.AccountID),
                new SqlParameter("@Amount", detail.Amount),
                new SqlParameter("@IsDebit", detail.IsDebit),
                new SqlParameter("@Description", (object?)detail.Description ?? DBNull.Value)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_JournalEntryDetails_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating journal entry detail: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int journalEntryDetailId)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryDetailID", journalEntryDetailId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_JournalEntryDetails_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting journal entry detail: {ex.Message}", ex);
            }
        }

        public async Task<List<JournalEntryDetail>> GetByJournalEntryIdAsync(int journalEntryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryID", journalEntryId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_JournalEntryDetails_GetByJournalEntryID", parameters);

            var details = new List<JournalEntryDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapToJournalEntryDetail(row));
            }

            return details;
        }

        public async Task<List<JournalEntryDetail>> GetByAccountAsync(int accountId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@AccountID", accountId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_JournalEntryDetails_GetByAccount", parameters);

            var details = new List<JournalEntryDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapToJournalEntryDetail(row));
            }

            return details;
        }

        private JournalEntryDetail MapToJournalEntryDetail(DataRow row)
        {
            return new JournalEntryDetail
            {
                JournalEntryDetailID = Convert.ToInt32(row["JournalEntryDetailID"]),
                JournalEntryID = Convert.ToInt32(row["JournalEntryID"]),
                LineNumber = row.Table.Columns.Contains("LineNumber") && row["LineNumber"] != DBNull.Value
                    ? Convert.ToInt32(row["LineNumber"]) : 0,
                AccountID = Convert.ToInt32(row["AccountID"]),
                Amount = row.Table.Columns.Contains("Amount") && row["Amount"] != DBNull.Value
                    ? Convert.ToDecimal(row["Amount"]) : 0,
                IsDebit = row.Table.Columns.Contains("IsDebit") && row["IsDebit"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsDebit"]) : true,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,

                AccountCode = row.Table.Columns.Contains("AccountCode") && row["AccountCode"] != DBNull.Value
                    ? row["AccountCode"].ToString() : null,
                AccountName = row.Table.Columns.Contains("AccountName") && row["AccountName"] != DBNull.Value
                    ? row["AccountName"].ToString() : null,
                AccountNameAr = row.Table.Columns.Contains("AccountNameAr") && row["AccountNameAr"] != DBNull.Value
                    ? row["AccountNameAr"].ToString() : null,
                DebitAmount = row.Table.Columns.Contains("DebitAmount") && row["DebitAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["DebitAmount"]) : 0,
                CreditAmount = row.Table.Columns.Contains("CreditAmount") && row["CreditAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["CreditAmount"]) : 0
            };
        }
    }
}