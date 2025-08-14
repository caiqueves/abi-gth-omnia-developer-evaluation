using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Provides implementation of <see cref="ISaleRepository"/> using Entity Framework Core.
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Creates a new instance of <see cref="SaleRepository"/>.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task AddAsync(Sale sale)
    {
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(Sale sale)
    {
        var existingSale = await _context.Sales
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == sale.Id);

        if (existingSale == null)
            throw new KeyNotFoundException($"Sale not found for Id {sale.Id}");

        // Atualiza propriedades de cabeçalho
        _context.Entry(existingSale).CurrentValues.SetValues(sale);

        // Sincroniza itens
        foreach (var item in sale.Items)
        {
            var existingItem = existingSale.Items.FirstOrDefault(i => i.Id == item.Id);

            if (existingItem == null)
            {
                // Novo item
                existingSale.AddItem(item.ProductName!,item.Quantity,item.UnitPrice);
            }
            else
            {
                // Atualiza item existente
                _context.Entry(existingItem).CurrentValues.SetValues(item);
            }
        }

        // Remove itens que não estão mais na venda
        foreach (var existingItem in existingSale.Items.ToList())
        {
            if (!sale.Items.Any(i => i.Id == existingItem.Id))
            {
                _context.Remove(existingItem);
            }
        }

        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id)
    {
        var sale = await _context.Sales.FindAsync(id);
        if (sale != null)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }
    }

    /// <inheritdoc/>
    public async Task<Sale?> GetByIdAsync(Guid id)
    {
        return await _context.Sales
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Sale>> GetAllAsync()
    {
        return await _context.Sales
            .Include(s => s.Items)
            .ToListAsync();
    }
}
