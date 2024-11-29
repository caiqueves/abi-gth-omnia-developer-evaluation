using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(a => a.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Image)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.RatingId)
                     .IsRequired();
        }
    }
}
