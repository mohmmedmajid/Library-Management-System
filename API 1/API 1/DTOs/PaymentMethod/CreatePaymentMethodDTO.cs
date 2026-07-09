namespace API_1.DTOs.PaymentMethod
{
    public class CreatePaymentMethodDTO
    {
        public string MethodName { get; set; } = string.Empty;
        public string MethodNameAr { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } = 0;
    }
}
