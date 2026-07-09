using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.ChartOfAccount;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChartOfAccountsController : ControllerBase
    {
        private readonly IChartOfAccountService _chartOfAccountService;

        public ChartOfAccountsController(IChartOfAccountService chartOfAccountService)
        {
            _chartOfAccountService = chartOfAccountService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateChartOfAccountDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int accountId = await _chartOfAccountService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = accountId },
                    new { AccountID = accountId, Message = "Account created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the account", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateChartOfAccountDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.AccountID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _chartOfAccountService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Account not found" });

                return Ok(new { Message = "Account updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while updating the account", Details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _chartOfAccountService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Account not found" });

                return Ok(new { Message = "Account deleted successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while deleting the account", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var account = await _chartOfAccountService.GetByIdAsync(id);

                if (account == null)
                    return NotFound(new { Error = "Account not found" });

                return Ok(account);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the account", Details = ex.Message });
            }
        }


        [HttpGet("by-code/{accountCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCode(string accountCode)
        {
            try
            {
                var account = await _chartOfAccountService.GetByCodeAsync(accountCode);

                if (account == null)
                    return NotFound(new { Error = "Account not found" });

                return Ok(account);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the account", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAccountsDTO dto)
        {
            try
            {
                var accounts = await _chartOfAccountService.GetAllAsync(dto);
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving accounts", Details = ex.Message });
            }
        }

     
        [HttpGet("tree")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTree([FromQuery] int? accountTypeId = null)
        {
            try
            {
                var accounts = await _chartOfAccountService.GetTreeAsync(accountTypeId);
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving account tree", Details = ex.Message });
            }
        }

 
        [HttpGet("leaf-accounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLeafAccounts([FromQuery] int? accountTypeId = null)
        {
            try
            {
                var accounts = await _chartOfAccountService.GetLeafAccountsAsync(accountTypeId);
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving leaf accounts", Details = ex.Message });
            }
        }


        [HttpPatch("{id}/balance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBalance(int id, [FromBody] UpdateAccountBalanceDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.AccountID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _chartOfAccountService.UpdateBalanceAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Account not found" });

                return Ok(new { Message = "Account balance updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while updating account balance", Details = ex.Message });
            }
        }


        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Search([FromQuery] string searchTerm)
        {
            try
            {
                var accounts = await _chartOfAccountService.SearchAsync(searchTerm);
                return Ok(accounts);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while searching accounts", Details = ex.Message });
            }
        }
    }
}