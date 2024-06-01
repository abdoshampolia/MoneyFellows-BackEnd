using AutoMapper;
using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Dtos.Orders;
using MoneyFellows.Application.Helper;
using MoneyFellows.Core.Entities;
using Serilog;

namespace MoneyFellows.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Response<OrderDto>>
    {
        public IOrderRepository _orderRepository { get; }
        public IMapper _mapper { get; }
        public ILogger _logger { get; }

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILogger logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(request.Id, "ProductsOrder.Product");

                if (order is not null)
                {
                    var result = _mapper.Map<Order, OrderDto>(order);
                    _logger.Information("Order get successfully: {OrderId", order.Id);

                    return Response.Ok(result);
                }
                else
                {
                    _logger.Warning("Can`t Find Order: {OrderId}", null);
                    //we must adding custom ex to only show the error 
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error occurred while retrieving order");
                throw ex;
            }
        }
    }
}
