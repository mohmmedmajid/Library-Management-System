namespace LibrarySystem.WinForms.Models
{
    public class ReturnDetail
    {
        public int ReturnDetailID { get; set; }
        public int ReturnID { get; set; }
        public int BorrowingDetailID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductNameAr { get; set; } = string.Empty;
        public int ReturnQuantity { get; set; }
        public int LateDays { get; set; }
        public decimal LateFeeAmount { get; set; }
        public decimal RefundAmount { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}