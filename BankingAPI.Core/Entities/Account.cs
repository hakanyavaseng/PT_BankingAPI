using BankingAPI.Core.Entities.Common;

namespace BankingAPI.Core.Entities
{
    public class Account : BaseEntity
    {
        public string AccountName { get; init; }
        public string AccountNumber { get; init; }
        public string IBAN { get; init; }
        public long Balance { get; set; }
        public DateTime AccountCreationDate { get; init; }
        public int CustomerId { get; init; }
        public Customer Customer { get; init; }
    }
}
