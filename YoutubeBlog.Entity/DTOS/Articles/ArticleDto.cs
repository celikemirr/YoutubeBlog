using YoutubeBlog.Entity.DTOS.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOS.Articles
{
    public class ArticleDto
	{
		public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public Image Image { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
    //Projemizin belirli alanlarında sadece bu kısımları göstermek için
    //böyle bir katman oluşturuyoruz

    //bu dosyayı entity katmanında oluşturma amacımız katmanlar arasındaki referansların
    //tek yönlü olması içindir(tek yönlü = iki farklı sınıf arasındaki alanları eşlemek)
}
