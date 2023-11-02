using Microsoft.EntityFrameworkCore;

namespace CourseApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<Course> Courses = null!;
        public DbSet<Student> Students = null!;
        public DbSet<CourseRegistration> CourseRegistrations = null!;
    }
}