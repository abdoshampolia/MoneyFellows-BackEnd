using FluentValidation;

namespace MoneyFellows.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("ProductName is required.")
                .Matches(@"^[a-zA-Z0-9]*$").WithMessage("ProductName must be alphanumeric.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("ProductDescription is required.")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("ProductDescription must be alphanumeric.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Price must be a numeric value.");

            RuleFor(p => p.Merchant)
                .NotEmpty().WithMessage("Merchant is required.")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("Merchant must be alphanumeric.");
        }
    }
}