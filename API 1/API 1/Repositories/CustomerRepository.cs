using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public CustomerRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public async Task<int> InsertAsync(Customer customer)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerName", customer.CustomerName),
                new SqlParameter("@Phone", (object?)customer.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object?)customer.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object?)customer.Address ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)customer.CreatedBy ?? DBNull.Value),
                new SqlParameter("@CustomerID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Customers_Insert", parameters));

            return (int)parameters[5].Value;
        }


        public async Task<bool> UpdateAsync(Customer customer)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", customer.CustomerID),
                new SqlParameter("@CustomerName", customer.CustomerName),
                new SqlParameter("@Phone", (object?)customer.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object?)customer.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object?)customer.Address ?? DBNull.Value),
                new SqlParameter("@IsActive", customer.IsActive)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Customers_Update", parameters));
            return result > 0;
        }


        public async Task<bool> DeleteAsync(int customerId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", customerId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Customers_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Customer?> GetByIdAsync(int customerId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", customerId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Customers_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToCustomer(dataTable.Rows[0]);
        }


        public async Task<List<Customer>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Customers_GetAll", parameters);

            var customers = new List<Customer>();
            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(MapToCustomer(row));
            }

            return customers;
        }


        public async Task<List<Customer>> SearchAsync(string searchTerm)
        {
            var parameters = new[]
            {
                new SqlParameter("@SearchTerm", searchTerm)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Customers_Search", parameters);

            var customers = new List<Customer>();
            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(MapToCustomerSearch(row));
            }

            return customers;
        }


        public async Task<bool> UpdateTotalsAsync(int customerId, decimal purchaseAmount, decimal debtAmount, decimal lateFeeAmount, int borrowingCount)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@PurchaseAmount", purchaseAmount),
                new SqlParameter("@DebtAmount", debtAmount),
                new SqlParameter("@LateFeeAmount", lateFeeAmount),
                new SqlParameter("@BorrowingCount", borrowingCount)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Customers_UpdateTotals", parameters));
            return result > 0;
        }


        private Customer MapToCustomer(DataRow row)
        {
            return new Customer
            {
                CustomerID = Convert.ToInt32(row["CustomerID"]),
                CustomerName = row["CustomerName"].ToString() ?? string.Empty,
                Phone = row["Phone"] == DBNull.Value ? null : row["Phone"].ToString(),
                Email = row["Email"] == DBNull.Value ? null : row["Email"].ToString(),
                Address = row["Address"] == DBNull.Value ? null : row["Address"].ToString(),
                TotalPurchases = row.Table.Columns.Contains("TotalPurchases") ? Convert.ToDecimal(row["TotalPurchases"]) : 0,
                TotalBorrowings = row.Table.Columns.Contains("TotalBorrowings") ? Convert.ToInt32(row["TotalBorrowings"]) : 0,
                TotalDebt = row.Table.Columns.Contains("TotalDebt") ? Convert.ToDecimal(row["TotalDebt"]) : 0,
                TotalLateFees = row.Table.Columns.Contains("TotalLateFees") ? Convert.ToDecimal(row["TotalLateFees"]) : 0,
                IsActive = row.Table.Columns.Contains("IsActive") ? Convert.ToBoolean(row["IsActive"]) : true,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value ? Convert.ToInt32(row["CreatedBy"]) : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value ? row["CreatedByName"].ToString() : null
            };
        }


        private Customer MapToCustomerSearch(DataRow row)
        {
            return new Customer
            {
                CustomerID = Convert.ToInt32(row["CustomerID"]),
                CustomerName = row["CustomerName"].ToString() ?? string.Empty,
                Phone = row["Phone"] == DBNull.Value ? null : row["Phone"].ToString(),
                Email = row["Email"] == DBNull.Value ? null : row["Email"].ToString(),
                TotalDebt = Convert.ToDecimal(row["TotalDebt"]),
                IsActive = row.Table.Columns.Contains("IsActive") ? Convert.ToBoolean(row["IsActive"]) : true,
            };
        }
    }
}