using OnlineMarket.Dto;
using OnlineMarket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarket.Services
{
    public interface ICustomerService
    {
        IAsyncEnumerable<Customer> GetCustomers();
        Task<Customer> GetCustomerId(int id);
        Task AddCustomer(CustomerDto customerDto);
        Task UpdateCustomer(CustomerDto customerDto, int id);
        Task DeleteCustomer(int id);

    }
}
