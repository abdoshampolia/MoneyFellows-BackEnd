using MediatR;
using MoneyFellows.Application.Dtos.Common;
using MoneyFellows.Application.Dtos.Orders;
using MoneyFellows.Application.Dtos.Products;
using MoneyFellows.Application.Helper;

namespace MoneyFellows.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : PageRequest, IRequest<Response<ListingDto<OrderDto>>>
    {
        public GetAllOrdersQuery()
        {

        }
    }
}
