namespace BankingAPI.Core.DTOs.Cards.DebitCards
{
    public record UpdateDebitCardDto
    {
        public int Id { get; init; }
        public string CardNumber { get; init; }
        public string CardHolderName { get; init; }
        public DateTime ExpiryDate { get; init; }
        public int Limit { get; init; }
        public short CVV { get; init; }
        public int AccountId { get; init; }
        public int CustomerId { get; init; }
    }
}
