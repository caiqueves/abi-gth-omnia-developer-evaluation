using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
   
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            // Definindo o nome da tabela no banco de dados
            builder.ToTable("Vendas");

            // Definindo a chave primária
            builder.HasKey(v => v.Id);

            // Definindo o tipo e a geração do Id (GUID)
            builder.Property(v => v.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            // Definindo as propriedades
            builder.Property(v => v.DataVenda)
                .IsRequired();

            builder.Property(v => v.ValorTotal)
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.Cancelado)
                .IsRequired();

            // Relacionamento com a tabela de Cliente (User)
            builder.HasOne(v => v.Cliente)  // Uma venda tem um cliente (usuario)
                .WithMany()  // Um cliente pode ter muitas vendas
                .HasForeignKey(v => v.ClienteId)  // Chave estrangeira para o cliente
                .OnDelete(DeleteBehavior.Restrict);  // Restrict para não excluir o cliente

            // Relacionamento com a tabela de Filial
            builder.HasOne(v => v.Filial)  // Uma venda tem uma filial
                .WithMany()  // Uma filial pode ter muitas vendas
                .HasForeignKey(v => v.FilialId)  // Chave estrangeira para a filial
                .OnDelete(DeleteBehavior.Restrict);  // Restrict para não excluir a filial

            // Relacionamento com a tabela de VendaProduto (muitos para muitos)
            builder.HasMany(v => v.VendaProdutos)  // Uma venda pode ter muitos produtos
                .WithOne()  // Um produto pode estar em muitas vendas (assumindo um relacionamento muitos-para-muitos)
                .HasForeignKey(vp => vp.VendaId)  // Chave estrangeira para a venda
                .OnDelete(DeleteBehavior.Cascade);  // Quando uma venda for excluída, os produtos associados também serão excluídos
        }
    }

}
