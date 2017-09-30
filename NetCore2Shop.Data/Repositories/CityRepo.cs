using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class CityRepo : Repository<City>, ICityRepo
    {
        public CityRepo(ShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}