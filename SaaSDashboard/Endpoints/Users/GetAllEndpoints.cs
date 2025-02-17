using FastEndpoints;
using SaaSDashboard.Data;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;

namespace SaaSDashboard.Endpoints.Users;

public class GetAllEndpoints : EndpointWithoutRequest<List<GetAllDto>>
{
    private readonly MariaDBContext _context;
    private readonly IUser _user;

    public GetAllEndpoints(MariaDBContext context, IUser user)
    {
        _context = context;
        _user = user;
    }
    
    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
        Group<UserEndpoints>();
        Description(
            d => d.Produces<GetAllDto>(200, "application/json")
                .Produces(404)
                .WithMetadata()
                .WithDescription("Get All Users")
                .WithName("Get All Users"));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<GetAllDto> users = await _user.GetAllAsync(ct);
        await SendAsync(users, cancellation: ct);
    }
}