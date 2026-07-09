using API_1.Models;
using API_1.Data;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class InvoiceTypeRepository : IInvoiceTypeRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public InvoiceTypeRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(InvoiceType invoiceType)
        {
            var parameters = new[]
            {
                new SqlParameter("@TypeName", invoiceType.TypeName),
                new SqlParameter("@TypeNameAr", invoiceType.TypeNameAr),
                new SqlParameter("@Description", (object?)invoiceType.Description ?? DBNull.Value),
                new SqlParameter("@InvoiceTypeID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_InvoiceTypes_Insert", parameters);

            return (int)parameters[3].Value;
        }

        public async Task<bool> UpdateAsync(InvoiceType invoiceType)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceTypeID", invoiceType.InvoiceTypeID),
                new SqlParameter("@TypeName", invoiceType.TypeName),
                new SqlParameter("@TypeNameAr", invoiceType.TypeNameAr),
                new SqlParameter("@Description", (object?)invoiceType.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", invoiceType.IsActive)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_InvoiceTypes_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int invoiceTypeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceTypeID", invoiceTypeId)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_InvoiceTypes_Delete", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting invoice type: {ex.Message}", ex);
            }
        }

        public async Task<InvoiceType?> GetByIdAsync(int invoiceTypeId)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceTypeID", invoiceTypeId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InvoiceTypes_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToInvoiceType(dataTable.Rows[0]);
        }

        public async Task<List<InvoiceType>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_InvoiceTypes_GetAll", parameters);

            var invoiceTypes = new List<InvoiceType>();
            foreach (DataRow row in dataTable.Rows)
            {
                invoiceTypes.Add(MapToInvoiceType(row));
            }

            return invoiceTypes;
        }

        private InvoiceType MapToInvoiceType(DataRow row)
        {
            return new InvoiceType
            {
                InvoiceTypeID = Convert.ToInt32(row["InvoiceTypeID"]),
                TypeName = row["TypeName"].ToString() ?? string.Empty,
                TypeNameAr = row["TypeNameAr"].ToString() ?? string.Empty,
                Description = row["Description"] == DBNull.Value ? null : row["Description"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"])
            };
        }
    }
}