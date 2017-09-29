using System;
using Microsoft.AspNetCore.Identity;

namespace NetCore2Shop.Models
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {
            Id = Guid.NewGuid().ToString("D");
        }
        public decimal AccountBalance { get; set; }
    }
}