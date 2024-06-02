using MediatR;
using MoneyFellows.Application.Dtos.Accounts.Login;


namespace MoneyFellows.Application.Features.Accounts.Commands.Login
{
    public class LoginUserCommand : IRequest<LoginDto>
    {
        public LoginUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public LoginUserCommand()
        {
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
