using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;
using SaaSDashboard.Mappers.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Endpoints.Users;

public class PostCreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse, PostCreateUserMapper>
{
    private readonly IUser _user;

    public PostCreateUserEndpoint(IUser user)
    {
        _user = user;
    }
    
    public override void Configure()
    {
        Post("/users/create");
        AllowAnonymous();
        Group<UserEndpoints>();
        Description(d => d.Produces<CreateUserResponse>(200, "application/json")
            .Produces(401)
            .WithMetadata()
            .WithDescription("Create A New User")
            .WithName("Create User"));
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        UserModel entity = Map.ToEntity(req);
        UserModel newUser = await _user.CreateAsync(entity, ct);
        var response = Map.FromEntity(newUser);
        await SendAsync(response, cancellation: ct);
    }
}