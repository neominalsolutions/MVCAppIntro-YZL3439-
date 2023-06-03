using Microsoft.AspNetCore.Mvc;
using MVCAppIntro.Models;

namespace MVCAppIntro.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {

      var plist = new List<ProductModel>();
      var p1 = new ProductModel();
      p1.Fiyat = 10;
      p1.Kategori = "Giyim";
      p1.Stok = 10;
      p1.İsim = "Ürün-1";

      plist.Add(p1);

      var p2 = new ProductModel
      {
        İsim = "Ürün-2",
        Kategori = "Giyim",
        Stok = 20,
        Fiyat = 100
      };

      plist.Add(p2);

      // view'e action içinde oluşturduğumuz veriyi gönderiyoruz
      return View(plist);
    }
  }
}
