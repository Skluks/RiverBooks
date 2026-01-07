using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using RiverBooks.Users.Models;
using RiverBooks.Users.Models.Request;

namespace RiverBooks.Users.Endpoints;

public class CreateEndpoint : Endpoint<CreateUserRequest, UserDto>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var newUser = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email
        };

        IdentityResult result = await _userManager.CreateAsync(newUser, request.Password);

        await Send.OkAsync(cancellationToken);
    }
}