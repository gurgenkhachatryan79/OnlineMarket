using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public List<Order> Orders { get; set; }

    }
}
