using Microsoft.EntityFrameworkCore;

namespace OnlineMarket.Models
{
    public class OnlineMarketDbContext : DbContext
    {

        public OnlineMarketDbContext(DbContextOptions<OnlineMarketDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
