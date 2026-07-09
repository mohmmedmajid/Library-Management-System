namespace API_1.DTOs.ExpenseCategory
{
    public class UpdateExpenseCategoryDTO
    {
        public int ExpenseCategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}