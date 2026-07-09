using API_1.DTOs.InventoryMovement;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;
using System.Data;

namespace API_1.Services
{
    public class InventoryMovementService : IInventoryMovementService
    {
        private readonly IInventoryMovementRepository _inventoryMovementRepository;
        private readonly IProductRepository _productRepository;

        public InventoryMovementService(
            IInventoryMovementRepository inventoryMovementRepository,
            IProductRepository productRepository)
        {
            _inventoryMovementRepository = inventoryMovementRepository;
            _productRepository = productRepository;
        }


        public async Task<int> CreateAsync(CreateInventoryMovementDTO dto)
        {
            var validMovementTypes = new[] { "Purchase", "Sale", "Borrow", "Return", "Adjustment" };
            if (!validMovementTypes.Contains(dto.MovementType))
                throw new ArgumentException("Invalid movement type");

            if (dto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            var product = await _productRepository.GetByIdAsync(dto.ProductID);
            if (product == null)
                throw new Exception("Product not found");


            var movement = new InventoryMovement
            {
                ProductID = dto.ProductID,
                MovementType = dto.MovementType,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                TotalAmount = dto.TotalAmount,
                ReferenceType = dto.ReferenceType,
                ReferenceID = dto.ReferenceID,
                Notes = dto.Notes?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _inventoryMovementRepository.InsertAsync(movement);
        }

        public async Task<List<InventoryMovement>> GetByProductAsync(GetMovementsByProductDTO dto)
        {
            var product = await _productRepository.GetByIdAsync(dto.ProductID);
            if (product == null)
                throw new Exception("Product not found");

            return await _inventoryMovementRepository.GetByProductAsync(
                dto.ProductID,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<InventoryMovement>> GetAllAsync(GetAllMovementsDTO dto)
        {
            return await _inventoryMovementRepository.GetAllAsync(
                dto.MovementType,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<DataTable> GetSummaryAsync(GetMovementsSummaryDTO dto)
        {
            if (dto.StartDate > dto.EndDate)
                throw new ArgumentException("Start date cannot be after end date");

            return await _inventoryMovementRepository.GetSummaryAsync(dto.StartDate,dto.EndDate);
        }
    }
}