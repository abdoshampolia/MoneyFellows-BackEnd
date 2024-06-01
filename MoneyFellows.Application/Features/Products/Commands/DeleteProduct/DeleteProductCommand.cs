using MediatR;
using MoneyFellows.Application.Helper;

namespace MoneyFellows.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Response<bool>>
    {
        public DeleteProductCommand(Guid id)
        {
       
            Id = id;
        }
        public DeleteProductCommand()
        {
        }
        public Guid Id { get; set; }
     
    }
}
