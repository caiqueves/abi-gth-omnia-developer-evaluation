using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.OpenApi.Extensions;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();

        CreateMap<User, CreateUserResult>()
         .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.GetDisplayName()))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetDisplayName()));

        CreateMap<CreateUserResult, CreateUserResponse>()
             .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
         //// .ForMember(dest => dest.Name!.FirstName, opt => opt.MapFrom(src => src.FirstName))
        ////.ForMember(dest => dest.Name!.LastName, opt => opt.MapFrom(src => src.LastName));

    }
}
