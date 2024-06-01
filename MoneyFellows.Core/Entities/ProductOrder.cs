using Microsoft.Extensions.Logging;
using MoneyFellows.Core.common;

namespace MoneyFellows.Core.Entities
{
    public class ProductOrder : Entity
    {
        public ProductOrder(Guid orderId, Guid productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
        protected ProductOrder() {
            Order = null!;
            Product = null!;
        }

        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public Order Order { get; private set; }
        public Product Product { get; private set; }
    }
}
