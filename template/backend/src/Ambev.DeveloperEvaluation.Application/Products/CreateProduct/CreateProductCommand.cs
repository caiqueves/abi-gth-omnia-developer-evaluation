using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;


public class CreateProductCommand : IRequest<CreateProductResult>
{
    public string Title { get; set; } = string.Empty;    // O nome do produto
    public decimal Price { get; set; }     // O preço do produto

    public int Amount { get; set; }
    public string Description { get; set; } = string.Empty; // A descrição do produto
    public string Category { get; set; } = string.Empty;   // A categoria do produto
    public string Image { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public int Count { get; set; }
    public ValidationResultDetail Validate()
    {
        var validator = new CreateProductComandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}