using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class AtualizarVendaProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public AtualizarVendaProfile()
    {
        CreateMap<AtualizarVendaComand, Venda>();
        CreateMap<SaleModifiedEvent, AtualizarVendaResult>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));




    }
}
