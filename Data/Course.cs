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
    }
}