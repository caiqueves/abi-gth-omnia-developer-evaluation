using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class GetUserHandler : IRequestHandler<GetUserCommand, GetUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IRedisService _redisService;

    /// <summary>
    /// Initializes a new instance of GetUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetUserCommand</param>
    public GetUserHandler(
        IUserRepository userRepository,
        IMapper mapper, 
        IRedisService redisService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _redisService = redisService;
    }

    /// <summary>
    /// Handles the GetUserCommand request
    /// </summary>
    /// <param name="request">The GetUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    public async Task<GetUserResult> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetUserValidator();
        var user = new User();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var userJson = _redisService.GetCache($"user:{request.Id}");

        //if (userJson != null)
        //{
        //    // Se o usuário existe no Redis, deserializa e retorna o objeto
        //    user = JsonConvert.DeserializeObject<User>(userJson);
        //}
        //else
        //{
            user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {request.Id} not found");

            //_redisService.SetCache($"user:{user!.Id}", JsonConvert.SerializeObject(user));
        //}

        return _mapper.Map<GetUserResult>(user);
    }
}
