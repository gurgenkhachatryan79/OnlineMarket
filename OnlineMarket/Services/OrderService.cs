using Microsoft.EntityFrameworkCore;
using OnlineMarket.Dto;
using OnlineMarket.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarket.Services
{
    public class OrderService : IOrderService
    {
        private OnlineMarketDbContext _context;
        public OrderService(OnlineMarketDbContext context)
        {
            _context = context;
        }
        public async Task AddOrder(OrderDto orderDto)
        {
            Order order = new Order()
            {
                Id = orderDto.Id,
                CustomerId = orderDto.CustomerId,
                Customer = orderDto.Customer,
                Products = orderDto.Products
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteOrder(int id)
        {
            ValidationNumber.ProductExists(id);
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();

        }

        public Task<Order> GetOrderId(int id)
        {
            ValidationNumber.ProductExists(id);
            var order = _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                throw new KeyNotFoundException();
            }
            return order;
        }

        public async IAsyncEnumerable<Order> GetOrders()
        {
            var orders = _context.Orders;
            if (orders == null)
            {
                throw new NullReferenceException();
            }
            await foreach (var item in orders)
            {
                yield return item;
            }
        }

        public async Task UpdateOrder(OrderDto orderDto, int id)
        {
            Order ord = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (ord == null)
            {
                throw new NullReferenceException();
            }
            ord.Id = orderDto.Id;
            ord.Customer = orderDto.Customer;
            ord.CustomerId = orderDto.CustomerId;
            ord.Products = orderDto.Products;
            await _context.SaveChangesAsync();

        }
    }
}
