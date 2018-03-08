using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2Shop.web.Models
{
    public class LoginViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public bool RemberMe { get; set; }
    }
}
