using OnlineMarket.Dto;
using OnlineMarket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarket.Services
{
    public interface IOrderService
    {
        IAsyncEnumerable<Order> GetOrders();
        Task<Order> GetOrderId(int id);
        Task AddOrder(OrderDto orderDto);
        Task UpdateOrder(OrderDto orderDto, int id);
        Task DeleteOrder(int id);
    }
}
