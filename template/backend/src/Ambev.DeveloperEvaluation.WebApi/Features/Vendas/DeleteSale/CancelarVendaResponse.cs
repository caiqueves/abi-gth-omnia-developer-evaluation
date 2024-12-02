using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.DeleteSale
{
    public record CancelarVendaResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public List<SaleItemDto>? Product { get; set; }

        public string Mensagem { get; set; } = string.Empty;
    }
}
