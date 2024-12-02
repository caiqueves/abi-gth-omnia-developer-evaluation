using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;


public class DeleteProductProfile : Profile
{
    public DeleteProductProfile()
    {
        CreateMap<Guid, Application.Products.DeleteProduct.DeleteProductCommand>()
            .ConstructUsing(id => new Application.Products.DeleteProduct.DeleteProductCommand(id));

        CreateMap<DeleteProductRequest, DeleteProductCommand>();
        CreateMap<DeleteProductResult, DeleteProductResponse>();
    }
}
