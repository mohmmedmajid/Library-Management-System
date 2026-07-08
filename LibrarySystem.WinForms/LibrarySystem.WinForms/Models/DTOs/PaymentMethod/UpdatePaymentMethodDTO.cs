namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdatePaymentMethodDTO
    {
        public int PaymentMethodID { get; set; }
        public string MethodName { get; set; } = string.Empty;
        public string MethodNameAr { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } = 0;
    }
}