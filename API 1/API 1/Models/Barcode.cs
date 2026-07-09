namespace API_1.Models
{
    public class Barcode
    {
        public int BarcodeID { get; set; }
        public int ProductID { get; set; }
        public string BarcodeValue { get; set; } = string.Empty;
        public string BarcodeType { get; set; } = string.Empty; 
        public bool IsDefault { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? AvailableQuantity { get; set; }
    }
}