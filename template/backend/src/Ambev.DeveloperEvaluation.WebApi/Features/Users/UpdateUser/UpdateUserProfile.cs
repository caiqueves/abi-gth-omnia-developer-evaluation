using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class UpdateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public UpdateUserProfile()
    {
        CreateMap<UpdateUserRequest, UpdateUserCommand>();
        CreateMap<UpdateUserCommand, User>();
    }
}
