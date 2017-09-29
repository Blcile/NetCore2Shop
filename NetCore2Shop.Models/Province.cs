using System.Collections.Generic;

namespace NetCore2Shop.Models
{
    public class Province : BaseModel
    {
        public string Name { get; set; }
        public IList<City> Cities { get; set; }
    }
}