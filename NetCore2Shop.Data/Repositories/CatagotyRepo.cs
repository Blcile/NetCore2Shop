using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class CatagotyRepo:Repository<Category>,ICatagoryRepo
    {
        public CatagotyRepo(ShopDbContext dbContext) : base(dbContext) { }
    }
}