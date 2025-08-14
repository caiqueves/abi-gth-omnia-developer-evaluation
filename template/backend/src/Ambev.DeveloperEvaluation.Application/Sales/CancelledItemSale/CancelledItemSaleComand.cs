using Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CancelledItemSale;

public class CancelledItemSaleComand : IRequest<CancelledItemSaleResult>
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
}
