namespace LibrarySystem.WinForms.Models.DTOs
{
    public class PayTaxDeclarationDTO
    {
        public int DeclarationID { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentReference { get; set; } = string.Empty;
    }
}