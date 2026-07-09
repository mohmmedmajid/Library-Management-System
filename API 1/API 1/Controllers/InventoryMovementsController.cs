using API_1.DTOs.InventoryMovement;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMovementsController : ControllerBase
    {
        private readonly IInventoryMovementService _inventoryMovementService;

        public InventoryMovementsController(IInventoryMovementService inventoryMovementService)
        {
            _inventoryMovementService = inventoryMovementService;
        }

        // ─── GET api/inventorymovements ───
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var dto = new GetAllMovementsDTO();
                var movements = await _inventoryMovementService.GetAllAsync(dto);
                return Ok(movements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        // ─── POST api/inventorymovements ───
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInventoryMovementDTO dto)
        {
            try
            {
                var movementId = await _inventoryMovementService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetByProduct), new { productId = dto.ProductID }, new { id = movementId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        // ─── POST api/inventorymovements/by-product ───
        [HttpPost("by-product")]
        public async Task<IActionResult> GetByProduct([FromBody] GetMovementsByProductDTO dto)
        {
            try
            {
                var movements = await _inventoryMovementService.GetByProductAsync(dto);
                return Ok(movements);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ─── POST api/inventorymovements/filter ───
        [HttpPost("filter")]
        public async Task<IActionResult> Filter([FromBody] GetAllMovementsDTO dto)
        {
            try
            {
                var movements = await _inventoryMovementService.GetAllAsync(dto);
                return Ok(movements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        // ─── POST api/inventorymovements/summary ───
        [HttpPost("summary")]
        public async Task<IActionResult> GetSummary([FromBody] GetMovementsSummaryDTO dto)
        {
            try
            {
                var summary = await _inventoryMovementService.GetSummaryAsync(dto);
                var result = new List<object>();
                foreach (System.Data.DataRow row in summary.Rows)
                {
                    result.Add(new
                    {
                        MovementType = row["MovementType"].ToString(),
                        TotalMovements = Convert.ToInt32(row["TotalMovements"]),
                        TotalQuantity = Convert.ToInt32(row["TotalQuantity"]),
                        TotalAmount = row["TotalAmount"] != DBNull.Value
                            ? Convert.ToDecimal(row["TotalAmount"]) : 0
                    });
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
}