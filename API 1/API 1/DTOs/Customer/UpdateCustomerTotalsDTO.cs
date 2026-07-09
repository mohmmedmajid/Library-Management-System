namespace API_1.DTOs.Customer
{
    public class UpdateCustomerTotalsDTO
    {
        public int CustomerID { get; set; }
        public decimal PurchaseAmount { get; set; } = 0;
        public decimal DebtAmount { get; set; } = 0;
        public decimal LateFeeAmount { get; set; } = 0;
        public int BorrowingCount { get; set; } = 0;
    }
}
