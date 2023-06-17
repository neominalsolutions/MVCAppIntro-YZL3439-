using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAppIntro.Data;
using MVCAppIntro.Models;
using System.Linq;
using System.Runtime.InteropServices;

namespace MVCAppIntro.Controllers
{
  public class CourseController : Controller
  {
    public IActionResult Index(int sayfa = 1, string aranan = "", string fiyatSiralama = "asc")
    {
      var db = new TestDbContext(); // sınıfa bağlan.
      // course çekilirken CourseTeacher bilgisinide çek yani joinle
      // eğer CourseTeacherId null değilse kayıt gelir.
      // sayfalama yapmadan önce sıralama yaparız.
      var clist = db.Courses.Include(x => x.CourseTeacher)
        .Where(x => x.StartDate.Value > DateTime.Now.Date) // henüz başlamış kursları getir.
        .Where(x => EF.Functions.Like(x.Name, "%" + aranan + "%"))
        .OrderBy(x => x.StartDate).ToList(); // başlangıç saatine göre sırala
 


      if(fiyatSiralama == "asc")
      {
        clist = clist.OrderBy(x => x.Price).ToList(); // select Name,SurName from Students.ToList();
      }
      else if(fiyatSiralama == "desc")
      {
        clist =  clist.OrderByDescending(x => x.Price).ToList();
      }


      // sıralandıktan sonra tekrar sıralamaya göre sayfalansın diye kodu buraya aldık.
      // sıralamaya göre sayfalama doğru çalışsın diye yaptık.
      clist = clist.Skip((sayfa - 1) * 5) // kayıt atlatma
        .Take(5) // kayıt alma
        .ToList();


      // sayfa sayısı hesaplama algoritması

      // select Count(*) from Courses db.Courses.Count()
      // her sayfada 5 adet kayıt görüneceği için kayıt sayısını 5 böldük. ve sayfa sayısını bulduk
      double kayitSayisi = Convert.ToDouble(db.Courses
        .Where(x => x.StartDate.Value > DateTime.Now.Date)
        .Where(x => EF.Functions.Like(x.Name, "%" + aranan + "%"))
        .Count());
      int sayfaSayisi = Convert.ToInt32(Math.Ceiling(kayitSayisi / 5)); // 11/5 2.1 => 3 yuvarlamamız lazım.olacağı için Convert.ToInt32 ile sayfa sayısını int tamsayı yaptık.
                                                                        // yukarı yuvarlama Ceiling

      ViewBag.SayfaSayisi = sayfaSayisi; // View'e göndeririz.
      ViewBag.OncekiSayfa = sayfa == 1 ? 1: sayfa - 1; // sayfa 1 ise zaten önceki sayfam olamaz.
      ViewBag.SonrakiSayfa = sayfa == sayfaSayisi ? sayfaSayisi : sayfa + 1; // son sayfadaysam zaten sayfa sondur, değilsem sonraki sayfa suanki sayfa + 1 olur.
      ViewBag.Aranan = aranan;
      ViewBag.Sayfa = sayfa;
      ViewBag.fiyatSiralama = fiyatSiralama;



      return View(clist);
    }


    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }


    [HttpPost]
    public IActionResult Create(Course course)
    {
      // kodun veri tabanına gitmeden önce kontrolden geçmesine olayına validasyon diyoruz.



      if (course.StartDate > course.EndDate)
      {
        ModelState.AddModelError("StartDate", "Başlangıç tarihi biriş tarihinden büyük olmaz");
      }


      // Validasyondan geçtiysek
      if (ModelState.IsValid)
      {
        var db = new TestDbContext();
        db.Courses.Add(course);
        db.SaveChanges();

        ModelState.Clear(); // Formu boşaltırız.

        ViewBag.message = "Kayıt Başarılı";
      }


      return View();
    }

    [HttpGet]
    public IActionResult AssingTeacherToCourse()
    {
      var db = new TestDbContext();
      ViewBag.Teachers = db.Teachers.ToList(); // öğretmenler listesi
      ViewBag.Courses = db.Courses.ToList(); // kurslar listesi

      return View();
    }

    // Bazı durumlarda ekran databasedeki modeller için yetersiz kalır. Fazladan Databasedeki modellerin alanlarını formdan göndermek yerine sadece formdan gönderilecek olan alanları berlirleyi model klasörü içerisinde tanımlarız.

    [HttpPost]
    public IActionResult AssingTeacherToCourse(CourseTeacher courseTeacher)
    {
      var db = new TestDbContext();
      ViewBag.Teachers = db.Teachers.ToList(); // öğretmenler listesi
      ViewBag.Courses = db.Courses.ToList();
      //// sayfa post edilince 2 kişi için bir güncelleme yapıalcak ise burası tekrar doldurulur.

      if (ModelState.IsValid)
      {
        
        var c = db.Courses.FirstOrDefault(x=> x.Name == courseTeacher.CourseName);
        c.CourseTeacherId = courseTeacher.TeacherId;

        db.Courses.Update(c);
        db.SaveChanges();
      }


      return View();
    }

    // TeacherId
    // CourseId


  }
}
