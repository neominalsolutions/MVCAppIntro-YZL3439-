var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // uygulama Mvc �aablonu ile �al��s�n

// Razor Pages Proje Template
// MVC Web Application Proje Template
// API Web Servis geli�tireme Proje Template
// Blazor Web Application Template

var app = builder.Build();

app.UseStaticFiles(); // wwwroot alt�ndaki css,js,image g�ven bunlar� uygula

app.UseRouting(); // uygulama da y�nlendirme i�lemleri �al��s�n.
// uygulama ilk a��ld���nda anasayfadan a��lmas� i�in a�a��daki kural� yazd�k.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // uygulamadan gelen istekler controllera y�nlendirilsin ayar� yapt�k.
app.Run();
