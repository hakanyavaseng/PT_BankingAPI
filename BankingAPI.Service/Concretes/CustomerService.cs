using AutoMapper;
using BankingAPI.Core.DTOs.Customers;
using BankingAPI.Core.Entities;
using BankingAPI.Data.Repositories.Interfaces;
using BankingAPI.Service.Interfaces;
using System.Security.Cryptography;

namespace BankingAPI.Service.Concretes
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CustomerService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<int> CreateCustomerAsync(CreateCustomerDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));


            Customer customerToAdd = _mapper.Map<CreateCustomerDto, Customer>(dto);

            //Check unique TCNumber
            Customer? customer = await _repositoryManager.GetReadRepository<Customer>().GetAsync(c => c.TCNumber.Equals(dto.TCNumber));
            if (customer is not null)
                throw new Exception("Customer already exists with same TC Identity Number.");

            await _repositoryManager.GetWriteRepository<Customer>().AddAsync(customerToAdd);
            return await _repositoryManager.SaveAsync();
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid Id.");

            var customer = await _repositoryManager.GetReadRepository<Customer>().GetAsync(c => c.Id.Equals(id));
            if (customer is null)
                throw new Exception("Customer not found.");

            await _repositoryManager.GetWriteRepository<Customer>().DeleteAsync(customer);
            int result = await _repositoryManager.SaveAsync();
            return result > 0;
        }

        public async Task<ListCustomerDto> GetCustomerByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid Id.");

            Customer? customer = await _repositoryManager.GetReadRepository<Customer>().GetAsync(c => c.Id.Equals(id));
            if (customer is null)
                throw new Exception("Customer not found.");

            return _mapper.Map<Customer, ListCustomerDto>(customer);
        }

        public async Task<IEnumerable<ListCustomerDto>> GetCustomersAsync()
        {
            IList<Customer> customers = await _repositoryManager.GetReadRepository<Customer>().GetAllAsync();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<ListCustomerDto>>(customers);
        }

        public async Task<bool> UpdateCustomerAsync(UpdateCustomerDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));
            if (dto.Id <= 0)
                throw new Exception("Invalid Id.");

            var customerToUpdate = await _repositoryManager
                                    .GetReadRepository<Customer>()
                                    .GetAsync(c => c.Id.Equals(dto.Id));
            if (customerToUpdate is null)
                throw new Exception("Customer not found with given Id");

            _mapper.Map(dto, customerToUpdate);

            await _repositoryManager.GetWriteRepository<Customer>().UpdateAsync(customerToUpdate);
            int result = await _repositoryManager.SaveAsync();
            return result > 0;
        }
    }
}
