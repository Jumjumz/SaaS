using System.ComponentModel.DataAnnotations;

namespace SaaSDashboard.DTOs.Users;

public class GetAllDto
{
    public int id { get; set; }
    [Required]
    public string employee_id { get; set; }
    [Required]
    public string username { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
    public int? group_id { get; set; }
    public bool is_active { get; set; }
    [StringLength(255)]
    public string? support_role { get; set; }
}