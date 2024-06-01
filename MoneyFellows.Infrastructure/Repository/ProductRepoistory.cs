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
    }
}
