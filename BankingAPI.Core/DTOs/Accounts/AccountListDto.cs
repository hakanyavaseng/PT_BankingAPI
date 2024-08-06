namespace BankingAPI.Core.DTOs.Accounts
{
    public record AccountListDto
    {
        public int Id { get; init; }
        public string AccountName { get; init; }
        public string AccountNumber { get; init; }
        public string IBAN { get; init; }
        public long Balance { get; set; }
        public int CustomerId { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
