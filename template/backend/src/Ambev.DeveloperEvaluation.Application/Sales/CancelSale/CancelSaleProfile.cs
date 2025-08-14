using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;


namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CancelSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CancelSaleProfile()
    {
        CreateMap<CancelSaleCommand, Sale>();
        CreateMap<SaleCancelledEvent, CancelSaleResult>()
           .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));




    }
}
