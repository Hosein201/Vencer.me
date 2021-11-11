using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model
{
    public class Shops: IEntityDb
    {
        public Shops()
        {
            this.Id = Guid.NewGuid();
            this.RegisterDate = DateTime.Now;

        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public Guid TypeShop { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public ICollection<Products> Products { get; set; }
    }

    public class ShopEntityConfiguration : IEntityTypeConfiguration<Shops>
    {
        public void Configure(EntityTypeBuilder<Shops> builder)
        {
            builder.ToTable("Shops");
            builder.HasOne<User>(h => h.User)
                .WithOne(w => w.Shop).HasForeignKey<Shops>(f => f.UserId);
        }
    }
}
