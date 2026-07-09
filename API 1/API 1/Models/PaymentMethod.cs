namespace API_1.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string MethodName { get; set; } = string.Empty;
        public string MethodNameAr { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedByName { get; set; }
    }
}
