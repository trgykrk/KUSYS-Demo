using KUSYS_Demo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KUSYS_Demo.DataAccess.Contexts
{
    public class KUSYSDemoContext : DbContext
    {
        public KUSYSDemoContext()
        {
        }

        public KUSYSDemoContext(DbContextOptions<KUSYSDemoContext> options) : base(options)
        {

        }

        public DbSet<Student> Students => this.Set<Student>();
        public DbSet<Course> Courses => this.Set<Course>();
        public DbSet<StudentCourse> StudentCourses => this.Set<StudentCourse>();
        public DbSet<User> Users => this.Set<User>();
        public DbSet<Role> Roles => this.Set<Role>();
    }
}
