using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
 
    public class FilialConfiguration : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {

            builder.ToTable("Filiais");


            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");


            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(f => f.Endereco)
                .IsRequired()
                .HasMaxLength(255);

            
            //builder.HasMany(f => f.Vendas) 
            //    .WithOne()  
            //    .HasForeignKey(v => v.FilialId) 
            //    .OnDelete(DeleteBehavior.Cascade); 
        }
    }

}
