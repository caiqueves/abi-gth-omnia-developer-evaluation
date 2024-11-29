using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Handler for processing DeleteUserCommand requests
/// </summary>
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IRedisService _redisService;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of DeleteUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="validator">The validator for DeleteUserCommand</param>
    public DeleteProductHandler(
        IProductRepository productRepository, IRedisService redisService, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _redisService = redisService;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Handles the DeleteUserCommand request
    /// </summary>
    /// <param name="request">The DeleteUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var success = await _productRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            await transaction.CommitAsync(cancellationToken);

            _redisService.RemoveCache(request.Id.ToString());

            return new DeleteProductResponse { Success = true };
        }
        catch (Exception)
        {
            // Rollback da transação
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
        
    }
}
