using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;


public class DeleteProductProfile : Profile
{

    public DeleteProductProfile()
    {
        CreateMap<DeleteUserCommand, Product>();
        CreateMap<Product, DeleteUserResult>();

    }
}
