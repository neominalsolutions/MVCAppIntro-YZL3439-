using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // uygulama Mvc þaablonu ile çalýþsýn

builder.Services.AddAuthentication("YZL3439")
  .AddCookie("YZL3439", option => // uygulamaya Cookie üzerinden kimlik doðrulama yapsýn
{
  option.Cookie.Name = "MyCookie";
  option.LoginPath = "/Account/Login"; // uygulama login sayfasýndan sürecine devam etsin
});

// Razor Pages Proje Template
// MVC Web Application Proje Template
// API Web Servis geliþtireme Proje Template
// Blazor Web Application Template

var app = builder.Build();

app.UseStaticFiles(); // wwwroot altýndaki css,js,image güven bunlarý uygula

app.UseRouting(); // uygulama da yönlendirme iþlemleri çalýþsýn.
// uygulama ilk açýldýðýnda anasayfadan açýlmasý için aþaðýdaki kuralý yazdýk.

app.UseAuthentication(); // sistemde login süreci varsa authentication middleware yazýyoruz.
app.UseAuthorization(); // Authorize attiribute çalýþsýn diye, yetkilendirme middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // uygulamadan gelen istekler controllera yönlendirilsin ayarý yaptýk.

//app.Lifetime.ApplicationStarted.Register(() =>
//{

//});


//app.Lifetime.ApplicationStopped.Register(() =>
//{
//  var context = app.Services.GetRequiredService<IHttpContextAccessor>();
//  context.HttpContext.Response.Cookies.Delete("MyCookie");

//});

app.Run();

