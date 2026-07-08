namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateBarcodeDTO
    {
        public int BarcodeID { get; set; }
        public string BarcodeValue { get; set; } = string.Empty;
        public string BarcodeType { get; set; } = "EAN13";
        public bool IsDefault { get; set; }
    }
}