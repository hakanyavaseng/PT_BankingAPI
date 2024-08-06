namespace BankingAPI.Core.DTOs.Accounts
{
    public record CreateAccountDto
    {
        public string AccountName { get; init; }
        public long Balance { get; set; }
        public int CustomerId { get; init; }
    }
}
