using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class AppUserRepo:Repository<AppUser>,IAppUserRepo
    {
        public AppUserRepo(ShopDbContext dbContext) : base(dbContext){}
    }
}