using MediatR;
using MoneyFellows.Application.Helper;

namespace MoneyFellows.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Response<bool>>
    {
        public UpdateProductCommand(string name, string description, byte[] image, decimal price, string merchant, Guid id)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Merchant = merchant;
            Id = id;
        }
        public UpdateProductCommand()
        {
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public string Merchant { get; set; }
    }
}
