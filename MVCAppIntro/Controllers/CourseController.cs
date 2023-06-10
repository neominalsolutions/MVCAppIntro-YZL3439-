using Microsoft.AspNetCore.Mvc;

namespace MVCAppIntro.Controllers
{
  public class CourseController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
