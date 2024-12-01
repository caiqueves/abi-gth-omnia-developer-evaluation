using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.AspNetCore.Authentication;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for User entity operations
/// </summary>
public interface IProductRepository
{
    Task<Product> CreateAsync(Product user, CancellationToken cancellationToken = default);

    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    IQueryable<Product> GetAllAsync(CancellationToken cancellationToken = default);

    List<string> GetAllByCategoryAsync(CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Product> UpdateAsync(Product user, CancellationToken cancellationToken = default);

    Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

    Task<Product> UpdateAmountAsync(Guid Id, int Amount, CancellationToken cancellationToken = default);
}
