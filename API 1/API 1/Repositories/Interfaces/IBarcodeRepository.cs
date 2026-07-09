using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IBarcodeRepository
    {
        Task<int> InsertAsync(Barcode barcode);
        Task<bool> UpdateAsync(Barcode barcode);
        Task<bool> DeleteAsync(int barcodeId);
        Task<Barcode?> GetByIdAsync(int barcodeId);
        Task<List<Barcode>> GetByProductAsync(int productId);
        Task<List<Barcode>> GetAllAsync();
        Task<Barcode?> GetProductByBarcodeAsync(string barcodeValue);
    }
}
