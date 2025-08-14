using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class ListProductResult
{
    public List<Product>? products { get; set; }
}
