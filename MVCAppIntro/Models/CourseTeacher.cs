

using System.ComponentModel.DataAnnotations;

namespace MVCAppIntro.Models
{
  public class CourseTeacher
  {

    [Required(ErrorMessage ="Kurs seçimi yapınız")]
    public string? CourseName { get; set; }

    [Required(ErrorMessage = "Öğretmen seçimi yapınız")]
    public int? TeacherId { get; set; }

  }
}
