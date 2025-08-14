
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleRequest, UpdateSaleComand>()
            .ConstructUsing(req => new UpdateSaleComand(
                req.Id,
                req.SaleNumber,
                req.CustomerId,
                req.BranchId,
                req.SaleDate,
                req.IsCancelled,
                req.SaleItems
            ));

            CreateMap<UpdateSaleRequest, UpdateSaleComand>();
            CreateMap<UpdateSaleResult, UpdateSaleResponse>();
        }
    }
}
