using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp .Net Core Denem Makalesi 1",
                Content = "ASP .NET Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\n",
                ViewCount = 15,
                CategoryId = Guid.Parse("5DDBDA80-1B6B-40C7-883C-09327C5DB051"),

                ImageId = Guid.Parse("10C694E0-0796-4AB4-B664-C8B74830CA68"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("1CA28C13-822E-45FA-99F1-7AA01B89D792")

            },
            new Article 
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Denem Makalesi 1",
                Content = "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\n",
                ViewCount = 15,
                CategoryId = Guid.Parse("C7BD74B3-9849-4543-920E-765685029892"),

                ImageId= Guid.Parse("C4C4D9EA-9E80-4F11-9FD4-6590B167C0A3"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("7B3F84A7-3D85-4231-861B-D61C048E2380")

            }

            ); ;
        }
    }
}
