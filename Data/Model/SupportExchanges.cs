using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class SupportExchanges : IEntityDb
    {
        public SupportExchanges()
        {
            this.Id = Guid.NewGuid();
            this.RegisterDate = DateTime.Now;
            this.HasFile = false;
            this.ConfirmedFile = false;
        }

        public Guid Id { get; set; }
        public int NumberOfTicket { get; set; }
        public int State { get; set; }
        public long AmountOfExchange { get; set; }
        public string Description { get; set; }
        public string AccountNumberOfBank { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool HasFile { get; set; }
        public bool ConfirmedFile { get; set; }
        public  string FilePath{ get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
    public class SupportExchangesEntityConfiguration : IEntityTypeConfiguration<SupportExchanges>
    {
        public void Configure(EntityTypeBuilder<SupportExchanges> builder)
        {
            builder.Property(p => p.NumberOfTicket).UseIdentityColumn<int>();
            builder.HasOne(s => s.User)
                .WithMany(w => w.SupportExchangeses).HasForeignKey(f => f.UserId);
            builder.Property(p => p.State).IsRequired(true);
        }
    }
}
