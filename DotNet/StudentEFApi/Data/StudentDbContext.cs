using Microsoft.EntityFrameworkCore;
using StudentEFApi.Model;

namespace StudentEFApi.Data
{
    public class StudentDbContext : DbContext
    {

        public StudentDbContext (DbContextOptions<StudentDbContext> options)
            : base(options)
        {

        }

        public DbSet<Student> student { get; set; }
    }
}
