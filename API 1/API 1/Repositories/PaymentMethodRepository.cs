using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public PaymentMethodRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

    
        public async Task<int> InsertAsync(PaymentMethod paymentMethod)
        {
            var parameters = new[]
            {
                new SqlParameter("@MethodName", paymentMethod.MethodName),
                new SqlParameter("@MethodNameAr", paymentMethod.MethodNameAr),
                new SqlParameter("@DisplayOrder", paymentMethod.DisplayOrder),
                new SqlParameter("@PaymentMethodID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_PaymentMethods_Insert", parameters));

            return (int)parameters[3].Value;
        }

       
        public async Task<bool> UpdateAsync(PaymentMethod paymentMethod)
        {
            var parameters = new[]
            {
                new SqlParameter("@PaymentMethodID", paymentMethod.PaymentMethodID),
                new SqlParameter("@MethodName", paymentMethod.MethodName),
                new SqlParameter("@MethodNameAr", paymentMethod.MethodNameAr),
                new SqlParameter("@IsActive", paymentMethod.IsActive),
                new SqlParameter("@DisplayOrder", paymentMethod.DisplayOrder)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_PaymentMethods_Update", parameters));
            return result > 0;
        }

    
        public async Task<bool> DeleteAsync(int paymentMethodId)
        {
            var parameters = new[]
            {
                new SqlParameter("@PaymentMethodID", paymentMethodId)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_PaymentMethods_Delete", parameters));
            return result > 0;
        }


        public async Task<PaymentMethod?> GetByIdAsync(int paymentMethodId)
        {
            var parameters = new[]
            {
                new SqlParameter("@PaymentMethodID", paymentMethodId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_PaymentMethods_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToPaymentMethod(dataTable.Rows[0]);
        }


        public async Task<List<PaymentMethod>> GetAllAsync(bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_PaymentMethods_GetAll", parameters);

            var paymentMethods = new List<PaymentMethod>();
            foreach (DataRow row in dataTable.Rows)
            {
                paymentMethods.Add(MapToPaymentMethod(row));
            }

            return paymentMethods;
        }


        private PaymentMethod MapToPaymentMethod(DataRow row)
        {
            return new PaymentMethod
            {
                PaymentMethodID = Convert.ToInt32(row["PaymentMethodID"]),
                MethodName = row["MethodName"].ToString() ?? string.Empty,
                MethodNameAr = row["MethodNameAr"].ToString() ?? string.Empty,
                IsActive = Convert.ToBoolean(row["IsActive"]),
                DisplayOrder = Convert.ToInt32(row["DisplayOrder"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"])
            };
        }
    }
}