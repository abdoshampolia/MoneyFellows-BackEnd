using MediatR;
using Microsoft.AspNetCore.Http;
using MoneyFellows.Application.Helpers;

namespace MoneyFellows.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Response<Unit>>
    {
        public CreateProductCommand(string name, string description, IFormFile? image, double price, string merchant)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Merchant = merchant;
        }
        public CreateProductCommand()
        {
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public double Price { get; set; }
        public string Merchant { get; set; }
    }
}
