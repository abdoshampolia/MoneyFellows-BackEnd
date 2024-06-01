using AutoMapper;
using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Dtos.Products;
using MoneyFellows.Application.Helper;
using MoneyFellows.Core.Entities;
using Serilog;

namespace MoneyFellows.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductDto>>
    {
        public IProductRepository _productRepository { get; }
        public IMapper _mapper { get; }
        public ILogger _logger { get; }

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                if (product is not null)
                {
                    var result = _mapper.Map<Product, ProductDto>(product);
                    _logger.Information("Product get successfully: {ProductName}", product.Name);

                    return Response.Ok(result);
                }
                else
                {
                    _logger.Warning("Can`t Find Product: {ProductName}", null);
                    //we must adding custom ex to only show the error 
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error occurred while retrieving product");
                throw ex;
            }
        }
    }
}
