using AutoMapper;
using BankingAPI.Core.DTOs.Accounts;
using BankingAPI.Core.Entities;

namespace BankingAPI.Service.Mapping.Configurations
{
    public class AccountConfigurations : Profile
    {
        public AccountConfigurations()
        {
            CreateMap<CreateAccountDto, Account>();
            CreateMap<Account, AccountListDto>()
                .ForMember(p => p.Customer, options =>
                {
                    options.MapFrom(src => src.Customer);
                });
        }
    }
}
