using MediatR;
using MoneyFellows.Application.Dtos.Products;
using MoneyFellows.Application.Helpers;

namespace MoneyFellows.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<ProductDto>>
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
        public GetProductByIdQuery()
        {
        }

        public Guid Id { get; set; }
    }
}
