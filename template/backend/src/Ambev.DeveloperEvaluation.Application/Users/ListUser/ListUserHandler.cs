using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Common.Security;


namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class ListUserHandler : IRequestHandler<ListUserCommand, PaginatedList<User>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Initializes a new instance of GetUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetUserCommand</param>
    public ListUserHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetUserCommand request
    /// </summary>
    /// <param name="request">The GetUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    public async Task<PaginatedList<User>> Handle(ListUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var users = await _userRepository.GetAllAsync(cancellationToken);

        IQueryable<User> query = request.Order == OrderDirection.Desc
            ? users.OrderByDescending(c => c.FirstName)
            : users.OrderBy(c => c.FirstName);

        return PaginatedList<User>.CreateAsync(query, request.Page, request.Size).Result; ;
    }
}
