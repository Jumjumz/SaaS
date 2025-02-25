using System.ComponentModel.DataAnnotations;

namespace SaaSDashboard.DTOs.Users;

public class UpdateUserRequest
{
    public int id { get; set; }
    public string username { get; set; }
    public string name { get; set; }
    public string email { get; set; }
}