
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Extensions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();

//Oturum y�netimi, web uygulamalar�nda kullan�c�lar�n verileri aras�nda ge�i� yapabilmelerini ve durumlar�n� takip edebilmelerini sa�layan bir mekanizmad�r(Session)
builder.Services.AddSession();


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//test projesi oldu�u i�in bu �zellikleri false belirliyoruz normalde b�yle yap�lmaz

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    //Bu sat�r, uygulaman�zdaki rol y�netimini yap�land�r�r. RoleManager s�n�f�, rol olu�turma, d�zenleme, silme ve di�er rol y�netimi i�lemlerini kolayla�t�r�r.
    .AddEntityFrameworkStores<AppDbContext>()
    //Bu sat�r, ASP.NET Identity'nin veritaban�n� y�netmek i�in Entity Framework Core'u kullanaca��n�z� belirtir. 
    .AddDefaultTokenProviders();
//Bu sat�r, varsay�lan kimlik do�rulama belirte�lerini etkinle�tirir.
//Kimlik do�rulama belirte�leri, kullan�c� hesaplar�na s�f�rlama parolas� veya e-posta onay belirte�leri gibi ek i�levselli�i ekler.
//Bu belirte�ler, kullan�c�lar�n kimliklerini do�rulama ve hesaplar�n� koruma i�lemlerinde kullan�l�r.

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "YoutubeBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
    config.SlidingExpiration = true;
    //cookie nin sistemde ne kadar tutulaca�� anlam�na geliyor
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
