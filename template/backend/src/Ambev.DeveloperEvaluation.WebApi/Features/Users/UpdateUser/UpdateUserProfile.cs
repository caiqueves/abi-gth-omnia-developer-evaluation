using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;
using Microsoft.OpenApi.Extensions;


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
        //CreateMap<UpdateUserCommand, User>();
        CreateMap<User, UpdateUserResult>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.GetDisplayName()))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetDisplayName()));

        CreateMap<UpdateUserResult, UpdateUserResponse>()
         .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
