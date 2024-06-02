using MoneyFellows.Application.Contracts.Common;
using MoneyFellows.Core.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MoneyFellows.Infrastructure.Helper
{
    public abstract class ModifiableEntityRepository<TEntity, TContext> : EntityRepository<TEntity, TContext>, IModifiableEntityRepository<TEntity>
       where TEntity : class, IModifiableEntityBase, IEntityBase
        where TContext : DbContext
    {
        public ModifiableEntityRepository(TContext context) : base(context)
        {
        }

    }
}
