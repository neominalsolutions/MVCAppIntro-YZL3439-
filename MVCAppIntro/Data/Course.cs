namespace MVCAppIntro.Data
{
  public class Course
  {
    public int Id { get; set; }
    public string Name { get; set; } // Ad
    public string Content { get; set; } // İcerik
    public decimal Price { get; set; } // Fiyat
    public int TotalHours { get; set; } // 300 saat Toplam Saat
    public DateTime StartDate { get; set; } // Baslangic Tarihi
    public DateTime EndDate { get; set; } // Bitis Tarihi

    // JOIN işlemleri için kullanırız.
    // Navigation Property yani gezinti property denir.

    public int? CourseTeacherId { get; set; } // int? diyerek boş geçilebilir bir foreign key tanımı yapıyoruz. Daha sonradan öğretmen atanabilir diye. ÖğretmenId

    public Teacher CourseTeacher { get; set; } // Kursun Eğitmeni

    public List<Student> CourseStudents { get; set; } // Kursa katılan öğrenciler


  }
}
