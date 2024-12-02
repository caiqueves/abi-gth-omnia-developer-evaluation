using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CriarVendaProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CriarVendaProfile()
    {
        CreateMap<CriarVendaCommand, Venda>();
        CreateMap<SaleCreatedEvent, CriarVendaResult>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));




    }
}
