namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateInvoiceDetailDTO
    {
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; } = 0;
        public decimal DiscountPercent { get; set; } = 0;
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}