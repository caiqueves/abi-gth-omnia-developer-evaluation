using Ambev.DeveloperEvaluation.Application.Users.ListUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUser;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class ListUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public ListUserProfile()
    {
        CreateMap<ListUserRequest, ListUserCommand>();
    }
}
