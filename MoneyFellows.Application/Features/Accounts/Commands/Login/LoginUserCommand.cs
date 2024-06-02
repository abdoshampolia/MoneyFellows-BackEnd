using MediatR;
using MoneyFellows.Application.Dtos.Accounts.Login;


namespace MoneyFellows.Application.Features.Accounts.Commands.Login
{
    public class LoginUserCommand : IRequest<LoginDto>
    {
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public LoginUserCommand()
        {
        }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
