using Microsoft.EntityFrameworkCore;
using Northwind.Core.GenericInterface;
using System.Linq.Expressions;

namespace Northwind.Infrastructure.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        public Repository(NorthwindContext context)
        {
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> CreateEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task DeleteEntityAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            if (entity == null)
                return;

            _dbSet.RemoveRange(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            var result = await _dbSet.FirstOrDefaultAsync(expression);

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<TEntity> UpdateEntityAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }
    }
}
