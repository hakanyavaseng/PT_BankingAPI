namespace BankingAPI.Core.DTOs.Accounts
{
    public record UpdateAccountDto
    {
        public int Id { get; init; }
        public string AccountName { get; init; }
        public long Balance { get; set; }
        public int CustomerId { get; init; }
        public bool IsActive { get; init; }
    }
}
