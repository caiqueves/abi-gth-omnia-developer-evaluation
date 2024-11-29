using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

/// <summary>
/// Handler for processing DeleteUserCommand requests
/// </summary>
public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IRedisService _redisService;
    private readonly IAdressRepository _adressRepository;
    private readonly IGeolocationRepository _geolocationRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of DeleteUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="validator">The validator for DeleteUserCommand</param>
    public DeleteUserHandler(
        IUserRepository userRepository, IRedisService redisService, IAdressRepository adressRepository, IGeolocationRepository geolocationRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _redisService = redisService;
        _adressRepository = adressRepository;
        _geolocationRepository = geolocationRepository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Handles the DeleteUserCommand request
    /// </summary>
    /// <param name="request">The DeleteUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        await _geolocationRepository.DeleteAsync(user!.Address.GeolocationId, cancellationToken);

        await _adressRepository.DeleteAsync(user!.AddressId, cancellationToken);

        await _adressRepository.DeleteAsync(user!.AddressId, cancellationToken);

        var success = await _userRepository.DeleteAsync(request.Id, cancellationToken);
        
        if (!success)
            throw new KeyNotFoundException($"User with ID {request.Id} not found");

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _redisService.RemoveCache(request.Id.ToString());

        return new DeleteUserResponse { Success = true };
    }
}
