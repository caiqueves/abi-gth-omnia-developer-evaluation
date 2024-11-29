using Ambev.DeveloperEvaluation.Application.Products.ListProducts;
using Ambev.DeveloperEvaluation.Application.Products.ListProductsCategory;
using Ambev.DeveloperEvaluation.Application.Users.ListUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductCategory;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class ListProductCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public ListProductCategoryProfile()
    {
        CreateMap<ListProductCategoryRequest, ListProductCategoryCommand>();
    }
}
