namespace API_1.DTOs.Expense
{
    public class GetAllExpensesDTO
    {
        public int? ExpenseCategoryID { get; set; }
        public int? SupplierID { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}