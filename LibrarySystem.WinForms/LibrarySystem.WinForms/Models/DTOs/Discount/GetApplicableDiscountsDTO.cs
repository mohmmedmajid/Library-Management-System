namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetApplicableDiscountsDTO
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public decimal PurchaseAmount { get; set; }
    }
}