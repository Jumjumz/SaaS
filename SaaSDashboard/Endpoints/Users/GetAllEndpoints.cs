using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;
using SaaSDashboard.Mappers.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Endpoints.Users;

public class GetAllEndpoints : EndpointWithoutRequest<List<GetAllDto>, GetAllMapper>
{
    private readonly IUser _user;
    public GetAllEndpoints(IUser user)
    {
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
        List<UserModel> users = await _user.GetAllAsync();
        var response = Map.FromEntity(users); // var response = users.Select(Map.FromEntity).ToList() though you dont need this if you implement the conversion in the mapper
        await SendAsync(response, cancellation: ct);
    }
}