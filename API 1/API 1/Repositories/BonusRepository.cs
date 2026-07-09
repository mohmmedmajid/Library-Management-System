using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class BonusRepository : IBonusRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public BonusRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<string> GenerateNumberAsync()
        {
            var parameters = new[]
            {
                new SqlParameter("@BonusNumber", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_Bonuses_GenerateNumber", parameters);

            return parameters[0].Value?.ToString() ?? string.Empty;
        }

        public async Task<int> InsertAsync(Bonus bonus)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", bonus.EmployeeID),
                new SqlParameter("@BonusDate", bonus.BonusDate),
                new SqlParameter("@BonusType", bonus.BonusType),
                new SqlParameter("@Amount", bonus.Amount),
                new SqlParameter("@Reason", (object?)bonus.Reason ?? DBNull.Value),
                new SqlParameter("@ApprovedBy", (object?)bonus.ApprovedBy ?? DBNull.Value),
                new SqlParameter("@Notes", (object?)bonus.Notes ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)bonus.CreatedBy ?? DBNull.Value),
                new SqlParameter("@BonusID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_Bonuses_Insert", parameters);
                return (int)parameters[8].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting bonus: {ex.Message}", ex);
            }
        }

        // BonusRepository.UpdateAsync
        public async Task<bool> UpdateAsync(Bonus bonus)
        {
            var parameters = new[]
            {
        new SqlParameter("@BonusID", bonus.BonusID),
        new SqlParameter("@BonusDate", bonus.BonusDate),
        new SqlParameter("@BonusType", bonus.BonusType),
        new SqlParameter("@Amount", bonus.Amount),
        new SqlParameter("@Reason", (object?)bonus.Reason ?? DBNull.Value),
        new SqlParameter("@Notes", (object?)bonus.Notes ?? DBNull.Value),
        new SqlParameter("@IsPaid", bonus.IsPaid)
    };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Bonuses_Update", parameters);
                return result != 0; // -1 و 1+ كلاهما نجاح، بس 0 فقط يعني لم يتغير شي
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating bonus: {ex.Message}", ex);
            }
        }

        public async Task<bool> MarkAsPaidAsync(int bonusId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BonusID", bonusId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_Bonuses_MarkAsPaid", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int bonusId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BonusID", bonusId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Bonuses_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting bonus: {ex.Message}", ex);
            }
        }

        public async Task<Bonus?> GetByIdAsync(int bonusId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BonusID", bonusId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Bonuses_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToBonus(dataTable.Rows[0]);
        }

        public async Task<List<Bonus>> GetByEmployeeAsync(int employeeId, string? bonusType = null, bool? isPaid = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@BonusType", (object?)bonusType ?? DBNull.Value),
                new SqlParameter("@IsPaid", (object?)isPaid ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Bonuses_GetByEmployee", parameters);

            var bonuses = new List<Bonus>();
            foreach (DataRow row in dataTable.Rows)
            {
                bonuses.Add(MapToBonus(row));
            }

            return bonuses;
        }

        public async Task<List<Bonus>> GetAllAsync(string? bonusType = null, bool? isPaid = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@BonusType", (object?)bonusType ?? DBNull.Value),
                new SqlParameter("@IsPaid", (object?)isPaid ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Bonuses_GetAll", parameters);

            var bonuses = new List<Bonus>();
            foreach (DataRow row in dataTable.Rows)
            {
                bonuses.Add(MapToBonus(row));
            }

            return bonuses;
        }

        private Bonus MapToBonus(DataRow row)
        {
            return new Bonus
            {
                BonusID = Convert.ToInt32(row["BonusID"]),
                BonusNumber = row["BonusNumber"].ToString() ?? string.Empty,
                EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                BonusDate = row.Table.Columns.Contains("BonusDate") && row["BonusDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["BonusDate"]) : DateTime.Now,
                BonusType = row.Table.Columns.Contains("BonusType") && row["BonusType"] != DBNull.Value
                    ? row["BonusType"].ToString() ?? string.Empty : string.Empty,
                Amount = row.Table.Columns.Contains("Amount") && row["Amount"] != DBNull.Value
                    ? Convert.ToDecimal(row["Amount"]) : 0,
                Reason = row.Table.Columns.Contains("Reason") && row["Reason"] != DBNull.Value
                    ? row["Reason"].ToString() : null,
                IsPaid = row.Table.Columns.Contains("IsPaid") && row["IsPaid"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsPaid"]) : false,
                PaidDate = row.Table.Columns.Contains("PaidDate") && row["PaidDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["PaidDate"]) : null,
                ApprovedBy = row.Table.Columns.Contains("ApprovedBy") && row["ApprovedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["ApprovedBy"]) : null,
                ApprovedDate = row.Table.Columns.Contains("ApprovedDate") && row["ApprovedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["ApprovedDate"]) : null,
                Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value
                    ? row["Notes"].ToString() : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,

                EmployeeCode = row.Table.Columns.Contains("EmployeeCode") && row["EmployeeCode"] != DBNull.Value
                    ? row["EmployeeCode"].ToString() : null,
                EmployeeName = row.Table.Columns.Contains("EmployeeName") && row["EmployeeName"] != DBNull.Value
                    ? row["EmployeeName"].ToString() : null,
                ApprovedByName = row.Table.Columns.Contains("ApprovedByName") && row["ApprovedByName"] != DBNull.Value
                    ? row["ApprovedByName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}