using Microsoft.EntityFrameworkCore;
using SaaSDashboard.Models;

namespace SaaSDashboard.Data;

public class MariaDBContext : DbContext
{
    public MariaDBContext(DbContextOptions<MariaDBContext> options) : base(options)
    {
    }
    
    public virtual DbSet<UserModel> system_users => Set<UserModel>();
}