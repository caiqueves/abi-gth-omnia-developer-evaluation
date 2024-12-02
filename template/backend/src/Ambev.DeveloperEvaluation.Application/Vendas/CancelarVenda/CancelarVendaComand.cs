using Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CancelarVenda;

public class CancelarVendaCommand : IRequest<CancelarVendaResult>
{
    public Guid Id { get; set; }

    public CancelarVendaCommand(Guid id)
    {
        Id = id;
    }
    public ValidationResultDetail Validate()
    {
        var validator = new CancelarVendaValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
