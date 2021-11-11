using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nest;

namespace Data.Model
{
    public class UserRoles:IdentityUserRole<Guid>, IEntityDb
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }

    public class UserRolesEntityConfiguration : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasOne(p => p.User).WithMany(w => w.UserRoles)
                .HasForeignKey(f=> f.UserId).IsRequired();

            builder.HasOne(p => p.Role).WithMany(w => w.UserRoles)
                .HasForeignKey(f=> f.RoleId).IsRequired();
        }
    }
}
