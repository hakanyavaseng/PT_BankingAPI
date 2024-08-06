using BankingAPI.Core.DTOs.Accounts;
using BankingAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AccountsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDto dto)
        {
            int result = await _serviceManager.AccountService.CreateAccountAsync(dto);
            if(result > 0)
                return Ok(result);
            return BadRequest();
        }
    }
}
