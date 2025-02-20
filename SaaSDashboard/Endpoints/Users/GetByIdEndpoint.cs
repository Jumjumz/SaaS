using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;
using SaaSDashboard.Mappers.Users;

namespace SaaSDashboard.Endpoints.Users;

public class GetByIdEndpoint : Endpoint<GetByIdRequestDto, GetAllDto, GetByIdMapper>
{
    private readonly IUser _user;

    public GetByIdEndpoint(IUser user)
    {
        _user = user;
    }
    
    public override void Configure()
    {
        Get("/{id}");
        AllowAnonymous();
        Group<UserEndpoints>();
        Description(d => d
            .Produces<GetAllDto>(200, "application/json")
            .Produces(404)
            .WithTags("Users")
            .WithName("GetUserById"));
    }

    public override async Task HandleAsync(GetByIdRequestDto r, CancellationToken ct)
    {
        var id = Map.ToEntity(r);
        var user = await _user.GetByIdAsync(id, ct);
        var response = Map.FromEntity(user);
        await SendAsync(response, cancellation: ct);
    }
}