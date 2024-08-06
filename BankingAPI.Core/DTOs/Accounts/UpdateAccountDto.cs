namespace BankingAPI.Core.DTOs.Accounts
{
    public record UpdateAccountDto
    {
        public int Id { get; init; }
        public string AccountName { get; init; }
        public string AccountNumber { get; init; }
        public string IBAN { get; init; }
        public long Balance { get; set; }
        public int CustomerId { get; init; }
    }
}
