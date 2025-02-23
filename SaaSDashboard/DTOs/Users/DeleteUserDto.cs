namespace SaaSDashboard.DTOs.Users;

public class DeleteUserDto
{
    public int id { get; set; }
    public string employee_id { get; set; }
    public string username { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public int? group_id { get; set; }
    public bool is_active { get; set; }
    public string? support_role { get; set; }
}