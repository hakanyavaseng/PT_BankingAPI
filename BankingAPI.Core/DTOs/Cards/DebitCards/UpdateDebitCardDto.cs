namespace BankingAPI.Core.DTOs.Cards.DebitCards
{
    public record UpdateDebitCardDto
    {
        public int Id { get; init; }
        public string CardHolderName { get; init; }
        public int Limit { get; init; }
        public int AccountId { get; init; }
        public int CustomerId { get; init; }
    }
}
