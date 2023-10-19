using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Article : EntityBase
    {
        //1 class diğer bir classı sadece 1 kere inheritance edebilir fakat interfaceler bu konuda sınırsızdır
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        

    }
}
