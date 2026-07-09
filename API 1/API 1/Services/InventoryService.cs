using API_1.DTOs.Inventory;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;

        public InventoryService(IInventoryRepository inventoryRepository, IProductRepository productRepository)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
        }


        public async Task<bool> UpdateStockAsync(UpdateStockDTO dto)
        {

            if (dto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            var validMovementTypes = new[] { "Add", "Remove", "Restock" };
            if (!validMovementTypes.Contains(dto.MovementType))
                throw new ArgumentException("Invalid movement type. Must be: Add, Remove, or Restock");


            var product = await _productRepository.GetByIdAsync(dto.ProductID);
            if (product == null)
                throw new Exception("Product not found");

            return await _inventoryRepository.UpdateStockAsync(dto.ProductID, dto.Quantity, dto.MovementType);
        }


        public async Task<bool> UpdateBorrowedAsync(UpdateBorrowedDTO dto)
        {

            if (dto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            var validOperations = new[] { "Borrow", "Return" };
            if (!validOperations.Contains(dto.Operation))
                throw new ArgumentException("Invalid operation. Must be: Borrow or Return");


            var product = await _productRepository.GetByIdAsync(dto.ProductID);
            if (product == null)
                throw new Exception("Product not found");

            return await _inventoryRepository.UpdateBorrowedAsync(dto.ProductID, dto.Quantity, dto.Operation);
        }

        public async Task<Inventory?> GetByProductIdAsync(int productId)
        {
            return await _inventoryRepository.GetByProductIdAsync(productId);
        }

        public async Task<List<Inventory>> GetAllAsync()
        {
            return await _inventoryRepository.GetAllAsync();
        }


        public async Task<List<Inventory>> GetLowStockAsync()
        {
            return await _inventoryRepository.GetLowStockAsync();
        }

        public async Task<bool> SetMinimumLevelAsync(SetMinimumLevelDTO dto)
        {
            if (dto.MinimumStockLevel < 0)
                throw new ArgumentException("Minimum stock level cannot be negative");

            var product = await _productRepository.GetByIdAsync(dto.ProductID);
            if (product == null)
                throw new Exception("Product not found");

            return await _inventoryRepository.SetMinimumLevelAsync(dto.ProductID, dto.MinimumStockLevel);
        }
    }
}