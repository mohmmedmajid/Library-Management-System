namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateBarcodeDTO
    {
        public int ProductID { get; set; }
        public string BarcodeValue { get; set; } = string.Empty;
        public string BarcodeType { get; set; } = "EAN13";
        public bool IsDefault { get; set; } = false;
    }
}