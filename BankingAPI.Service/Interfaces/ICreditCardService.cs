using BankingAPI.Core.DTOs.Cards.CreditCards;

namespace BankingAPI.Service.Interfaces
{
    public interface ICreditCardService
    {
        Task<ListCreditCardDto> GetCreditCardByIdAsync(int id);
        Task<IEnumerable<ListCreditCardDto>> GetCreditCardsAsync();
        Task<int> CreateCreditCardAsync(CreateCreditCardDto creditCard);
        Task<bool> UpdateCreditCardAsync(UpdateCreditCardDto creditCard);
        Task<bool> DeleteCreditCardAsync(int id);
    }
}
