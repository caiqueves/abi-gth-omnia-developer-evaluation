using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Address> Addresss { get; set; }

    public DbSet<Geolocation> Geolocation { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Rating> Ratings { get; set; }

    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Filial> Filiais { get; set; }
    public DbSet<VendaProduto> VendaProdutos { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<User>()
            .HasOne(u => u.Address) // Um usuário tem um endereço
            .WithMany() // O endereço pode ter muitos usuários (ajuste conforme sua lógica)
            .HasForeignKey(u => u.AddressId)  // Definindo a chave estrangeira no lado do usuário
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Address>()
           .HasOne(a => a.Geolocation)
           .WithOne()  // Se for um para um
           .HasForeignKey<Address>(a => a.GeolocationId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<VendaProduto>()
            .HasKey(vp => new { vp.VendaId, vp.ProdutoId });

        modelBuilder.Entity<VendaProduto>()
            .HasOne(vp => vp.Venda)
            .WithMany(v => v.VendaProdutos)
            .HasForeignKey(vp => vp.VendaId);

        modelBuilder.Entity<VendaProduto>()
            .HasOne(vp => vp.Produto)
            .WithMany(p => p.VendaProdutos)
            .HasForeignKey(vp => vp.ProdutoId);
 
        base.OnModelCreating(modelBuilder);
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
        );

        return new DefaultContext(builder.Options);
    }
}