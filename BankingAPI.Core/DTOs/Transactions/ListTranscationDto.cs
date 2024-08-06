using BankingAPI.Core.Entities;

namespace BankingAPI.Core.DTOs.Transactions
{
    public record ListTranscationDto
    {
        public int Id { get; set; }
        public string CardType { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int? DebitCardId { get; set; }
        public int? CreditCardId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
