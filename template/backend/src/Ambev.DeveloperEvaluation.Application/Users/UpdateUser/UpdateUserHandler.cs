using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Services;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAdressRepository _adressRepository;
    private readonly IGeolocationRepository _geolocationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRedisService _redisService;

    /// <summary>
    /// Initializes a new instance of CreateUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateUserCommand</param>
    public UpdateUserHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, IAdressRepository adressRepository, IGeolocationRepository geolocationRepository,
        IUnitOfWork unitOfWork, IRedisService redisService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _adressRepository = adressRepository;
        _geolocationRepository = geolocationRepository;
        _unitOfWork = unitOfWork;
        _redisService = redisService;
    }

    /// <summary>
    /// Handles the CreateUserCommand request
    /// </summary>
    /// <param name="command">The CreateUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingUser = await _userRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (existingUser != null)
            throw new ApplicationException($"User with email {command.Email} already exists");

            // Criação da Geolocalização
            var geolocation = new Geolocation
            {
                Lat = Convert.ToDecimal(command.Latitude),
                Long = Convert.ToDecimal(command.Longitude)
            };

            await _geolocationRepository.UpdateAsync(geolocation);

            // Criação do Endereço
            var address = new Address
            {
                City = command.City,
                Street = command.Street,
                Number = command.Number,
                Zipcode = command.ZipCode,
                GeolocationId = geolocation.Id
            };

            await _adressRepository.UpdateAsync(address);

            var user = _mapper.Map<User>(command);

            switch ((int)user.Status)
            {
                case 0:
                    user.Deactivate(); break;
                case 1:
                    user.Activate(); break;
                case 2:
                    user.Suspend(); break;
            }
            user.Password = _passwordHasher.HashPassword(command.Password);

            var createdUser = await _userRepository.UpdateAsync(user, cancellationToken);

            // Salvar todas as alterações no banco de dados
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _redisService.SetCache($"user:{user.Id}", JsonConvert.SerializeObject(createdUser));

            var result = _mapper.Map<UpdateUserResult>(createdUser);
            return result;
    }
}
