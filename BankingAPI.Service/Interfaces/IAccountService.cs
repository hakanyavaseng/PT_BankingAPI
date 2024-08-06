using BankingAPI.Core.DTOs.Accounts;

namespace BankingAPI.Service.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountListDto>> GetAccountsAsync();
        Task<AccountListDto> GetAccountByIdAsync(int id);
        Task<int> CreateAccountAsync(CreateAccountDto account);
        Task<bool> UpdateAccountAsync(UpdateAccountDto account);
        Task<bool> DeleteAccountAsync(int id);
    }
}
