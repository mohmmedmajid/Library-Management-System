using System;

namespace LibrarySystem.WinForms.Models.Core
{
    public class InventoryMovement
    {
        public int MovementID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string MovementType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalAmount { get; set; }
        public string ReferenceType { get; set; } = string.Empty;
        public int? ReferenceID { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime MovementDate { get; set; } = DateTime.Now;
    }
}