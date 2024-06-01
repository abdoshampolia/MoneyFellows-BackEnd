using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Helper;
using Serilog;

namespace MoneyFellows.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<bool>>
    {
        public IProductRepository _productRepository { get; }
        private readonly ILogger _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _logger = Log.ForContext<UpdateProductCommandHandler>();
        }

        public async Task<Response<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(request.Id);

                if (existingProduct is not null)
                {
                    //We must track the modifier user and send it to modify user id 
                    var result = existingProduct.EditProduct(request.Name, request.Description, request.Price, request.Image);

                    if (result)
                    {
                        _logger.Information("Product updated successfully: {ProductName}", existingProduct.Name);
                        return Response.Ok(await _productRepository.SaveChangesAsync() > 0);
                    }
                    else
                    {
                        _logger.Information("Product updated faild: {ProductName}", existingProduct.Name);
                        return Response.Ok(false);
                    }
                }
                else
                {
                    _logger.Warning("Product not found: {ProductId}", request.Id);
                    //we must adding custom ex 
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error updateing product");
                throw ex;
            }
        }
    }
}
