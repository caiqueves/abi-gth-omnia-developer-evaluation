using Ambev.DeveloperEvaluation.Domain.Dto;


namespace Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;

public class CriarVendaResult
{
    public Guid Id { get; set; } 
    public Guid UserId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItemDto>? Product { get; set; }

}
