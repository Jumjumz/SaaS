using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Mappers.Users;

public class UpdateUserMapper : Mapper<UpdateUserRequest, CreateUserResponse, UserModel>
{
    public override UserModel ToEntity(UpdateUserRequest u) => new()
    {
        id = u.id,
        username = u.username,
        name = u.name,
        email = u.email
    };

    public override CreateUserResponse FromEntity(UserModel user) => new()
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