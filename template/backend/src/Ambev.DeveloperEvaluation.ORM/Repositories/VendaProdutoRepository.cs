using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class VendaProdutoRepository : IVendaProdutoRepository
    {
        private readonly DefaultContext _context;

        public VendaProdutoRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<VendaProduto> GetByIdAsync(Guid vendaId, Guid produtoId)
        {
            return await _context.VendaProdutos
                .Include(vp => vp.Venda) 
                .Include(vp => vp.Produto) 
                .FirstOrDefaultAsync(vp => vp.VendaId == vendaId && vp.ProdutoId == produtoId);
        }


        public async Task<IEnumerable<VendaProduto>> GetByVendaIdAsync(Guid vendaId)
        {
            return await _context.VendaProdutos
                .Where(vp => vp.VendaId == vendaId)
                .Include(vp => vp.Produto) 
                .ToListAsync();
        }

        public async Task AddAsync(VendaProduto vendaProduto)
        {
            await _context.VendaProdutos.AddAsync(vendaProduto);
            await SaveAsync(); 
        }

        
        public async Task UpdateAsync(VendaProduto vendaProduto)
        {
            _context.VendaProdutos.Update(vendaProduto);
            await SaveAsync(); 
        }


        public async Task DeleteAsync(Guid vendaId, Guid produtoId)
        {
            var vendaProduto = await GetByIdAsync(vendaId, produtoId);
            if (vendaProduto != null)
            {
                _context.VendaProdutos.Remove(vendaProduto);
                await SaveAsync(); 
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
