using BankingAPI.Core.Entities;
using BankingAPI.Core.Entities.Common;

public class DebitCard : BaseEntity
{
    public string CardNumber { get; init; }
    public string CardHolderName { get; init; }
    public DateTime ExpiryDate { get; init; }
    public decimal Limit { get; init; }
    public short CVV { get; init; }
    public int AccountId { get; init; }
    public int CustomerId { get; init; }
    public Customer Customer { get; init; }
    public Account Account { get; init; }
}


