namespace NetCore2Shop.Models
{
    public class Image : BaseModel
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Url { get; set; }
    }
}