using BankingAPI.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAPI.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string TCNumber { get; init; }
        public string BirthPlace { get; init; }
        public DateTime BirthDate { get; init; }
        public decimal RiskLimit { get; init; } 

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<DebitCard> DebitCards { get; set; }

        public Customer(
            string firstName,
            string lastName,
            string tcNumber, 
            string birthPlace,
            DateTime birthDate,
            decimal riskLimit) 
        {
            FirstName = firstName;
            LastName = lastName;
            TCNumber = tcNumber;
            BirthPlace = birthPlace;
            BirthDate = birthDate;
            RiskLimit = riskLimit;
        }

        public Customer()
        {
        }
    }
}