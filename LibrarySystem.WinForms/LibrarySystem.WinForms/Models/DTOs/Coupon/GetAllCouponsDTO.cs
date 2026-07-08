namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllCouponsDTO
    {
        public bool IsActive { get; set; } = true;
        public bool CurrentOnly { get; set; } = false;
    }
}