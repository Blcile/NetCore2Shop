using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data.Interface
{
    public interface IRepository<T> where T:BaseModel
    {
        Task<Guid> AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(Guid id);
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> GetCountAsync();
        Task<Page<T>> GetPage(Expression<Func<T, bool>> Filter, int index, int size);
    }
}