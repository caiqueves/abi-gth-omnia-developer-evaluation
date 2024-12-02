
using Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.AtualizarVenda
{
    public class AtualizarVendaProfile : Profile
    {
        public AtualizarVendaProfile()
        {
            CreateMap<Guid, Application.Vendas.AtualizarVenda.AtualizarVendaComand>()
           .ConstructUsing(id => new Application.Vendas.AtualizarVenda.AtualizarVendaComand(id));

            CreateMap<AtualizarVendaRequest, AtualizarVendaComand>();
            CreateMap<AtualizarVendaResult, AtualizarVendaResponse>();
        }
    }
}
