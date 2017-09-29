namespace NetCore2Shop.Models
{
    public class Address : BaseModel
    {
        public City City { get; set; }
        public Province Province { get; set; }
        public string OtherInfo { get; set; }
        public string Postcode { get; set; }
    }
}