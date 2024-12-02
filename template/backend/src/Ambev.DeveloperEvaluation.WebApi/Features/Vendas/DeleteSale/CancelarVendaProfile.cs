using Ambev.DeveloperEvaluation.Application.Vendas.CancelarVenda;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.DeleteSale
{
    public class CancelarVendaProfile : Profile
    {
        public CancelarVendaProfile()
        {
            CreateMap<Guid, Application.Vendas.CancelarVenda.CancelarVendaCommand>()
            .ConstructUsing(id => new Application.Vendas.CancelarVenda.CancelarVendaCommand(id));

            CreateMap<CancelarVendaRequest, CancelarVendaCommand>();


            CreateMap<CancelarVendaResult, CancelarVendaResponse>();
        }
    }
}
