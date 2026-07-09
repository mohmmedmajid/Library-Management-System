namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateSupplierTotalsDTO
    {
        public int SupplierID { get; set; }
        public decimal PurchaseAmount { get; set; } = 0;
        public decimal DebtAmount { get; set; } = 0;
    }
}