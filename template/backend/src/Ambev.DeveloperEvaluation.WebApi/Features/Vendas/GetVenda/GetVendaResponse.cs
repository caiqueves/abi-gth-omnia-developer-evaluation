using Ambev.DeveloperEvaluation.Domain.Dto;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda
{
    public record GetVendaResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public List<SaleItemDto>? Product { get; set; }
    }
}
