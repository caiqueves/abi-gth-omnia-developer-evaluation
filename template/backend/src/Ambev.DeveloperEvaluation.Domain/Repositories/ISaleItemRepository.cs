using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Defines the operations for managing sale items in the data store.
/// </summary>
public interface ISaleItemRepository
{
    /// <summary>
    /// Adds a new sale item to the data store.
    /// </summary>
    /// <param name="saleItem">The sale item entity to be added.</param>
    Task AddAsync(SaleItem saleItem);

    /// <summary>
    /// Updates an existing sale item in the data store.
    /// </summary>
    /// <param name="saleItem">The sale item entity with updated data.</param>
    Task UpdateAsync(SaleItem saleItem);

    /// <summary>
    /// Deletes a sale item from the data store.
    /// </summary>
    /// <param name="id">The unique identifier of the sale item to delete.</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Gets a sale item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the sale item.</param>
    /// <returns>The sale item entity if found; otherwise, null.</returns>
    Task<SaleItem?> GetByIdAsync(Guid id);

    /// <summary>
    /// Gets all sale items for a specific sale.
    /// </summary>
    /// <param name="saleId">The unique identifier of the sale.</param>
    /// <returns>A collection of sale items for the given sale.</returns>
    Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId);
}
