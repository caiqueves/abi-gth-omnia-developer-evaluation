using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;


public class GetProductResult
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;    // O nome do produto
    public decimal Price { get; set; }     // O preço do produto
    public string Description { get; set; } = string.Empty; // A descrição do produto
    public string Category { get; set; } = string.Empty;   // A categoria do produto
    public string Image { get; set; } = string.Empty;
    public Rating? Rating { get; set; }
}
