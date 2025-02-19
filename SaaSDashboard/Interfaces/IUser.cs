using SaaSDashboard.DTOs.Users;
using SaaSDashboard.Models;

namespace SaaSDashboard.Interfaces;

public interface IUser
{
    Task<List<UserModel>> GetAllAsync();
    Task<UserModel> GetByIdAsync(int id);
}