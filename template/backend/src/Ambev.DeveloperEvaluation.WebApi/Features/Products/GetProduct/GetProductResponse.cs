using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public record GetProductResponse
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