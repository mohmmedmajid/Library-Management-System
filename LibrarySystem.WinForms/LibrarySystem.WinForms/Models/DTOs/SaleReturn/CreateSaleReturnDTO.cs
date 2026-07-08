// Models/DTOs/CreateSaleReturnDTO.cs
using System.Collections.Generic;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class SaleReturnDetailInputDTO
    {
        public int InvoiceDetailID { get; set; }
        public int ReturnedQuantity { get; set; }
    }

    public class CreateSaleReturnDTO
    {
        public int OriginalInvoiceID { get; set; }
        public int CustomerID { get; set; }
        public string RefundMethod { get; set; } = string.Empty;
        public int PaymentMethodID { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }
        public List<SaleReturnDetailInputDTO> Details { get; set; } = new List<SaleReturnDetailInputDTO>();
    }
}