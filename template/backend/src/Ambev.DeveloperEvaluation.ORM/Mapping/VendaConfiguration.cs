using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
   
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {

            builder.ToTable("Vendas");

            
            builder.HasKey(v => v.Id);

            
            builder.Property(v => v.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            
            builder.Property(v => v.DataVenda)
                .IsRequired();

            builder.Property(v => v.ValorTotal)
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.Cancelado)
                .IsRequired();

            
            builder.HasOne(v => v.Cliente)  
                .WithMany()  
                .HasForeignKey(v => v.ClienteId)  
                .OnDelete(DeleteBehavior.Restrict);  

            
            //builder.HasOne(v => v.Filial)  
            //    .WithMany()  
            //    .HasForeignKey(v => v.FilialId) 
            //    .OnDelete(DeleteBehavior.Restrict);  

            
            builder.HasMany(v => v.VendaProdutos) 
                .WithOne()  
                .HasForeignKey(vp => vp.VendaId)  
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }

}
