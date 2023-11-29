using AutoMapper;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOS.Articles;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;


namespace YoutubeBlog.Service.Services.Concretes
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        //alttaki metotta demek istediğimiz bütün makaleleri kategorileriyle beraber getir ama silinmeyenleri getirtmek için bu şekilde isimlendiriyoruz
        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x =>!x.IsDeleted, x=>x.Category);
            //x in başındaki ünlem false değer olması için konulmuştur normalde x true olarak gelir
            var map = mapper.Map<List<ArticleDto>>(articles);

            return map;
        }
    }
    //servislerde filtreleme kullanabileceğimiz için örnek oluşturulma tarihi en son olanı başta getir gibi
    //bunun gibi durumlar söz konusu olacağı için bu yapıyı kullanıcaz
}
