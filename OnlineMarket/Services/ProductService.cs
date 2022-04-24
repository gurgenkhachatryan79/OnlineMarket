using Microsoft.EntityFrameworkCore;
using OnlineMarket.Dto;
using OnlineMarket.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarket.Services
{
    public class ProductService : IProductService
    {
        private OnlineMarketDbContext _context;
        public ProductService(OnlineMarketDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(ProductDto productdto)
        {
            Product product = new Product()
            {
                Id = productdto.Id,
                Name = productdto.Name,
                Price = productdto.Price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            // return product;
        }

        public async Task DeleteProduct(int id)
        {
            ValidationNumber.ProductExists(id);
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            ValidationNumber.ProductExists(id);
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return product;

        }


        public async IAsyncEnumerable<Product> GetProducts()
        {
            var products = _context?.Products;
            if (products is null)
            {
                throw new NullReferenceException();
            }
            await foreach (Product item in products)
            {
                yield return item;
            }
        }

        public async Task UpdateProduct(ProductDto productdto, int id)
        {
            ValidationNumber.ProductExists(id);
            Product pr = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (pr == null)
            {
                throw new KeyNotFoundException();
            }
            pr.Name = productdto.Name;
            pr.Price = productdto.Price;
            await _context.SaveChangesAsync();

        }

    }
}
