using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2Shop.web.Models
{
    public class RegistViewModel
    {
        [MaxLength(15)]
        public string UserName { get; set; }
        [MaxLength(16)]
        public string Password { get; set; }
        [MaxLength(16)]
        public string Password1 { get; set; }
        public string Code { get; set; }
    }
}
