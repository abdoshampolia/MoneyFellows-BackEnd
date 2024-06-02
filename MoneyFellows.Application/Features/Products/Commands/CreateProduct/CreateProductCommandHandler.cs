using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Helpers;
using MoneyFellows.Core.Entities;
using Serilog;

namespace MoneyFellows.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<Unit>>
    {
        public IProductRepository _productRepository { get; }
        private readonly ILogger _logger;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _logger = Log.ForContext<CreateProductCommandHandler>(); 
        }

        public async Task<Response<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = (await _productRepository.GetAsync(p => p.Name == request.Name)).FirstOrDefault();
                string pathFile = string.Empty;

                if (existingProduct is null)
                {
                    //We must track the creator user and send it to creator user id 
                    if (request.Image != null)
                    {
                        pathFile = await Helper.UploadFile(request.Image);
                    }

                    var newProduct = new Product(Guid.NewGuid(), request.Name, request.Description, pathFile, request.Price, request.Merchant);
                    newProduct = await _productRepository.CreateOnDbAsync(newProduct);
                    _logger.Information("Product added successfully: {ProductName}", newProduct.Name);
                    return Response.Ok(Unit.Value);
                }
                else
                {
                    _logger.Warning("Product already exists: {ProductName}", request.Name);
                    //we must adding custom ex 
                    throw new Exception ();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error occurred while adding product");
                throw ex;
            }
        }
    }
}
