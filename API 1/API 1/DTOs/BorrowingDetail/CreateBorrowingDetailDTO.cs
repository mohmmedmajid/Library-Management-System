namespace API_1.DTOs.BorrowingDetail
{
    public class CreateBorrowingDetailDTO
    {
        public int BorrowingID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerDay { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Notes { get; set; }
    }
}