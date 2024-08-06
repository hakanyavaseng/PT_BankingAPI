using BankingAPI.Core.DTOs.Transactions;

namespace BankingAPI.Service.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<ListTranscationDto>> GetTransactionsAsync();
        Task<ListTranscationDto> GetTransactionByIdAsync(int id);
        Task<int> CreateTransactionAsync(CreateTranscationDto transaction);
        Task<bool> UpdateTransactionAsync(UpdateTransactionDto transaction);
        Task<bool> DeleteTransactionAsync(int id);
    }
}
