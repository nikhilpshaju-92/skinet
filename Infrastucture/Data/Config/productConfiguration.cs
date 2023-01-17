using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Data.Config
{
    public class productConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=> p.Id).IsRequired();
            builder.Property(p=> p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=> p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p=> p.Price).HasColumnType("decimal(18,2)");

            builder.Property(p=> p.PictureUrl).IsRequired();

            builder.HasOne(b=> b.ProductBrand).WithMany()
                .HasForeignKey( p => p.ProductBrandId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t=> t.ProductType).WithMany()
                .HasForeignKey( p => p.ProductTypeId)
                 .OnDelete(DeleteBehavior.Cascade); 
        }
        public void Configurebrand(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(p => p.Id).IsRequired();
        }
    }
}