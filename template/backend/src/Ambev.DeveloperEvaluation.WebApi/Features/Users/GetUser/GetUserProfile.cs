using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;
using Microsoft.OpenApi.Extensions;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetUserProfile()
    {
        CreateMap<GetUserRequest, GetUserCommand>();

        CreateMap<Guid, Application.Users.GetUser.GetUserCommand>()
            .ConstructUsing(id => new Application.Users.GetUser.GetUserCommand(id));

        CreateMap<User, GetUserResult>()
           .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.GetDisplayName()))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetDisplayName()));

        CreateMap<GetUserResult, GetUserResponse>()
          .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        ////.ForMember(dest => dest.Name.FirstName, opt => opt.MapFrom(src => src.FirstName))
        ////.ForMember(dest => dest.Name.LastName, opt => opt.MapFrom(src => src.LastName));

    }
}
