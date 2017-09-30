using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class ProvinceRepo:Repository<Province>,IProvinceRepo
    {
        public  ProvinceRepo(ShopDbContext dbContext) : base(dbContext) { }
    }
}