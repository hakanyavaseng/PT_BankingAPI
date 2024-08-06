using AutoMapper;
using BankingAPI.Core.DTOs.Cards.CreditCards;
using BankingAPI.Core.Entities;

namespace BankingAPI.Service.Mapping.Configurations
{
    public class CreditCardConfiguration : Profile
    {
        public CreditCardConfiguration()
        {
            CreateMap<CreateCreditCardDto, CreditCard>();
            CreateMap<UpdateCreditCardDto, CreditCard>();
            CreateMap<CreditCard, ListCreditCardDto>()
                .ForMember(p => p.Customer, options =>
                {
                    options.MapFrom(src => src.Customer);
                });;
        }

    }
}
