using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class AssetDepreciationRepository : IAssetDepreciationRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public AssetDepreciationRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> CreateAsync(AssetDepreciation depreciation)
        {
            var parameters = new[]
            {
                new SqlParameter("@AssetID", depreciation.AssetID),
                new SqlParameter("@DepreciationDate", depreciation.DepreciationDate),
                new SqlParameter("@DepreciationPeriod", depreciation.DepreciationPeriod),
                new SqlParameter("@FiscalYear", depreciation.FiscalYear),
                new SqlParameter("@FiscalMonth", (object?)depreciation.FiscalMonth ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)depreciation.CreatedBy ?? DBNull.Value),
                new SqlParameter("@DepreciationID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_AssetDepreciation_Create", parameters);
                return (int)parameters[6].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error creating asset depreciation: {ex.Message}", ex);
            }
        }

        public async Task<bool> PostAsync(int depreciationId, int postedBy)
        {
            var parameters = new[]
            {
        new SqlParameter("@DepreciationID", depreciationId),
        new SqlParameter("@PostedBy", postedBy)
    };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_AssetDepreciation_Post", parameters);
                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error posting asset depreciation: {ex.Message}", ex);
            }
        }

        public async Task<bool> ProcessMonthlyAsync(int fiscalYear, int fiscalMonth, int createdBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@FiscalYear", fiscalYear),
                new SqlParameter("@FiscalMonth", fiscalMonth),
                new SqlParameter("@CreatedBy", createdBy)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_AssetDepreciation_ProcessMonthly", parameters);
                return result >= 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error processing monthly depreciation: {ex.Message}", ex);
            }
        }

        public async Task<AssetDepreciation?> GetByIdAsync(int depreciationId)
        {
            var parameters = new[]
            {
                new SqlParameter("@DepreciationID", depreciationId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AssetDepreciation_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToAssetDepreciation(dataTable.Rows[0]);
        }

        public async Task<List<AssetDepreciation>> GetByAssetAsync(int assetId)
        {
            var parameters = new[]
            {
                new SqlParameter("@AssetID", assetId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AssetDepreciation_GetByAsset", parameters);

            var depreciations = new List<AssetDepreciation>();
            foreach (DataRow row in dataTable.Rows)
            {
                depreciations.Add(MapToAssetDepreciation(row));
            }

            return depreciations;
        }

        public async Task<List<AssetDepreciation>> GetAllAsync(int? fiscalYear = null, int? fiscalMonth = null, string? status = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@FiscalYear", (object?)fiscalYear ?? DBNull.Value),
                new SqlParameter("@FiscalMonth", (object?)fiscalMonth ?? DBNull.Value),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AssetDepreciation_GetAll", parameters);

            var depreciations = new List<AssetDepreciation>();
            foreach (DataRow row in dataTable.Rows)
            {
                depreciations.Add(MapToAssetDepreciation(row));
            }

            return depreciations;
        }

        public async Task<List<AssetDepreciation>> GetSummaryAsync(int fiscalYear)
        {
            var parameters = new[]
            {
                new SqlParameter("@FiscalYear", fiscalYear)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_AssetDepreciation_GetSummary", parameters);

            var depreciations = new List<AssetDepreciation>();
            foreach (DataRow row in dataTable.Rows)
            {
                depreciations.Add(MapToAssetDepreciation(row));
            }

            return depreciations;
        }

        private AssetDepreciation MapToAssetDepreciation(DataRow row)
        {
            return new AssetDepreciation
            {
                DepreciationID = Convert.ToInt32(row["DepreciationID"]),
                AssetID = Convert.ToInt32(row["AssetID"]),
                DepreciationDate = Convert.ToDateTime(row["DepreciationDate"]),
                DepreciationPeriod = row["DepreciationPeriod"].ToString() ?? string.Empty,
                FiscalYear = Convert.ToInt32(row["FiscalYear"]),
                FiscalMonth = row["FiscalMonth"] == DBNull.Value ? null : Convert.ToInt32(row["FiscalMonth"]),
                DepreciationAmount = Convert.ToDecimal(row["DepreciationAmount"]),
                AccumulatedDepreciation = Convert.ToDecimal(row["AccumulatedDepreciation"]),
                BookValue = Convert.ToDecimal(row["BookValue"]),
                JournalEntryID = row["JournalEntryID"] == DBNull.Value ? null : Convert.ToInt32(row["JournalEntryID"]),
                Status = row["Status"].ToString() ?? "Draft",
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                CreatedBy = row["CreatedBy"] == DBNull.Value ? null : Convert.ToInt32(row["CreatedBy"]),

                AssetCode = row.Table.Columns.Contains("AssetCode") && row["AssetCode"] != DBNull.Value
                    ? row["AssetCode"].ToString() : null,
                AssetName = row.Table.Columns.Contains("AssetName") && row["AssetName"] != DBNull.Value
                    ? row["AssetName"].ToString() : null,
                JournalEntryNumber = row.Table.Columns.Contains("JournalEntryNumber") && row["JournalEntryNumber"] != DBNull.Value
                    ? row["JournalEntryNumber"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}