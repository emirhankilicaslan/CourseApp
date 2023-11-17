using System.ComponentModel.DataAnnotations;

namespace CourseApp.Data
{    
    public class Student
    {
        [Key]
        [Display(Name = "Öğrenci Id")]
        public int StudentId { get; set; }
        [Display(Name = "Öğrenci Adı")]
        public string? StudentName { get; set; }
        [Display(Name = "Öğrenci Soyadı")]
        public string? StudentSurname { get; set; }
        public string NameSurname {
            get
            {
                return this.StudentName + " " + this.StudentSurname;
            }
        }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
    }
}