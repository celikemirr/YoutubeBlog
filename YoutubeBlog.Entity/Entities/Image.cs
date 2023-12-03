using YoutubeBlog.Core.Entities;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Entity.Entities
{
    public class Image : EntityBase
    {
        public Image()
        {
            
        }
        public Image(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }
        //başka bir kişi projeye erişim yaptığında ve bakmak istediğinde entity katmanındaki tablelarımın içine ne geleceğine tek tek bakmaması için bu uygulamayı yapıp
        //içinde nelerin bulunması gerektiğini bu şekilde söylüyoruz    
        public string FileName { get; set; }
        public string FileType { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
