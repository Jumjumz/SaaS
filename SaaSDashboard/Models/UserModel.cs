using System.ComponentModel.DataAnnotations;

namespace SaaSDashboard.Models;

public class UserModel
{
    public int id { get; set; }
    [StringLength(255)]
    public string employee_id { get; set; }
    [StringLength(255)]
    public string username { get; set; }
    [StringLength(255)]
    public string name { get; set; }
    [StringLength(255)]
    public string email { get; set; }
    [StringLength(255)]
    public string password { get; set; }
    public int? group_id { get; set; }
    public bool is_active { get; set; }
    [StringLength(255)]
    public string? support_role { get; set; }
    
}