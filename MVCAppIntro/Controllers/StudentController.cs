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

    public IActionResult Index()
    {
      var db = new TestDbContext(); // sınıfa bağlan.
      var slist = db.Students.ToList(); // select Name,SurName from Students

      return View(slist);
    }
  }
}
