using System;

namespace NetCore2Shop.Models
{
    public class AppUser :BaseModel
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public decimal AccountBalance { get; set; }
    }
}