using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOS.Articles;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;


namespace YoutubeBlog.Service.Services.Concretes
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ClaimsPrincipal _user;

		public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
		}

		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
			var userId = _user.GetLoggedInUserId(); // Id ile giriş yapan kullanıcıyı bulma
			var userEmail = _user.GetLoggedInEmail(); // E mail ile giriş yapan kullanıcıyı bulma

			var imageId = Guid.Parse("10C694E0-0796-4AB4-B664-C8B74830CA68");
			var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, userEmail, articleAddDto.CategoryId, imageId);


			await unitOfWork.GetRepository<Article>().AddAsync(article);
			await unitOfWork.SaveAsync();

		}

		//alttaki metotta demek istediğimiz bütün makaleleri kategorileriyle beraber getir ama silinmeyenleri getirtmek için bu şekilde isimlendiriyoruz
		public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
		{
			var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
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

		public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
		{
			var userEmail = _user.GetLoggedInEmail(); // E mail ile giriş yapan kullanıcıyı bulma

			var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);

			article.Title = articleUpdateDto.Title;
			article.Content = articleUpdateDto.Content;
			article.CategoryId = articleUpdateDto.CategoryId;
			article.ModifiendDate = DateTime.Now;
			article.ModifiendBy = userEmail;

			await unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await unitOfWork.SaveAsync();

			return article.Title;
		}
		public async Task<string> SafeDeleteArticleAsync(Guid articleId)
		{
			var userEmail = _user.GetLoggedInEmail(); // E mail ile giriş yapan kullanıcıyı bulma
			var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

			article.IsDeleted = true;
			article.DeletedDate = DateTime.Now;
			article.DeletedBy = userEmail;

			await unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await unitOfWork.SaveAsync();

			return article.Title;
		}
	}
	//servislerde filtreleme kullanabileceğimiz için örnek oluşturulma tarihi en son olanı başta getir gibi
	//bunun gibi durumlar söz konusu olacağı için bu yapıyı kullanıcaz
}
