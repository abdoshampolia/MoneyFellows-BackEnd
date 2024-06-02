using AutoMapper;
using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Dtos.Common;
using MoneyFellows.Application.Dtos.Products;
using MoneyFellows.Application.Helpers;
using MoneyFellows.Application.Dtos.Common.Extensions;
using Serilog;
using MoneyFellows.Application.Dtos.Orders;
using MoneyFellows.Core.Entities;

namespace MoneyFellows.Application.Features.Products.Queries.GetAllProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Response<ListingDto<ProductDto>>>
    {
        public IProductRepository _productRepository { get; }
        public IMapper _mapper { get; }
        public ILogger _logger { get; }

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<ListingDto<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = (await _productRepository.GetAsync());

                var result = await _productRepository
                           .OrderBy(products, request.OrderBy, request.IsAcending)
                           .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                           .PaginatedListAsync(request.PageNumber, request.PageSize);
               
                _logger.Information("Get Products : {Products}", result);

                return Response.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error occurred while retrieving products");
                throw ex;
            }
        }
    }
}
