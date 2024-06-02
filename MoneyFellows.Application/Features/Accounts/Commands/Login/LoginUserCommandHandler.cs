using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoneyFellows.Application.Dtos.Accounts.Login;
using MoneyFellows.Application.Features.Accounts.Commands.Login;
using MoneyFellows.Core.Entities;
using Serilog;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginDto>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public LoginUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, ILogger logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(request.UserName);

            if (user == null)
            {
                return new LoginDto { Success = false, Errors = new[] { "Invalid login attempt." } };
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if (!result.Succeeded)
            {
                return new LoginDto { Success = false, Errors = new[] { "Invalid login attempt." } };
            }

            // Get roles
            var roles = await _userManager.GetRolesAsync(user);

            // Generate JWT token
            var token = GenerateJwtToken(user, roles);

            return new LoginDto { Success = true, Token = token };
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An error occurred while logging in.");
            return new LoginDto { Success = false, Errors = new[] { "An unexpected error occurred. Please try again later." } };
        }
    }

    private string GenerateJwtToken(User user, IList<string> roles)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email)
        };

        // Add role claims
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresInMinutes"])),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
