using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Diagnostics; 
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations = null!;
    }
}