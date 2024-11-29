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

            // Definindo a chave primária
            builder.HasKey(p => p.Id);

            // Configuração do campo 'Id' com UUID
            builder.Property(p => p.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            // Configuração do 'Title' (obrigatório e com limite de tamanho)
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            // Configuração do 'Price' (tipo decimal com precisão e escala)
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            // Configuração da 'Description' (obrigatória e com limite de tamanho)
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(100);

            // Configuração da 'Category' (obrigatória e com limite de tamanho)
            builder.Property(p => p.Category)
                .IsRequired()
                .HasMaxLength(100);

            // Configuração da 'Image' (obrigatória e com limite de tamanho)
            builder.Property(p => p.Image)
                .IsRequired()
                .HasMaxLength(100);

            // Definindo o relacionamento com 'RatingId' (presumindo que seja uma chave estrangeira)
            builder.Property(p => p.RatingId)
                .IsRequired();

            // Se 'Rating' é uma entidade relacionada, faça o mapeamento do relacionamento
            builder.HasOne(p => p.Rating) // Assumindo que 'Rating' seja uma entidade relacionada
                .WithMany() // Um Produto tem um Rating, mas um Rating pode ter muitos Produtos (ajustar conforme necessário)
                .HasForeignKey(p => p.RatingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
