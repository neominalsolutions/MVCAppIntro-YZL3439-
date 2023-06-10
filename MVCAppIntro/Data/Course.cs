using System.ComponentModel.DataAnnotations;

namespace MVCAppIntro.Data
{
  // entity
  // idsi olan veri tabanınında kaydı tutulan nesneler
  public class Course
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Name alanı boş geçilemez")] // attribute
    [MaxLength(50)]
    public string Name { get; set; } // Ad

    [Required(ErrorMessage = "Kurs içeriği girmek zorundasınız")]
    [MaxLength(200)]
    public string Content { get; set; } // İcerik

    // required attribute çalışması için date,int,decimal gibi alanlar ? yani nullable tanımlı olmalıdır.

    [Range(45000,65000, ErrorMessage ="Kurs fiyatı 45 Bin ile 65 Bin arasında olabilir")]
    public decimal? Price { get; set; } // Fiyat

    [Range(200,320, ErrorMessage = "Kurslar 200 ile 320 saat arasında planlanabilir")]
    public int? TotalHours { get; set; } // 300 saat Toplam Saat

    [Required(ErrorMessage ="Başlangıç saati boş geçilemez")]
    public DateTime? StartDate { get; set; } // Baslangic Tarihi

    [Required(ErrorMessage = "Bitiş saati boş geçilemez")]
    public DateTime? EndDate { get; set; } // Bitis Tarihi

    // JOIN işlemleri için kullanırız.
    // Navigation Property yani gezinti property denir.

    public int? CourseTeacherId { get; set; } // int? diyerek boş geçilebilir bir foreign key tanımı yapıyoruz. Daha sonradan öğretmen atanabilir diye. ÖğretmenId

    // validasyonlara girmesin diye ? koyalım
    public Teacher? CourseTeacher { get; set; } // Kursun Eğitmeni

    public List<Student>? CourseStudents { get; set; } // Kursa katılan öğrenciler


  }
}
