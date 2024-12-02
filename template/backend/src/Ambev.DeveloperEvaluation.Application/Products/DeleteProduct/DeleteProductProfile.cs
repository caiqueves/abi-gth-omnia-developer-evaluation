using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;


public class DeleteProductProfile : Profile
{

    public DeleteProductProfile()
    {
        CreateMap<DeleteProductCommand, Product>();
        CreateMap<Product, DeleteProductResult>();

    }
}
