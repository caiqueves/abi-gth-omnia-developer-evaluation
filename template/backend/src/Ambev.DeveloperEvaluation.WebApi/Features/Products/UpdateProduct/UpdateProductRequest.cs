
namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;


public class UpdateProductRequest
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;   
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; } = string.Empty; 
    public string Category { get; set; } = string.Empty;   
    public string Image { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public int Count { get; set; }
}
