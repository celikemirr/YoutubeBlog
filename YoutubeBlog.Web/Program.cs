
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Extensions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();

//Oturum yönetimi, web uygulamalarýnda kullanýcýlarýn verileri arasýnda geçiþ yapabilmelerini ve durumlarýný takip edebilmelerini saðlayan bir mekanizmadýr(Session)
builder.Services.AddSession();


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//test projesi olduðu için bu özellikleri false belirliyoruz normalde böyle yapýlmaz

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    //Bu satýr, uygulamanýzdaki rol yönetimini yapýlandýrýr. RoleManager sýnýfý, rol oluþturma, düzenleme, silme ve diðer rol yönetimi iþlemlerini kolaylaþtýrýr.
    .AddEntityFrameworkStores<AppDbContext>()
    //Bu satýr, ASP.NET Identity'nin veritabanýný yönetmek için Entity Framework Core'u kullanacaðýnýzý belirtir. 
    .AddDefaultTokenProviders();
//Bu satýr, varsayýlan kimlik doðrulama belirteçlerini etkinleþtirir.
//Kimlik doðrulama belirteçleri, kullanýcý hesaplarýna sýfýrlama parolasý veya e-posta onay belirteçleri gibi ek iþlevselliði ekler.
//Bu belirteçler, kullanýcýlarýn kimliklerini doðrulama ve hesaplarýný koruma iþlemlerinde kullanýlýr.

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
    //cookie nin sistemde ne kadar tutulacaðý anlamýna geliyor
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
