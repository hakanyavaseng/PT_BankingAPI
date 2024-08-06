namespace BankingAPI.Core.DTOs.Customers
{
    public record CreateCustomerDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string TCNumber { get; init; }
        public string BirthPlace { get; init; }
        public DateTime BirthDate { get; set; }
    }
}
