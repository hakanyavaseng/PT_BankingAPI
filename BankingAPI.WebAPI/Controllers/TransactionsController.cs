using BankingAPI.Core.DTOs.Transactions;
using BankingAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public TransactionsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactionAsync([FromBody] CreateTranscationDto transaction)
        {
            int result = await serviceManager.TransactionService.CreateTransactionAsync(transaction);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionsAsync()
        {
            var transactions = await serviceManager.TransactionService.GetTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionAsync(int id)
        {
            var transaction = await serviceManager.TransactionService.GetTransactionByIdAsync(id);
            return Ok(transaction);
        }
    }
}
