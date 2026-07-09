namespace LibrarySystem.WinForms.Models
{
    public class BorrowingDetail
    {
        public int BorrowingDetailID { get; set; }
        public int BorrowingID { get; set; }
        public string BorrowingNumber { get; set; } = string.Empty;
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductNameAr { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int ReturnedQuantity { get; set; }
        public int RemainingQuantity { get; set; }
        public decimal PricePerDay { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}