using BookShop.Persistence.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T?>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<ResultDTO> AddAsync(T entity);
        Task<ResultDTO> DeleteAsync(int id);
        Task<ResultDTO> UpdateAsync(T entity);
        Task<IEnumerable<T?>> GetByConditionAsync(Expression<Func<T, bool>> condition);
    }
}
