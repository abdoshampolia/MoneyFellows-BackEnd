using Microsoft.AspNetCore.Mvc;
using MoneyFellows.API.Controllers.Base;
using MoneyFellows.Application.Features.Accounts.Commands.Login;
using MoneyFellows.Application.Features.Accounts.Commands.RegisterAdmin;
using MoneyFellows.Application.Features.Accounts.Commands.RegisterUser;

namespace MoneyFellows.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ApiControllerBase
    {
        //Commands
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
