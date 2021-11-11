using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class Messages //: IEntityDb
    {
        public Messages()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string TitelMessage { get; set; }
        public string BodyMessage { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsRead { get; set; }

        public Guid To { get; set; }
        [ForeignKey(nameof(To))]
        public User ToUser { get; set; }

        public Guid From { get; set; }
        [ForeignKey(nameof(From))]
        public User FromUser { get; set; }
    }

    //public class MessagesEntityConfiguration : IEntityTypeConfiguration<Messages>
    //{
    //    public void Configure(EntityTypeBuilder<Messages> builder)
    //    {
    //        builder.ToTable("Messages");
    //        builder.HasOne<User>(h => h.ToUser).WithOne(w => w.MessagesTo).HasForeignKey<Messages>(f=> f.To);
    //        builder.HasOne<User>(h => h.FromUser).WithOne(w => w.MessagesFrom).HasForeignKey<Messages>(f => f.From);
    //    }
    //}
}
