using BankingAPI.Core.DTOs.Customers;
using BankingAPI.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public CustomersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _serviceManager.CustomerService.GetCustomersAsync();
            if(customers is not null)
                return Ok(customers);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _serviceManager.CustomerService.GetCustomerByIdAsync(id);
            if(customer is not null)
                return Ok(customer);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto dto)
        {
            int result = await _serviceManager.CustomerService.CreateCustomerAsync(dto);
            if(result > 0)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerDto dto)
        {
            bool result = await _serviceManager.CustomerService.UpdateCustomerAsync(dto);
            if(result)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _serviceManager.CustomerService.DeleteCustomerAsync(id);
            if(result)
                return Ok(result);
            return BadRequest();
        }


    }
}
