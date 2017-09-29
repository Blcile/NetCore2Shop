using System.Collections.Generic;

namespace NetCore2Shop.Models
{
    public class Order : BaseModel
    {
        public int ProductCount { get; set; }
        public IEnumerable<OrderDetail> Details { get; set; }
        public decimal TotalPrice { get; set; }
    }
}