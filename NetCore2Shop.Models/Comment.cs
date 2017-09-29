namespace NetCore2Shop.Models
{
    public class Comment : BaseModel
    {
        public AppUser User { get; set; }
        public string CommentText { get; set; }
    }
}