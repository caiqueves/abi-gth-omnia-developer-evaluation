using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;


public class GetSaleProfile : Profile
{
 
    public GetSaleProfile()
    {
        CreateMap<GetSaleComand, Sale>();
        //CreateMap<GetSaleDto, GetSaleResult>()
        //   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
        //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        //.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));

    }
}
