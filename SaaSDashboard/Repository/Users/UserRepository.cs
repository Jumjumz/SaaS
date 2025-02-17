using Microsoft.EntityFrameworkCore;
using SaaSDashboard.Data;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;

namespace SaaSDashboard.Repository.Users;

public class UserRepository : IUser
{
    private readonly MariaDBContext _context;

    public UserRepository(MariaDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<GetAllDto>> GetAllAsync(CancellationToken ct)
    {
        var users = await _context.system_users
            .Select(u => new GetAllDto
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
            })
            .ToListAsync();
        
        return users;
    }
}