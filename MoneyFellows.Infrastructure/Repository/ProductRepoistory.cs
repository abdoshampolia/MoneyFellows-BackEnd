using Microsoft.EntityFrameworkCore;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Core.Entities;
using MoneyFellows.Infrastructure.Common;
using MoneyFellows.Infrastructure.Contexts;

namespace MoneyFellows.Infrastructure.Repository
{
    public class ProductRepoistory : ModifiableRepository<Product>, IProductRepository
    {
        public ProductRepoistory(MoneyFellowsDbContext context) : base(context)
        { }

        public override IQueryable<Product> OrderBy(IQueryable<Product> entities, string? orderBy, bool isAccending = true)
        {
            if (orderBy != null)
            {
                switch (orderBy.ToLower())
                {
                    case "name":
                        entities = isAccending ? entities.OrderBy(a => a.Name) : entities.OrderByDescending(a => a.Name);
                        break;

                }
            }
            return entities;
        }
    }
}
