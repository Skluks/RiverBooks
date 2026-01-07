using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;
using RiverBooks.Users.Models.Request;

namespace RiverBooks.Users.Endpoints;

public class LoginEndpoint : Endpoint<UserLoginRequest, string>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserLoginRequest request, CancellationToken cancellationToken)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            await Send.UnauthorizedAsync(cancellationToken);
            return;
        }

        var loginSuccess = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!loginSuccess)
        {
            await Send.UnauthorizedAsync(cancellationToken);
            return;
        }

        var jwtSecret = Config["Auth:JwtSecret"]!;
        var token = JwtBearer.CreateToken(o =>
        {
            o.SigningKey = jwtSecret;
        });

        await Send.OkAsync(token, cancellationToken);
    }
}