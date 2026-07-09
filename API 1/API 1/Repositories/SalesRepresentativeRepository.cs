using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class SalesRepresentativeRepository : ISalesRepresentativeRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public SalesRepresentativeRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(SalesRepresentative salesRep)
        {
            var parameters = new[]
            {
                new SqlParameter("@RepName", salesRep.RepName),
                new SqlParameter("@Phone", (object?)salesRep.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object?)salesRep.Email ?? DBNull.Value),
                new SqlParameter("@CommissionPercent", salesRep.CommissionPercent),
                new SqlParameter("@CreatedBy", (object?)salesRep.CreatedBy ?? DBNull.Value),
                new SqlParameter("@SalesRepID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_SalesRepresentatives_Insert", parameters);

            return (int)parameters[5].Value;
        }

        public async Task<bool> UpdateAsync(SalesRepresentative salesRep)
        {
            var parameters = new[]
            {
                new SqlParameter("@SalesRepID", salesRep.SalesRepID),
                new SqlParameter("@RepName", salesRep.RepName),
                new SqlParameter("@Phone", (object?)salesRep.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object?)salesRep.Email ?? DBNull.Value),
                new SqlParameter("@CommissionPercent", salesRep.CommissionPercent),
                new SqlParameter("@IsActive", salesRep.IsActive)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_SalesRepresentatives_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int salesRepId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SalesRepID", salesRepId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_SalesRepresentatives_Delete", parameters);
            return result > 0;
        }

        public async Task<SalesRepresentative?> GetByIdAsync(int salesRepId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SalesRepID", salesRepId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SalesRepresentatives_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToSalesRepresentative(dataTable.Rows[0]);
        }

        public async Task<List<SalesRepresentative>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_SalesRepresentatives_GetAll", parameters);

            var salesReps = new List<SalesRepresentative>();
            foreach (DataRow row in dataTable.Rows)
            {
                salesReps.Add(MapToSalesRepresentative(row));
            }

            return salesReps;
        }

        public async Task<bool> UpdateTotalsAsync(int salesRepId, decimal salesAmount, decimal commissionAmount)
        {
            var parameters = new[]
            {
                new SqlParameter("@SalesRepID", salesRepId),
                new SqlParameter("@SalesAmount", salesAmount),
                new SqlParameter("@CommissionAmount", commissionAmount)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_SalesRepresentatives_UpdateTotals", parameters);
            return result > 0;
        }

        private SalesRepresentative MapToSalesRepresentative(DataRow row)
        {
            return new SalesRepresentative
            {
                SalesRepID = Convert.ToInt32(row["SalesRepID"]),
                RepName = row["RepName"].ToString() ?? string.Empty,
                Phone = row.Table.Columns.Contains("Phone") && row["Phone"] != DBNull.Value
                    ? row["Phone"].ToString() : null,
                Email = row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value
                    ? row["Email"].ToString() : null,
                CommissionPercent = row.Table.Columns.Contains("CommissionPercent") && row["CommissionPercent"] != DBNull.Value
                    ? Convert.ToDecimal(row["CommissionPercent"]) : 0,
                TotalSales = row.Table.Columns.Contains("TotalSales") && row["TotalSales"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalSales"]) : 0,
                TotalCommissions = row.Table.Columns.Contains("TotalCommissions") && row["TotalCommissions"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalCommissions"]) : 0,
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
