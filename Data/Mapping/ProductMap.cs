using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Name);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Property(p=>p.Price).IsRequired();
            builder.Property(p=>p.Stock).IsRequired();
        }
    }
}