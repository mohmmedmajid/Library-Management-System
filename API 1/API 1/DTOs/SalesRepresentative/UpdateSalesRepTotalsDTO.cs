namespace API_1.DTOs.SalesRepresentative
{
    public class UpdateSalesRepTotalsDTO
    {
        public int SalesRepID { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal CommissionAmount { get; set; }
    }
}