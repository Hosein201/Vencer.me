using System;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model
{
    public class Products: IEntityDb
    {
        public Products()
        {
            this.Id = Guid.NewGuid();
            this.RegisterDate = DateTime.Now;
            this.HasImg = false;
            this.HasFile = false;

        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public Guid TypeItem { get; set; }
        public bool HasImg { get; set; }
        public string PathImg { get; set; }
        public bool HasFile { get; set; }
        public string PathFile { get; set; }
        public long CountItem { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public Guid ShopId { get; set; }
        [ForeignKey(nameof(ShopId))]
        public Shops Shop { get; set; }
    }

    public class ShopItemsEntityConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");
            builder.HasOne<Shops>(h => h.Shop)
                .WithMany(w => w.Products).HasForeignKey(f => f.ShopId);
        }
    }
}