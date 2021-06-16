using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Domain.DomainModels
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [RegularExpression(@"^(\+44\s?\d{10}|0044\s?\d{10}|0\s?\d{10})?$")]
        public string PhoneNumber { get; set; }

        [Required]
        public string ReturnUrl { get; set; }

        public bool RememberLogin { get; set; }
    }
}
