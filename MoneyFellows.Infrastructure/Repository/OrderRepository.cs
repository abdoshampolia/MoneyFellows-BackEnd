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

        public override IQueryable<Order> OrderBy(IQueryable<Order> entities, string? orderBy, bool isAccending = true)
        {
            if (orderBy != null)
            {
                switch (orderBy.ToLower())
                {
                    case "deliveryTime":
                        entities = isAccending ? entities.OrderBy(a => a.DeliveryTime) : entities.OrderByDescending(a => a.DeliveryTime);
                        break;
                }
            }
            return entities;
        }
    }
}
