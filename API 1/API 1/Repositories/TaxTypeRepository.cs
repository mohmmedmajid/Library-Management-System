using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class TaxTypeRepository : ITaxTypeRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public TaxTypeRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(TaxType taxType)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxCode", taxType.TaxCode),
                new SqlParameter("@TaxName", taxType.TaxName),
                new SqlParameter("@TaxNameAr", taxType.TaxNameAr),
                new SqlParameter("@TaxRate", taxType.TaxRate),
                new SqlParameter("@TaxCategory", taxType.TaxCategory),
                new SqlParameter("@Description", (object?)taxType.Description ?? DBNull.Value),
                new SqlParameter("@EffectiveFrom", taxType.EffectiveFrom),
                new SqlParameter("@EffectiveTo", (object?)taxType.EffectiveTo ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)taxType.CreatedBy ?? DBNull.Value),
                new SqlParameter("@TaxTypeID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_TaxTypes_Insert", parameters);
                return (int)parameters[9].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting tax type: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(TaxType taxType)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxTypeID", taxType.TaxTypeID),
                new SqlParameter("@TaxCode", taxType.TaxCode),
                new SqlParameter("@TaxName", taxType.TaxName),
                new SqlParameter("@TaxNameAr", taxType.TaxNameAr),
                new SqlParameter("@TaxRate", taxType.TaxRate),
                new SqlParameter("@TaxCategory", taxType.TaxCategory),
                new SqlParameter("@Description", (object?)taxType.Description ?? DBNull.Value),
                new SqlParameter("@EffectiveFrom", taxType.EffectiveFrom),
                new SqlParameter("@EffectiveTo", (object?)taxType.EffectiveTo ?? DBNull.Value),
                new SqlParameter("@IsActive", taxType.IsActive)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_TaxTypes_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating tax type: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int taxTypeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxTypeID", taxTypeId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_TaxTypes_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting tax type: {ex.Message}", ex);
            }
        }

        public async Task<TaxType?> GetByIdAsync(int taxTypeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxTypeID", taxTypeId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_TaxTypes_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToTaxType(dataTable.Rows[0]);
        }

        public async Task<List<TaxType>> GetAllAsync(string? taxCategory = null, bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxCategory", (object?)taxCategory ?? DBNull.Value),
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_TaxTypes_GetAll", parameters);

            var taxTypes = new List<TaxType>();
            foreach (DataRow row in dataTable.Rows)
            {
                taxTypes.Add(MapToTaxType(row));
            }

            return taxTypes;
        }

        public async Task<TaxType?> GetActiveByCategoryAsync(string taxCategory)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxCategory", taxCategory)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_TaxTypes_GetActiveByCategory", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToTaxType(dataTable.Rows[0]);
        }

        public async Task<decimal> CalculateTaxAsync(int taxTypeId, decimal baseAmount)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxTypeID", taxTypeId),
                new SqlParameter("@BaseAmount", baseAmount),
                new SqlParameter("@TaxAmount", SqlDbType.Decimal) { Direction = ParameterDirection.Output, Precision = 18, Scale = 2 }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_TaxTypes_CalculateTax", parameters);

            return (decimal)parameters[2].Value;
        }

        private TaxType MapToTaxType(DataRow row)
        {
            return new TaxType
            {
                TaxTypeID = Convert.ToInt32(row["TaxTypeID"]),
                TaxCode = row["TaxCode"]?.ToString() ?? string.Empty,
                TaxName = row["TaxName"]?.ToString() ?? string.Empty,
                TaxNameAr = row["TaxNameAr"]?.ToString() ?? string.Empty,
                TaxRate = row["TaxRate"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TaxRate"]),
                TaxCategory = row["TaxCategory"]?.ToString() ?? string.Empty,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                              ? row["Description"].ToString() : null,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                              && Convert.ToBoolean(row["IsActive"]),
                EffectiveFrom = row.Table.Columns.Contains("EffectiveFrom") && row["EffectiveFrom"] != DBNull.Value
                                ? Convert.ToDateTime(row["EffectiveFrom"]) : DateTime.MinValue,
                EffectiveTo = row.Table.Columns.Contains("EffectiveTo") && row["EffectiveTo"] != DBNull.Value
                                ? Convert.ToDateTime(row["EffectiveTo"]) : null,
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