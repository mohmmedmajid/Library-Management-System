using System;

namespace LibrarySystem.WinForms.Models.Core
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal TotalPurchases { get; set; } = 0;
        public int TotalBorrowings { get; set; } = 0;
        public decimal TotalDebt { get; set; } = 0;
        public decimal TotalLateFees { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}