using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsCategory;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class ListProductCategoryResult
{
    public List<Product>? products { get; set; }
}
