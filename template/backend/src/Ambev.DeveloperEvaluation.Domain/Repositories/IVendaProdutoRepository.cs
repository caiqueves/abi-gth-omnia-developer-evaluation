using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IVendaProdutoRepository
    {
        Task<VendaProduto> GetByIdAsync(Guid vendaId, Guid produtoId);
        Task<IEnumerable<VendaProduto>> GetByVendaIdAsync(Guid vendaId);
        Task AddAsync(VendaProduto vendaProduto);
        Task UpdateAsync(VendaProduto vendaProduto);
        Task DeleteAsync(Guid vendaId, Guid produtoId);
        Task SaveAsync();
    }

}
