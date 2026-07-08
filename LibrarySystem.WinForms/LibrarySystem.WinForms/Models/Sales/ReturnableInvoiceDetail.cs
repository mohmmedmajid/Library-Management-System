// Models/Sales/ReturnableInvoiceDetail.cs
namespace LibrarySystem.WinForms.Models.Sales
{
    public class ReturnableInvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductNameAr { get; set; }
        public int Quantity { get; set; }
        public int AlreadyReturnedQuantity { get; set; }
        public int ReturnableQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
    }
}