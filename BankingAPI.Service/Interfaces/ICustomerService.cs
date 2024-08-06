using BankingAPI.Core.DTOs.Customers;

namespace BankingAPI.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<ListCustomerDto>> GetCustomersAsync();
        Task<ListCustomerDto> GetCustomerByIdAsync(int id);
        Task<int> CreateCustomerAsync(CreateCustomerDto customer);
        Task<bool> UpdateCustomerAsync(UpdateCustomerDto customer);
        Task<bool> DeleteCustomerAsync(int id);
    }

}
