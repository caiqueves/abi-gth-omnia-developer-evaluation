using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{

    public class VendaProdutoConfiguration : IEntityTypeConfiguration<VendaProduto>
    {
        public void Configure(EntityTypeBuilder<VendaProduto> builder)
        {
            builder.ToTable("VendaProdutos");

            builder.HasKey(vp => new { vp.VendaId, vp.ProdutoId });

            builder.Property(vp => vp.VendaId)
                .HasColumnType("uuid");

            builder.Property(vp => vp.ProdutoId)
                .HasColumnType("uuid");

            builder.HasOne(vp => vp.Venda)  
                .WithMany(v => v.VendaProdutos)  
                .HasForeignKey(vp => vp.VendaId)  
                .OnDelete(DeleteBehavior.Cascade);  

            builder.HasOne(vp => vp.Produto)  
                .WithMany()  
                .HasForeignKey(vp => vp.ProdutoId)  
                .OnDelete(DeleteBehavior.Restrict);  

            builder.Property(vp => vp.Quantidade)
                .IsRequired();  

            builder.Property(vp => vp.PrecoUnitario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();  

            builder.Property(vp => vp.Desconto)
                .HasColumnType("decimal(18,2)")
                .IsRequired(); 

            builder.Property(vp => vp.ValorTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();  
        }
    }

}
