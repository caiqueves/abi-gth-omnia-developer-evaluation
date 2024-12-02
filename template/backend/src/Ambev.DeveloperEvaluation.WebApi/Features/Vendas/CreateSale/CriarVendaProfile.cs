using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CriarVenda
{
    public class CriarVendaProfile : Profile
    {
        public CriarVendaProfile()
        {
            CreateMap<CriarVendaRequest, CriarVendaCommand>();


            CreateMap<CriarVendaResult, CriarVendaResponse>();
        }
    }
}
