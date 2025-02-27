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
        return await _context.system_users.ToListAsync(ct);
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

    public async Task<IResult> DeleteAsync(int id, CancellationToken ct)
    {
        //await _context.system_users.Where(u => u.id == id).ExecuteDeleteAsync(ct); instantly delete the user no need to do save changes
        try
        {
            var user = await _context.system_users.FindAsync(id);
            
            if (user == null)
            {
                return Results.NotFound();
            }
            
            _context.system_users.Remove(user);
            await _context.SaveChangesAsync(ct);
            return Results.Ok("User deleted");
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    public async Task<UserModel> UpdateAsync(int id, UserModel entity, CancellationToken ct)
    {
        var user = await _context.system_users.FirstOrDefaultAsync((u => u.id == id), ct);

        if (user is null) return null;

        var updateUser = new UserModel()
        {
            username = user.username,
            name = user.name,
            email = user.email,
        };

        //_context.Entry(updateUser).CurrentValues.SetValues(entity);
        _context.system_users.Update(updateUser);
        await _context.SaveChangesAsync(ct);
        
        return updateUser;
    }
}