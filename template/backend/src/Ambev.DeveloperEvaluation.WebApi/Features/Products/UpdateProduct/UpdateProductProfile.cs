using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;


public class UpdateProductProfile : Profile
{

    public UpdateProductProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
        CreateMap<UpdateProductCommand, Product>();
    }
}
