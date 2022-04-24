using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Dto
{
    public class CustomerDto
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Address { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

    }
}
