using System.ComponentModel.DataAnnotations;

namespace SaaSDashboard.DTOs.Users;

public class PostCreateUserDto // empty as create user req and res is in one dto file
{
}
public class CreateUserRequest 
{
    public string employee_id { get; set; }
    [Required]
    public string username { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string password { get; set; }
    [Required]
    public string email { get; set; }
}

public class CreateUserResponse
{
    public int id { get; set; }
    public string employee_id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public int? group_id { get; set; }
    public bool is_active { get; set; }
    public string? support_role { get; set; }
}
