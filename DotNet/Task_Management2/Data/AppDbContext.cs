using Microsoft.EntityFrameworkCore;
using Task_Management2.Model;
namespace Task_Management2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<TasksItem> tasksItems { get; set; }

    }
}
