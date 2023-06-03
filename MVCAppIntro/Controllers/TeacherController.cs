using Microsoft.AspNetCore.Mvc;
using MVCAppIntro.Data;

namespace MVCAppIntro.Controllers
{
  public class TeacherController : Controller
  {
    public IActionResult Index()
    {
      var db = new TestDbContext();
      var tlist = db.Teachers.ToList();

      return View();
    }
  }
}
