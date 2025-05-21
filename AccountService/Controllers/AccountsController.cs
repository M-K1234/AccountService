using DTOs = AccountService.DTOs; // Alias the namespace for DTOs
using Services = AccountService.Services; // Alias the namespace for Services
using Microsoft.AspNetCore.Mvc;
using AccountService.Services;
using AccountService.DTOs; // Add this using directive to resolve the type mismatch

namespace AccountService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(DTOs.CreateAccountDto dto) // Use the aliased namespace
        {
            var serviceDto = new DTOs.CreateAccountDto
            {
                AccountType = dto.AccountType,
                CustomerId = dto.CustomerId
            };

            var result = await _service.CreateAccountAsync(serviceDto);
            return CreatedAtAction(nameof(GetAccount), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(String id)
        {
            var result = await _service.GetAccountAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var results = await _service.GetAllAccountsAsync();
            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(String id, DTOs.UpdateAccountDto dto) 
        {
            var serviceDto = new DTOs.UpdateAccountDto
            {
                AccountType = dto.AccountType,
                Balance = dto.Balance
            };

            var updated = await _service.UpdateAccountAsync(id, serviceDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(String id)
        {
            var deleted = await _service.DeleteAccountAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
