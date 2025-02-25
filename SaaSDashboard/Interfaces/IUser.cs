using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Interfaces;

public interface IUser
{
    Task<List<UserModel>> GetAllAsync(CancellationToken ct);
    Task<UserModel> GetByIdAsync(int id, CancellationToken ct);
    Task<UserModel> CreateAsync(UserModel user, CancellationToken ct);
    Task<IResult> DeleteAsync(int id, CancellationToken ct);
    Task<UserModel> UpdateAsync(UserModel entity, CancellationToken ct);
}