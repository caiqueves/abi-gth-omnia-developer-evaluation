using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new user.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateProductResult
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;    // O nome do produto
    public decimal Price { get; set; }     // O preço do produto
    public int Amount { get; set; }
    public string Description { get; set; } = string.Empty; // A descrição do produto
    public string Category { get; set; } = string.Empty;   // A categoria do produto
    public string Image { get; set; } = string.Empty;
    public Rating? Rating { get; set; }
}
