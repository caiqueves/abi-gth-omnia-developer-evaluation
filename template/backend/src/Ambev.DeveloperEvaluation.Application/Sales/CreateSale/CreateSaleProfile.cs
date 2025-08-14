using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleComand, Sale>();
        CreateMap<SaleCreatedEvent, CreateSaleResult>()
           .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));




    }
}
