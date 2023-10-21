using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Repositories.Abstractions;
using YoutubeBlog.Data.Repositories.Concretes;
using YoutubeBlog.Data.UnitOfWorks;

namespace YoutubeBlog.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
        //Burada genişletme yöntemi kullanıyoruz (bir sınıfın veya türün mevcut işlevselliğini genişletmek amacıyla kullanılır)
        //Static bir sınıfta tanımlanmasının nedeni, bu tür genişletme yöntemlerinin nesne örneği oluşturmadan çağrılabilmesidir
        //AddScoped metodu, ASP.NET Core uygulamalarında servislerin nasıl yaşam döngüsüne sahip olacağını belirlemek için kullanılan bir konfigürasyon metodudur.
        //buradaki amacımız IRepository i nesnesini çağırdıgımızda bize Repository nesnesi oluşturması gerektiğini belirticez scope olarak ekleyerek
        //IRepository e yollanan her istekte Repository de getirilicektir
        //Program.cs kısmını temiz tutmak için veritabanını bağladımız kodumuzu buraya çekiyoruz
    }
}
