using AutoMapper;
using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Dtos.Common;
using MoneyFellows.Application.Dtos.Products;
using MoneyFellows.Application.Helper;
using MoneyFellows.Application.Dtos.Common.Extensions;
using Serilog;

namespace MoneyFellows.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Response<ListingDto<ProductDto>>>
    {
        public IProductRepository _productRepository { get; }
        public IMapper _mapper { get; }
        public ILogger _logger { get; }

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<ListingDto<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAsync();

                var result = await products
                            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);
                _logger.Information("Get Products : {Products}", result);

                return Response.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error get product");
                throw ex;
            }
        }
    }
}
