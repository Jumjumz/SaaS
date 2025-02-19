using Microsoft.EntityFrameworkCore;
using SaaSDashboard.Data;
using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Interfaces;
using SaaSDashboard.Models;

namespace SaaSDashboard.Repository.Users;

public class UserRepository : IUser
{
    private readonly MariaDBContext _context;

    public UserRepository(MariaDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<UserModel>> GetAllAsync()
    {
        return await _context.system_users.ToListAsync();
    }

    public async Task<UserModel> GetByIdAsync(int id)
    {
        return await _context.system_users.FirstOrDefaultAsync(u => u.id == id);
    }
}