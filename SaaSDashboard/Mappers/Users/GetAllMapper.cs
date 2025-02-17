using System.Data;
using FastEndpoints;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Mappers.Users;

public class GetAllMapper : Mapper<GetAllDto, GetAllDto, UserModel>
{
    public override UserModel ToEntity(GetAllDto dto) => new()
    {
        id = dto.id,
        employee_id = dto.employee_id,
        username = dto.username,
        name = dto.name,
        email = dto.email,
        password = dto.password,
        group_id = dto.group_id,
        is_active = dto.is_active,
        support_role = dto.support_role,
    };
    
    public override GetAllDto FromEntity(UserModel dto) => new()
    {
        id = dto.id,
        employee_id = dto.employee_id,
        username = dto.username,
        name = dto.name,
        email = dto.email,
        password = dto.password,
        group_id = dto.group_id,
        is_active = dto.is_active,
        support_role = dto.support_role,
    };
}