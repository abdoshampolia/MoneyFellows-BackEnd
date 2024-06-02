using MoneyFellows.Core.Common.Contracts;

namespace MoneyFellows.Application.Contracts.Common
{
    public interface IModifiableEntityRepository<TEntity> : IEntityRepository<TEntity>
       where TEntity : class, IModifiableEntityBase, IEntityBase
    {
        
    }
}
