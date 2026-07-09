namespace API_1.Models
{
    public class SaleReturnDetail
    {
        public int SaleReturnDetailID { get; set; }
        public int SaleReturnID { get; set; }
        public int InvoiceDetailID { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductNameAr { get; set; }
        public int ReturnedQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RefundAmount { get; set; }
    }
}