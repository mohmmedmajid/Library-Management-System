using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class CostCenterRepository : ICostCenterRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public CostCenterRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(CostCenter costCenter)
        {
            var parameters = new[]
            {
                new SqlParameter("@CostCenterCode", costCenter.CostCenterCode),
                new SqlParameter("@CostCenterName", costCenter.CostCenterName),
                new SqlParameter("@CostCenterNameAr", costCenter.CostCenterNameAr),
                new SqlParameter("@Description", (object?)costCenter.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)costCenter.CreatedBy ?? DBNull.Value),
                new SqlParameter("@CostCenterID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_CostCenters_Insert", parameters);
                return (int)parameters[5].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting cost center: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(CostCenter costCenter)
        {
            var parameters = new[]
            {
                new SqlParameter("@CostCenterID", costCenter.CostCenterID),
                new SqlParameter("@CostCenterCode", costCenter.CostCenterCode),
                new SqlParameter("@CostCenterName", costCenter.CostCenterName),
                new SqlParameter("@CostCenterNameAr", costCenter.CostCenterNameAr),
                new SqlParameter("@Description", (object?)costCenter.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", costCenter.IsActive)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_CostCenters_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating cost center: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int costCenterId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CostCenterID", costCenterId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_CostCenters_Delete", parameters);
            return result > 0;
        }

        public async Task<CostCenter?> GetByIdAsync(int costCenterId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CostCenterID", costCenterId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_CostCenters_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToCostCenter(dataTable.Rows[0]);
        }

        public async Task<List<CostCenter>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_CostCenters_GetAll", parameters);

            var costCenters = new List<CostCenter>();
            foreach (DataRow row in dataTable.Rows)
            {
                costCenters.Add(MapToCostCenter(row));
            }

            return costCenters;
        }

        private CostCenter MapToCostCenter(DataRow row)
        {
            return new CostCenter
            {
                CostCenterID = Convert.ToInt32(row["CostCenterID"]),
                CostCenterCode = row["CostCenterCode"].ToString() ?? string.Empty,
                CostCenterName = row["CostCenterName"].ToString() ?? string.Empty,
                CostCenterNameAr = row["CostCenterNameAr"].ToString() ?? string.Empty,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}