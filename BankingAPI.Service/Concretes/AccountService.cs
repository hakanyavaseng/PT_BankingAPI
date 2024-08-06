using AutoMapper;
using BankingAPI.Core.DTOs.Accounts;
using BankingAPI.Core.Entities;
using BankingAPI.Data.Repositories.Interfaces;
using BankingAPI.Service.Helpers;
using BankingAPI.Service.Interfaces;
using BankingAPI.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using SinKien.IBAN4Net;

namespace BankingAPI.Service.Concretes
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
            if (customer is null)
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

        public async Task<bool> DeleteAccountAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));
            var account = await repositoryManager.GetReadRepository<Account>().GetAsync(a => a.Id.Equals(id));

            if (account is null)
                throw new Exception("Girilen ID'ye ait hesap kaydı bulunamadı.");

            await repositoryManager.GetWriteRepository<Account>().DeleteAsync(account);
            int result = await repositoryManager.SaveAsync();
            return result > 0;
        }

        public async Task<AccountListDto> GetAccountByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception(nameof(id));
            Account account = await repositoryManager.GetReadRepository<Account>().GetAsync(a => a.Id.Equals(id), p => p.Include(c => c.Customer));
            return mapper.Map<Account, AccountListDto>(account);
        }

        public async Task<IEnumerable<AccountListDto>> GetAccountsAsync()
        {
            IList<Account> accounts = await repositoryManager.GetReadRepository<Account>().GetAllAsync(include: p => p.Include(c => c.Customer));
            return mapper.Map<IEnumerable<Account>, IEnumerable<AccountListDto>>(accounts);
        }

        public async Task<bool> UpdateAccountAsync(UpdateAccountDto dto)
        {
            Account account = await repositoryManager.GetReadRepository<Account>().GetAsync(a => a.Id.Equals(dto.Id));

            if (account is null)
                throw new Exception("Girilen ID'ye ait hesap kaydı bulunamadı.");

            mapper.Map(dto, account);

            await repositoryManager.GetWriteRepository<Account>().UpdateAsync(account);
            int result = await repositoryManager.SaveAsync();
            return result > 0;
        }
    }
}
