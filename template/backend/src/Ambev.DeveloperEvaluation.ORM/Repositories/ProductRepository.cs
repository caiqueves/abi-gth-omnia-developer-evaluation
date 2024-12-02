using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;

    
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new products in the database
    /// </summary>
    /// <param name="product">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        //await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    /// <summary>
    /// Retrieves a product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(o => o.Id == id)
            .Include(ads => ads.Rating)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(o => o.Title == title)
            .Include(ads => ads.Rating)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public IQueryable<Product> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _context.Products.Where(static c => c.Id != null)
            .Include(ads => ads.Rating);
    }

    public List<string> GetAllByCategoryAsync(CancellationToken cancellationToken = default)
    {
        return _context.Products.Select(c => c.Category).Distinct().ToList();
    }

    /// <summary>
    /// Deletes a product from the database
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the product was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product == null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        var existingProduct = await _context.Products.FindAsync(new object[] { product.Id }, cancellationToken);

        if (existingProduct == null)
        {
            return new Product { }; 
        }

        existingProduct.Title = product.Title;
        existingProduct.Price = product.Price;
        existingProduct.Amount = product.Amount;
        existingProduct.Description = product.Description;
        existingProduct.Category = product.Category;
        existingProduct.Image = product.Image;

        _context.Products.Update(existingProduct);

        try
        {
            //await _context.SaveChangesAsync(cancellationToken);
            return existingProduct; 
        }
        catch (Exception)
        {
            
            return new Product { }; 
        }
    }

    public async Task<Product> UpdateAmountAsync(Guid Id, int Amount, CancellationToken cancellationToken = default)
    {
        var existingProduct = await _context.Products.FindAsync(new object[] { Id }, cancellationToken);

        if (existingProduct == null)
        {
            return new Product { };
        }

        existingProduct.Amount = Amount;

        _context.Products.Update(existingProduct);

        try
        {
            _context.SaveChangesAsync(cancellationToken);
            return existingProduct;
        }
        catch (Exception)
        {
            return new Product { };
        }
    }
}
