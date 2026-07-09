using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class FixedAssetRepository : IFixedAssetRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public FixedAssetRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(FixedAsset asset)
        {
            var parameters = new[]
            {
                new SqlParameter("@AssetName", asset.AssetName),
                new SqlParameter("@AssetNameAr", asset.AssetNameAr),
                new SqlParameter("@CategoryID", asset.CategoryID),
                new SqlParameter("@PurchaseDate", asset.PurchaseDate),
                new SqlParameter("@PurchasePrice", asset.PurchasePrice),
                new SqlParameter("@SalvageValue", asset.SalvageValue),
                new SqlParameter("@Location", (object?)asset.Location ?? DBNull.Value),
                new SqlParameter("@ResponsibleEmployee", (object?)asset.ResponsibleEmployee ?? DBNull.Value),
                new SqlParameter("@SerialNumber", (object?)asset.SerialNumber ?? DBNull.Value),
                new SqlParameter("@Manufacturer", (object?)asset.Manufacturer ?? DBNull.Value),
                new SqlParameter("@Model", (object?)asset.Model ?? DBNull.Value),
                new SqlParameter("@WarrantyExpiry", (object?)asset.WarrantyExpiry ?? DBNull.Value),
                new SqlParameter("@Notes", (object?)asset.Notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)asset.CreatedBy ?? DBNull.Value),
                new SqlParameter("@AssetID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_FixedAssets_Insert", parameters);
                return (int)parameters[14].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting fixed asset: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(FixedAsset asset)
        {
            var parameters = new[]
            {
                new SqlParameter("@AssetID", asset.AssetID),
                new SqlParameter("@AssetName", asset.AssetName),
                new SqlParameter("@AssetNameAr", asset.AssetNameAr),
                new SqlParameter("@CategoryID", asset.CategoryID),
                new SqlParameter("@Location", (object?)asset.Location ?? DBNull.Value),
                new SqlParameter("@ResponsibleEmployee", (object?)asset.ResponsibleEmployee ?? DBNull.Value),
                new SqlParameter("@Status", asset.Status),
                new SqlParameter("@SerialNumber", (object?)asset.SerialNumber ?? DBNull.Value),
                new SqlParameter("@Manufacturer", (object?)asset.Manufacturer ?? DBNull.Value),
                new SqlParameter("@Model", (object?)asset.Model ?? DBNull.Value),
                new SqlParameter("@WarrantyExpiry", (object?)asset.WarrantyExpiry ?? DBNull.Value),
                new SqlParameter("@LastMaintenanceDate", (object?)asset.LastMaintenanceDate ?? DBNull.Value),
                new SqlParameter("@NextMaintenanceDate", (object?)asset.NextMaintenanceDate ?? DBNull.Value),
                new SqlParameter("@Notes", (object?)asset.Notes ?? DBNull.Value)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_FixedAssets_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating fixed asset: {ex.Message}", ex);
            }
        }

        public async Task<bool> DisposeAsync(int assetId, DateTime disposalDate, decimal disposalValue, string? notes)
        {
            var parameters = new[]
            {
                new SqlParameter("@AssetID", assetId),
                new SqlParameter("@DisposalDate", disposalDate),
                new SqlParameter("@DisposalValue", disposalValue),
                new SqlParameter("@Notes", (object?)notes ?? DBNull.Value)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_FixedAssets_Dispose", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error disposing fixed asset: {ex.Message}", ex);
            }
        }

        public async Task<FixedAsset?> GetByIdAsync(int assetId)
        {
            var parameters = new[]
            {
                new SqlParameter("@AssetID", assetId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_FixedAssets_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToFixedAsset(dataTable.Rows[0]);
        }

        public async Task<List<FixedAsset>> GetAllAsync(int? categoryId = null, string? status = null, int? responsibleEmployee = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@CategoryID", (object?)categoryId ?? DBNull.Value),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@ResponsibleEmployee", (object?)responsibleEmployee ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_FixedAssets_GetAll", parameters);

            var assets = new List<FixedAsset>();
            foreach (DataRow row in dataTable.Rows)
            {
                assets.Add(MapToFixedAsset(row));
            }

            return assets;
        }

        public async Task<List<FixedAsset>> GetDueForMaintenanceAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_FixedAssets_GetDueForMaintenance", null);

            var assets = new List<FixedAsset>();
            foreach (DataRow row in dataTable.Rows)
            {
                assets.Add(MapToFixedAsset(row));
            }

            return assets;
        }

        public async Task<List<FixedAsset>> GetSummaryAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_FixedAssets_GetSummary", null);

            var assets = new List<FixedAsset>();
            foreach (DataRow row in dataTable.Rows)
            {
                assets.Add(MapToFixedAsset(row));
            }

            return assets;
        }

        private FixedAsset MapToFixedAsset(DataRow row)
        {
            return new FixedAsset
            {
                AssetID = Convert.ToInt32(row["AssetID"]),
                AssetCode = row["AssetCode"].ToString() ?? string.Empty,
                AssetName = row["AssetName"].ToString() ?? string.Empty,
                AssetNameAr = row.Table.Columns.Contains("AssetNameAr") && row["AssetNameAr"] != DBNull.Value
                    ? row["AssetNameAr"].ToString() ?? string.Empty : string.Empty,
                CategoryID = Convert.ToInt32(row["CategoryID"]),
                PurchaseDate = Convert.ToDateTime(row["PurchaseDate"]),
                PurchasePrice = Convert.ToDecimal(row["PurchasePrice"]),
                SalvageValue = Convert.ToDecimal(row["SalvageValue"]),
                DepreciableValue = row.Table.Columns.Contains("DepreciableValue") && row["DepreciableValue"] != DBNull.Value
                    ? Convert.ToDecimal(row["DepreciableValue"]) : 0,
                AccumulatedDepreciation = Convert.ToDecimal(row["AccumulatedDepreciation"]),
                BookValue = row.Table.Columns.Contains("BookValue") && row["BookValue"] != DBNull.Value
                    ? Convert.ToDecimal(row["BookValue"]) : 0,
                Status = row["Status"].ToString() ?? "InUse",
                Location = row["Location"] == DBNull.Value ? null : row["Location"].ToString(),
                ResponsibleEmployee = row["ResponsibleEmployee"] == DBNull.Value ? null : Convert.ToInt32(row["ResponsibleEmployee"]),
                SerialNumber = row["SerialNumber"] == DBNull.Value ? null : row["SerialNumber"].ToString(),
                Manufacturer = row["Manufacturer"] == DBNull.Value ? null : row["Manufacturer"].ToString(),
                Model = row["Model"] == DBNull.Value ? null : row["Model"].ToString(),
                WarrantyExpiry = row["WarrantyExpiry"] == DBNull.Value ? null : Convert.ToDateTime(row["WarrantyExpiry"]),
                LastMaintenanceDate = row["LastMaintenanceDate"] == DBNull.Value ? null : Convert.ToDateTime(row["LastMaintenanceDate"]),
                NextMaintenanceDate = row["NextMaintenanceDate"] == DBNull.Value ? null : Convert.ToDateTime(row["NextMaintenanceDate"]),
                DisposalDate = row["DisposalDate"] == DBNull.Value ? null : Convert.ToDateTime(row["DisposalDate"]),
                DisposalValue = row["DisposalValue"] == DBNull.Value ? null : Convert.ToDecimal(row["DisposalValue"]),
                Notes = row["Notes"] == DBNull.Value ? null : row["Notes"].ToString(),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                CreatedBy = row["CreatedBy"] == DBNull.Value ? null : Convert.ToInt32(row["CreatedBy"]),

                CategoryName = row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != DBNull.Value
                    ? row["CategoryName"].ToString() : null,
                EmployeeName = row.Table.Columns.Contains("EmployeeName") && row["EmployeeName"] != DBNull.Value
                    ? row["EmployeeName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null,
                UsefulLifeYears = row.Table.Columns.Contains("UsefulLifeYears") && row["UsefulLifeYears"] != DBNull.Value
                    ? Convert.ToInt32(row["UsefulLifeYears"]) : null,
                AnnualDepreciationRate = row.Table.Columns.Contains("AnnualDepreciationRate") && row["AnnualDepreciationRate"] != DBNull.Value
                    ? Convert.ToDecimal(row["AnnualDepreciationRate"]) : null,
                AgeInMonths = row.Table.Columns.Contains("AgeInMonths") && row["AgeInMonths"] != DBNull.Value
                    ? Convert.ToInt32(row["AgeInMonths"]) : null
            };
        }
    }
}
