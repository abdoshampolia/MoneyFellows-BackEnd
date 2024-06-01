using MoneyFellows.Core.Common.Contracts;
using System.Linq.Expressions;

namespace MoneyFellows.Application.Contracts.Common
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntityBase
    {
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity?> GetByIdAsync(Guid id, string? includeProperties = null);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> CreateOnDbAsync(TEntity entity);
        Task CreateRangeAsync(params TEntity[] entities);
        Task<TEntity?> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        void DeleteRange(params Guid[] entitiesIds);
        Task<int> SaveChangesAsync();
        IQueryable<TEntity> OrderBy(IQueryable<TEntity> entities, string? orderBy, bool isAccending = true);
    }
}
