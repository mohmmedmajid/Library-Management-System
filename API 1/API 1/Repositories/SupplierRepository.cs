using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public SupplierRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(Supplier supplier)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierName", supplier.SupplierName),
                new SqlParameter("@ContactPerson", (object?)supplier.ContactPerson ?? DBNull.Value),
                new SqlParameter("@Phone", (object?)supplier.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object?)supplier.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object?)supplier.Address ?? DBNull.Value),
                new SqlParameter("@TaxNumber", (object?)supplier.TaxNumber ?? DBNull.Value),
                new SqlParameter("@CreditLimit", supplier.CreditLimit),
                new SqlParameter("@PaymentTerms", (object?)supplier.PaymentTerms ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)supplier.CreatedBy ?? DBNull.Value),
                new SqlParameter("@SupplierID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Suppliers_Insert", parameters));

            return (int)parameters[9].Value;
        }

        public async Task<bool> UpdateAsync(Supplier supplier)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierID", supplier.SupplierID),
                new SqlParameter("@SupplierName", supplier.SupplierName),
                new SqlParameter("@ContactPerson", (object?)supplier.ContactPerson ?? DBNull.Value),
                new SqlParameter("@Phone", (object?)supplier.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object?)supplier.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object?)supplier.Address ?? DBNull.Value),
                new SqlParameter("@TaxNumber", (object?)supplier.TaxNumber ?? DBNull.Value),
                new SqlParameter("@CreditLimit", supplier.CreditLimit),
                new SqlParameter("@PaymentTerms", (object?)supplier.PaymentTerms ?? DBNull.Value),
                new SqlParameter("@IsActive", supplier.IsActive)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Suppliers_Update", parameters));
            return result > 0;
        }

        public async Task<bool> UpdateTotalsAsync(int supplierId, decimal purchaseAmount, decimal debtAmount)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierID", supplierId),
                new SqlParameter("@PurchaseAmount", purchaseAmount),
                new SqlParameter("@DebtAmount", debtAmount)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Suppliers_UpdateTotals", parameters));
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int supplierId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierID", supplierId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Suppliers_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Supplier?> GetByIdAsync(int supplierId)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierID", supplierId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Suppliers_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToSupplier(dataTable.Rows[0]);
        }

        public async Task<List<Supplier>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Suppliers_GetAll", parameters);

            var suppliers = new List<Supplier>();
            foreach (DataRow row in dataTable.Rows)
            {
                suppliers.Add(MapToSupplier(row));
            }

            return suppliers;
        }

        public async Task<List<Supplier>> SearchAsync(string searchTerm)
        {
            var parameters = new[]
            {
                new SqlParameter("@SearchTerm", searchTerm)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Suppliers_Search", parameters);

            var suppliers = new List<Supplier>();
            foreach (DataRow row in dataTable.Rows)
            {
                suppliers.Add(MapToSupplier(row));
            }

            return suppliers;
        }

        public async Task<List<Supplier>> GetSuppliersWithDebtAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Suppliers_GetWithDebt", null);

            var suppliers = new List<Supplier>();
            foreach (DataRow row in dataTable.Rows)
            {
                suppliers.Add(MapToSupplier(row));
            }

            return suppliers;
        }

        private Supplier MapToSupplier(DataRow row)
        {
            return new Supplier
            {
                SupplierID = Convert.ToInt32(row["SupplierID"]),
                SupplierName = row["SupplierName"].ToString() ?? string.Empty,
                ContactPerson = row.Table.Columns.Contains("ContactPerson") && row["ContactPerson"] != DBNull.Value
                    ? row["ContactPerson"].ToString() : null,
                Phone = row.Table.Columns.Contains("Phone") && row["Phone"] != DBNull.Value
                    ? row["Phone"].ToString() : null,
                Email = row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value
                    ? row["Email"].ToString() : null,
                Address = row.Table.Columns.Contains("Address") && row["Address"] != DBNull.Value
                    ? row["Address"].ToString() : null,
                TaxNumber = row.Table.Columns.Contains("TaxNumber") && row["TaxNumber"] != DBNull.Value
                    ? row["TaxNumber"].ToString() : null,
                TotalPurchases = row.Table.Columns.Contains("TotalPurchases") && row["TotalPurchases"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalPurchases"]) : 0,
                TotalDebt = row.Table.Columns.Contains("TotalDebt") && row["TotalDebt"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalDebt"]) : 0,
                CreditLimit = row.Table.Columns.Contains("CreditLimit") && row["CreditLimit"] != DBNull.Value
                    ? Convert.ToDecimal(row["CreditLimit"]) : 0,
                PaymentTerms = row.Table.Columns.Contains("PaymentTerms") && row["PaymentTerms"] != DBNull.Value
                    ? row["PaymentTerms"].ToString() : null,
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