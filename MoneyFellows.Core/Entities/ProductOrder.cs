using MoneyFellows.Core.common;

namespace MoneyFellows.Core.Entities
{
    public class ProductOrder : Entity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
