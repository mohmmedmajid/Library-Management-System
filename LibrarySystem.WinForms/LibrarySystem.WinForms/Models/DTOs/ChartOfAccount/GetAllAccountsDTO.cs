namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllAccountsDTO
    {
        public int AccountTypeID { get; set; }
        public bool IsActive { get; set; } = true;
        public bool AllowPosting { get; set; } = true;
    }
}