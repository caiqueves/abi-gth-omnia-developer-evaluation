using Ambev.DeveloperEvaluation.Application.Vendas.ObterVenda;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;

public class GetVendaProfile : Profile
{
    public GetVendaProfile()
    {
        CreateMap<GetVendaRequest, ObterVendaCommand>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<ObterVendaResult, GetVendaResponse>();
    }
}
