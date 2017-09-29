using System.Collections.Generic;

namespace NetCore2Shop.Models
{
    public class Brand : BaseModel
    {
        public string Name { get; set; }
        public Image BrandImage { get; set; }
        public IEnumerable<Brand> ChildrenBrands { get; set; }
    }
}