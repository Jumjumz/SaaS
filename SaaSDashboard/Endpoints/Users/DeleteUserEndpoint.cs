using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;

namespace SaaSDashboard.Endpoints.Users;

public class DeleteUserEndpoint : Endpoint<GetByIdRequestDto, IResult>
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
        Description(d => d.Produces<IResult>(200, "application/json")
            .Produces(400)
            .WithDescription("Delete User By Id")
            .WithName("Delete User By Id"));
    }

    public override async Task HandleAsync(GetByIdRequestDto r, CancellationToken ct)
    {
        IResult entity = await _user.DeleteAsync(r.id, ct);
        await SendOkAsync(entity, cancellation: ct);
    }
}