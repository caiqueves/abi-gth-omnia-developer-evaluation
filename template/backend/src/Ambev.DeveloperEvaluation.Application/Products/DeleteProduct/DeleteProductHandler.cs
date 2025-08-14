using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Handler for processing DeleteUserCommand requests
/// </summary>
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IRedisService _redisService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRatingRepository _ratingRepository;
    private readonly IMapper _mapper;


    /// <summary>
    /// Initializes a new instance of DeleteUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="validator">The validator for DeleteUserCommand</param>
    public DeleteProductHandler(
        IProductRepository productRepository, IRedisService redisService, IUnitOfWork unitOfWork, IRatingRepository ratingRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _redisService = redisService;
        _unitOfWork = unitOfWork;
        _ratingRepository = ratingRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the DeleteUserCommand request
    /// </summary>
    /// <param name="request">The DeleteUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        if(product is null)
            throw new ApplicationException($"Product for Id {request.Id} not found");

        var success = await _productRepository.DeleteAsync(request.Id, cancellationToken);
        await _ratingRepository.DeleteAsync(product!.RatingId, cancellationToken);

        if (!success)
            throw new KeyNotFoundException($"Product with ID {request.Id} not found");

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //_redisService.RemoveCache("product:" + request.Id.ToString());

        return _mapper.Map<DeleteProductResult>(product);

    }
}
