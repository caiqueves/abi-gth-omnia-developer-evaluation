using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;


namespace Ambev.DeveloperEvaluation.Application.Vendas.CancelarVenda;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CancelarVendaProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CancelarVendaProfile()
    {
        CreateMap<CancelarVendaCommand, Venda>();
        CreateMap<SaleCancelledEvent, CancelarVendaResult>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));




    }
}
