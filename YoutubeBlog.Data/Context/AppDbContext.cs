using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Context
{
    //identity yapımızı kurarken ilk önce identity entityframeworkcore sınıfımızı indiriyoruz
    //sonrasında microsofttan örnek alarak baktıgımız entitylerimi oluşturuyoruz
    //daha sonra hazır kütüphanede ki sınıfları miras olarak entitylerimize ekliyoruz
    //bunu da dbcontext kısmında belirtip miras alınan sınıfı IdentityDbContext olarak değiştiriyoruz
    //daha sonra base olarak onmodelcreating methodunu çağırıyoruz
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
    {
        protected AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
    }
}
