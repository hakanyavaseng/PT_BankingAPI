using BankingAPI.Core.Entities.Common;

namespace BankingAPI.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public string CardType { get; set; }
        public string TransactionType { get; set; }
        public int? DebitCardId { get; set; }
        public int? CreditCardId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public DebitCard DebitCard { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
