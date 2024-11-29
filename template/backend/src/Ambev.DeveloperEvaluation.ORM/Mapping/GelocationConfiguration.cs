using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class GeolocationConfiguration : IEntityTypeConfiguration<Geolocation>
    {
        public void Configure(EntityTypeBuilder<Geolocation> builder)
        {
            builder.ToTable("Geolocation");

            // Definindo a chave primária
            builder.HasKey(g => g.Id);

            // Definindo a propriedade 'Latitude' (Usando decimal para garantir precisão)
            builder.Property(g => g.Lat)
                .IsRequired()
                .HasColumnType("decimal(9, 6)"); // 9 dígitos no total e 6 casas decimais

            // Definindo a propriedade 'Longitude' (Usando decimal para garantir precisão)
            builder.Property(g => g.Long)
                .IsRequired()
                .HasColumnType("decimal(9, 6)"); // 9 dígitos no total e 6 casas decimais
        }
    }
}
