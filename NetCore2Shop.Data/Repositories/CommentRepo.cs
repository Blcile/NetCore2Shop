using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class CommentRepo:Repository<Comment>,ICommentRepo
    {
        public CommentRepo (ShopDbContext dnContext) : base(dnContext) { }
    }
}