using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Defines the operations for managing sales in the data store.
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Adds a new sale to the data store.
    /// </summary>
    /// <param name="sale">The sale entity to be added.</param>
    Task AddAsync(Sale sale);

    /// <summary>
    /// Updates an existing sale in the data store.
    /// </summary>
    /// <param name="sale">The sale entity with updated data.</param>
    Task UpdateAsync(Sale sale);

    /// <summary>
    /// Deletes a sale from the data store.
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete.</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Gets a sale by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the sale.</param>
    /// <returns>The sale entity if found; otherwise, null.</returns>
    Task<Sale?> GetByIdAsync(Guid id);

    /// <summary>
    /// Gets all sales from the data store.
    /// </summary>
    /// <returns>A collection of all sales.</returns>
    Task<IEnumerable<Sale>> GetAllAsync();
}
