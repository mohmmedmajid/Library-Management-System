namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateInvoiceDetailDTO
    {
        public int InvoiceDetailID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}