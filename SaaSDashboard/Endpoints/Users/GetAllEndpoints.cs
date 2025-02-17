using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SaaSDashboard.Data;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Mappers.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Endpoints.Users;

public class GetAllEndpoints : EndpointWithoutRequest<List<GetAllDto>>
{
    private readonly MariaDBContext _context;

    public GetAllEndpoints(MariaDBContext context)
    {
        _context = context;
    }
    
    public override void Configure()
    {
        Get("/users");
        AllowAnonymous();
        Description(
            d => d.Produces<GetAllDto>(200, "application/json")
            .Produces(404)
            .WithMetadata()
            .WithTags("Get All Users"));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = await _context.system_users.ToListAsync(ct);
        await SendAsync(users.Select(u => new GetAllDto
        {
            id = u.id,
            employee_id = u.employee_id,
            username = u.username,
            name = u.name,
            email = u.email,
            password = u.password,
            group_id = u.group_id,
            is_active = u.is_active,
            support_role = u.support_role,
        }).ToList(), cancellation: ct);
    }
}