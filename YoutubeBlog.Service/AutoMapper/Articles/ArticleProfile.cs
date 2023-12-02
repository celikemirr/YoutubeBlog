using AutoMapper;
using YoutubeBlog.Entity.DTOS.Articles;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Articles
{
	//AutoMapper ı kullanmak için 2 adet kütüphane eklememiz gerekiyor automapper ve automapper dejection olmak üzere
	public class ArticleProfile : Profile
	{
		public ArticleProfile()
		{
			CreateMap<ArticleDto,Article>().ReverseMap();
			CreateMap<ArticleUpdateDto,Article>().ReverseMap();
			CreateMap<ArticleUpdateDto,ArticleDto>().ReverseMap();
			CreateMap<ArticleAddDto,Article>().ReverseMap();
		}
		//article ile işlem yapmak istersek articledto ile articledto ile işlem yapmak istersek article ile maplama yapabiliyoruz
	}
}
