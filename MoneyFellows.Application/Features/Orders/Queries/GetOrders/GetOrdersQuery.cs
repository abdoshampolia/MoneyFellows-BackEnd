using MediatR;
using MoneyFellows.Application.Dtos.Common;
using MoneyFellows.Application.Dtos.Orders;
using MoneyFellows.Application.Helpers;

namespace MoneyFellows.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetOrdersQuery : PageRequest, IRequest<Response<ListingDto<OrderDto>>>
    {
        public GetOrdersQuery()
        {

        }
    }
}
