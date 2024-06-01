using FluentValidation;

namespace MoneyFellows.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("Product Id  is required.");

            RuleFor(p => p.DeliveryAddress)
                .NotEmpty().WithMessage("DeliveryAddress is required.")
                .Matches(@"^[a-zA-Z0-9]*$").WithMessage("DeliveryAddress must be alphanumeric.");

            RuleFor(p => p.DeliveryTime)
                .NotNull().WithMessage("DeliveryTime is required.");

            RuleFor(p => p.ProductsOrder)
                .NotEmpty().WithMessage("ProductsIds is required.");
        }
    }
}