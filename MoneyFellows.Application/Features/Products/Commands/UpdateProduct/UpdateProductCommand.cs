using MediatR;
using Microsoft.AspNetCore.Http;
using MoneyFellows.Application.Helpers;

namespace MoneyFellows.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Response<bool>>
    {
        public UpdateProductCommand(string name, string description, IFormFile image, double price, string merchant, Guid id)
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
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public double? Price { get; set; }
        public string? Merchant { get; set; }
    }
}
