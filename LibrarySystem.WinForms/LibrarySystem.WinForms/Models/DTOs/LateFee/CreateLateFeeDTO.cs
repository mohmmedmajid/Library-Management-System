namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateLateFeeDTO
    {
        public int BorrowingID { get; set; }
        public int CustomerID { get; set; }
        public int LateDays { get; set; }
        public decimal FeePerDay { get; set; }
        public decimal TotalFee { get; set; }
        public decimal PaidAmount { get; set; } = 0;
        public decimal RemainingAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public string Notes { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}