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
    public class GeolocationConfiguration : IEntityTypeConfiguration<Geolocation>
    {
        public void Configure(EntityTypeBuilder<Geolocation> builder)
        {
            builder.ToTable("Geolocation");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Lat)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Long)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
