using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new();
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
