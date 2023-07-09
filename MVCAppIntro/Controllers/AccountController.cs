using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAppIntro.Data;
using MVCAppIntro.Models;
using System.Security.Claims;

namespace MVCAppIntro.Controllers
{
  public class AccountController : Controller
  {
    [HttpGet]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel model)
    {
      var db = new TestDbContext();
      // user rollerinin joinle sonra bu user rolleri ile birlikte dbden bul
      var user = db.Users.Include(c=> c.Roles).FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

      if(user is not null)
      {
        List<Claim> claims = new List<Claim>(); // login olurken sistemde cookiede saklanacak kullanıcı değerlerini listeye atıcağımız liste

        var claim1 = new Claim(ClaimTypes.Name, user.UserName);
        var claim2 = new Claim(ClaimTypes.Email, user.Email);
        
        claims.Add(claim1);
        claims.Add(claim2);

        foreach (var role in user.Roles)
        {
          var claim3 = new Claim(ClaimTypes.Role, role.Name);
          claims.Add(claim3);
        }
        

        var identity = new ClaimsIdentity(claims, "YZL3439"); // login olucak kişi için yukarıdaki özelliklerde bir kimlik oluşturduk

        var claimPrinciple = new ClaimsPrincipal(identity); // bu kimlik bilgilerini sisteme oturum açacak olan sınıfa atamasını yaptık

        //var claimsPrinciples = new ClaimsPrincipal(new ClaimsIdentity(claims));

        var authProps = new AuthenticationProperties(); // yani kimlik doğrulamada oluşacak olan cookie kalıcı olup olmayacağı gibi bilgileri burada bu sınıf üzerinden belirleriz.
        authProps.IsPersistent = model.RememberMe; // cokie kalıcı olsun. session bazlı olmasın demek.

        //authProps.AllowRefresh = true;
       
        // remember me seçilmez ise session değeri 20 dk olarak ayarlanır. 20 dakika sonra oturum düşer.

        if(model.RememberMe)
        {
          authProps.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30); // Eğer kullanıcı beni hatılayı seçtiyse 1 aylık cookie seçmediyse 1 gün içerisinde oturum düşsün.
        }

        HttpContext.SignInAsync(claimPrinciple,authProps); // Sistemde Cookie oluşturmamızı sağlayacak kod

        return RedirectToAction("Index", "Home");

      }
      else
      {
        return View();
      }

    }


    [Authorize] // not oturum açmış bir hesap sadece bu methodu çağırabilir. o yüzden authorize attribute koyduk
    [HttpGet]
    public IActionResult LogOut()
    {
      HttpContext.SignOutAsync("YZL3439"); // Authentication Scheme Ödemli, yazmayı unutmayalım.

      return RedirectToAction("Index", "Home"); // logout olunca beni anasayfaya yönlendir.
    }


    [HttpGet]
    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterModel model)
    {
      if(ModelState.IsValid)
      {
        try
        {
          var user = new User();
          user.Email = model.Email;
          user.UserName = model.UserName;
          user.Password = model.Password;

          var db = new TestDbContext();
          db.Users.Add(user);

          db.SaveChanges();

          ViewBag.Message = "Kayıt başarılı sisteme giriş yapabilirsiniz";
        }
        catch (Exception )
        {
          ModelState.AddModelError("Email", "Aynı E-posta adresinden mevcut");
          ModelState.AddModelError("UserName", "Aynı Username mevcut");

        }
      }

      return View();

    }

  }
}
