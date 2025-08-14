
using Ambev.DeveloperEvaluation.Application.Products.ListCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListCategory;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class ListCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public ListCategoryProfile()
    {
        CreateMap<ListCategoryRequest, ListCategoryCommand>();
    }
}
