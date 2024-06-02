using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MoneyFellows.Application.Features.Accounts.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<IdentityResult>
    {
        public RegisterUserCommand(string firstName, string lastName, string userName, string password, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public RegisterUserCommand()
        {
            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
