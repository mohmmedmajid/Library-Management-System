using API_1.DTOs.Inventory;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
     
        [HttpPut("update-stock")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStockDTO dto)
        {
            try
            {
                var result = await _inventoryService.UpdateStockAsync(dto);

                if (!result)
                    return BadRequest(new { message = "Failed to update stock" });

                return Ok(new { message = "Stock updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

     
        [HttpPut("update-borrowed")]
        public async Task<IActionResult> UpdateBorrowed([FromBody] UpdateBorrowedDTO dto)
        {
            try
            {
                var result = await _inventoryService.UpdateBorrowedAsync(dto);

                if (!result)
                    return BadRequest(new { message = "Failed to update borrowed quantity" });

                return Ok(new { message = "Borrowed quantity updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

 
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            try
            {
                var inventory = await _inventoryService.GetByProductIdAsync(productId);

                if (inventory == null)
                    return NotFound(new { message = "Inventory not found" });

                return Ok(inventory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var inventory = await _inventoryService.GetAllAsync();
                return Ok(inventory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }


        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStock()
        {
            try
            {
                var lowStockItems = await _inventoryService.GetLowStockAsync();
                return Ok(lowStockItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }


        [HttpPut("set-minimum-level")]
        public async Task<IActionResult> SetMinimumLevel([FromBody] SetMinimumLevelDTO dto)
        {
            try
            {
                var result = await _inventoryService.SetMinimumLevelAsync(dto);

                if (!result)
                    return NotFound(new { message = "Product not found" });

                return Ok(new { message = "Minimum stock level set successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}