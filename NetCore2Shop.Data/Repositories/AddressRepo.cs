using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class AddressRepo:Repository<Address>,IAddressRepo
    {
        public AddressRepo(ShopDbContext dbContext) : base(dbContext) { }
    }
}