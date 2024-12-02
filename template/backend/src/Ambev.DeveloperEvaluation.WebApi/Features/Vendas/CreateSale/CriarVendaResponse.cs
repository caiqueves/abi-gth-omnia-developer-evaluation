using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CriarVenda
{
    public record CriarVendaResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public List<SaleItemDto>? Product { get; set; }
    }
}
