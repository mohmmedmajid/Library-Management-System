namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateBorrowingDetailDTO
    {
        public int BorrowingDetailID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerDay { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}