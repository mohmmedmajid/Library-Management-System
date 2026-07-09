namespace API_1.DTOs.Discount
{
    public class GetApplicableDiscountsDTO
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public decimal PurchaseAmount { get; set; }
    }
}