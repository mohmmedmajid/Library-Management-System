namespace API_1.DTOs.SaleReturn
{
    public class SaleReturnDetailInputDTO
    {
        public int InvoiceDetailID { get; set; }
        public int ProductID { get; set; }
        public int ReturnedQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RefundAmount { get; set; }
    }
}