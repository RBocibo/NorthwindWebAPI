using System.Linq.Expressions;

namespace Northwind.Core.GenericInterface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateEntityAsync(TEntity entity);
        Task<TEntity> UpdateEntityAsync(TEntity entity);
        Task DeleteEntityAsync(Expression<Func<TEntity, bool>> expression);
    }
}
