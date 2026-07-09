using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class InvoiceTaxRepository : IInvoiceTaxRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public InvoiceTaxRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(InvoiceTax invoiceTax)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceID", invoiceTax.InvoiceID),
                new SqlParameter("@TaxTypeID", invoiceTax.TaxTypeID),
                new SqlParameter("@TaxableAmount", invoiceTax.TaxableAmount),
                new SqlParameter("@TaxRate", invoiceTax.TaxRate),
                new SqlParameter("@TaxAmount", invoiceTax.TaxAmount),
                new SqlParameter("@InvoiceTaxID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_InvoiceTaxes_Insert", parameters);
                return (int)parameters[5].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting invoice tax: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(InvoiceTax invoiceTax)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceTaxID", invoiceTax.InvoiceTaxID),
                new SqlParameter("@TaxableAmount", invoiceTax.TaxableAmount),
                new SqlParameter("@TaxRate", invoiceTax.TaxRate),
                new SqlParameter("@TaxAmount", invoiceTax.TaxAmount)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_InvoiceTaxes_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int invoiceTaxId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceTaxID", invoiceTaxId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_InvoiceTaxes_Delete", parameters);
            return result > 0;
        }

        public async Task<InvoiceTax?> GetByIdAsync(int invoiceTaxId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceTaxID", invoiceTaxId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InvoiceTaxes_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToInvoiceTax(dataTable.Rows[0]);
        }

        public async Task<List<InvoiceTax>> GetByInvoiceIdAsync(int invoiceId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceID", invoiceId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InvoiceTaxes_GetByInvoiceID", parameters);

            var taxes = new List<InvoiceTax>();
            foreach (DataRow row in dataTable.Rows)
            {
                taxes.Add(MapToInvoiceTax(row));
            }

            return taxes;
        }

        public async Task<List<InvoiceTax>> GetAllAsync(int? taxTypeId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@TaxTypeID", (object?)taxTypeId ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InvoiceTaxes_GetAll", parameters);

            var taxes = new List<InvoiceTax>();
            foreach (DataRow row in dataTable.Rows)
            {
                taxes.Add(MapToInvoiceTax(row));
            }

            return taxes;
        }

        public async Task<List<InvoiceTax>> GetSummaryAsync(DateTime startDate, DateTime endDate)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InvoiceTaxes_GetSummary", parameters);

            var taxes = new List<InvoiceTax>();
            foreach (DataRow row in dataTable.Rows)
            {
                taxes.Add(MapToInvoiceTax(row));
            }

            return taxes;
        }

        private InvoiceTax MapToInvoiceTax(DataRow row)
        {
            return new InvoiceTax
            {
                InvoiceTaxID = Convert.ToInt32(row["InvoiceTaxID"]),
                InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                TaxTypeID = Convert.ToInt32(row["TaxTypeID"]),
                TaxableAmount = Convert.ToDecimal(row["TaxableAmount"]),
                TaxRate = Convert.ToDecimal(row["TaxRate"]),
                TaxAmount = Convert.ToDecimal(row["TaxAmount"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),

                InvoiceNumber = row.Table.Columns.Contains("InvoiceNumber") && row["InvoiceNumber"] != DBNull.Value
                    ? row["InvoiceNumber"].ToString() : null,
                InvoiceDate = row.Table.Columns.Contains("InvoiceDate") && row["InvoiceDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["InvoiceDate"]) : null,
                TaxCode = row.Table.Columns.Contains("TaxCode") && row["TaxCode"] != DBNull.Value
                    ? row["TaxCode"].ToString() : null,
                TaxName = row.Table.Columns.Contains("TaxName") && row["TaxName"] != DBNull.Value
                    ? row["TaxName"].ToString() : null,
                TaxCategory = row.Table.Columns.Contains("TaxCategory") && row["TaxCategory"] != DBNull.Value
                    ? row["TaxCategory"].ToString() : null
            };
        }
    }
}