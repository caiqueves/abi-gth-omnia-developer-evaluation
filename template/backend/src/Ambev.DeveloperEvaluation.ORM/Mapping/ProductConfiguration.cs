using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");


            builder.HasKey(p => p.Id);


            builder.Property(p => p.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");


            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);


            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");


            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(p => p.Category)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(p => p.Image)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(p => p.RatingId)
                .IsRequired();

          
            builder.HasOne(p => p.Rating) 
                .WithMany() 
                .HasForeignKey(p => p.RatingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Amount)
                .IsRequired(); 
        }
    }
}
