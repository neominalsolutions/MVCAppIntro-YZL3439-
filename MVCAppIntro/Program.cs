var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // uygulama Mvc þaablonu ile çalýþsýn

// Razor Pages Proje Template
// MVC Web Application Proje Template
// API Web Servis geliþtireme Proje Template
// Blazor Web Application Template

var app = builder.Build();

app.UseStaticFiles(); // wwwroot altýndaki css,js,image güven bunlarý uygula

app.UseRouting(); // uygulama da yönlendirme iþlemleri çalýþsýn.
// uygulama ilk açýldýðýnda anasayfadan açýlmasý için aþaðýdaki kuralý yazdýk.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // uygulamadan gelen istekler controllera yönlendirilsin ayarý yaptýk.
app.Run();
