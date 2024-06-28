using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Models
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base(options)
        {
            
        }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
