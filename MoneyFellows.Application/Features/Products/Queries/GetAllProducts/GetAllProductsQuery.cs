using MediatR;
using MoneyFellows.Application.Dtos.Common;
using MoneyFellows.Application.Dtos.Products;
using MoneyFellows.Application.Helper;

namespace MoneyFellows.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : PageRequest, IRequest<Response<ListingDto<ProductDto>>>
    {
        public GetAllProductsQuery()
        {

        }
    }
}
