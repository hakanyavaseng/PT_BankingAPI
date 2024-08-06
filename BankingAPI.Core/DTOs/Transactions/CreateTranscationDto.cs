namespace BankingAPI.Core.DTOs.Transactions
{
    public record CreateTranscationDto
    {
        public int? DebitCardId { get; set; }
        public int? CreditCardId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
