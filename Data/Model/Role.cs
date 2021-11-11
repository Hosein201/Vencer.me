using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Repository;

namespace Data.Model
{
    public class Role : IdentityRole<Guid>, IEntityDb
    {
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public int CodeRole { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }

    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.Property(p=>p.CodeRole).UseIdentityColumn<int>();
        }
    }
}
