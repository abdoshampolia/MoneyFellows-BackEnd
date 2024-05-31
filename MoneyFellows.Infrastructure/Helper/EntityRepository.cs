﻿using MoneyFellows.Application.Contracts.Common;
using MoneyFellows.Core.Common.Contracts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MoneyFellows.Infrastructure.Helper
{
    public abstract class EntityRepository<TEntity, TContext> : IEntityRepository<TEntity>, IDisposable
       where TEntity : class, IEntityBase where TContext : DbContext
    {
        private readonly DbSet<TEntity> dbSet;
        protected TContext Context { get; }
        public EntityRepository(TContext context)
        {
            dbSet = context.Set<TEntity>();
            this.Context = context;
        }

        public async virtual Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await Task.FromResult(query);
        }
        public async Task<TEntity?> GetByIdAsync(Guid id, string? includeProperties = null)
        {
            return (await GetAsync(a => a.Id.Equals(id))).FirstOrDefault();
        }
        public virtual async Task<TEntity> CreateOnDbAsync(TEntity entity)
        {
            TEntity result = await CreateAsync(entity);
            await SaveChangesAsync();
            return result;
        }
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var dbChangeTracker = await dbSet.AddAsync(entity);
            return dbChangeTracker.Entity;
        }
        public virtual async Task CreateRangeAsync(params TEntity[] entities)
        {
            await dbSet.AddRangeAsync(entities);
        }
        public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                var dbChangeTracker = dbSet.Update(entity);
                return dbChangeTracker.State == EntityState.Modified ? dbChangeTracker.Entity : null;
            });
        }
        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            TEntity? entityToDelete = await GetByIdAsync(id);
            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
                return true;
            }
            return false;
        }
        public virtual async void DeleteRange(params Guid[] entitiesIds)
        {
            IQueryable<TEntity> entities = await GetAsync(e => entitiesIds.Contains(e.Id));
            Context.RemoveRange(entities);
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
        public virtual void ClearTracking()
        {
            Context.ChangeTracker.Clear();
        }
        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
        ~EntityRepository()
        {
            Dispose();
        }
    }
}