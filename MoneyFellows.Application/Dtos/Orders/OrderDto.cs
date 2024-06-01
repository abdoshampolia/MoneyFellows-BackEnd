using MoneyFellows.Application.Dtos.ProductOrders;
using MoneyFellows.Core.Entities;

namespace MoneyFellows.Application.Dtos.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string DeliveryAddress { get;  set; }
        public decimal TotalCost { get;  set; }
        public DateTime DeliveryTime { get;  set; }
        public Guid UserId { get;  set; }
        public ICollection<ProductOrderDto>? ProductsOrder { get; }

    }
}
