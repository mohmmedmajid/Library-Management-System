using System;

namespace LibrarySystem.WinForms.Models.Sales
{
    public class SalesRepresentative
    {
        public int SalesRepID { get; set; }
        public string RepName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal CommissionPercent { get; set; } = 0;
        public decimal TotalSales { get; set; } = 0;
        public decimal TotalCommissions { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}