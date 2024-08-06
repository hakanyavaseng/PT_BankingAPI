using AutoMapper;
using BankingAPI.Core.DTOs.Cards.CreditCards;
using BankingAPI.Core.DTOs.Cards.DebitCards;
using BankingAPI.Core.Entities;

namespace BankingAPI.Service.Mapping.Configurations
{
    public class DebitCardConfiguration : Profile
    {
        public DebitCardConfiguration()
        {
            CreateMap<CreateDebitCardDto, DebitCard>();
            CreateMap<UpdateDebitCardDto, DebitCard>();
            CreateMap<DebitCard, ListDebitCardDto>();
                //.ForMember(p => p.Customer, options =>
                //{
                //    options.MapFrom(src => src.Customer);
                //});
                //.ForMember(p => p.Account, options =>
                //{
                //    options.MapFrom(src => src.Account);
                //});
        }
    }
}
