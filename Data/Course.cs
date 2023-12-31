using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseApp.Data
{
    public class Course
    {
        [Display(Name = "Kurs Id")]
        [Key]
        public int CourseId { get; set; }
        [Display(Name = "Kurs Adı")]
        public string? CourseName { get; set; }
        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public  ICollection<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();
    }
}