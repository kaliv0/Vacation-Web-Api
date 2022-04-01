using Microsoft.EntityFrameworkCore;
using Vacation.Domain.Contracts.Repositories;

namespace Vacation.Data.Repositories
{
    internal abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly VacationDbContext _dbContext;

        public BaseRepository(VacationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var entityInDb = _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entityInDb.Entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
