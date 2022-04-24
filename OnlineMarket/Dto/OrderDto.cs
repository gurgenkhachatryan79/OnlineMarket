using OnlineMarket.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Dto
{
    public class OrderDto
    {
        [Key]
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new();
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
