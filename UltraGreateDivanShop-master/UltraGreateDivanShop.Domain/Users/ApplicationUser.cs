using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraGreateDivanShop.Domain.Users
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public required string? FirstName { get; set; }
        [Required]
        public required string? LastName { get; set; } 
    }
}
