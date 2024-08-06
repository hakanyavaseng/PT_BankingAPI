using BankingAPI.Core.Entities.Common;

namespace BankingAPI.Core.Entities
{
    public class CreditCard : BaseEntity
    {
        public string CardNumber { get; init; }
        public short ExpiryMonth { get; init; }
        public short ExpiryYear { get; init; }
        public DateTime ExpiryDate => new(ExpiryYear, ExpiryMonth, 1);
        public decimal Limit { get; init; }
        public short CVV { get; init; }
        public int CustomerId { get; init; }
        public Customer Customer { get; init; }
    }
}
