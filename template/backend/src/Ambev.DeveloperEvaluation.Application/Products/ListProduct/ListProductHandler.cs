using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common;
using Microsoft.EntityFrameworkCore;

using Ambev.DeveloperEvaluation.Application.Event;
using Newtonsoft.Json;
using Ambev.DeveloperEvaluation.Application.Users.ListUser;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class ListProductHandler : IRequestHandler<ListProductCommand, PaginatedList<Product>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<PaginatedList<Product>> Handle(ListProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var query = _productRepository.GetAllAsync(cancellationToken);

        query = request.Order == OrderDirection.Desc
            ? query.OrderByDescending(c => c.Description)
            : query.OrderBy(c => c.Description);

        return PaginatedList<Product>.CreateAsync(query, request.Page, request.Size).Result;
    }
}
