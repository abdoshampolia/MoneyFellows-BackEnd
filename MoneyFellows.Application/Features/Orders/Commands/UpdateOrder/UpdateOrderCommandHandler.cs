using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Helper;
using Serilog;

namespace MoneyFellows.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response<bool>>
    {
        public IOrderRepository _orderRepository { get; }
        private readonly ILogger _logger;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _logger = Log.ForContext<UpdateOrderCommandHandler>();
        }

        public async Task<Response<bool>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingOrder = await _orderRepository.GetByIdAsync(request.Id);

                if (existingOrder is not null)
                {
                    //We must track the modifier user and send it to modify user id 
                    var result = existingOrder.EditOrder(request.DeliveryAddress, request.DeliveryTime, request.ProductsOrder);

                    if (result)
                    {
                        _logger.Information("Order updated successfully: {OrderId}", existingOrder.Id);
                        return Response.Ok(await _orderRepository.SaveChangesAsync() > 0);
                    }
                    else
                    {
                        _logger.Information("Order updated faild: {OrderId}", existingOrder.Id);
                        return Response.Ok(false);
                    }
                }
                else
                {
                    _logger.Warning("Order not found: {OrderId}", request.Id);
                    //we must adding custom ex 
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error occurred while updating order");
                throw ex;
            }
        }
    }
}
