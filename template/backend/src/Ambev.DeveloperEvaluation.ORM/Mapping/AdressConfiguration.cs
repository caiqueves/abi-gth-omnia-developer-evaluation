using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            // Definindo a chave primária
            builder.HasKey(a => a.Id);

            // Definindo a coluna 'Id' como tipo UUID e gerando valor por padrão
            builder.Property(a => a.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            // Definindo as propriedades (campos) da tabela 'Address'
            builder.Property(a => a.Street)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(a => a.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Zipcode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(a => a.Number)
                   .IsRequired();

            builder.Property(a => a.GeolocationId)
                   .IsRequired();

            builder.HasOne(a => a.Geolocation) 
                   .WithOne()  
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
