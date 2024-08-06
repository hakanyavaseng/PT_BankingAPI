namespace BankingAPI.Core.DTOs.Cards.DebitCards
{
    public record CreateDebitCardDto
    {
        public int AccountId { get; init; }
        public int CustomerId { get; init; }   
    }
}
