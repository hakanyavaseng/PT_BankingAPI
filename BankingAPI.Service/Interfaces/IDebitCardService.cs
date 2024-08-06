using BankingAPI.Core.DTOs.Cards.DebitCards;

namespace BankingAPI.Service.Interfaces
{
    public interface IDebitCardService
    {
        Task<IEnumerable<ListDebitCardDto>> GetDebitCardsAsync();
        Task<ListDebitCardDto> GetDebitCardByIdAsync(int id);
        Task<int> CreateDebitCardAsync(CreateDebitCardDto debitCard);
        Task<bool> UpdateDebitCardAsync(UpdateDebitCardDto debitCard);
        Task<bool> DeleteDebitCardAsync(int id);
    }
}
