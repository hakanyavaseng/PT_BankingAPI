using AutoMapper;
using BankingAPI.Core.DTOs.Customers;
using BankingAPI.Core.Entities;

namespace BankingAPI.Service.Mapping.Configurations
{
    public class CustomerConfiguration : Profile
    {
        public CustomerConfiguration()
        {
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<Customer, ListCustomerDto>();

        }
    }
}
