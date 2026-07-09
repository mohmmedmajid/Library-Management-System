namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateExchangeDTO
    {
        public int OriginalInvoiceID { get; set; }
        public int OriginalInvoiceDetailID { get; set; }
        public int CustomerID { get; set; }
        public int OldProductID { get; set; }
        public int OldQuantity { get; set; }
        public int NewProductID { get; set; }
        public int NewQuantity { get; set; }
        public int PaymentMethodID { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }
    }
}