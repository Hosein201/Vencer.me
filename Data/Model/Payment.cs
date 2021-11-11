using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nest;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Repository;

namespace Data.Model
{
    public class Payment : IEntityDb
    {
        public Payment()
        {
            this.Id = Guid.NewGuid();
            this.IsSite = true;
            this.RegisterDate = DateTime.Now;
            this.TransactionBetweenUser = false;
        }
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public bool Discount { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsComplete { get; set; }
        public bool IsSite { get; set; }
        public bool Increase { get; set; }
        public bool TransactionBetweenUser { get; set; }
        public string Authority { get; set; }
        public int Status { get; set; }
        public string RefID { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }

    public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne<User>(h => h.User)
            .WithMany(w => w.Payments).HasForeignKey(f => f.UserId);
        }
    }
}
