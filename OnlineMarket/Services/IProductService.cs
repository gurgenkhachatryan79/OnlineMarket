using OnlineMarket.Dto;
using OnlineMarket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarket.Services
{
    public interface IProductService
    {
        IAsyncEnumerable<Product> GetProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(ProductDto productdto);
        Task UpdateProduct(ProductDto productdto, int id);
        Task DeleteProduct(int id);

    }
}
