using SaaSDashboard.DTOs.Users;

namespace SaaSDashboard.Interfaces;

public interface IUser
{
    Task<List<GetAllDto>> GetAllAsync(CancellationToken ct);
}