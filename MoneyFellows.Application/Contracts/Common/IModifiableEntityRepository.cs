using MoneyFellows.Core.Common.Contracts;

namespace MoneyFellows.Application.Contracts.Common
{
    public interface IModifiableEntityRepository<TEntity> : IEntityRepository<TEntity>
       where TEntity : class, IModifiableEntityBase, IEntityBase
    {
        public Task<bool> DeleteLogicalAsync(Guid userId, Guid id);
        public void DeleteRangeLogicalAsync(Guid userId, params Guid[] entitiesIds);
    }
}
