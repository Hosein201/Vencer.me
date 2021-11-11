using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;
using Data.Repository;

namespace Data.Model
{
    public class Lookups: IEntityDb
    {
        public Lookups()
        {
            Id = Guid.NewGuid();
            IsActive = true;
        }

       
        public Guid Id { get; set; }
        public string Type { get; set; }
        public int Code { get; set; }
        public string Title  { get; set; }
        public string Aux1 { get; set; }
        public string Aux2 { get; set; }
        public bool IsActive { get; set; }
    }
    public class LookupEntityTypeConfiguration : IEntityTypeConfiguration<Lookups>
    {
        public void Configure(EntityTypeBuilder<Lookups> builder)
        {
            builder.ToTable("Lookups");
            builder.HasIndex(s=> s.Id);
            builder.Property(s => s.Type).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Code).IsRequired();
        }
    }
}
