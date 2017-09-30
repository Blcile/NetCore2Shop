using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class ImageRepo:Repository<Image>,IImageRepo
    {
        public ImageRepo(ShopDbContext dbContext) : base(dbContext) { }
    }
}