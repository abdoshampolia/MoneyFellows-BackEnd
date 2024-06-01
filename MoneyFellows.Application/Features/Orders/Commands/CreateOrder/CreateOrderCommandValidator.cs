using FluentValidation;

namespace MoneyFellows.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.DeliveryAddress)
                .NotEmpty().WithMessage("DeliveryAddress is required.")
                .Matches(@"^[a-zA-Z0-9]*$").WithMessage("DeliveryAddress must be alphanumeric.");

            RuleFor(p => p.DeliveryTime)
                .NotNull().WithMessage("DeliveryTime is required.");

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(p => p.ProductsOrder)
                .NotEmpty().WithMessage("ProductsIds is required.");
        }
    }
}