using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Mappers.Users;

public class GetByIdMapper : Mapper<GetByIdRequestDto, GetAllDto, UserModel>
{
    public override GetAllDto FromEntity(UserModel user) => new()
    {
        id = user.id,
        employee_id = user.employee_id,
        username = user.username,
        name = user.name,
        email = user.email,
        group_id = user.group_id,
        is_active = user.is_active,
        support_role = user.support_role,
    };
}