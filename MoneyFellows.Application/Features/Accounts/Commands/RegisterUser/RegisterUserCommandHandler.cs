using MediatR;
using Microsoft.AspNetCore.Identity;
using MoneyFellows.Core.Entities;
using Serilog;

namespace MoneyFellows.Application.Features.Accounts.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;
        public ILogger _logger { get; }

        public RegisterUserCommandHandler(UserManager<User> userManager, ILogger logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _userManager.FindByNameAsync(request.UserName) != null)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Username is already taken." });
                }

                if (await _userManager.FindByEmailAsync(request.Email) != null)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Email is already registered." });
                }

                var user = new User(request.FirstName, request.LastName, request.UserName, request.Email, request.PhoneNumber);

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User"); // Assign the "User" role
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while registering a new user.");
                return IdentityResult.Failed(new IdentityError { Description = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}