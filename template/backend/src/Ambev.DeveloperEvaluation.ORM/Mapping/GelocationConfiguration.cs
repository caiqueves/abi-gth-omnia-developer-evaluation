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


            builder.HasKey(g => g.Id);


            builder.Property(g => g.Lat)
                .IsRequired()
                .HasColumnType("decimal(9, 6)"); 


            builder.Property(g => g.Long)
                .IsRequired()
                .HasColumnType("decimal(9, 6)"); 
        }
    }
}
