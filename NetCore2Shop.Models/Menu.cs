using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore2Shop.Models
{
    public class Menu:BaseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Iconic { get; set; }
        public int Sort { get; set; }
        public string Reamark { get; set; }
        public string Status { get; set; }
        public string IsLeaf { get; set; }
        public int MenuLevel { get; set; }

    }
}
