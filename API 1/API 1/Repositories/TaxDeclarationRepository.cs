using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class TaxDeclarationRepository : ITaxDeclarationRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public TaxDeclarationRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> CreateAsync(TaxDeclaration declaration)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxTypeID", declaration.TaxTypeID),
                new SqlParameter("@DeclarationType", declaration.DeclarationType),
                new SqlParameter("@FiscalYear", declaration.FiscalYear),
                new SqlParameter("@FiscalMonth", (object?)declaration.FiscalMonth ?? DBNull.Value),
                new SqlParameter("@FiscalQuarter", (object?)declaration.FiscalQuarter ?? DBNull.Value),
                new SqlParameter("@PeriodStartDate", declaration.PeriodStartDate),
                new SqlParameter("@PeriodEndDate", declaration.PeriodEndDate),
                new SqlParameter("@CreatedBy", (object?)declaration.CreatedBy ?? DBNull.Value),
                new SqlParameter("@DeclarationID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_TaxDeclarations_Create", parameters);
                return (int)parameters[8].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error creating tax declaration: {ex.Message}", ex);
            }
        }

        public async Task<bool> SubmitAsync(int declarationId)
        {
            var parameters = new[]
            {
                new SqlParameter("@DeclarationID", declarationId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_TaxDeclarations_Submit", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error submitting tax declaration: {ex.Message}", ex);
            }
        }

        public async Task<bool> MarkAsPaidAsync(int declarationId, decimal paidAmount, string paymentReference)
        {
            var parameters = new[]
            {
                new SqlParameter("@DeclarationID", declarationId),
                new SqlParameter("@PaidAmount", paidAmount),
                new SqlParameter("@PaymentReference", paymentReference)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_TaxDeclarations_MarkAsPaid", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error marking tax declaration as paid: {ex.Message}", ex);
            }
        }

        public async Task<TaxDeclaration?> GetByIdAsync(int declarationId)
        {
            var parameters = new[]
            {
                new SqlParameter("@DeclarationID", declarationId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_TaxDeclarations_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToTaxDeclaration(dataTable.Rows[0]);
        }

        public async Task<List<TaxDeclaration>> GetAllAsync(int? taxTypeId = null, string? declarationType = null, int? fiscalYear = null, string? status = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxTypeID", (object?)taxTypeId ?? DBNull.Value),
                new SqlParameter("@DeclarationType", (object?)declarationType ?? DBNull.Value),
                new SqlParameter("@FiscalYear", (object?)fiscalYear ?? DBNull.Value),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_TaxDeclarations_GetAll", parameters);

            var declarations = new List<TaxDeclaration>();
            foreach (DataRow row in dataTable.Rows)
            {
                declarations.Add(MapToTaxDeclaration(row));
            }

            return declarations;
        }

        private TaxDeclaration MapToTaxDeclaration(DataRow row)
        {
            return new TaxDeclaration
            {
                DeclarationID = Convert.ToInt32(row["DeclarationID"]),
                DeclarationNumber = row["DeclarationNumber"].ToString() ?? string.Empty,
                TaxTypeID = Convert.ToInt32(row["TaxTypeID"]),
                DeclarationType = row["DeclarationType"].ToString() ?? string.Empty,
                FiscalYear = Convert.ToInt32(row["FiscalYear"]),
                FiscalMonth = row["FiscalMonth"] == DBNull.Value ? null : Convert.ToInt32(row["FiscalMonth"]),
                FiscalQuarter = row["FiscalQuarter"] == DBNull.Value ? null : Convert.ToInt32(row["FiscalQuarter"]),
                PeriodStartDate = Convert.ToDateTime(row["PeriodStartDate"]),
                PeriodEndDate = Convert.ToDateTime(row["PeriodEndDate"]),
                TotalSalesAmount = Convert.ToDecimal(row["TotalSalesAmount"]),
                TotalPurchaseAmount = Convert.ToDecimal(row["TotalPurchaseAmount"]),
                TotalSalesTax = Convert.ToDecimal(row["TotalSalesTax"]),
                TotalPurchaseTax = Convert.ToDecimal(row["TotalPurchaseTax"]),
                NetTaxDue = Convert.ToDecimal(row["NetTaxDue"]),
                PaidAmount = Convert.ToDecimal(row["PaidAmount"]),
                RemainingAmount = Convert.ToDecimal(row["RemainingAmount"]),
                Status = row["Status"].ToString() ?? "Draft",
                SubmittedDate = row["SubmittedDate"] == DBNull.Value ? null : Convert.ToDateTime(row["SubmittedDate"]),
                PaidDate = row["PaidDate"] == DBNull.Value ? null : Convert.ToDateTime(row["PaidDate"]),
                PaymentReference = row["PaymentReference"] == DBNull.Value ? null : row["PaymentReference"].ToString(),
                Notes = row["Notes"] == DBNull.Value ? null : row["Notes"].ToString(),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                CreatedBy = row["CreatedBy"] == DBNull.Value ? null : Convert.ToInt32(row["CreatedBy"]),

                TaxCode = row.Table.Columns.Contains("TaxCode") && row["TaxCode"] != DBNull.Value
                    ? row["TaxCode"].ToString() : null,
                TaxName = row.Table.Columns.Contains("TaxName") && row["TaxName"] != DBNull.Value
                    ? row["TaxName"].ToString() : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}