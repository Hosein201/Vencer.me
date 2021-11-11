using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Repository;

namespace Data.Model
{
    public class BusinessFull : IEntityDb
    {
        public BusinessFull()
        {
            Id =Guid.NewGuid();
            RegisterDate = DateTime.Now;
            IsActive = true;
        }
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "لطفالینک مورد نظر خود را برای کسب کار خود وارد کنید"), MaxLength(50)]
        public string BusinessUrl { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public BioBusiness Bio‌Business { get; set; }
    }

    public class BusinessFullEntityTypeConfiguration : IEntityTypeConfiguration<BusinessFull>
    {
        public void Configure(EntityTypeBuilder<BusinessFull> builder)
        {

            builder.Property(p => p.BusinessUrl).IsRequired(true);

            builder.HasOne<User>(h => h.User)
              .WithMany(w => w.BusinessFulls).HasForeignKey(f => f.UserId);

            builder.HasOne<BioBusiness>(h => h.Bio‌Business)
                .WithOne(w => w.BusinessFull).HasForeignKey<BioBusiness>(f => f.BusinessFullId);
        }
    }
}
