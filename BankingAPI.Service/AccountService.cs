using BankingAPI.Core.DTOs.Accounts;
using BankingAPI.Data.Repositories.Interfaces;
using BankingAPI.Service.Interfaces;

namespace BankingAPI.Service
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryManager repositoryManager;
        public AccountService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public Task<int> CreateAccountAsync(CreateAccountDto account)
        {
            
            
        }

        public Task<bool> DeleteAccountAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountListDto> GetAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountListDto>> GetAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAccountAsync(UpdateAccountDto account)
        {
            throw new NotImplementedException();
        }
    }
}
