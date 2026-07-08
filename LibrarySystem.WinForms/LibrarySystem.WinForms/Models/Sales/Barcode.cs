using System;

namespace LibrarySystem.WinForms.Models
{
    public class Barcode
    {
        public int BarcodeID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string BarcodeValue { get; set; } = string.Empty;
        public string BarcodeType { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
        public decimal? UnitPrice { get; set; }        
        public int? AvailableQuantity { get; set; }    
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}