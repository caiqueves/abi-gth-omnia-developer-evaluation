using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using System.Drawing;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsCategory;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class ListProductCategoryHandler : IRequestHandler<ListProductCategoryCommand, PaginatedList<Product>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductCategoryHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<PaginatedList<Product>> Handle(ListProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListProductCategoryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var query = _productRepository.GetAllAsync(cancellationToken).Where(c=> c.Category == request.Category)
        .OrderBy(request.Order);

        return PaginatedList<Product>.CreateAsync(query, request.Page, request.Size).Result;
    }
}
