using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Dto;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;

public class CriarVendaCommand : IRequest<CriarVendaResult>
{   
    public Guid ClienteId { get; set; }  
    //public Guid FilialId { get; set; }   
    public DateTime DataVenda { get; set; } 

    public List<SaleItemDto>? ItensVenda { get; set; }

    // Construtor
    public ValidationResultDetail Validate()
    {
        var validator = new CriarVendaComandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
