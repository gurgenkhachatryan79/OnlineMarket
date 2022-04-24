using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Address { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNaumber { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new();


    }
}
