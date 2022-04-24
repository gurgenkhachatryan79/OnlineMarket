using Microsoft.EntityFrameworkCore;
using OnlineMarket.Dto;
using OnlineMarket.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarket.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly OnlineMarketDbContext _context;
        public CustomerService(OnlineMarketDbContext context)
        {
            _context = context;
        }
        public async Task AddCustomer(CustomerDto customerDto)
        {
            Customer customer = new Customer()
            {
                Id = customerDto.Id,
                Address = customerDto.Address,
                Email = customerDto.Email,
                Name = customerDto.Name,
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteCustomer(int id)
        {
            ValidationNumber.ProductExists(id);
            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerId(int id)
        {
            ValidationNumber.ProductExists(id);
            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new KeyNotFoundException();
            }
            return customer;
        }

        public async IAsyncEnumerable<Customer> GetCustomers()
        {
            var customers = _context.Customers;
            if (customers == null)
            {
                throw new NullReferenceException();
            }
            foreach (var item in customers)
            {
                yield return item;
            }
        }

        public async Task UpdateCustomer(CustomerDto customerDto, int id)
        {
            ValidationNumber.ProductExists(id);
            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new NullReferenceException();
            }
            customer.Id = customerDto.Id;
            customer.Name = customerDto.Name;
            customer.Address = customerDto.Address;
            customer.Email = customerDto.Email;
            await _context.SaveChangesAsync();

        }
    }
}

