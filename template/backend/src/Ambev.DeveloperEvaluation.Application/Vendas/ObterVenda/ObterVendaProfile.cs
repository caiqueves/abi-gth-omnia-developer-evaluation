using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Vendas.ObterVenda;


public class ObterVendaProfile : Profile
{
 
    public ObterVendaProfile()
    {
        CreateMap<ObterVendaCommand, Venda>();
        CreateMap<GetSaleDto, ObterVendaResult>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));

    }
}
