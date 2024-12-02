using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{

    public class VendaRepository : IVendaRepository
    {
        private readonly DefaultContext _contexto;

        public VendaRepository(DefaultContext contexto)
        {
            _contexto = contexto;
        }

        // Criar uma nova venda
        public async Task<Venda> CriarVendaAsync(Venda venda)
        {
            await _contexto.Vendas.AddAsync(venda);
            await _contexto.SaveChangesAsync();
            return venda;
        }

        // Obter detalhes de uma venda
        public async Task<Venda> ObterVendaAsync(Guid vendaId)
        {
            return await _contexto.Vendas
                                 .Include(v => v.VendaProdutos)
                                 .ThenInclude(iv => iv.Produto)
                                 .FirstOrDefaultAsync(v => v.Id == vendaId);
        }

        // Atualizar uma venda
        public async Task<Venda> AtualizarVendaAsync(Guid vendaId, Venda venda)
        {
            var vendaExistente = await _contexto.Vendas.Include(v => v.VendaProdutos)
                                                       .FirstOrDefaultAsync(v => v.Id == vendaId);

            if (vendaExistente == null) throw new KeyNotFoundException($"Not possible refresh sale. Because not foun sale for {vendaId.ToString()}");

            vendaExistente.ClienteId = venda.ClienteId;
            //vendaExistente.FilialId = venda.FilialId;
            vendaExistente.VendaProdutos = venda.VendaProdutos;

            vendaExistente.ValorTotal = venda.ValorTotal;

            _contexto.Vendas.Update(vendaExistente);
            await _contexto.SaveChangesAsync();

            return vendaExistente;
        }

        // Cancelar uma venda
        public async Task<bool> CancelarVendaAsync(Guid vendaId)
        {
            var venda = await _contexto.Vendas.Include(v => v.VendaProdutos)
                                               .FirstOrDefaultAsync(v => v.Id == vendaId);

            if (venda == null) throw new KeyNotFoundException("Not possible remove sale. Because not found sale");

            venda.Cancelado = true;
            _contexto.Vendas.Update(venda);
            await _contexto.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancelarItemAsync(Guid vendaId, Guid itemId)
        {
            var itemVenda = await _contexto.VendaProdutos
                                            .FirstOrDefaultAsync(iv => iv.VendaId == vendaId && iv.ProdutoId == itemId);

            if (itemVenda == null) throw new KeyNotFoundException("Item não encontrado");

            itemVenda.Desconto = 0;
            itemVenda.ValorTotal = 0;  // Zera o valor total do item

            _contexto.VendaProdutos.Update(itemVenda);
            await _contexto.SaveChangesAsync();

            return true;
        }
    }
}
