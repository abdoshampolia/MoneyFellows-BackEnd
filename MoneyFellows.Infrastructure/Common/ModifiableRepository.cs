using MoneyFellows.Core.Common;
using MoneyFellows.Infrastructure.Contexts;
using MoneyFellows.Infrastructure.Helper;

namespace MoneyFellows.Infrastructure.Common
{
    public abstract class ModifiableRepository<TEntity> : ModifiableEntityRepository<TEntity, MoneyFellowsDbContext>
      where TEntity : ModifiableEntity
    {
        public ModifiableRepository(MoneyFellowsDbContext context) : base(context)
        {
        }
    }
}
