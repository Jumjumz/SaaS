using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;
using SaaSDashboard.Mappers.Users;

namespace SaaSDashboard.Endpoints.Users;

public class DeleteUserEndpoint : Endpoint<GetByIdRequestDto, DeleteUserDto, DeleteUserMapper>
{
    private readonly IUser _user;

    public DeleteUserEndpoint(IUser user)
    {
        _user = user;
    }

    public override void Configure()
    {
        Delete("{id}");
        AllowAnonymous();
        Group<UserEndpoints>();
        Description(d => d.Produces<DeleteUserDto>(200, "application/json")
            .Produces(404)
            .WithDescription("Delete User By Id")
            .WithName("Delete User By Id"));
    }

    public async override Task HandleAsync(GetByIdRequestDto r, CancellationToken ct)
    {
        var entity = await _user.DeleteAsync(r.id, ct);
        var user = Map.FromEntity(entity);
        await SendAsync(user, cancellation: ct);
    }
}