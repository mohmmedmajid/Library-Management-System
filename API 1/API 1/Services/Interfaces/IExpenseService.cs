
using API_1.DTOs.Expense;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IExpenseService
    {
        Task<int> CreateAsync(CreateExpenseDTO dto);
        Task<bool> UpdateAsync(UpdateExpenseDTO dto);
        Task<bool> DeleteAsync(int expenseId);
        Task<Expense?> GetByIdAsync(int expenseId);
        Task<List<Expense>> GetAllAsync(GetAllExpensesDTO dto);
        Task<List<Expense>> GetRecurringExpensesAsync();
        Task<bool> ApproveExpenseAsync(ApproveExpenseDTO dto);
        Task<(decimal TotalAmount, int TotalCount)> GetExpenseSummaryAsync(GetExpenseSummaryDTO dto);
        Task<List<Expense>> GetPendingExpensesAsync();
    }
}