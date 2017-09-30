using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class BrandRepo:Repository<Brand>,IBrandRepo
    {
        public BrandRepo(ShopDbContext dbContext) : base(dbContext) { }
}
}