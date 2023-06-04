using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCAppIntro.Data;

namespace MVCAppIntro.Controllers
{
  public class StudentController : Controller
  {
    // private TestDbContext db; // db ye controller içerisinde constructor üzerinden bağlanıyoruz. Mvc de bir class başka bir class'a bağlanacak ise bunu contructor içerisine yazarak yapabiliriz.

    //public StudentController(TestDbContext db)
    //{
    //  // Dependency Injection yöntemi diyoruz.
    //  this.db = db;
    //}

    [HttpGet]
    public IActionResult Index()
    {
      var db = new TestDbContext(); // sınıfa bağlan.
      var slist = db.Students.ToList(); // select Name,SurName from Students

      return View(slist);
    }

    // sayfaya gelen ilk istekler ise Http Get ile yapılır. Action üzerine [HttpGet] yazmazsak mvc bu action HttpGet olarak algılar. Bu sebeple Formdan veri gönderirken HttpPost yazmak zorundayız.
    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    // Eğer bir sayfada formdan birşey gönderiliyorsa HttpPost olan action çağırılır

    [HttpPost]
    public IActionResult Create(Student student) // student yeni öğrenci nesnesi
    {
      var db = new TestDbContext();
      db.Students.Add(student);
      db.SaveChanges();

      return RedirectToAction("Index"); // Kayıttan sonra tablo listeleme sayfasına yönlendir.
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
      // id sine göre veri tabanındaki student tablosundan ilgili kaydı bulduk ki view dolduralım. Bu sayede form sayfası dolu görüntülenecek.
      var db = new TestDbContext();
      var student = db.Students.Find(id); // find methodu id üzerinden bulur
      //var student1 = db.Students.FirstOrDefault(x => x.Name == "Ali");

      return View(student);
    }

    [HttpPost]
    public IActionResult Update(Student student) // student formdan yeni gelen student
    {
      var db = new TestDbContext();
      db.Students.Update(student);
      db.SaveChanges();

      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      var db = new TestDbContext();
      var student = db.Students.Find(id);

      // delete sayfasında silinmek istenen kaydın ekrandan silmeden önce gösterilmesi için yaptık.

      return View(student);
    }

    [HttpPost]
    public IActionResult Delete(Student student)
    {
      // silinecek olan kayıtlarda id alanın hiddenInput ile yakalamak yeterlidir.
      var db = new TestDbContext();
      // silinecek kaydı formdan gelen kaydın idsine göre bulduk
      db.Students.Remove(student);
      db.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}
