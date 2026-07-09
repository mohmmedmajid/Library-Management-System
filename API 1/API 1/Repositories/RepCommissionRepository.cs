using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class RepCommissionRepository : IRepCommissionRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public RepCommissionRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(RepCommission commission)
        {
            var parameters = new[]
 {
                new SqlParameter("@SalesRepID", commission.SalesRepID),
                new SqlParameter("@InvoiceID", commission.InvoiceID),
                new SqlParameter("@SalesAmount", commission.SalesAmount),
                new SqlParameter("@CommissionPercent", commission.CommissionPercent),
                new SqlParameter("@CommissionAmount", commission.CommissionAmount),
                new SqlParameter("@IsPaid", commission.IsPaid),
                new SqlParameter("@Notes", (object?)commission.Notes ?? DBNull.Value),
                new SqlParameter("@CommissionID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };
            await _dbHelper.ExecuteNonQueryAsync("SP_RepCommissions_Insert", parameters);

            return (int)parameters[7].Value;
        }

        public async Task<bool> UpdateAsync(RepCommission commission)
        {
            var parameters = new[]
{
                new SqlParameter("@CommissionID", commission.CommissionID),
                new SqlParameter("@CommissionAmount", commission.CommissionAmount),
                new SqlParameter("@IsPaid", commission.IsPaid),
                new SqlParameter("@Notes", (object?)commission.Notes ?? DBNull.Value)
            };
            var result = await _dbHelper.ExecuteNonQueryAsync("SP_RepCommissions_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int commissionId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CommissionID ", commissionId),
            };
            var result = await _dbHelper.ExecuteNonQueryAsync("SP_RepCommissions_Delete", parameters);
            return result > 0;
        }

        public async Task<RepCommission?> GetByIdAsync(int commissionId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CommissionID", commissionId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_RepCommissions_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToRepCommission(dataTable.Rows[0]);
        }
        public async Task<List<RepCommission>> GetBySalesRepAsync(int salesRepId, bool? isPaid = null,
            DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
                  {
                new SqlParameter("@SalesRepID", salesRepId),
                new SqlParameter("@IsPaid", (object?)isPaid ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_RepCommissions_GetBySalesRep", parameters);

            var commissions = new List<RepCommission>();
            foreach (DataRow row in dataTable.Rows)
            {
                commissions.Add(MapToRepCommission(row));
            }

            return commissions;
        }

        public async Task<List<RepCommission>> GetAllAsync(bool? isPaid = null, 
            DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
 {
                new SqlParameter("@IsPaid", (object?)isPaid ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_RepCommissions_GetAll", parameters);

            var commissions = new List<RepCommission>();
            foreach (DataRow row in dataTable.Rows)
            {
                commissions.Add(MapToRepCommission(row));
            }

            return commissions;
        }
        public async Task<bool> MarkAsPaidAsync(int commissionId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CommissionID", commissionId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_RepCommissions_MarkAsPaid", parameters);
            return result > 0;
        }

        public async Task<Dictionary<string, object>?> GetUnpaidTotalAsync(int salesRepId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SalesRepID", salesRepId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_RepCommissions_GetUnpaidTotal", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new Dictionary<string, object>
            {
                { "SalesRepID", Convert.ToInt32(row["SalesRepID"]) },
                { "UnpaidCount", Convert.ToInt32(row["UnpaidCount"]) },
                { "UnpaidTotal", Convert.ToDecimal(row["UnpaidTotal"]) }
            };
        }

        private RepCommission MapToRepCommission(DataRow row)
        {
            return new RepCommission
            {
                CommissionID = Convert.ToInt32(row["CommissionID"]),
                SalesRepID = Convert.ToInt32(row["SalesRepID"]),
                InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                SalesAmount = Convert.ToDecimal(row["SalesAmount"]),
                CommissionPercent = Convert.ToDecimal(row["CommissionPercent"]),
                CommissionAmount = Convert.ToDecimal(row["CommissionAmount"]),
                IsPaid = Convert.ToBoolean(row["IsPaid"]),
                PaidDate = row["PaidDate"] == DBNull.Value ? null : Convert.ToDateTime(row["PaidDate"]),
                Notes = row["Notes"] == DBNull.Value ? null : row["Notes"].ToString(),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),

                RepName = row.Table.Columns.Contains("RepName") && row["RepName"] != DBNull.Value
                    ? row["RepName"].ToString() : null,
                InvoiceNumber = row.Table.Columns.Contains("InvoiceNumber") && row["InvoiceNumber"] != DBNull.Value
                    ? row["InvoiceNumber"].ToString() : null
            };
        }

    }
}
