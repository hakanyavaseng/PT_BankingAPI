using BankingAPI.Core.DTOs.Cards.CreditCards;
using BankingAPI.Core.DTOs.Cards.DebitCards;
using BankingAPI.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public CardsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet("credit")]
        public async Task<IActionResult> GetCreditCards()
        {
            var creditCards = await serviceManager.CreditCardService.GetCreditCardsAsync();
            return Ok(creditCards);
        }

        [HttpGet("credit/{id}")]
        public async Task<IActionResult> GetCreditCardById(int id)
        {
            var creditCard = await serviceManager.CreditCardService.GetCreditCardByIdAsync(id);
            return Ok(creditCard);
        }

        [HttpPost("credit")]
        public async Task<IActionResult> CreateCreditCard([FromBody] CreateCreditCardDto creditCard)
        {
            var newCreditCardId = await serviceManager.CreditCardService.CreateCreditCardAsync(creditCard);
            return Ok(newCreditCardId);
        }

        [HttpPut("credit")]
        public async Task<IActionResult> UpdateCreditCard([FromBody] UpdateCreditCardDto creditCard)
        {
            var isUpdated = await serviceManager.CreditCardService.UpdateCreditCardAsync(creditCard);
            return Ok(isUpdated);
        }

        [HttpDelete("credit/{id}")]
        public async Task<IActionResult> DeleteCreditCard(int id)
        {
            var isDeleted = await serviceManager.CreditCardService.DeleteCreditCardAsync(id);
            return Ok(isDeleted);
        }

        // Debit card endpoints
        [HttpGet("debit")]
        public async Task<IActionResult> GetDebitCards()
        {
            var debitCards = await serviceManager.DebitCardService.GetDebitCardsAsync();
            return Ok(debitCards);
        }

        [HttpGet("debit/{id}")]
        public async Task<IActionResult> GetDebitCardById(int id)
        {
            var debitCard = await serviceManager.DebitCardService.GetDebitCardByIdAsync(id);
            return Ok(debitCard);
        }

        [HttpPost("debit")]
        public async Task<IActionResult> CreateDebitCard([FromBody] CreateDebitCardDto debitCard)
        {
            var newDebitCardId = await serviceManager.DebitCardService.CreateDebitCardAsync(debitCard);
            return Ok(newDebitCardId);
        }

        [HttpPut("debit")]
        public async Task<IActionResult> UpdateDebitCard([FromBody] UpdateDebitCardDto debitCard)
        {
            var isUpdated = await serviceManager.DebitCardService.UpdateDebitCardAsync(debitCard);
            return Ok(isUpdated);
        }

        [HttpDelete("debit/{id}")]
        public async Task<IActionResult> DeleteDebitCard(int id)
        {
            var isDeleted = await serviceManager.DebitCardService.DeleteDebitCardAsync(id);
            return Ok(isDeleted);
        }
    }
}
