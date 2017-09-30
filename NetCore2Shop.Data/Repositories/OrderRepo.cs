using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class OrderRepo:Repository<Order>,IOrderRepo
    {
        public OrderRepo(ShopDbContext dbContext) : base(dbContext) { }
    }
}