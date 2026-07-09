using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public ExpenseRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(Expense expense)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseCategoryID", expense.ExpenseCategoryID),
                new SqlParameter("@ExpenseDate", expense.ExpenseDate),
                new SqlParameter("@Amount", expense.Amount),
                new SqlParameter("@PaymentMethodID", expense.PaymentMethodID),
                new SqlParameter("@ReferenceNumber", (object?)expense.ReferenceNumber ?? DBNull.Value),
                new SqlParameter("@Description", (object?)expense.Description ?? DBNull.Value),
                new SqlParameter("@SupplierID", (object?)expense.SupplierID ?? DBNull.Value),
                new SqlParameter("@ReceiptNumber", (object?)expense.ReceiptNumber ?? DBNull.Value),
                new SqlParameter("@IsRecurring", expense.IsRecurring),
                new SqlParameter("@RecurringPeriod", (object?)expense.RecurringPeriod ?? DBNull.Value),
                new SqlParameter("@ApprovedBy", (object?)expense.ApprovedBy ?? DBNull.Value),
                new SqlParameter("@Status", expense.Status),
                new SqlParameter("@CreatedBy", (object?)expense.CreatedBy ?? DBNull.Value),
                new SqlParameter("@ExpenseID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Expenses_Insert", parameters));

            return (int)parameters[13].Value;
        }

        public async Task<bool> UpdateAsync(Expense expense)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseID", expense.ExpenseID),
                new SqlParameter("@ExpenseCategoryID", expense.ExpenseCategoryID),
                new SqlParameter("@ExpenseDate", expense.ExpenseDate),
                new SqlParameter("@Amount", expense.Amount),
                new SqlParameter("@PaymentMethodID", expense.PaymentMethodID),
                new SqlParameter("@ReferenceNumber", (object?)expense.ReferenceNumber ?? DBNull.Value),
                new SqlParameter("@Description", (object?)expense.Description ?? DBNull.Value),
                new SqlParameter("@SupplierID", (object?)expense.SupplierID ?? DBNull.Value),
                new SqlParameter("@ReceiptNumber", (object?)expense.ReceiptNumber ?? DBNull.Value),
                new SqlParameter("@Status", expense.Status)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Expenses_Update", parameters));
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int expenseId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseID", expenseId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Expenses_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Expense?> GetByIdAsync(int expenseId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseID", expenseId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Expenses_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToExpense(dataTable.Rows[0]);
        }

        public async Task<List<Expense>> GetAllAsync(int? categoryId = null, int? supplierId = null, string? status = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseCategoryID", (object?)categoryId ?? DBNull.Value),
                new SqlParameter("@SupplierID", (object?)supplierId ?? DBNull.Value),
                new SqlParameter("@Status", (object?)status ?? DBNull.Value),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Expenses_GetAll", parameters);

            var expenses = new List<Expense>();
            foreach (DataRow row in dataTable.Rows)
            {
                expenses.Add(MapToExpense(row));
            }

            return expenses;
        }

        public async Task<List<Expense>> GetByCategoryAsync(int categoryId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseCategoryID", categoryId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Expenses_GetByCategory", parameters);

            var expenses = new List<Expense>();
            foreach (DataRow row in dataTable.Rows)
            {
                expenses.Add(MapToExpense(row));
            }

            return expenses;
        }

        public async Task<List<Expense>> GetBySupplierAsync(int supplierId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierID", supplierId),
                new SqlParameter("@StartDate", (object?)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object?)endDate ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Expenses_GetBySupplier", parameters);

            var expenses = new List<Expense>();
            foreach (DataRow row in dataTable.Rows)
            {
                expenses.Add(MapToExpense(row));
            }

            return expenses;
        }
        public async Task<(decimal TotalAmount, int TotalCount)> GetSummaryAsync(DateTime startDate, DateTime endDate)
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Expenses_GetSummary", parameters);

            if (dataTable.Rows.Count == 0)
                return (0, 0);

            var row = dataTable.Rows[0];
            var totalAmount = row["TotalAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TotalAmount"]);
            var totalCount = row["TotalCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalCount"]);

            return (totalAmount, totalCount);
        }

        public async Task<bool> ApproveExpenseAsync(int expenseId, int approvedBy)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseID", expenseId),
                new SqlParameter("@ApprovedBy", approvedBy)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_Expenses_Approve", parameters));
            return result > 0;
        }
        public async Task<List<Expense>> GetRecurringExpensesAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Expenses_GetRecurring", null);

            var expenses = new List<Expense>();
            foreach (DataRow row in dataTable.Rows)
            {
                expenses.Add(MapToExpense(row));
            }

            return expenses;
        }

        private Expense MapToExpense(DataRow row)
        {
            return new Expense
            {
                ExpenseID = Convert.ToInt32(row["ExpenseID"]),
                ExpenseCategoryID = Convert.ToInt32(row["ExpenseCategoryID"]),
                CategoryName = row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != DBNull.Value
                    ? row["CategoryName"].ToString()
                    : null,
                CategoryNameAr = row.Table.Columns.Contains("CategoryNameAr") && row["CategoryNameAr"] != DBNull.Value
                    ? row["CategoryNameAr"].ToString()
                    : null,
                ExpenseDate = Convert.ToDateTime(row["ExpenseDate"]),
                Amount = Convert.ToDecimal(row["Amount"]),
                PaymentMethodID = Convert.ToInt32(row["PaymentMethodID"]),
                MethodName = row.Table.Columns.Contains("MethodName") && row["MethodName"] != DBNull.Value
                    ? row["MethodName"].ToString()
                    : null,
                MethodNameAr = row.Table.Columns.Contains("MethodNameAr") && row["MethodNameAr"] != DBNull.Value
                    ? row["MethodNameAr"].ToString()
                    : null,
                ReferenceNumber = row["ReferenceNumber"] == DBNull.Value ? null : row["ReferenceNumber"].ToString(),
                Description = row["Description"] == DBNull.Value ? null : row["Description"].ToString(),
                SupplierID = row["SupplierID"] == DBNull.Value ? null : Convert.ToInt32(row["SupplierID"]),
                SupplierName = row.Table.Columns.Contains("SupplierName") && row["SupplierName"] != DBNull.Value
                    ? row["SupplierName"].ToString()
                    : null,
                ReceiptNumber = row["ReceiptNumber"] == DBNull.Value ? null : row["ReceiptNumber"].ToString(),
                IsRecurring = Convert.ToBoolean(row["IsRecurring"]),
                RecurringPeriod = row["RecurringPeriod"] == DBNull.Value ? null : row["RecurringPeriod"].ToString(),
                ApprovedBy = row["ApprovedBy"] == DBNull.Value ? null : Convert.ToInt32(row["ApprovedBy"]),
                ApprovedByName = row.Table.Columns.Contains("ApprovedByName") && row["ApprovedByName"] != DBNull.Value
                    ? row["ApprovedByName"].ToString()
                    : null,
                Status = row["Status"].ToString() ?? "Paid",
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"])
                    : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString()
                    : null
            };
        }
    }
}