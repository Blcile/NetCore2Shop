using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected ShopDbContext _dbContext;

        public Repository(ShopDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Guid> AddAsync(T model)
        {
            if (null == model)
            {
                return Guid.Empty;
            }
            _dbContext.Set<T>().Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var T = _dbContext.Set<T>().SingleOrDefault(c => c.Id == id);
            if (null != T)
            {
                _dbContext.Set<T>().Remove(T);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _dbContext.Set<T>().Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<Page<T>> GetPage(Expression<Func<T, bool>> Filter, int index, int size)
        {
            var datas = _dbContext.Set<T>().Where(Filter).AsQueryable();
            int count = await datas.CountAsync();
            var data = await datas.Take((index - 1) * size).Skip(size).ToListAsync();
            return new Page<T>(data, index, count, size);
        }

        public async Task UpdateAsync(T model)
        {
            if(null==model)
                return;
            _dbContext.Set<T>().Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}