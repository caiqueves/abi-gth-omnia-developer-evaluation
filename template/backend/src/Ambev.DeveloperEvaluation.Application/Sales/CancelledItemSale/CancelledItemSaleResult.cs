
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;

public class CancelledItemSaleResult
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItem>? Product { get; set; }
}
