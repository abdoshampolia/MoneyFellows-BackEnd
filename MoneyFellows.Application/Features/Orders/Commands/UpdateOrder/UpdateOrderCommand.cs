using MediatR;
using MoneyFellows.Application.Helper;
using MoneyFellows.Core.VM;

namespace MoneyFellows.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<Response<bool>>
    {
        public UpdateOrderCommand(Guid id, string deliveryAddress, DateTime deliveryTime, ProductOrderVM[] productsOrder)
        {
            DeliveryAddress = deliveryAddress;
            DeliveryTime = deliveryTime;
            ProductsOrder = productsOrder;
            Id = id;
        }
        public UpdateOrderCommand()
        {
        }
        public Guid Id { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryTime { get; set; }
        public ProductOrderVM[] ProductsOrder { get; set; }
    }
}
