using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Dto
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
    }
}
