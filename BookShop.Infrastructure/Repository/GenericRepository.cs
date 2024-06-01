using BookShop.Persistence.DTOs;
using BookShop.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _dbSet = applicationDbContext.Set<T>();
        }
        public async Task<ResultDTO> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _applicationDbContext.SaveChangesAsync();
                return new ResultDTO { Succeeded = true, Message = "Added successfully." };
            }
            catch(Exception ex)
            {
                return new ResultDTO { Succeeded = false, Message = $"Error adding entity: {ex.Message}" };
            }
        }

        public async Task<ResultDTO> DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if(entity == null)
                {
                    return new ResultDTO { Succeeded = false, Message = "Not found." };
                }
                _dbSet.Remove(entity);
                await _applicationDbContext.SaveChangesAsync();
                return new ResultDTO { Succeeded = true, Message = "Removed successfully." };
            }
            catch(Exception ex)
            {
                return new ResultDTO { Succeeded = false, Message =  $"Error removing entity: {ex.Message}" };
            }
        }

        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<ResultDTO> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _applicationDbContext.SaveChangesAsync();
                return new ResultDTO { Succeeded = true, Message = "Updated Successfully ." };
            }
            catch(Exception ex)
            {
                return new ResultDTO { Succeeded = false, Message = $"Error updating entity: {ex.Message}" };
            }
        }
        public async Task<IEnumerable<T?>> GetByConditionAsync(Expression<Func<T, bool>> condition)
        {
            return await _dbSet.Where(condition).ToListAsync();
        }
    }
}
