using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Helpers;
using MoneyFellows.Core.Entities;
using Serilog;

namespace MoneyFellows.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<Unit>>
    {
        public IOrderRepository _orderRepository { get; }
        private readonly ILogger _logger;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _logger = Log.ForContext<CreateOrderCommandHandler>();
        }

        public async Task<Response<Unit>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Generate a new order with a unique identifier, delivery address, time, and user ID.
                //We must track the creator user and send it to creator user id 
                var newOrder = new Order(Guid.NewGuid(), request.DeliveryAddress, request.DeliveryTime, request.UserId);

                // Add products to the order. 
                newOrder.AddProductsOrder(request.ProductsOrder);

                // Save the new order to the database.
                newOrder = await _orderRepository.CreateOnDbAsync(newOrder);

                // Log the successful addition of the order.
                _logger.Information("Order added successfully: {OrderName}", newOrder.Id);

                // Return a successful response.
                return Response.Ok(Unit.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error occurred while adding order");
                throw ex;
            }
        }
    }
}
