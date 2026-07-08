using System;

namespace LibrarySystem.WinForms.Models.Core
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductNameAr { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal CostPrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ProductType { get; set; } = "Other";
        public bool IsActive { get; set; } = true;
        public int QuantityInStock { get; set; }
        public int QuantityBorrowed { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}