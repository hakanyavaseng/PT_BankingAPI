namespace BankingAPI.Core.DTOs.Customers
{
    public record ListCustomerDto
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string TCNumber { get; init; }
        public string BirthPlace { get; init; }
        public DateTime BirthDate { get; init; }
        public decimal RiskLimit { get; init; }
    }
}
