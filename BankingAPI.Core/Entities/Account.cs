using BankingAPI.Core.Entities.Common;

namespace BankingAPI.Core.Entities
{
    public class Account : BaseEntity
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public long Balance { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
