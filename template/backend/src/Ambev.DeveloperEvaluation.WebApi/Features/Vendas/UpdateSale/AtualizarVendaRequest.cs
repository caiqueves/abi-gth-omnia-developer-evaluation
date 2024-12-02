using Ambev.DeveloperEvaluation.Domain.Dto;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.AtualizarVenda
{
    public class AtualizarVendaRequest
    {
        public Guid ClienteId { get; set; }  // ID do cliente
        //public Guid FilialId { get; set; }   // ID da filial
        public DateTime DataVenda { get; set; } // Data da venda

        public List<SaleItemDto>? ItensVenda { get; set; }  // Lista de itens da venda

        
    }
}
