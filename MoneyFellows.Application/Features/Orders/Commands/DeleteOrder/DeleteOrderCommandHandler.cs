using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Helpers;
using Serilog;

namespace MoneyFellows.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Response<bool>>
    {
        public IOrderRepository _orderRepository { get; }
        private readonly ILogger _logger;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _logger = Log.ForContext<DeleteOrderCommandHandler>();
        }

        public async Task<Response<bool>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingOrder = await _orderRepository.GetByIdAsync(request.Id);

                if (existingOrder != null && existingOrder.DeliveryTime < DateTime.Now)
                {
                    _logger.Warning("Attempt to create an order with past delivery time: {DeliveryTime}", existingOrder.DeliveryTime);
                    return Response.Fail<bool>("Cannot create an order with a past delivery time.");
                }
                else
                {
                    if (existingOrder is not null)
                    {
                        //We must track the modifier user and send it to modify user id 
                        if (await _orderRepository.DeleteAsync(request.Id))
                        {
                            _logger.Information("Order deleted successfully: {OrderId}", existingOrder.Id);
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
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error occurred while deleting order");
                throw ex;
            }
        }
    }
}
