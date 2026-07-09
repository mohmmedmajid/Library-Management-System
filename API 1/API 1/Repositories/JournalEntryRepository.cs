using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class JournalEntryRepository : IJournalEntryRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public JournalEntryRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<string> GenerateNumberAsync()
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryNumber", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_JournalEntries_GenerateNumber", parameters);

            return parameters[0].Value?.ToString() ?? string.Empty;
        }

        public async Task<int> InsertAsync(JournalEntry journalEntry)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryNumber", (object?)journalEntry.JournalEntryNumber ?? DBNull.Value),
                new SqlParameter("@EntryDate", journalEntry.EntryDate),
                new SqlParameter("@EntryType", journalEntry.EntryType),
                new SqlParameter("@ReferenceType", (object?)journalEntry.ReferenceType ?? DBNull.Value),
                new SqlParameter("@ReferenceID", (object?)journalEntry.ReferenceID ?? DBNull.Value),
                new SqlParameter("@CostCenterID", (object?)journalEntry.CostCenterID ?? DBNull.Value),
                new SqlParameter("@Description", (object?)journalEntry.Description ?? DBNull.Value),
                new SqlParameter("@FiscalYear", (object?)journalEntry.FiscalYear ?? DBNull.Value),
                new SqlParameter("@FiscalMonth", (object?)journalEntry.FiscalMonth ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)journalEntry.CreatedBy ?? DBNull.Value),
                new SqlParameter("@JournalEntryID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_JournalEntries_Insert", parameters);
                return (int)parameters[10].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting journal entry: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(JournalEntry journalEntry)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryID", journalEntry.JournalEntryID),
                new SqlParameter("@EntryDate", journalEntry.EntryDate),
                new SqlParameter("@CostCenterID", (object?)journalEntry.CostCenterID ?? DBNull.Value),
                new SqlParameter("@Description", (object?)journalEntry.Description ?? DBNull.Value)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_JournalEntries_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating journal entry: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int journalEntryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryID", journalEntryId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_JournalEntries_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting journal entry: {ex.Message}", ex);
            }
        }

        public async Task<bool> PostAsync(int journalEntryId, int postedBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryID", journalEntryId),
                new SqlParameter("@PostedBy", postedBy)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_JournalEntries_Post", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error posting journal entry: {ex.Message}", ex);
            }
        }

        public async Task<int> ReverseAsync(int journalEntryId, int reversedBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryID", journalEntryId),
                new SqlParameter("@ReversedBy", reversedBy),
                new SqlParameter("@ReversalEntryID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_JournalEntries_Reverse", parameters);
                return (int)parameters[2].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error reversing journal entry: {ex.Message}", ex);
            }
        }

        public async Task<JournalEntry?> GetByIdAsync(int journalEntryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@JournalEntryID", journalEntryId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_JournalEntries_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToJournalEntry(dataTable.Rows[0]);
        }

        public async Task<List<JournalEntry>> GetAllAsync(string? entryType = null, string? status = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@EntryType", (object?)entryType ?? DBNull.Value),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_JournalEntries_GetAll", parameters);

            var journalEntries = new List<JournalEntry>();
            foreach (DataRow row in dataTable.Rows)
            {
                journalEntries.Add(MapToJournalEntry(row));
            }

            return journalEntries;
        }

        public async Task<List<JournalEntry>> GetByReferenceAsync(string referenceType, int referenceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ReferenceType", referenceType),
                new SqlParameter("@ReferenceID", referenceId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_JournalEntries_GetByReference", parameters);

            var journalEntries = new List<JournalEntry>();
            foreach (DataRow row in dataTable.Rows)
            {
                journalEntries.Add(MapToJournalEntry(row));
            }

            return journalEntries;
        }

        private JournalEntry MapToJournalEntry(DataRow row)
        {
            return new JournalEntry
            {
                JournalEntryID = Convert.ToInt32(row["JournalEntryID"]),
                JournalEntryNumber = row["JournalEntryNumber"].ToString() ?? string.Empty,
                EntryDate = row.Table.Columns.Contains("EntryDate") && row["EntryDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["EntryDate"]) : DateTime.Now,
                EntryType = row.Table.Columns.Contains("EntryType") && row["EntryType"] != DBNull.Value
                    ? row["EntryType"].ToString() ?? string.Empty : string.Empty,
                ReferenceType = row.Table.Columns.Contains("ReferenceType") && row["ReferenceType"] != DBNull.Value
                    ? row["ReferenceType"].ToString() : null,
                ReferenceID = row.Table.Columns.Contains("ReferenceID") && row["ReferenceID"] != DBNull.Value
                    ? Convert.ToInt32(row["ReferenceID"]) : null,
                CostCenterID = row.Table.Columns.Contains("CostCenterID") && row["CostCenterID"] != DBNull.Value
                    ? Convert.ToInt32(row["CostCenterID"]) : null,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
                TotalDebit = row.Table.Columns.Contains("TotalDebit") && row["TotalDebit"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalDebit"]) : 0,
                TotalCredit = row.Table.Columns.Contains("TotalCredit") && row["TotalCredit"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalCredit"]) : 0,
                IsBalanced = row.Table.Columns.Contains("IsBalanced") && row["IsBalanced"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsBalanced"]) : false,
                Status = row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value
                    ? row["Status"].ToString() ?? "Draft" : "Draft",
                PostedDate = row.Table.Columns.Contains("PostedDate") && row["PostedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["PostedDate"]) : null,
                PostedBy = row.Table.Columns.Contains("PostedBy") && row["PostedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["PostedBy"]) : null,
                ReversedDate = row.Table.Columns.Contains("ReversedDate") && row["ReversedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["ReversedDate"]) : null,
                ReversedBy = row.Table.Columns.Contains("ReversedBy") && row["ReversedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["ReversedBy"]) : null,
                ReversalEntryID = row.Table.Columns.Contains("ReversalEntryID") && row["ReversalEntryID"] != DBNull.Value
                    ? Convert.ToInt32(row["ReversalEntryID"]) : null,
                FiscalYear = row.Table.Columns.Contains("FiscalYear") && row["FiscalYear"] != DBNull.Value
                    ? Convert.ToInt32(row["FiscalYear"]) : null,
                FiscalMonth = row.Table.Columns.Contains("FiscalMonth") && row["FiscalMonth"] != DBNull.Value
                    ? Convert.ToInt32(row["FiscalMonth"]) : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                CostCenterName = row.Table.Columns.Contains("CostCenterName") && row["CostCenterName"] != DBNull.Value
                    ? row["CostCenterName"].ToString() : null,
                PostedByName = row.Table.Columns.Contains("PostedByName") && row["PostedByName"] != DBNull.Value
                    ? row["PostedByName"].ToString() : null,
                ReversedByName = row.Table.Columns.Contains("ReversedByName") && row["ReversedByName"] != DBNull.Value
                    ? row["ReversedByName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}