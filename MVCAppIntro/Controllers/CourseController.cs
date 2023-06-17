using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAppIntro.Data;
using MVCAppIntro.Models;

namespace MVCAppIntro.Controllers
{
  public class CourseController : Controller
  {
    public IActionResult Index()
    {

      var db = new TestDbContext(); // sınıfa bağlan.
      // course çekilirken CourseTeacher bilgisinide çek yani joinle
      // eğer CourseTeacherId null değilse kayıt gelir.
      var clist = db.Courses.Include(x=> x.CourseTeacher).ToList(); // select Name,SurName from Students

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
