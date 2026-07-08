using System;

namespace LibrarySystem.WinForms.Models.Core
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductNameAr { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int QuantityInStock { get; set; } = 0;
        public int QuantityBorrowed { get; set; } = 0;
        public int AvailableQuantity { get; set; } = 0;
        public int MinimumStockLevel { get; set; } = 5;
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
    }
}