using MoneyFellows.Core.Common.Contracts;
using MoneyFellows.Infrastructure.Contexts;
using MoneyFellows.Infrastructure.Helper;

namespace MoneyFellows.Infrastructure.Common
{
    public abstract class Repository<TEntity> : EntityRepository<TEntity, MoneyFellowsDbContext>
          where TEntity : class, IEntityBase
    {
        public Repository(MoneyFellowsDbContext context) : base(context)
        { }
    }
}
