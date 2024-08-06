using BankingAPI.Core.DTOs.Accounts;
using BankingAPI.Core.Entities;
using BankingAPI.Data.Repositories.Interfaces;
using BankingAPI.Service.Helpers;
using BankingAPI.Service.Interfaces;
using BankingAPI.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using SinKien.IBAN4Net;

namespace BankingAPI.Service
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        public AccountService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<int> CreateAccountAsync(CreateAccountDto accountDto)
        {
            if (accountDto is null) 
                throw new ArgumentNullException(nameof(accountDto)); 

            //Customer check
            Customer? customer = await repositoryManager.GetReadRepository<Customer>().GetAsync(c => c.Id.Equals(accountDto.CustomerId));
            if(customer is null)
                throw new Exception("Girilen ID'ye ait kullanıcı kaydı bulunamadı.");

            //Mapping
            Account accountToAdd = mapper.Map<CreateAccountDto, Account>(accountDto);

            //Account Number
            var resultFromSequence = await repositoryManager.DbContext.Database.SqlQueryRaw<int>($"select nextval('accountnumbersequence') as \"Value\"").FirstAsync();
            accountToAdd.AccountNumber = resultFromSequence.ToString();

            //IBAN
            string IBAN = IBANGenerator.GenerateIban("0800", "23", accountToAdd.AccountNumber);

            accountToAdd.IBAN = IBAN.ToString();

            // Add and Save
            await repositoryManager.GetWriteRepository<Account>().AddAsync(accountToAdd);
            return await repositoryManager.SaveAsync();
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
