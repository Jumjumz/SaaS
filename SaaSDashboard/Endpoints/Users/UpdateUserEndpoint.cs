using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;
using SaaSDashboard.Mappers.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Endpoints.Users;

public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, CreateUserResponse, UpdateUserMapper>
{
    private readonly IUser _user;

    public UpdateUserEndpoint(IUser user) => _user = user; // constructor shorthand?

    public override void Configure()
    {   
        Put("update/{id}");
        Group<UserEndpoints>();
        AllowAnonymous();
        Description(d => d.Produces<CreateUserResponse>(200, "application/json")
            .Produces(400)
            .WithDescription("Update User By Id")
            .WithName("Create User Response"));
    }

    public override async Task HandleAsync(UpdateUserRequest r, CancellationToken ct)
    {
        UserModel entity = Map.ToEntity(r);
        var user = await _user.UpdateAsync(entity, ct);
        var response = Map.FromEntity(user);
        await SendAsync(response, cancellation: ct);
    }
}