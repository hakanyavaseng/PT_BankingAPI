using BankingAPI.Core.Entities.Common;

namespace BankingAPI.Core.Entities
{
    public class CreditCard : BaseEntity
    {
        public string CardNumber { get; set; }
        public short ExpiryMonth { get; set; }
        public short ExpiryYear { get; set; }
        public DateTime ExpiryDate => new(ExpiryYear, ExpiryMonth, 1);
        public decimal Limit { get; set; }
        public short CVV { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
