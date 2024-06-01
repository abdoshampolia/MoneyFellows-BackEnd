using MediatR;
using MoneyFellows.Application.Dtos.Orders;
using MoneyFellows.Application.Helper;

namespace MoneyFellows.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Response<OrderDto>>
    {
        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
        public GetOrderByIdQuery()
        {
        }

        public Guid Id { get; set; }
    }
}
