

using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IVendaRepository
    {
        Task<Venda> CriarVendaAsync(Venda venda);

        Task<Venda> ObterVendaAsync(Guid vendaId);

        Task<Venda> AtualizarVendaAsync(Guid vendaId, Venda venda);

        Task<bool> CancelarVendaAsync(Guid vendaId);

        Task<bool> CancelarItemAsync(Guid vendaId, Guid itemId);


    }
}
