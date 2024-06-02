using FluentValidation;

namespace MoneyFellows.Application.Features.Accounts.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("FirstName must contain only alphabetic characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("LastName must contain only alphabetic characters.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Matches("^[a-zA-Z0-9]+$").WithMessage("Username must be alphanumeric.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(6, 100).WithMessage("Password must be between 6 and 100 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^\d+$").WithMessage("Phone must contain only numeric characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}