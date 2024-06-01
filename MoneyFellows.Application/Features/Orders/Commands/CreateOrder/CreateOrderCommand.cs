using MediatR;
using MoneyFellows.Application.Dtos.ProductOrders;
using MoneyFellows.Application.Helper;
using MoneyFellows.Core.VM;

namespace MoneyFellows.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Response<Unit>>
    {
        public CreateOrderCommand(string deliveryAddress, DateTime deliveryTime, Guid userId, ProductOrderVM[] productsOrder)
        {
            DeliveryAddress = deliveryAddress;
            DeliveryTime = deliveryTime;
            UserId = userId;
            ProductsOrder = productsOrder;
        }
        public CreateOrderCommand()
        {
        }

        public string DeliveryAddress { get; set; }
        public DateTime DeliveryTime { get; set; }
        public Guid UserId { get; set; }
        public ProductOrderVM[] ProductsOrder { get; set; }
    }
}
