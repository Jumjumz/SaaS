using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;
using SaaSDashboard.Mappers.Users;
using SaaSDashboard.Models;

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
        Get("{id}");
        AllowAnonymous();
        Group<UserEndpoints>();
        Description(
            d => d.Produces<GetAllDto>(200, "application/json")
                .Produces(404)
                .Accepts<GetByIdRequestDto>()
                .WithDescription("Get User By Id")
                .WithName("Get User By Id"));
    }

    public override async Task HandleAsync(GetByIdRequestDto r, CancellationToken ct)
    {
        UserModel user = await _user.GetByIdAsync(r.id, ct);
        GetAllDto response = Map.FromEntity(user);
        await SendAsync(response, cancellation: ct);
    }
}