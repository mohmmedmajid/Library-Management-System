using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class LateFeeRuleRepository : ILateFeeRuleRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public LateFeeRuleRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(LateFeeRule rule)
        {
            var parameters = new[]
            {
                new SqlParameter("@RuleName", rule.RuleName),
                new SqlParameter("@RuleNameAr", rule.RuleNameAr),
                new SqlParameter("@FeePerDay", rule.FeePerDay),
                new SqlParameter("@GracePeriodDays", rule.GracePeriodDays),
                new SqlParameter("@MaximumFee", (object?)rule.MaximumFee ?? DBNull.Value),
                new SqlParameter("@ApplicableFrom", rule.ApplicableFrom),
                new SqlParameter("@ApplicableTo", (object?)rule.ApplicableTo ?? DBNull.Value),
                new SqlParameter("@Description", (object?)rule.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)rule.CreatedBy ?? DBNull.Value),
                new SqlParameter("@RuleID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_LateFeeRules_Insert", parameters);
                return (int)parameters[9].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting late fee rule: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(LateFeeRule rule)
        {
            var parameters = new[]
            {
                new SqlParameter("@RuleID", rule.RuleID),
                new SqlParameter("@RuleName", rule.RuleName),
                new SqlParameter("@RuleNameAr", rule.RuleNameAr),
                new SqlParameter("@FeePerDay", rule.FeePerDay),
                new SqlParameter("@GracePeriodDays", rule.GracePeriodDays),
                new SqlParameter("@MaximumFee", (object?)rule.MaximumFee ?? DBNull.Value),
                new SqlParameter("@Description", (object?)rule.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", rule.IsActive)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_LateFeeRules_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating late fee rule: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int ruleId)
        {
            var parameters = new[]
            {
                new SqlParameter("@RuleID", ruleId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_LateFeeRules_Delete", parameters);
            return result > 0;
        }

        public async Task<LateFeeRule?> GetByIdAsync(int ruleId)
        {
            var parameters = new[]
            {
                new SqlParameter("@RuleID", ruleId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LateFeeRules_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToLateFeeRule(dataTable.Rows[0]);
        }

        public async Task<LateFeeRule?> GetActiveAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LateFeeRules_GetActive", null);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToLateFeeRule(dataTable.Rows[0]);
        }

        public async Task<List<LateFeeRule>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_LateFeeRules_GetAll", parameters);

            var rules = new List<LateFeeRule>();
            foreach (DataRow row in dataTable.Rows)
            {
                rules.Add(MapToLateFeeRule(row));
            }

            return rules;
        }

        public async Task<(int LateDays, decimal LateFee)> CalculateFeeAsync(DateTime expectedReturnDate, DateTime actualReturnDate)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpectedReturnDate", expectedReturnDate),
                new SqlParameter("@ActualReturnDate", actualReturnDate),
                new SqlParameter("@LateDays", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@LateFee", SqlDbType.Decimal) { Direction = ParameterDirection.Output, Precision = 18, Scale = 2 }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_LateFeeRules_CalculateFee", parameters);

            int lateDays = parameters[2].Value != DBNull.Value ? Convert.ToInt32(parameters[2].Value) : 0;
            decimal lateFee = parameters[3].Value != DBNull.Value ? Convert.ToDecimal(parameters[3].Value) : 0;

            return (lateDays, lateFee);
        }

        private LateFeeRule MapToLateFeeRule(DataRow row)
        {
            return new LateFeeRule
            {
                RuleID = Convert.ToInt32(row["RuleID"]),
                RuleName = row["RuleName"].ToString() ?? string.Empty,
                RuleNameAr = row["RuleNameAr"].ToString() ?? string.Empty,
                FeePerDay = row.Table.Columns.Contains("FeePerDay") && row["FeePerDay"] != DBNull.Value
                    ? Convert.ToDecimal(row["FeePerDay"]) : 0,
                GracePeriodDays = row.Table.Columns.Contains("GracePeriodDays") && row["GracePeriodDays"] != DBNull.Value
                    ? Convert.ToInt32(row["GracePeriodDays"]) : 0,
                MaximumFee = row.Table.Columns.Contains("MaximumFee") && row["MaximumFee"] != DBNull.Value
                    ? Convert.ToDecimal(row["MaximumFee"]) : null,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                ApplicableFrom = row.Table.Columns.Contains("ApplicableFrom") && row["ApplicableFrom"] != DBNull.Value
                    ? Convert.ToDateTime(row["ApplicableFrom"]) : DateTime.Now,
                ApplicableTo = row.Table.Columns.Contains("ApplicableTo") && row["ApplicableTo"] != DBNull.Value
                    ? Convert.ToDateTime(row["ApplicableTo"]) : null,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
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