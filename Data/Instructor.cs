using System.ComponentModel.DataAnnotations;

namespace CourseApp.Data
{
    public class Instructor
    {
        [Display(Name = "Öğretmen Id")]
        public int InstructorId { get; set; }
        [Display(Name = "Öğretmen Adı")]
        public string? InstructorName { get; set; }
        [Display(Name = "Öğretmen Soyadı")]
        public string? InstructorSurname { get; set; }
        public string NameSurname {
            get
            {
                return this.InstructorName + " " + this.InstructorSurname;
            }
        }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode =false)]
        [Display(Name = "Kurs Başlangıç Tarihi")]
        public DateTime StartingDate { get; set; }
    }
}