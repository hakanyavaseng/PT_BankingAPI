namespace BankingAPI.Core.DTOs.Cards.CreditCards
{
    public record CreateCreditCardDto
    {
        public int CustomerId { get; init; }
    }
}
