using System.Collections.Generic;

namespace NetCore2Shop.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<Category> ChildrenCategories { get; set; }
    }
}