using System.Collections.Generic;

namespace NetCore2Shop.Models
{
    public class Product : BaseModel
    {
        public string name { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public Address ProdutAddress { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public decimal OrginPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Deatils { get; set; }
    }
}