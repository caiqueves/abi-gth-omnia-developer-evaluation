using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Dto;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;

public class AtualizarVendaComand : IRequest<AtualizarVendaResult>
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }  
    //public Guid FilialId { get; set; }   
    public DateTime DataVenda { get; set; } 

    public List<SaleItemDto>? ItensVenda { get; set; }


    public AtualizarVendaComand(Guid id)
    {
        Id = id;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new AtualizarVendaCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
