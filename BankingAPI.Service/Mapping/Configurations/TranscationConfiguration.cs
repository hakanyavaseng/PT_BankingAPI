using AutoMapper;
using BankingAPI.Core.DTOs.Transactions;
using System.Transactions;

namespace BankingAPI.Service.Mapping.Configurations
{
    public class TranscationConfiguration : Profile
    {
        public TranscationConfiguration()
        {
            CreateMap<Transaction, ListTranscationDto>();
        }
    }
}
