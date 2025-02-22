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
    
    public async Task<List<UserModel>> GetAllAsync(CancellationToken ct)
    {
        return await _context.system_users.ToListAsync();
    }

    public async Task<UserModel> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.system_users.Where(u => u.id == id).FirstOrDefaultAsync(ct);
    }

    public async Task<UserModel> CreateAsync(UserModel user, CancellationToken ct)
    {
        await _context.system_users.AddAsync(user);
        await _context.SaveChangesAsync(ct);

        return user;
    }
}