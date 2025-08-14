using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class UpdateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<GetSaleComand, Sale>();
        //CreateMap<SaleModifiedEvent, UpdateSaleResult>()
        //   .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
        //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        //.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));

        CreateMap<Sale, UpdateSaleResult>();


    }
}
