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

        public async Task<bool> DeleteLogicalAsync(Guid userId, Guid id)
        {
            TEntity? entityToDelete = await GetByIdAsync(id);
            if (entityToDelete != null)
            {
                entityToDelete.IsDeleted = true;
                entityToDelete.DeletedOn = DateTime.Now;
                entityToDelete.DeletingUserId = userId;
                return true;
            }
            return false;
        }
        public async void DeleteRangeLogicalAsync(Guid userId, params Guid[] entitiesIds)
        {
            foreach (var id in entitiesIds)
            {
                await DeleteLogicalAsync(userId, id);
            }
        }
    }
}
