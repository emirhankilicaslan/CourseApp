using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CourseApp.Data;

namespace CourseApp.Models
{
    public class CourseViewModel
    {
        [Display(Name = "Kurs Id")]
        [Key]
        public int CourseId { get; set; }
        [Display(Name = "Kurs Adı")]
        public string? CourseName { get; set; }
        public int? InstructorId { get; set; }
        public  ICollection<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();
    }
}