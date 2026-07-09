namespace API_1.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public decimal TotalPurchases { get; set; } = 0;
        public int TotalBorrowings { get; set; } = 0;
        public decimal TotalDebt { get; set; } = 0;
        public decimal TotalLateFees { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now; 
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}
