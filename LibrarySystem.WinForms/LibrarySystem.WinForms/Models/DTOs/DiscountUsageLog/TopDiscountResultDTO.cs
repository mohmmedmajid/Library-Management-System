namespace LibrarySystem.WinForms.Models.DTOs
{
    public class TopDiscountResultDTO
    {
        public int DiscountID { get; set; }
        public string DiscountName { get; set; } = string.Empty;
        public string DiscountNameAr { get; set; } = string.Empty;
        public int UsageCount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
    }
}