namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateExpenseCategoryDTO
    {
        public int ExpenseCategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}