using MoneyFellows.Core.Common;

namespace MoneyFellows.Core.Entities
{
    public class Order : ModifiableEntity
    {
        public Order(Guid creatorUserId) : base(creatorUserId)
        {
        }

        public string DeliveryAddress { get; private set; }
        public decimal TotalCost { get; private set; }
        public string UserId { get; private set; }
        public DateTime DeliveryTime { get; private set; }

        public User User { get; private set; }
        public ICollection<ProductOrder> ProductsOrder { get; private set; }
    }
}
