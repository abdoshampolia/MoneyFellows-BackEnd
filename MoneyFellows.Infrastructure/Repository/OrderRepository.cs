using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Core.Entities;
using MoneyFellows.Infrastructure.Common;
using MoneyFellows.Infrastructure.Contexts;

namespace MoneyFellows.Infrastructure.Repository
{
    public class OrderRepository : ModifiableRepository<Order>, IOrderRepository
    {
        public OrderRepository(MoneyFellowsDbContext context) : base(context)
        { }
    }
}
