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

		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
            var userId = Guid.Parse("1CA28C13-822E-45FA-99F1-7AA01B89D792");
            var article = new Article
            {
                Title = articleAddDto.Title,
                Content = articleAddDto.Content,
                CategoryId = articleAddDto.CategoryId,
                UserId = userId,
            };

            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();

		}

		//alttaki metotta demek istediğimiz bütün makaleleri kategorileriyle beraber getir ama silinmeyenleri getirtmek için bu şekilde isimlendiriyoruz
		public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x =>!x.IsDeleted, x=>x.Category);
            //x in başındaki ünlem false değer olması için konulmuştur normalde x true olarak gelir
            var map = mapper.Map<List<ArticleDto>>(articles);

            return map;
        }
		public async Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleId)
		{
			var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category);
			//x in başındaki ünlem false değer olması için konulmuştur normalde x true olarak gelir
			var map = mapper.Map<ArticleDto>(article);

			return map;
		}

        public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
            
            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryId;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
        }
	}
    //servislerde filtreleme kullanabileceğimiz için örnek oluşturulma tarihi en son olanı başta getir gibi
    //bunun gibi durumlar söz konusu olacağı için bu yapıyı kullanıcaz
}
