using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Service.Services.Concretes;

namespace YoutubeBlog.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assambly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService, ArticleService>();

            services.AddAutoMapper(assambly);
            //assambly bu sınıfın çağırıldıgı automapperınadd edildiği katmanın ismidir (service katmanı)

            return services;
        }
    }
}
