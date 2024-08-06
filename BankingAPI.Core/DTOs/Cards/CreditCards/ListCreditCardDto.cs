using BankingAPI.Core.Entities;

namespace BankingAPI.Core.DTOs.Cards.CreditCards
{
    public record ListCreditCardDto
    {
        public int Id { get; init; }
        public string CardNumber { get; init; }
        public short ExpiryMonth { get; init; }
        public short ExpiryYear { get; init; }
        public DateTime ExpiryDate => new(ExpiryYear, ExpiryMonth, 1);
        public int Limit { get; init; }
        public short CVV { get; init; }
        public Customer Customer { get; init; }
    }
}
