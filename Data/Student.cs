using System.ComponentModel.DataAnnotations;

namespace CourseApp.Data
{    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
    }
}