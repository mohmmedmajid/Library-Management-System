using API_1.Models;
using API_1.DTOs.Barcode;

namespace API_1.Services.Interfaces
{
    public interface IBarcodeService
    {
        Task<int> CreateAsync(CreateBarcodeDTO dto);
        Task<bool> UpdateAsync(UpdateBarcodeDTO dto);
        Task<bool> DeleteAsync(int barcodeId);
        Task<Barcode?> GetByIdAsync(int barcodeId);
        Task<List<Barcode>> GetByProductAsync(int productId);
        Task<List<Barcode>> GetAllAsync();
        Task<Barcode?> GetProductByBarcodeAsync(string barcodeValue);
    }
}
