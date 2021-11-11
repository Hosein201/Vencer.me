using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Data.Repository;

namespace Data.Model
{
    public class User : IdentityUser<Guid>, IEntityDb
    {
        public User()
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
            this.RegisterDate = DateTime.Now;
        }
        public string FullName { get; set; }
        public Guid CountryId { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid CityId { get; set; }
       // public Guid JobId { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public string PathImgUser { get; set; }
        public Guid RefreshToken { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<BusinessFull> BusinessFulls { get; set; }
        public ICollection<SupportExchanges> SupportExchangeses { get; set; }
        public ICollection<Vencoin> Vencoins { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        public Shops Shop { get; set; }
      //  public Messages MessagesTo { get; set; }
      //  public Messages MessagesFrom { get; set; }
    }

    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .Property(p => p.UserName).IsRequired(true).HasMaxLength(20);
            builder.HasKey(h => h.Id);
            builder.Property(m => m.PhoneNumber).IsRequired(true).HasMaxLength(11);
            builder.Property(p => p.PasswordHash).IsRequired();
            
        }
    }
}
