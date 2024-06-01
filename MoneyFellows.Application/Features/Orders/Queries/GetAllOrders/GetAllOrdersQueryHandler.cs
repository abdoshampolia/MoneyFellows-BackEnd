using AutoMapper;
using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Dtos.Common;
using MoneyFellows.Application.Dtos.Orders;
using MoneyFellows.Application.Helper;
using MoneyFellows.Application.Dtos.Common.Extensions;
using Serilog;

namespace MoneyFellows.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Response<ListingDto<OrderDto>>>
    {
        public IOrderRepository _orderRepository { get; }
        public IMapper _mapper { get; }
        public ILogger _logger { get; }

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILogger logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<ListingDto<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _orderRepository.GetAsync();

                var result = await _orderRepository
                            .OrderBy(orders, request.OrderBy, request.IsAcending)
                            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);

                _logger.Information("Get Orders : {Orders}", result);

                return Response.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error occurred while retrieving orders");
                throw ex;
            }
        }
    }
}
