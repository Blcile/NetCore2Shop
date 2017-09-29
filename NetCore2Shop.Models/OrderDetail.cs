namespace NetCore2Shop.Models
{
    public class OrderDetail : BaseModel
    {
        public Product Product { get; set; }
        public int ItemCount { get; set; }
        public decimal ByPrice { get; set; }
        public decimal ByDiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}