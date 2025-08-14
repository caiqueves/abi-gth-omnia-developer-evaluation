using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<GetSaleRequest, GetSaleComand>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
