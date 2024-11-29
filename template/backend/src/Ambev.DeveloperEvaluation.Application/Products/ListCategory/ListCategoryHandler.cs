using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using System.Drawing;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategory;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class ListCategoryHandler : IRequestHandler<ListCategoryCommand, List<string>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListCategoryHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<List<string>> Handle(ListCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListCategoryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var query = _productRepository.GetAllByCategoryAsync(cancellationToken);

        return query;
    }
}
