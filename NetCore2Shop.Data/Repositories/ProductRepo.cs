using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class ProductRepo:Repository<Product>,IProductRepo
    {
       public ProductRepo(ShopDbContext dbContext) : base(dbContext) { } 
    }
}