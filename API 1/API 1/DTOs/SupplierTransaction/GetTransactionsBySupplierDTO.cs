namespace API_1.DTOs.SupplierTransaction
{
    public class GetTransactionsBySupplierDTO
    {
        public int SupplierID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}