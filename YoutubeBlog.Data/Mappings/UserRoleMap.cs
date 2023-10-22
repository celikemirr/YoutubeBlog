using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("1CA28C13-822E-45FA-99F1-7AA01B89D792"),
                RoleId = Guid.Parse("B78E76DA-F0FD-4D53-A127-5778E157909E")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("7B3F84A7-3D85-4231-861B-D61C048E2380"),
                RoleId = Guid.Parse("174309FC-CF51-4EC4-8CB2-CE8DB8DC04F9")
            });
        }
    }
}
