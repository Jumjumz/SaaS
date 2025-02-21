using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Mappers.Users;

public class GetAllMapper : Mapper<GetAllDto, GetAllDto, UserModel>, IResponseMapper
{
    public List<GetAllDto> FromEntity(List<UserModel> user) => user.Select(u => new GetAllDto
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
    }).ToList();
}