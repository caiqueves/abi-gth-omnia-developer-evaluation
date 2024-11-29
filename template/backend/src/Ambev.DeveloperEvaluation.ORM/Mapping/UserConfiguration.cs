using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        // Definindo a chave primária
        builder.HasKey(u => u.Id);

        // Configurando a coluna ID com UUID gerado automaticamente
        builder.Property(u => u.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        // Configurações para as propriedades de texto
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Phone)
            .HasMaxLength(20); // Definindo o comprimento máximo para o telefone

        // Configuração de conversão para Enum para Status e Role
        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .HasMaxLength(20);

        // Configuração de AddressId
        builder.Property(u => u.AddressId)
            .IsRequired();

        // Relacionamento com a tabela de Address
        builder.HasOne(u => u.Address)
            .WithMany() // Supondo que um endereço possa ter muitos usuários
            .HasForeignKey(u => u.AddressId)
            .OnDelete(DeleteBehavior.Cascade); // Ao excluir o usuário, o endereço será excluído

        // Configuração de CreateAt (data de criação)
        builder.Property(u => u.CreateAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP") // Usando a função SQL padrão para a data/hora atual
            .ValueGeneratedOnAdd();

        // Configuração de UpdateAt (data de atualização)
        builder.Property(u => u.UpdateAt)
            .HasDefaultValue(null) // Pode ser null inicialmente
            .ValueGeneratedOnAddOrUpdate(); // Atualiza automaticamente ao alterar
    }


}

