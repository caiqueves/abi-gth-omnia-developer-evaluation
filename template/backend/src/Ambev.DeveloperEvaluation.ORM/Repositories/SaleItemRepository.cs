using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Provides implementation of <see cref="ISaleItemRepository"/> using Entity Framework Core.
/// </summary>
public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Creates a new instance of <see cref="SaleItemRepository"/>.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task AddAsync(SaleItem saleItem)
    {
        await _context.SaleItems.AddAsync(saleItem);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(SaleItem saleItem)
    {
        _context.SaleItems.Update(saleItem);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id)
    {
        var saleItem = await _context.SaleItems.FindAsync(id);
        if (saleItem != null)
        {
            _context.SaleItems.Remove(saleItem);
            await _context.SaveChangesAsync();
        }
    }

    /// <inheritdoc/>
    public async Task<SaleItem?> GetByIdAsync(Guid id)
    {
        return await _context.SaleItems
            .FirstOrDefaultAsync(si => si.Id == id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId)
    {
        return await _context.SaleItems
            .Where(si => si.Id == saleId)
            .ToListAsync();
    }
}