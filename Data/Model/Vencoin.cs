using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class Vencoin : IEntityDb
    {
        public Vencoin()
        {
            this.Id = Guid.NewGuid();
            this.RegisterDate = DateTime.Now;
            this.ModifyDate = DateTime.Now;
            this.Cancel = false;
        }
        public Guid Id { get; set; }
        public int TypeSaleOrBuy { get; set; }
        public long Price { get; set; }
        public long Total { get; set; }
        public bool Cancel { get; set; }
        public int Condition { get; set; }
        public bool Complete { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
    public class VencoreEntityConfiguration : IEntityTypeConfiguration<Vencoin>
    {
        public void Configure(EntityTypeBuilder<Vencoin> builder)
        {
            builder.HasOne<User>(h => h.User)
                .WithMany(w => w.Vencoins).HasForeignKey(f => f.UserId);
        }
    }
}
