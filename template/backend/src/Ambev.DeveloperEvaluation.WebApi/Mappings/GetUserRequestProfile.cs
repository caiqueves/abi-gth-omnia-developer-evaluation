﻿using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class GetUserRequestProfile : Profile
{
    public GetUserRequestProfile()
    {
        CreateMap<GetUserRequest, GetUserCommand>();

        //CreateMap<GetUserResult, GetUserResponse>()
        //    .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}