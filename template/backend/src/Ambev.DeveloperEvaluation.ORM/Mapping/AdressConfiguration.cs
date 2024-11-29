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

            // Definindo a propriedade 'GeolocationId' como obrigatória
            builder.Property(a => a.GeolocationId)
                   .IsRequired();

            // Definindo o relacionamento com a tabela 'Geolocation' (assumindo que existe uma entidade chamada 'Geolocation')
            builder.HasOne(a => a.Geolocation)  // Assumindo que a entidade 'Address' tem uma propriedade de navegação 'Geolocation'
                   .WithMany()  // Relacionamento de 1 para N (1 Geolocation pode ter vários Endereços, dependendo do seu modelo)
                   .HasForeignKey(a => a.GeolocationId)  // Definindo a chave estrangeira 'GeolocationId'
                   .OnDelete(DeleteBehavior.Cascade);  // Definindo o comportamento de exclusão em cascata (opcional, mas pode ser útil)
        }
    }
}
