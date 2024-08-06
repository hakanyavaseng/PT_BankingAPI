namespace BankingAPI.Core.Models
{
    public record ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
