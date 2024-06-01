using MediatR;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Application.Helper;
using Serilog;

namespace MoneyFellows.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<bool>>
    {
        public IProductRepository _productRepository { get; }
        private readonly ILogger _logger;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _logger = Log.ForContext<DeleteProductCommandHandler>();
        }

        public async Task<Response<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(request.Id);

                if (existingProduct is not null)
                {
                    //We must track the modifier user and send it to modify user id 
                    if (await _productRepository.DeleteAsync(request.Id))
                    {
                        _logger.Information("Product deleted successfully: {ProductName}", existingProduct.Id);
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
                _logger.Error(ex, "Error deleting product");
                throw ex;
            }
        }
    }
}
