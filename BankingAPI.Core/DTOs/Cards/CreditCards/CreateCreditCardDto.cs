namespace BankingAPI.Core.DTOs.Cards.CreditCards
{
    public record CreateCreditCardDto
    {
        public string CardNumber { get; init; }
        public string CardHolderName { get; init; }
        public short ExpiryMonth { get; init; }
        public short ExpiryYear { get; init; }
        public int Limit { get; init; }
        public short CVV { get; init; }
        public int CustomerId { get; init; }
    }
}
