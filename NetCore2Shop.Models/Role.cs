using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore2Shop.Models
{
    public class Role:BaseModel
    {
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
    }
}
