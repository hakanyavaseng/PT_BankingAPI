using BankingAPI.Core.Entities;

namespace BankingAPI.Core.DTOs.Cards.DebitCards
{
    public class ListDebitCardDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Limit { get; set; }
        public short CVV { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
    }
}
