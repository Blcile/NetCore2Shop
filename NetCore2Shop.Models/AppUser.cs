using Microsoft.AspNetCore.Identity;
using System;

namespace NetCore2Shop.Models
{
    public class AppUser :IdentityUser
    {
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDelete { get; set; }
    }
}