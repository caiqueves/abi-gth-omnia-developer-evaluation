using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Application.Event;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System;
using Newtonsoft.Json;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAdressRepository _adressRepository;
    private readonly IGeolocationRepository _geolocationRepository;
    private readonly IUnitOfWork _unitOfWork;
    //private readonly IRedisService _redisService;
    //private readonly EventService _eventService;

    /// <summary>
    /// Initializes a new instance of CreateUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateUserCommand</param>
    public CreateUserHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, IAdressRepository adressRepository, 
        IGeolocationRepository geolocationRepository,IUnitOfWork unitOfWork /*, EventService eventService, IRedisService redisService*/)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _adressRepository = adressRepository;
        _geolocationRepository = geolocationRepository;
        _unitOfWork = unitOfWork;
        /*_eventService = eventService*/;
        //_redisService = redisService;
    }

    /// <summary>
    /// Handles the CreateUserCommand request
    /// </summary>
    /// <param name="command">The CreateUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingUser = await _userRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (existingUser != null)
            throw new InvalidOperationException($"User with email {command.Email} already exists");

            // Criação da Geolocalização
            var geolocation = new Geolocation
            {
                Id = Guid.NewGuid(),
                Lat = Convert.ToDecimal(command.Latitude),
                Long = Convert.ToDecimal(command.Longitude)
            };

            await _geolocationRepository.CreateAsync(geolocation);

            // Criação do Endereço
            var address = new Address
            {
                Id = Guid.NewGuid(),
                City = command.City,
                Street = command.Street,
                Number = command.Number,
                Zipcode = command.ZipCode,
                GeolocationId = geolocation.Id
            };

            await _adressRepository.CreateAsync(address);

            var user = _mapper.Map<User>(command);

            user.Password = _passwordHasher.HashPassword(command.Password);
            user.AddressId = address.Id;
            var createdUser = await _userRepository.CreateAsync(user, cancellationToken);

            // Salvar todas as alterações no banco de dados
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //_redisService.SetCache($"user:{user.Id}", JsonConvert.SerializeObject(command));

            var users = await _userRepository.GetByIdAsync(user.Id);
            var result = _mapper.Map<CreateUserResult>(users);

            return result;
        
        
    }
}
