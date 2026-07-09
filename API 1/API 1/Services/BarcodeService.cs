using API_1.DTOs.Barcode;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class BarcodeService : IBarcodeService
    {
        private readonly IBarcodeRepository _barcodeRepository;

        public BarcodeService(IBarcodeRepository barcodeRepository)
        {
            _barcodeRepository = barcodeRepository;
        }
        public async Task<int> CreateAsync(CreateBarcodeDTO dto)
        {
            if (dto.ProductID <= 0)
                throw new ArgumentException("Invalid product ID");

            if (string.IsNullOrWhiteSpace(dto.BarcodeValue))
                throw new ArgumentException("Barcode value is required");

            if (string.IsNullOrWhiteSpace(dto.BarcodeType))
                throw new ArgumentException("Barcode type is required");

            var validTypes = new[] { "EAN13", "CODE128", "QR" };
            if (!validTypes.Contains(dto.BarcodeType.Trim().ToUpper()))
                throw new ArgumentException($"Invalid barcode type. Must be one of: {string.Join(", ", validTypes)}");


            ValidateBarcodeFormat(dto.BarcodeValue.Trim(), dto.BarcodeType.Trim());

            var barcode = new Barcode
            {
                ProductID = dto.ProductID,
                BarcodeValue = dto.BarcodeValue.Trim(),
                BarcodeType = dto.BarcodeType.Trim().ToUpper(),
                IsDefault = dto.IsDefault
            };

            return await _barcodeRepository.InsertAsync(barcode);
        }
        public async Task<bool> UpdateAsync(UpdateBarcodeDTO dto)
        {
            if (dto.BarcodeID <= 0)
                throw new ArgumentException("Invalid barcode ID");

            if (string.IsNullOrWhiteSpace(dto.BarcodeValue))
                throw new ArgumentException("Barcode value is required");

            if (string.IsNullOrWhiteSpace(dto.BarcodeType))
                throw new ArgumentException("Barcode type is required");

            var validTypes = new[] { "EAN13", "CODE128", "QR" };
            if (!validTypes.Contains(dto.BarcodeType.Trim().ToUpper()))
                throw new ArgumentException($"Invalid barcode type. Must be one of: {string.Join(", ", validTypes)}");

            ValidateBarcodeFormat(dto.BarcodeValue.Trim(), dto.BarcodeType.Trim());

            var existing = await _barcodeRepository.GetByIdAsync(dto.BarcodeID);
            if (existing == null)
                throw new InvalidOperationException("Barcode not found");

            var barcode = new Barcode
            {
                BarcodeID = dto.BarcodeID,
                BarcodeValue = dto.BarcodeValue.Trim(),
                BarcodeType = dto.BarcodeType.Trim().ToUpper(),
                IsDefault = dto.IsDefault
            };

            return await _barcodeRepository.UpdateAsync(barcode);
        }

        public async Task<bool> DeleteAsync(int barcodeId)
        {
            if (barcodeId <= 0)
                throw new ArgumentException("Invalid barcode ID");

            var existing = await _barcodeRepository.GetByIdAsync(barcodeId);
            if (existing == null)
                throw new InvalidOperationException("Barcode not found");

            return await _barcodeRepository.DeleteAsync(barcodeId);
        }

        public async Task<Barcode?> GetByIdAsync(int barcodeId)
        {
            if (barcodeId <= 0)
                throw new ArgumentException("Invalid barcode ID");

            return await _barcodeRepository.GetByIdAsync(barcodeId);
        }

        public async Task<List<Barcode>> GetByProductAsync(int productId)
        {
            if (productId <= 0)
                throw new ArgumentException("Invalid product ID");

            return await _barcodeRepository.GetByProductAsync(productId);
        }

        public async Task<List<Barcode>> GetAllAsync()
        {
            return await _barcodeRepository.GetAllAsync();
        }

        public async Task<Barcode?> GetProductByBarcodeAsync(string barcodeValue)
        {
            if (string.IsNullOrWhiteSpace(barcodeValue))
                throw new ArgumentException("Barcode value is required");

            return await _barcodeRepository.GetProductByBarcodeAsync(barcodeValue.Trim());
        }

        private void ValidateBarcodeFormat(string barcodeValue, string barcodeType)
        {
            switch (barcodeType.ToUpper())
            {
                case "EAN13":
                    if (barcodeValue.Length != 13 || !barcodeValue.All(char.IsDigit))
                        throw new ArgumentException("EAN13 barcode must be exactly 13 digits");
                    break;

                case "CODE128":
                    if (barcodeValue.Length < 1 || barcodeValue.Length > 128)
                        throw new ArgumentException("CODE128 barcode must be between 1 and 128 characters");
                    break;

                case "QR":
                    if (string.IsNullOrWhiteSpace(barcodeValue))
                        throw new ArgumentException("QR code value cannot be empty");
                    break;
            }
        }
    }
}
