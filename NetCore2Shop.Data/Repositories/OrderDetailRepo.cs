using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class OrderDetailRepo:Repository<OrderDetail>,IOrderDetailRepo
    {
        public OrderDetailRepo(ShopDbContext dbContext):base(dbContext){ }
    }
}