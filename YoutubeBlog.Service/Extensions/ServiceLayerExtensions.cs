using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
using YoutubeBlog.Service.FluentValidations;
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
			services.AddScoped<ICategoryService, CategoryService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //mevcut olan kullanıcıyı dönen değerlerden bu şekilde bulucaz


			services.AddAutoMapper(assambly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("en"); //dil seçeneği
            });
            //assambly bu sınıfın çağırıldıgı automapperınadd edildiği katmanın ismidir (service katmanı)

            return services;
        }
    }
}
