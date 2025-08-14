using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public record ListProductResponse
{
    public List<Product>? Data { get; set; }  // Lista de usuários
    public int TotalItems { get; set; }  // Total de itens no banco
    public int CurrentPage { get; set; }  // Página atual
    public int TotalPages { get; set; }  // Total de páginas

}
