using MediatR;
using MoneyFellows.Application.Dtos.Common;
using MoneyFellows.Application.Dtos.Products;
using MoneyFellows.Application.Helpers;

namespace MoneyFellows.Application.Features.Products.Queries.GetAllProducts
{
    public class GetProductsQuery : PageRequest, IRequest<Response<ListingDto<ProductDto>>>
    {
        public GetProductsQuery()
        {

        }
    }
}
